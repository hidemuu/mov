import { Dispatch, SetStateAction, createContext, useContext, useState } from "react";
import { ITableItemResponse } from "../types/tables/ITableItemResponse";
import { RegionTableStore } from "../models/RegionTableStore";

export type RegionTableContextState = ITableItemResponse[];

export type RegionTableContextValue = {
  prefState: RegionTableContextState;
  setPrefState: Dispatch<SetStateAction<RegionTableContextState>>;
  cityState: RegionTableContextState;
  setCityState: Dispatch<SetStateAction<RegionTableContextState>>;
};

export const RegionTableContext = createContext<RegionTableStore | undefined>(undefined);

export function useRegionTableContext() {
  const store = useContext(RegionTableContext);
  if (store === undefined)
    throw new Error("Expected an AppProvider somewhere in the react tree to set context value");
  if (store.isEmpty()) {
    store.update();
  }
  return store; // now has type AppContextValue
  // or even provide domain methods for better encapsulation
}

export function useRegionTableContextValue(): RegionTableStore {
  const [prefState, setPrefState] = useState<RegionTableContextState>([]);
  const [cityState, setCityState] = useState<RegionTableContextState>([]);
  return new RegionTableStore({
    prefState: prefState,
    setPrefState: setPrefState,
    cityState: cityState,
    setCityState: setCityState,
  });
}
