import { RegionItemContextValue } from "../contexts/RegionItemContext";
import { ApiClient } from "./ApiClient";
import { IRegionItemResponse } from "../types/keys/IRegionItemResponse";

const API_ENDPOINT = "/api/analizers/regions/resas/ResasPrefecture";

export class RegionItemStore {
  private contextValue: RegionItemContextValue;
  private apiClient: ApiClient<IRegionItemResponse>;

  constructor(contextValue: RegionItemContextValue) {
    this.contextValue = contextValue;
    this.apiClient = new ApiClient(API_ENDPOINT);
  }

  public update() {
    if (this.contextValue.state.length > 0) return;
    this.apiClient.get("", this.contextValue.setState);
  }

  public isEmpty(): boolean {
    return this.contextValue.state.length === 0;
  }

  public asString(): string {
    let result = "";
    for (const item of this.contextValue.state) {
      result += `code:${item.code}name:${item.name}\n`;
    }
    return result;
  }
}
