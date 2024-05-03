import React from "react";
import { ComboBox } from "../index";
import { ComboboxProps } from "@fluentui/react-components";

type SingleSelectComboBoxProps = {
  selectedValue: string;
  values: string[];
  placeHolder: string;
  onOptionSelect: ComboboxProps["onOptionSelect"];
  onInput: ComboboxProps["onInput"];
};

export const SingleSelectComboBox = (props: SingleSelectComboBoxProps) => {
  const { selectedValue, values, placeHolder, onOptionSelect, onInput } = props;

  return (
    <ComboBox
      multiselect={false}
      selectedValue={selectedValue}
      values={values}
      placeHolder={placeHolder}
      onOptionSelect={onOptionSelect}
      onInput={onInput}
    />
  );
};
