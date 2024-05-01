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
    let endpoint: string;
    if (keyValue.cityCode === 0 && keyValue.prefCode === 0) {
      endpoint = "";
    } else if (keyValue.cityCode === 0) {
      endpoint = API_KEY_POPULATION_PER_YEARS + "/" + String(keyValue.prefCode);
    } else {
      endpoint =
        API_KEY_POPULATION_PER_YEARS +
        "/" +
        String(keyValue.prefCode) +
        "/" +
        String(keyValue.cityCode);
    }
    if (endpoint !== "") {
      this.apiClient.get(endpoint, this.contextValue.setState);
    }
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
