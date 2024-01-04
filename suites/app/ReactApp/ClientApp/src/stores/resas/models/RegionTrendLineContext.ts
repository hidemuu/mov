import React , { useContext } from 'react'
import { IRegionTrendLines } from '../types/trends/IRegionTrendLines'

export class RegionTrendLineContext {
    
    private static instance :RegionTrendLineContext

    public static getInstance() :RegionTrendLineContext{
        if (!this.instance)
            this.instance = new RegionTrendLineContext(RegionTrendLineContext.getInstance);
        return this.instance;
    }

    private context = React.createContext<IRegionTrendLines[] | null>(null)

    constructor(caller:Function){
        if (caller == RegionTrendLineContext.getInstance)
            console.log("インスタンスを作成。一度しか呼ばれない。");
        else if (RegionTrendLineContext.instance)
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