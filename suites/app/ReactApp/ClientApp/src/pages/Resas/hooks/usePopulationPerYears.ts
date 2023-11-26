import { useState, } from 'react';
import axios from "axios";
import { TrendLine } from "../models/TrendLine";

export default function usePopulationPerYears(prefectureCode: string, cityCode: string) {
    console.log(prefectureCode + ' ' + cityCode);
    const [trendLines, setTrendLines] = useState<TrendLine[]>();
    axios
        .get('api/TrendLine/population_per_years' + '/' + prefectureCode + '/' + cityCode, { })
        .then((results) => {
            setTrendLines(results.data);
        })
        .catch((error) => { });
    return trendLines;
}