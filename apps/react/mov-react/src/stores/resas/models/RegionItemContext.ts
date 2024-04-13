import React from "react";
import { IRegionItem } from "../types/IRegionItem";
import fetchData from "utils/services/fatchData";

const API_KEY = "/api/analizers/regions/resas/ResasPrefecture";

export class RegionItemContext {
  private static current: RegionItemContext;

  public static get instance(): RegionItemContext {
    if (!this.current) this.current = new RegionItemContext();
    return this.current;
  }

  private constructor() {
    this.update();
  }

  private context: React.Context<IRegionItem[]> = React.createContext<
    IRegionItem[]
  >([]);

  public state: [
    s: IRegionItem[],
    a: React.Dispatch<React.SetStateAction<IRegionItem[]>>,
  ] = React.useState<IRegionItem[]>([]);

  public getContext(): React.Context<IRegionItem[]> {
    return this.context;
  }

  private update() {
    fetchData<IRegionItem>(API_KEY, this.state[1]);

    //this.context.Provider.bind(this.regionTable)
  }
}
