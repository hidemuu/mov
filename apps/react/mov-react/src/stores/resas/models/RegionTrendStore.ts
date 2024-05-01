import { RegionTrendContextValue } from "../contexts/RegionTrendContext";
import { ApiClient } from "./ApiClient";
import { IRegionKeyValue } from "../types/keys/IRegionKeyValue";
import { IRegionTrendResponse } from "../types/trends/IRegionTrendResponse";

const API_ENDPOINT = "/api/analizers/regions/TrendLine/";
const API_KEY_POPULATION_PER_YEARS = `population_per_years`;

export class RegionTrendStore {
  private contextValue: RegionTrendContextValue;
  private apiClient: ApiClient<IRegionTrendResponse>;

  constructor(contextValue: RegionTrendContextValue) {
    this.contextValue = contextValue;
    this.apiClient = new ApiClient(API_ENDPOINT);
  }

  public updatePopulationPerYears(keyValue: IRegionKeyValue) {
    const path: string = this.createPopulationPerYearsPath(keyValue);
    if (path !== "") {
      this.apiClient.get(path, this.contextValue.setState);
    }
  }

  public async updatePopulationPerYearsAsync(keyValue: IRegionKeyValue) {
    const path: string = this.createPopulationPerYearsPath(keyValue);
    if (path !== "") {
      await this.apiClient.getAsync(path, this.contextValue.setState);
    }
  }

  private createPopulationPerYearsPath(keyValue: IRegionKeyValue): string {
    let path: string;
    if (keyValue.cityCode === 0 && keyValue.prefCode === 0) {
      path = "";
    } else if (keyValue.cityCode === 0) {
      path = API_KEY_POPULATION_PER_YEARS + "/" + String(keyValue.prefCode);
    } else {
      path =
        API_KEY_POPULATION_PER_YEARS +
        "/" +
        String(keyValue.prefCode) +
        "/" +
        String(keyValue.cityCode);
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
    let result: string = "";
    for (const item of this.contextValue.state) {
      result += `prefcode:${item.region.prefCode}prefname:${item.region.prefName}citycode:${item.region.cityCode}cityname:${item.region.cityName}\n`;
    }
    return result;
  }
}
