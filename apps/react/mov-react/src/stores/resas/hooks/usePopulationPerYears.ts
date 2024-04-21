import { useEffect } from "react";
import { RegionTrendStore } from "../models/RegionTrendStore";
import { IRegionValue } from "../types/IRegionValue";

export default function usePopulationPerYear(
  regionValue: IRegionValue,
  store: RegionTrendStore
) {
  useEffect(() => {
    store.updatePopulationPerYears(regionValue);
  }, [regionValue, store]);
}
