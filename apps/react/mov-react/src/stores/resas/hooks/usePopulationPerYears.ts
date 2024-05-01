import { useEffect } from "react";
import { RegionTrendStore } from "../models/RegionTrendStore";
import { IRegionKey } from "../types/keys/IRegionKey";

export default function usePopulationPerYear(
  regionKey: IRegionKey,
  store: RegionTrendStore
) {
  useEffect(() => {
    const update = async () => {
      await store.updatePopulationPerYearsAsync(regionKey);
    };
    update();
  }, [regionKey]);
}
