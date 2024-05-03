import React from "react";
import { RegionComboBox } from "../index";
import { IRegionSelections } from "domains/selections/types/IRegionSelections";
import { ComboboxProps } from "@fluentui/react-components";

declare type PrefComboBoxProps = {
  regionSelections: IRegionSelections;
  onOptionSelect: ComboboxProps["onOptionSelect"];
};

export const PrefComboBox = (props: PrefComboBoxProps) => {
  const { regionSelections, onOptionSelect } = props;

  return (
    <RegionComboBox
      selectedValue={regionSelections.selected.prefName}
      values={regionSelections.prefSelections}
      onOptionSelect={onOptionSelect}
      placeHolder="都道府県選択"
    />
  );
};
