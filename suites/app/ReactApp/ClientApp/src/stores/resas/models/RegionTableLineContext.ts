import React from 'react'
import { IRegionTableLines } from '../types/tables/IRegionTableLines'

export class RegionTableLineContext {
    
    private static current :RegionTableLineContext

    public static get instance() :RegionTableLineContext{
        if (!this.current)
            this.current = new RegionTableLineContext();
        return this.current;
    }

    private constructor(){
    }

    private context = React.createContext<IRegionTableLines | null>(null)

    getContext() :React.Context<IRegionTableLines | null> {
        return this.context;
    }

    useContext() :IRegionTableLines | null{
        return React.useContext(this.context);
    }
}