import { RegionTableStore } from "stores/resas/models/RegionTableStore";
import { IRegionSelections } from "../types/IRegionSelections";
import { IRegionValue } from "stores/resas/types/IRegionValue";
import { IRegionKey } from "stores/resas/types/IRegionKey";
import { Dispatch, SetStateAction } from "react";

type RegionSelectionState = {
  state: IRegionKey;
  setState: Dispatch<SetStateAction<IRegionKey>>;
};

export class RegionSelection {
  private state: RegionSelectionState;
  private tableStore: RegionTableStore;

  constructor(
    useState: [IRegionKey, Dispatch<SetStateAction<IRegionKey>>],
    tableStore: RegionTableStore
  ) {
    this.state = { state: useState[0], setState: useState[1] };
    this.tableStore = tableStore;
  }

  public setSelected(regionKey: IRegionKey) {
    this.state.setState(regionKey);
  }

  public getSelected(): IRegionKey {
    return this.state.state;
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

  public getSelectedValue(): IRegionValue {
    return this.tableStore.getRegionValue(this.state.state);
  }
}
