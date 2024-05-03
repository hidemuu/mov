import React, { FC } from "react";
import type { ComboboxProps } from "@fluentui/react-components";
import { IRegionSelections } from "../../../../domains/selections/types/IRegionSelections";
import { SingleSelectComboBox } from "components/atoms/ComboBox/containers/SingleSelectComboBox";

declare type PrefComboBoxProps = {
  regionSelections: IRegionSelections;
  onOptionSelect: ComboboxProps["onOptionSelect"];
};

export const PrefComboBox: FC<PrefComboBoxProps> = ({ regionSelections, onOptionSelect }) => {
  // eslint-disable-next-line @typescript-eslint/no-empty-function
  const onInput: ComboboxProps["onInput"] = (ev) => {};

  return (
    <SingleSelectComboBox
      selectedValue={regionSelections.selected.prefName}
      values={regionSelections.prefSelections}
      placeHolder="都道府県選択"
      onInput={onInput}
      onOptionSelect={onOptionSelect}
    />
  );
};
