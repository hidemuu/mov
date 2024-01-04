import React, { useState, useEffect } from 'react'
import axios from "axios";
import { IRegionTableLines } from '../types/tables/IRegionTableLines'
import { ITableLine } from '../types/tables/ITableLine';

const API_KEY_PREFECTURE :string = 'api/TableLine/prefecture';
const API_KEY_CITY :string = 'api/TableLine/city';

const [prefectureTableLines, setPrefectureTableLines] = useState<ITableLine[]>([]);
const [cityTableLines, setCityTableLines] = useState<ITableLine[]>([]);

export class RegionTableLineContext {
    
    private static current :RegionTableLineContext

    public static get instance() :RegionTableLineContext{
        if (!this.current)
            this.current = new RegionTableLineContext();
        return this.current;
    }

    private constructor(){
        this.update();
    }

    private context :React.Context<IRegionTableLines | null> = React.createContext<IRegionTableLines | null>(null)

    public getContext() :React.Context<IRegionTableLines | null> {
        return this.context;
    }

    public getValue() :IRegionTableLines | null{
        return React.useContext(this.context);
    }

    private update(){

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

        const response : IRegionTableLines = {
            pref : prefectureTableLines,
            city : cityTableLines,
        }

        this.context.Provider.bind(response)
    }
}