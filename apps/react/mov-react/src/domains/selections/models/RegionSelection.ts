import { RegionTableStore } from "stores/resas/models/RegionTableStore";
import { IRegionSelections } from "../types/IRegionSelections";
import { IRegionValue } from "stores/resas/types/IRegionValue";
import { IRegionKey } from "stores/resas/types/IRegionKey";

export class RegionSelection {
  private tableStore: RegionTableStore;

  constructor(tableStore: RegionTableStore) {
    this.tableStore = tableStore;
  }

  public getSelections(regionKey: IRegionKey): IRegionSelections {
    const regionValue = this.getSelectedValue(regionKey);
    const prefCities = this.tableStore.getPrefCities(regionValue.prefCode);
    const regionSelections: IRegionSelections = {
      selected: regionValue,
      prefSelections: this.tableStore.getTable().pref.map((x) => x.content),
      citySelections: prefCities.map((x) => x.content),
    };
    return regionSelections;
  }

  public getSelectedValue(regionKey: IRegionKey): IRegionValue {
    return this.tableStore.getRegionValue(regionKey);
  }
}
