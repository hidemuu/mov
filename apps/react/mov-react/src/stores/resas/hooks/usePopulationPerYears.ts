import { useEffect } from "react";
import { RegionTrendStore } from "../models/RegionTrendStore";
import { IRegionKeyValue } from "../types/IRegionKeyValue";

export default function usePopulationPerYear(
  regionValue: IRegionKeyValue,
  store: RegionTrendStore
) {
  useEffect(() => {
    store.updatePopulationPerYears(regionValue);
  }, [regionValue]);
}
