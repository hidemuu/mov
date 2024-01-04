import React from 'react'
import { IRegionTableLines } from '../types/tables/IRegionTableLines'

export class RegionTableLineContext {
    
    private context = React.createContext<IRegionTableLines | null>(null)

    getContext() :React.Context<IRegionTableLines | null> {
        return this.context;
    }

    useContext() :IRegionTableLines | null{
        return React.useContext(this.context);
    }
}