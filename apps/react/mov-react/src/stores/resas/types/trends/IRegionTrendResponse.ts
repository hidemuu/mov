import { IRegionKeyValue } from "../keys/IRegionKeyValue";
import { ITrendItem } from "./ITrendItem";

export interface IRegionTrendResponse {
  region: IRegionKeyValue;
  data: ITrendItem[];
}
