import { useState, useEffect } from 'react';
import axios from "axios";
import { TrendLine } from "../features/models/TrendLine";
import { PopulationPerYear } from '../features/models/PopulationPerYear';
import { RegionValue } from '../features/models/RegionValue';
import { RegionTrendLines } from '../features/models/RegionTrendLines';

export default function usePopulationPerYearTrendLines(region: RegionValue) : RegionTrendLines[] {
    const API_KEY : string = 'api/TrendLine/population_per_years';
    const prefectureCode = region.prefCode;
    const cityCode = region.cityCode;
    console.log(API_KEY + ' ' + prefectureCode + ' ' + cityCode);
    const [populationPerYears, setPopulationPerYears] = useState<RegionTrendLines[]>([]);
    
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
                const regionTrendLines : RegionTrendLines[] = [];
                for(let data of results.data){
                    const regionTrendLine : RegionTrendLines = {
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