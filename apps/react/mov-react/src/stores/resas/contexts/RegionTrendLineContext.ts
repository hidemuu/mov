import {
  Dispatch,
  SetStateAction,
  createContext,
  useContext,
  useState,
} from "react";
import { IRegionTrend } from "../types/trends/IRegionTrend";
import fetchData from "stores/resas/services/fatchData";
import { IRegionValue } from "../types/IRegionValue";

const API_KEY = "/api/analizers/regions/TrendLine";
const API_KEY_POPULATION_PER_YEARS = `${API_KEY}/population_per_years`;

type RegionTrendContextState = IRegionTrend[];

type RegionTrendContextValue = {
  state: RegionTrendContextState;
  setState: Dispatch<SetStateAction<RegionTrendContextState>>;
};

export const RegionTrendContext = createContext<
  RegionTrendContextValue | undefined
>(undefined);

export function useRegionTrendContext() {
  const value = useContext(RegionTrendContext);
  if (value === undefined)
    throw new Error(
      "Expected an AppProvider somewhere in the react tree to set context value"
    );
  return value; // now has type AppContextValue
  // or even provide domain methods for better encapsulation
}

export function useRegionTrendState(): [
  RegionTrendContextState,
  Dispatch<SetStateAction<RegionTrendContextState>>,
] {
  return useState<RegionTrendContextState>([]);
}

export function updateRegionTrendPopulationPerYearsState(
  region: IRegionValue,
  setState: Dispatch<SetStateAction<RegionTrendContextState>>
) {
  let endpoint: string;
  if (region.cityCode === 0 && region.prefCode === 0) {
    endpoint = "";
  } else if (region.cityCode === 0) {
    endpoint = API_KEY_POPULATION_PER_YEARS + "/" + String(region.prefCode);
  } else {
    endpoint =
      API_KEY_POPULATION_PER_YEARS +
      "/" +
      String(region.prefCode) +
      "/" +
      String(region.cityCode);
  }
  if (endpoint !== "") {
    fetchData<IRegionTrend>(endpoint, setState);
  }
}

export function asStringRegionTrendState(
  state: RegionTrendContextState
): string {
  let result: string = "";
  for (const item of state) {
    result += `prefcode:${item.region.prefCode}prefname:${item.region.prefName}citycode:${item.region.cityCode}cityname:${item.region.cityName}\n`;
  }
  return result;
}
