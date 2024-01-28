import React, { FC } from 'react'
import type { ComboboxProps } from '@fluentui/react-components'
import { ComboBox } from 'components/atoms/ComboBox'
import { IRegionSelections } from '../../../domains/statistics/types/IRegionSelections'

declare type CityComboBoxProps = {
  regionSelections: IRegionSelections
  onOptionSelect: ComboboxProps['onOptionSelect']
}

export const CityComboBox: FC<CityComboBoxProps> = ({
  regionSelections,
  onOptionSelect
}) => {
  // eslint-disable-next-line @typescript-eslint/no-empty-function
  const onInput: ComboboxProps['onInput'] = (ev) => {}

  return (
    <ComboBox
      selectedValue={regionSelections.selected.cityName}
      values={regionSelections.citySelections}
      placeHolder="市町村選択"
      onInput={onInput}
      onOptionSelect={onOptionSelect}
    />
  )
}
