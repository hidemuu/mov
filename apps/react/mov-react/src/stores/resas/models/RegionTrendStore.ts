import { RegionTrendContextValue } from "../contexts/RegionTrendContext";

export class RegionTrendStore {
  private contextValue: RegionTrendContextValue;

  constructor(contextValue: RegionTrendContextValue) {
    this.contextValue = contextValue;
  }
}
