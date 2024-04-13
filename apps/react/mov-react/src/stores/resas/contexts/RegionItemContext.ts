import React, {
  Dispatch,
  SetStateAction,
  createContext,
  useContext,
} from "react";
import { IRegionItem } from "../types/IRegionItem";
import fetchData from "stores/resas/services/fatchData";

const API_KEY = "/api/analizers/regions/resas/ResasPrefecture";

type RegionItemContextState = IRegionItem[];

type RegionItemContextValue = {
  state: RegionItemContextState;
  setState: Dispatch<SetStateAction<RegionItemContextState>>;
};

export const RegionItemContext: React.Context<
  RegionItemContextValue | undefined
> = createContext<RegionItemContextValue | undefined>(undefined);

export function useThisContext() {
  const value = useContext(RegionItemContext);
  if (value === undefined)
    throw new Error(
      "Expected an AppProvider somewhere in the react tree to set context value"
    );
  return value; // now has type AppContextValue
  // or even provide domain methods for better encapsulation
}

export function update(value: RegionItemContextValue) {
  fetchData<IRegionItem>(API_KEY, value.setState);
}

export function asString(state: RegionItemContextState): string {
  let result: string = "";
  for (const item of state) {
    result += item;
  }
  return result;
}
