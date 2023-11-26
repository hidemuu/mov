import { useState, useEffect } from 'react';
import axios from "axios";
import { TrendLine } from "../models/TrendLine";
import { PopulationPerYear } from '../models/PopulationPerYear';
import { RegionValue } from '../models/RegionValue';

export default function usePopulationPerYearTrendLines(region: RegionValue) : TrendLine[] {
    const API_KEY : string = 'api/TrendLine/population_per_years';
    const prefectureCode = region.pref;
    const cityCode = region.city;
    console.log(API_KEY + ' ' + prefectureCode + ' ' + cityCode);
    const [populationPerYears, setPopulationPerYears] = useState<TrendLine[]>([]);
    
    useEffect(() =>{
        let endpoint : string;
        if(cityCode === ''){
            endpoint = API_KEY + '/' + prefectureCode;
        }
        else if(cityCode === '' && prefectureCode === ''){
            endpoint = '';
        }
        else{
            endpoint = API_KEY + '/' + prefectureCode + '/' + cityCode;
        }
        
        if(endpoint !== ''){
            axios
            .get(endpoint)
            .then((results) => {
                setPopulationPerYears(results.data);
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