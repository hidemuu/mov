import React , { useContext } from 'react'
import { IRegionTrendLines } from '../types/trends/IRegionTrendLines'

export class RegionTrendLineContext {
    
    private static current :RegionTrendLineContext

    public static getInstance() :RegionTrendLineContext{
        if (!this.current)
            this.current = new RegionTrendLineContext(RegionTrendLineContext.getInstance);
        return this.current;
    }

    private context = React.createContext<IRegionTrendLines[] | null>(null)

    constructor(caller:Function){
        if (caller == RegionTrendLineContext.getInstance)
            console.log("インスタンスを作成。一度しか呼ばれない。");
        else if (RegionTrendLineContext.current)
            throw new Error("既にインスタンスが存在するためエラー。");
        else
            throw new Error("コンストラクタの引数が不正な為エラー。");
    }

    getContext() :React.Context<IRegionTrendLines[] | null> {
        return this.context;
    }

    useContext() :IRegionTrendLines[] | null{
        return React.useContext(this.context);
    }
}