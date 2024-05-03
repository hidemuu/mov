import React, { FC } from "react";
import type { ComboboxProps } from "@fluentui/react-components";
import { MultiSelectComboBox } from "components/atoms/ComboBox/containers/MultiSelectComboBox";

declare type RegionComboBoxProps = {
  selectedValue: string;
  values: string[];
  onOptionSelect: ComboboxProps["onOptionSelect"];
  placeHolder: string;
};

export const RegionComboBox: FC<RegionComboBoxProps> = ({
  selectedValue,
  values,
  onOptionSelect,
  placeHolder,
}) => {
  // eslint-disable-next-line @typescript-eslint/no-empty-function
  const onInput: ComboboxProps["onInput"] = (ev) => {};

  return (
    <MultiSelectComboBox
      selectedValue={selectedValue}
      values={values}
      placeHolder={placeHolder}
      onInput={onInput}
      onOptionSelect={onOptionSelect}
    />
  );
};
