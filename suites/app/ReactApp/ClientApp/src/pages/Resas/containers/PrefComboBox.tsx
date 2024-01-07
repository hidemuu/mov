import React, { useState, useEffect, FC } from 'react'
import type { ComboboxProps } from '@fluentui/react-components'
import { IRegionTable } from 'stores/resas/types/tables/IRegionTable'
import useRegionSelections from '../hooks/useRegionSelections'
import { IRegionValue } from 'stores/resas/types/IRegionValue'
import { ComboBox } from 'components/atoms/ComboBox'

declare type PrefComboBoxProps = {
  regionValue: IRegionValue
  tableLines: IRegionTable
}

export const PrefComboBox: FC<PrefComboBoxProps> = ({
  regionValue,
  tableLines
}) => {
  const regionSelections = useRegionSelections(regionValue, tableLines)

  useEffect(() => {
    setSelectedOptions(regionSelections.prefSelections)
  }, [regionSelections])

  const [value, setValue] = useState(regionValue.prefName)
  const [selectedOptions, setSelectedOptions] = useState<string[]>([])

  const onOptionSelect: ComboboxProps['onOptionSelect'] = (ev, data) => {
    //setSelectedOptions(data.selectedOptions);
    setValue(data.optionText ?? '')
  }

  const onInput: ComboboxProps['onInput'] = (ev) => {
    const value = ev.target
  }

  return (
    <ComboBox
      initValue={value}
      values={selectedOptions}
      placeHolder="都道府県選択"
      onInput={onInput}
      onOptionSelect={onOptionSelect}
    />
  )
}
