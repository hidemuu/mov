import { IRegionValue } from "../IRegionValue";
import { ITrendItem } from "./ITrendItem";

export interface IRegionTrendResponse {
  region: IRegionValue;
  data: ITrendItem[];
}
