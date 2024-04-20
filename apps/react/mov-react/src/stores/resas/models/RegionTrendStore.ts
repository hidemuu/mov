import { RegionTrendContextValue } from "../contexts/RegionTrendContext";
import fetchData from "../services/fatchData";
import { IRegionValue } from "../types/IRegionValue";
import { IRegionTrend } from "../types/trends/IRegionTrend";

const API_KEY = "/api/analizers/regions/TrendLine";
const API_KEY_POPULATION_PER_YEARS = `${API_KEY}/population_per_years`;

export class RegionTrendStore {
  private contextValue: RegionTrendContextValue;

  constructor(contextValue: RegionTrendContextValue) {
    this.contextValue = contextValue;
  }

  public updatePopulationPerYears(region: IRegionValue) {
    let endpoint: string;
    if (region.cityCode === 0 && region.prefCode === 0) {
      endpoint = "";
    } else if (region.cityCode === 0) {
      endpoint = API_KEY_POPULATION_PER_YEARS + "/" + String(region.prefCode);
    } else {
      endpoint =
        API_KEY_POPULATION_PER_YEARS +
        "/" +
        String(region.prefCode) +
        "/" +
        String(region.cityCode);
    }
    if (endpoint !== "") {
      fetchData<IRegionTrend>(endpoint, this.contextValue.setState);
    }
  }

  public getTrend(): IRegionTrend[] {
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
