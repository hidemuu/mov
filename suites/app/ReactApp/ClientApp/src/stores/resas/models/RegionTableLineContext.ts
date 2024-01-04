import React from 'react'
import { IRegionTableLines } from '../types/tables/IRegionTableLines'

export class RegionTableLineContext {
    
    private static current :RegionTableLineContext

    public static getInstance() :RegionTableLineContext{
        if (!this.current)
            this.current = new RegionTableLineContext(RegionTableLineContext.getInstance);
        return this.current;
    }

    private context = React.createContext<IRegionTableLines | null>(null)

    constructor(caller:Function){
        if (caller == RegionTableLineContext.getInstance)
            console.log("インスタンスを作成。一度しか呼ばれない。");
        else if (RegionTableLineContext.current)
            throw new Error("既にインスタンスが存在するためエラー。");
        else
            throw new Error("コンストラクタの引数が不正な為エラー。");
    }


    getContext() :React.Context<IRegionTableLines | null> {
        return this.context;
    }

    useContext() :IRegionTableLines | null{
        return React.useContext(this.context);
    }
}