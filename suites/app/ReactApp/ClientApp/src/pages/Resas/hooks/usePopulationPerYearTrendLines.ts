import { useState, useEffect } from 'react';
import axios from "axios";
import { TrendLine } from "../models/TrendLine";
import { PopulationPerYear } from '../models/PopulationPerYear';
import { RegionValue } from '../models/RegionValue';
import { RegionTrendLines } from '../models/RegionTrendLines';

export default function usePopulationPerYearTrendLines(region: RegionValue) : RegionTrendLines[] {
    const API_KEY : string = 'api/TrendLine/population_per_years';
    const prefectureCode = String(region.pref);
    const cityCode = String(region.city);
    console.log(API_KEY + ' ' + prefectureCode + ' ' + cityCode);
    const [populationPerYears, setPopulationPerYears] = useState<RegionTrendLines[]>([]);
    
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
                const regionTrendLines : RegionTrendLines[] = [];
                for(let data of results.data){
                    const regionTrendLine : RegionTrendLines = {
                        region : {
                            city : data.city,
                            pref : data.pref,
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