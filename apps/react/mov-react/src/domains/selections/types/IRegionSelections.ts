import { IRegionKeyValue } from "stores/resas/types/IRegionKeyValue";

export interface IRegionSelections {
  selected: IRegionKeyValue;
  prefSelections: string[];
  citySelections: string[];
}
