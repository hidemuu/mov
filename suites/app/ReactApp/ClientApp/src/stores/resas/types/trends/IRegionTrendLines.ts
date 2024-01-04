import { IRegionKey } from "../IRegionKey";
import { ITrendLine } from "./ITrendLine";

export interface IRegionTrendLines {
    region: IRegionKey;
    trendLines: ITrendLine[];
}