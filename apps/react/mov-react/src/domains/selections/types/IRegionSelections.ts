import { IRegionKeyValue } from "stores/resas/types/keys/IRegionKeyValue";

export interface IRegionSelections {
  selected: IRegionKeyValue;
  prefSelections: string[];
  citySelections: string[];
}
