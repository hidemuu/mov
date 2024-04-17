import { RegionTableContextValue } from "../contexts/RegionTableLineContext";
import fetchData from "../services/fatchData";
import { ITableItem } from "../types/tables/ITableItem";

const API_KEY = `api/TableLine`;
const API_KEY_PREFECTURE = `${API_KEY}/prefecture`;
const API_KEY_CITY = `${API_KEY}/city`;

export class RegionTable {
  private contextValue: RegionTableContextValue;

  constructor(contextValue: RegionTableContextValue) {
    this.contextValue = contextValue;
  }

  public updateRegionTableState() {
    fetchData<ITableItem>(API_KEY_PREFECTURE, this.contextValue.setPrefState);
    fetchData<ITableItem>(API_KEY_CITY, this.contextValue.setCityState);
  }
}
