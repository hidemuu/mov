import {
  Dispatch,
  SetStateAction,
  createContext,
  useContext,
  useState,
} from "react";
import { ITableItem } from "../types/tables/ITableItem";
import { RegionTableLine } from "../models/RegionTableLine";

type RegionTableContextState = ITableItem[];

export type RegionTableContextValue = {
  prefState: RegionTableContextState;
  setPrefState: Dispatch<SetStateAction<RegionTableContextState>>;
  cityState: RegionTableContextState;
  setCityState: Dispatch<SetStateAction<RegionTableContextState>>;
};

export const RegionTableContext = createContext<
  RegionTableContextValue | undefined
>(undefined);

export function useRegionTableContext() {
  const value = useContext(RegionTableContext);
  if (value === undefined)
    throw new Error(
      "Expected an AppProvider somewhere in the react tree to set context value"
    );
  updateRegionTable(value);
  return value; // now has type AppContextValue
  // or even provide domain methods for better encapsulation
}

export function useRegionTableState(): RegionTableContextValue {
  const [prefState, setPrefState] = useState<RegionTableContextState>([]);
  const [cityState, setCityState] = useState<RegionTableContextState>([]);
  return {
    prefState: prefState,
    setPrefState: setPrefState,
    cityState: cityState,
    setCityState: setCityState,
  };
}

export function updateRegionTable(value: RegionTableContextValue) {
  const model = new RegionTableLine(value);
  if (!model.isEmpty()) return;
  model.update();
}
