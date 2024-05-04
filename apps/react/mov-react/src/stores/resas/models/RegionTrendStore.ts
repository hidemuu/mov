import { RegionTrendContextValue } from "../contexts/RegionTrendContext";
import { ApiClient } from "./ApiClient";
import { IRegionTrendResponse } from "../types/trends/IRegionTrendResponse";
import { IRegionKey } from "../types/keys/IRegionKey";

const API_ENDPOINT = "/api/analizers/regions/TrendLine/";
const API_KEY_POPULATION_PER_YEARS = `population_per_years`;

export class RegionTrendStore {
  private contextValue: RegionTrendContextValue;
  private apiClient: ApiClient<IRegionTrendResponse>;

  constructor(contextValue: RegionTrendContextValue) {
    this.contextValue = contextValue;
    this.apiClient = new ApiClient(API_ENDPOINT);
  }

  public updatePopulationPerYears(key: IRegionKey) {
    const path: string = this.createPopulationPerYearsPath(key);
    if (path !== "") {
      this.apiClient.get(path, this.contextValue.setState);
    }
  }

  public async updatePopulationPerYearsAsync(key: IRegionKey) {
    const path: string = this.createPopulationPerYearsPath(key);
    if (path !== "") {
      await this.apiClient.getAsync(path, this.contextValue.setState);
    }
  }

  public async updateMultiPopulationPerYearsAsync(keys: IRegionKey[]) {
    const paths: string[] = [];
    for (const key of keys) {
      paths.push(this.createPopulationPerYearsPath(key));
    }
    await this.apiClient.getsAsync(paths, this.contextValue.setState);
  }

  private createPopulationPerYearsPath(key: IRegionKey): string {
    let path: string;
    if (key.cityCode === 0 && key.prefCode === 0) {
      path = "";
    } else if (key.cityCode === 0) {
      path = API_KEY_POPULATION_PER_YEARS + "/" + String(key.prefCode);
    } else {
      path = API_KEY_POPULATION_PER_YEARS + "/" + String(key.prefCode) + "/" + String(key.cityCode);
    }
    return path;
  }

  public getTrend(): IRegionTrendResponse[] {
    return this.contextValue.state;
  }

  public isEmpty(): boolean {
    return this.contextValue.state.length === 0;
  }

  public asString(): string {
    let result = "";
    for (const item of this.contextValue.state) {
      result += `prefcode:${item.region.prefCode}prefname:${item.region.prefName}citycode:${item.region.cityCode}cityname:${item.region.cityName}\n`;
    }
    return result;
  }
}
