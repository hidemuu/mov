import React from "react";
import { ComboBox } from "../index";
import { ComboboxProps } from "@fluentui/react-components";

type MultiSelectComboBoxProps = {
  selectedValue: string;
  values: string[];
  placeHolder: string;
  onOptionSelect: ComboboxProps["onOptionSelect"];
  onInput: ComboboxProps["onInput"];
};

export const MultiSelectComboBox = (props: MultiSelectComboBoxProps) => {
  const { selectedValue, values, placeHolder, onOptionSelect, onInput } = props;

  return (
    <ComboBox
      multiselect={true}
      selectedValue={selectedValue}
      values={values}
      placeHolder={placeHolder}
      onOptionSelect={onOptionSelect}
      onInput={onInput}
    />
  );
};
