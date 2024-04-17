import {
  Dispatch,
  SetStateAction,
  createContext,
  useContext,
  useState,
} from "react";
import { ITableItem } from "../types/tables/ITableItem";

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
  return value; // now has type AppContextValue
  // or even provide domain methods for better encapsulation
}

export function useRegionTableState(): [
  RegionTableContextState,
  Dispatch<SetStateAction<RegionTableContextState>>,
  RegionTableContextState,
  Dispatch<SetStateAction<RegionTableContextState>>,
] {
  const [prefState, setPrefState] = useState<RegionTableContextState>([]);
  const [cityState, setCityState] = useState<RegionTableContextState>([]);
  return [prefState, setPrefState, cityState, setCityState];
}
