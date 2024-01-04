import { useState, useEffect } from 'react';
import axios from "axios";
import { ITableLine } from '../types/ITableLine';
import { IRegionTableLines } from '../types/IRegionTableLines';

export default function useRegionTableLines() : IRegionTableLines {
    const API_KEY_PREFECTURE : string = 'api/TableLine/prefecture';
    const API_KEY_CITY : string = 'api/TableLine/city';
    const [prefectureTableLines, setPrefectureTableLines] = useState<ITableLine[]>([]);
    const [cityTableLines, setCityTableLines] = useState<ITableLine[]>([]);
    
    useEffect(() =>{
        axios
            .get(API_KEY_PREFECTURE, {
            })
            .then((results) => {
                setPrefectureTableLines(results.data);
            })
            .catch((error) => { });
        axios
            .get(API_KEY_CITY, {
            })
            .then((results) => {
                setCityTableLines(results.data);
            })
            .catch((error) => { });    
    },[]);

    const regionTable : IRegionTableLines = {
        pref : prefectureTableLines,
        city : cityTableLines,
    }
    return regionTable;
}