import { useState, useEffect } from 'react';
import axios from "axios";
import { RegionValue } from '../models/RegionValue';
import { TableLine } from '../models/TableLine';
import { RegionTableLines } from '../models/RegionTableLines';

export default function useRegionTableLines() : RegionTableLines {
    const API_KEY_PREFECTURE : string = 'api/TableLine/prefecture';
    const API_KEY_CITY : string = 'api/TableLine/city';
    const [prefectureTableLines, setPrefectureTableLines] = useState<TableLine[]>([]);
    const [cityTableLines, setCityTableLines] = useState<TableLine[]>([]);
    
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

    const regionTable : RegionTableLines = {
        pref : prefectureTableLines,
        city : cityTableLines,
    }
    return regionTable;
}