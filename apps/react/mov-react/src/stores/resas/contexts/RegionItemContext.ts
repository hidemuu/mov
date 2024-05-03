import { Dispatch, SetStateAction, createContext, useContext, useState } from "react";
import { IRegionItemResponse } from "../types/keys/IRegionItemResponse";
import { RegionItemStore } from "../models/RegionItemStore";

type RegionItemContextState = IRegionItemResponse[];

export type RegionItemContextValue = {
  state: RegionItemContextState;
  setState: Dispatch<SetStateAction<RegionItemContextState>>;
};

export const RegionItemContext = createContext<RegionItemStore | undefined>(undefined);

export function useRegionItemContext() {
  const store = useContext(RegionItemContext);
  if (store === undefined)
    throw new Error("Expected an AppProvider somewhere in the react tree to set context value");
  if (store.isEmpty()) {
    store.update();
  }
  return store; // now has type AppContextValue
  // or even provide domain methods for better encapsulation
}

export function useRegionItemContextValue(): RegionItemStore {
  const [state, setState] = useState<RegionItemContextState>([]);
  return new RegionItemStore({ state: state, setState: setState });
}
