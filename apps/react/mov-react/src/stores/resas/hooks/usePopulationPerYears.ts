import { useEffect } from "react";
import { RegionTrendStore } from "../models/RegionTrendStore";
import { IRegionKeyValue } from "../types/keys/IRegionKeyValue";

export default function usePopulationPerYear(
  regionValue: IRegionKeyValue,
  store: RegionTrendStore
) {
  useEffect(() => {
    const update = async () => {
      await store.updatePopulationPerYearsAsync(regionValue);
    };
    update();
  }, [regionValue]);
}
