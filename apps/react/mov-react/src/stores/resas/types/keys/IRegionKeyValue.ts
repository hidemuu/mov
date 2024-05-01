import { IRegionKey } from "./IRegionKey";

export interface IRegionKeyValue extends IRegionKey {
  prefName: string;
  cityName: string;
}
