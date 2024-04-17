import React, {
  Dispatch,
  SetStateAction,
  createContext,
  useContext,
  useState,
} from "react";
import axios from "axios";
import { IRegionTable } from "../types/tables/IRegionTable";
import { ITableItem } from "../types/tables/ITableItem";

const API_KEY = `api/TableLine`;
const API_KEY_PREFECTURE = `${API_KEY}/prefecture`;
const API_KEY_CITY = `${API_KEY}/city`;

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

export class RegionTableLineContext {
  private static current: RegionTableLineContext;

  public static get instance(): RegionTableLineContext {
    if (!this.current) this.current = new RegionTableLineContext();
    return this.current;
  }

  private context: React.Context<IRegionTable> =
    React.createContext<IRegionTable>({ pref: [], city: [] });

  public regionTable: IRegionTable = { pref: [], city: [] };

  public getContext(): React.Context<IRegionTable> {
    return this.context;
  }

  private updateRegionTableState() {
    axios
      .get(API_KEY_PREFECTURE, {})
      .then((results) => {
        this.regionTable.pref = results.data;
      })
      .catch((error) => {
        console.log(error);
      });
    axios
      .get(API_KEY_CITY, {})
      .then((results) => {
        this.regionTable.city = results.data;
      })
      .catch((error) => {
        console.log(error);
      });
  }
}
