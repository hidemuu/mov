import {
  Dispatch,
  SetStateAction,
  createContext,
  useContext,
  useState,
} from "react";
import { IRegionTrend } from "../types/trends/IRegionTrend";
import { RegionTrendStore } from "../models/RegionTrendStore";

type RegionTrendContextState = IRegionTrend[];

export type RegionTrendContextValue = {
  state: RegionTrendContextState;
  setState: Dispatch<SetStateAction<RegionTrendContextState>>;
};

export const RegionTrendContext = createContext<RegionTrendStore | undefined>(
  undefined
);

export function useRegionTrendContext() {
  const store = useContext(RegionTrendContext);
  if (store === undefined)
    throw new Error(
      "Expected an AppProvider somewhere in the react tree to set context value"
    );
  return store; // now has type AppContextValue
  // or even provide domain methods for better encapsulation
}

export function useRegionTrendContextValue(): RegionTrendStore {
  const [state, setState] = useState<RegionTrendContextState>([]);
  return new RegionTrendStore({ state: state, setState: setState });
}
