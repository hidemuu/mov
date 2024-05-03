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
};

export const ComboBox: FC<ComboBoxProps> = ({
  multiselect,
  selectedValue,
  values,
  placeHolder,
  onOptionSelect,
  onInput,
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
    >
      {values.map((v) => (
        <Option key={v} disabled={v === selectedValue}>
          {v}
        </Option>
      ))}
    </Combobox>
  );
};
