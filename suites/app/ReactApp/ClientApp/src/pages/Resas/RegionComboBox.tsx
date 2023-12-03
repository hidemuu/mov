import React, { useState, useEffect, FC } from 'react';
import {
    useId, 
    Combobox,
    Option,
} from '@fluentui/react-components';
import type {
    ComboboxProps,
  } from "@fluentui/react-components";
import { RegionTableLines } from './models/RegionTableLines';


export declare type RegionComboBoxProps = {
    regionTableLines : RegionTableLines, 
}

export const RegionComboBox: FC<RegionComboBoxProps> = ({ regionTableLines }) => {

    const comboId = useId("combo-default");

    const [value, setValue] = useState("Cat");

    const [selectedOptions, setSelectedOptions] = useState<string[]>([
        "Cat", "Dog", "Ferret", "Fish", "Hamster", "Snake"
      ]);

    const onOptionSelect: ComboboxProps["onOptionSelect"] = (ev, data) => {
        //setSelectedOptions(data.selectedOptions);
        setValue(data.optionText ?? "");
    };

    const onInput: ComboboxProps["onInput"] = (ev) =>{
        let value = ev.target;
    }

    return(
        <Combobox 
            aria-labelledby={comboId} 
            placeholder="都道府県選択" 
            value={value}
            onInput={onInput}
            onOptionSelect={onOptionSelect}>
            {selectedOptions.map((option) => (
                <Option key={option} disabled={option === "Ferret"}>
                    {option}
                </Option>
            ))}
        </Combobox>
    );
}