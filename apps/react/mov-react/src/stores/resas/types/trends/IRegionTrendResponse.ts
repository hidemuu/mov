import { IRegionKeyValue } from "../IRegionKeyValue";
import { ITrendItem } from "./ITrendItem";

export interface IRegionTrendResponse {
  region: IRegionKeyValue;
  data: ITrendItem[];
}
