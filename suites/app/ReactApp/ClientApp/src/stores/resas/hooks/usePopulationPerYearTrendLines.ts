import { useState, useEffect } from 'react';
import axios from "axios";
import { ITrendLine } from "../types/ITrendLine";
import { IRegionValue } from '../types/IRegionValue';
import { IRegionTrendLines } from '../types/IRegionTrendLines';

export default function usePopulationPerYearTrendLines(region: IRegionValue) : IRegionTrendLines[] {
    const API_KEY : string = 'api/TrendLine/population_per_years';
    const prefectureCode = region.prefCode;
    const cityCode = region.cityCode;
    console.log(API_KEY + ' ' + prefectureCode + ' ' + cityCode);
    const [populationPerYears, setPopulationPerYears] = useState<IRegionTrendLines[]>([]);
    
    useEffect(() =>{
        let endpoint : string;
        if(cityCode === 0 && prefectureCode === 0){
            endpoint = '';
        }
        else if(cityCode === 0){
            endpoint = API_KEY + '/' + String(prefectureCode);
        }
        else{
            endpoint = API_KEY + '/' + String(prefectureCode) + '/' + String(cityCode);
        }
        
        if(endpoint !== ''){
            axios
            .get(endpoint)
            .then((results) => {
                const regionTrendLines : IRegionTrendLines[] = [];
                for(let data of results.data){
                    const regionTrendLine : IRegionTrendLines = {
                        region : {
                            cityCode : data.region.cityCode,
                            cityName : data.region.cityName,
                            prefCode : data.region.prefCode,
                            prefName : data.region.prefName,
                        },
                        trendLines : data.data,
                    }
                    regionTrendLines.push(regionTrendLine);
                }
                setPopulationPerYears(regionTrendLines);
            })
            .catch((error) => { });
        }
            
    },[region]);

    return populationPerYears;
}

const getTrendLines = async (endpoint : string) => { return await axios.get(endpoint); };

const getResult = async (endpoint : string) => {
    const result = await getTrendLines(endpoint);
    const trendLines : ITrendLine[] = [];
    for (let data of result.data) {
        const line : ITrendLine = {
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