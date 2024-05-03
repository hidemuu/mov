import React from "react";
import { RegionComboBox } from "../index";
import { IRegionSelections } from "domains/selections/types/IRegionSelections";
import { ComboboxProps } from "@fluentui/react-components";

declare type CityComboBoxProps = {
  regionSelections: IRegionSelections;
  onOptionSelect: ComboboxProps["onOptionSelect"];
};

export const CityComboBox = (props: CityComboBoxProps) => {
  const { regionSelections, onOptionSelect } = props;

  return (
    <RegionComboBox
      selectedValue={regionSelections.selected.cityName}
      values={regionSelections.citySelections}
      onOptionSelect={onOptionSelect}
      placeHolder="市町村選択"
    />
  );
};
