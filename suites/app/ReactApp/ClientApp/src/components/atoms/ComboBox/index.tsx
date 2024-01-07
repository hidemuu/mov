import React, { FC } from 'react'
import { useId, Combobox, Option } from '@fluentui/react-components'
import type { ComboboxProps } from '@fluentui/react-components'

export declare type ComboBoxProps = {
  initValue: string
  values: string[]
  placeHolder: string
  onOptionSelect: ComboboxProps['onOptionSelect']
  onInput: ComboboxProps['onInput']
}

export const ComboBox: FC<ComboBoxProps> = ({
  initValue,
  values,
  placeHolder,
  onOptionSelect,
  onInput
}) => {
  const comboId = useId('combo-default')

  return (
    <Combobox
      aria-labelledby={comboId}
      placeholder={placeHolder}
      value={initValue}
      onInput={onInput}
      onOptionSelect={onOptionSelect}
    >
      {values.map((v) => (
        <Option key={v} disabled={v === initValue}>
          {v}
        </Option>
      ))}
    </Combobox>
  )
}
