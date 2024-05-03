import { RegionTableStore } from "stores/resas/models/RegionTableStore";
import { IRegionSelections } from "../types/IRegionSelections";
import { IRegionKeyValue } from "stores/resas/types/keys/IRegionKeyValue";
import { IRegionKey } from "stores/resas/types/keys/IRegionKey";

export class RegionSelection {
  private latestSelectRegionKey: IRegionKey;
  private selectedRegionKeys: IRegionKey[];
  private tableStore: RegionTableStore;

  constructor(
    latestSelectRegionKey: IRegionKey,
    selectedRegionKeys: IRegionKey[],
    tableStore: RegionTableStore,
  ) {
    this.latestSelectRegionKey = latestSelectRegionKey;
    this.selectedRegionKeys = selectedRegionKeys;
    this.tableStore = tableStore;
  }

  public getSelections(): IRegionSelections {
    const regionValue = this.getSelectedValue();
    const prefCities = this.tableStore.getPrefCities(regionValue.prefCode);
    const regionSelections: IRegionSelections = {
      selected: regionValue,
      prefSelections: this.tableStore.getTable().pref.map((x) => x.content),
      citySelections: prefCities.map((x) => x.content),
    };
    return regionSelections;
  }

  public getSelectedValue(): IRegionKeyValue {
    return this.tableStore.getRegionValue(this.latestSelectRegionKey);
  }
}
