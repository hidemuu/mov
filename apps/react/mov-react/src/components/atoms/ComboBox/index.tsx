import React, { FC } from "react";
import { useId, Combobox, Option } from "@fluentui/react-components";
import type { ComboboxProps } from "@fluentui/react-components";

export declare type ComboBoxProps = {
  multiselect: boolean;
  selectedValue: string;
  values: string[];
  placeHolder: string;
  onOptionSelect: ComboboxProps["onOptionSelect"];
  onInput: ComboboxProps["onInput"];
  onChange: ComboboxProps["onChange"];
};

export const ComboBox: FC<ComboBoxProps> = ({
  multiselect,
  selectedValue,
  values,
  placeHolder,
  onOptionSelect,
  onInput,
  onChange,
}) => {
  const comboId = useId("combo-default");

  return (
    <Combobox
      multiselect={multiselect}
      aria-labelledby={comboId}
      placeholder={placeHolder}
      value={selectedValue}
      onInput={onInput}
      onOptionSelect={onOptionSelect}
      onChange={onChange}
    >
      {values.map((value) => (
        <Option key={value} disabled={value === selectedValue && !multiselect}>
          {value}
        </Option>
      ))}
    </Combobox>
  );
};
