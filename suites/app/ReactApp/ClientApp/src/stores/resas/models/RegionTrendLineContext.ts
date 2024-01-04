import React , { useContext } from 'react'
import { IRegionTrendLines } from '../types/trends/IRegionTrendLines'

export class RegionTrendLineContext {
    
    private context = React.createContext<IRegionTrendLines[] | null>(null)

    getContext() :React.Context<IRegionTrendLines[] | null> {
        return this.context;
    }

    useContext() :IRegionTrendLines[] | null{
        return React.useContext(this.context);
    }
}