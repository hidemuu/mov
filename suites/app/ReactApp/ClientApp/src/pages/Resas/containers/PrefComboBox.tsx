import React, { FC } from 'react'
import type { ComboboxProps } from '@fluentui/react-components'
import { ComboBox } from 'components/atoms/ComboBox'
import { IRegionSelections } from '../types/IRegionSelections'

declare type PrefComboBoxProps = {
  regionSelections: IRegionSelections
  onOptionSelect: ComboboxProps['onOptionSelect']
}

export const PrefComboBox: FC<PrefComboBoxProps> = ({
  regionSelections,
  onOptionSelect
}) => {
  // eslint-disable-next-line @typescript-eslint/no-empty-function
  const onInput: ComboboxProps['onInput'] = (ev) => {}

  return (
    <ComboBox
      selectedValue={regionSelections.selected.prefName}
      values={regionSelections.prefSelections}
      placeHolder="都道府県選択"
      onInput={onInput}
      onOptionSelect={onOptionSelect}
    />
  )
}
