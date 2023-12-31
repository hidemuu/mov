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
import useRegionSelections from './hooks/useRegionSelections';
import { TableLine } from './models/TableLine';
import { RegionValue } from './models/RegionValue';


export declare type RegionComboBoxProps = {
    regionValue : RegionValue,
    tableLines : RegionTableLines, 
}

export const RegionComboBox: FC<RegionComboBoxProps> = ({ regionValue, tableLines }) => {

    const comboId = useId("combo-default");
    const regionSelections = useRegionSelections(regionValue, tableLines);

    useEffect(()=>{
        setSelectedOptions(regionSelections.prefSelections);
    },[regionSelections]);

    const [value, setValue] = useState(regionValue.prefCode);
    const [selectedOptions, setSelectedOptions] = useState<string[]>([]);

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
                <Option key={option} disabled={option === value}>
                    {option}
                </Option>
            ))}
        </Combobox>
    );
}