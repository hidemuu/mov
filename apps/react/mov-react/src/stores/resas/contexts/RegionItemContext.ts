import React from "react";
import { IRegionItem } from "../types/IRegionItem";
import fetchData from "stores/resas/services/fatchData";

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

  private state: [
    s: IRegionItem[],
    a: React.Dispatch<React.SetStateAction<IRegionItem[]>>,
  ] = React.useState<IRegionItem[]>([]);

  public store: IRegionItem[] = this.state[0];

  private context: React.Context<IRegionItem[]> = React.createContext<
    IRegionItem[]
  >(this.store);

  public getContext(): React.Context<IRegionItem[]> {
    return this.context;
  }

  public update() {
    fetchData<IRegionItem>(API_KEY, this.state[1]);
    //this.context.Provider.bind(this.regionTable)
  }

  public asString(): string {
    let result: string = "";
    for (const item of this.store) {
      result += item;
    }
    return result;
  }
}
