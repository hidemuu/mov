import { RegionTableContextValue } from "../contexts/RegionTableContext";
import { ApiClient } from "./ApiClient";
import { IRegionKey } from "../types/IRegionKey";
import { IRegionKeyValue } from "../types/IRegionKeyValue";
import { IRegionTable } from "../types/tables/IRegionTable";
import { ITableItemResponse } from "../types/tables/ITableItemResponse";

const API_KEY = `/api/analizers/regions/TableLine`;
const API_KEY_PREFECTURE = `${API_KEY}/prefecture`;
const API_KEY_CITY = `${API_KEY}/city`;

export class RegionTableStore {
  private contextValue: RegionTableContextValue;
  private apiClient: ApiClient<ITableItemResponse>;

  constructor(contextValue: RegionTableContextValue) {
    this.contextValue = contextValue;
    this.apiClient = new ApiClient("");
  }

  public update() {
    this.apiClient.get(API_KEY_PREFECTURE, this.contextValue.setPrefState);
    this.apiClient.get(API_KEY_CITY, this.contextValue.setCityState);
  }

  public getTable(): IRegionTable {
    return {
      pref: this.contextValue.prefState,
      city: this.contextValue.cityState,
    };
  }

  public getPrefectureCode(name: string): number {
    return (
      this.contextValue.prefState.filter((x) => x.content === name)[0].id ?? 0
    );
  }

  public getCityCode(name: string): number {
    return (
      this.contextValue.cityState.filter((x) => x.content === name)[0].id ?? 0
    );
  }

  public getPrefCities(prefCode: number): ITableItemResponse[] {
    return this.contextValue.cityState.filter(
      (x) => Number(x.label) === prefCode
    );
  }

  public getRegionValue(regionKey: IRegionKey): IRegionKeyValue {
    const targetPref = this.contextValue.prefState.filter(
      (x) => x.id === regionKey.prefCode
    )[0];
    const targetCity = this.contextValue.cityState.filter(
      (x) => x.id === regionKey.cityCode
    )[0];
    if (targetPref === undefined || targetCity === undefined) {
      return {
        prefCode: regionKey.prefCode,
        prefName: "",
        cityCode: regionKey.cityCode,
        cityName: "",
      };
    }
    const updateCity =
      Number(targetCity.label) === targetPref.id
        ? targetCity
        : this.getPrefCities(targetPref.id)[0] ?? targetCity;
    const updateRegionValue: IRegionKeyValue = {
      prefCode: targetPref.id,
      prefName: targetPref?.content ?? "",
      cityCode: updateCity.id,
      cityName: updateCity?.content ?? "",
    };
    return updateRegionValue;
  }

  public isEmpty(): boolean {
    return (
      this.contextValue.prefState.length === 0 ||
      this.contextValue.cityState.length === 0
    );
  }
}
