import { RegionItemContextValue } from "../contexts/RegionItemContext";
import { ApiClient } from "./ApiClient";
import { IRegionItem } from "../types/IRegionItem";

const API_KEY = "/api/analizers/regions/resas/ResasPrefecture";

export class RegionItemStore {
  private contextValue: RegionItemContextValue;
  private apiClient: ApiClient<IRegionItem>;

  constructor(contextValue: RegionItemContextValue) {
    this.contextValue = contextValue;
    this.apiClient = new ApiClient("");
  }

  public update() {
    if (this.contextValue.state.length > 0) return;
    this.apiClient.get(API_KEY, this.contextValue.setState);
  }

  public isEmpty(): boolean {
    return this.contextValue.state.length === 0;
  }

  public asString(): string {
    let result: string = "";
    for (const item of this.contextValue.state) {
      result += `code:${item.code}name:${item.name}\n`;
    }
    return result;
  }
}
