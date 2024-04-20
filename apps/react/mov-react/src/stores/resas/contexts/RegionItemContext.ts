import {
  Dispatch,
  SetStateAction,
  createContext,
  useContext,
  useState,
} from "react";
import { IRegionItem } from "../types/IRegionItem";
import fetchData from "stores/resas/services/fatchData";

const API_KEY = "/api/analizers/regions/resas/ResasPrefecture";

type RegionItemContextState = IRegionItem[];

type RegionItemContextValue = {
  state: RegionItemContextState;
  setState: Dispatch<SetStateAction<RegionItemContextState>>;
};

export const RegionItemContext = createContext<
  RegionItemContextValue | undefined
>(undefined);

export function useRegionItemContext() {
  const value = useContext(RegionItemContext);
  if (value === undefined)
    throw new Error(
      "Expected an AppProvider somewhere in the react tree to set context value"
    );
  return value; // now has type AppContextValue
  // or even provide domain methods for better encapsulation
}

export function useRegionItemState(): [
  RegionItemContextState,
  Dispatch<SetStateAction<RegionItemContextState>>,
] {
  return useState<RegionItemContextState>([]);
}

export function updateRegionItemState(value: RegionItemContextValue) {
  if (value.state.length > 0) return;
  fetchData<IRegionItem>(API_KEY, value.setState);
}

export function asStringRegionItemState(state: RegionItemContextState): string {
  let result: string = "";
  for (const item of state) {
    result += `code:${item.code}name:${item.name}\n`;
  }
  return result;
}
