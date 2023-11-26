import { useState, } from 'react';
import axios from "axios";
import { TrendLine } from "../models/TrendLine";

const API_KEY : string = 'api/TrendLine/population_per_years';

export default function usePopulationPerYears(prefectureCode: string, cityCode: string) {
    console.log(prefectureCode + ' ' + cityCode);
    const [trendLines, setTrendLines] = useState<TrendLine[]>();
    let endpoint : string;

    if(cityCode === ''){
        endpoint = API_KEY + '/' + prefectureCode;
    }
    else{
        endpoint = API_KEY + '/' + prefectureCode + '/' + cityCode;
    }
 
    axios
        .get(endpoint, { })
        .then((results) => {
            setTrendLines(results.data);
        })
        .catch((error) => { });
    
    return trendLines;
}