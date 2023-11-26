import axios from "axios";
import { TrendLine } from "../models/TrendLine";

const API_KEY : string = 'api/TrendLine/population_per_years';

export default function usePopulationPerYears(prefectureCode: string, cityCode: string) {
    console.log(prefectureCode + ' ' + cityCode);
    let endpoint : string;

    if(cityCode === ''){
        endpoint = API_KEY + '/' + prefectureCode;
    }
    else{
        endpoint = API_KEY + '/' + prefectureCode + '/' + cityCode;
    }
 
    const result = getResult(endpoint);
    return result;
}

const getTrendLines = async (endpoint : string) => { return await axios.get(endpoint); };

const getResult = async (endpoint : string) => {
    const result = await getTrendLines(endpoint);
    const trendLines : TrendLine[] = [];
    for (let data of result.data) {
        const line : TrendLine = {
            id : data.id,
            category : data.category,
            label: data.label,
            number: data.number,
            value: data.value,
        }
        trendLines.push(line);
    }
    return trendLines;
}