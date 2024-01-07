import React, { useEffect } from 'react'
import type { InputProps } from '@fluentui/react-components'
import usePopulationPerYearTrendLines from '../../stores/resas/hooks/usePopulationPerYearTrends'
import useSelectedRegionState from './hooks/useSelectedRegionState'
import { IRegionValue } from '../../stores/resas/types/IRegionValue'
import useRegionTableLines from '../../stores/resas/hooks/useRegionTable'
import { useInputId } from '../../domains/inputs/hooks/useInputId'
import { IRegionKeyCode } from '../../stores/resas/types/IRegionKeyCode'
import { ResasTemplate } from '.'

export const ResasPage: React.FunctionComponent = () => {
  const inputId = useInputId()
  const regionTable = useRegionTableLines()
  const initRegionCode: IRegionKeyCode = { pref: 11, city: 11362 }
  const [selectedRegionValue, setSelectedRegionValue] = useSelectedRegionState(
    regionTable,
    initRegionCode
  )
  const populationPerYearTrendLines =
    usePopulationPerYearTrendLines(selectedRegionValue)

  const onChangePrefecture: InputProps['onChange'] = (ev, data) => {
    if (data.value.length <= 20) {
      const prefCode = Number(data.value)
      const updateRegionValue: IRegionValue = {
        prefCode: prefCode,
        prefName: '',
        cityCode: selectedRegionValue.cityCode,
        cityName: selectedRegionValue.cityName
      }
      setSelectedRegionValue(updateRegionValue)
    }
  }

  const onChangeCity: InputProps['onChange'] = (ev, data) => {
    if (data.value.length <= 20) {
      const cityCode = Number(data.value)
      const updateRegionValue: IRegionValue = {
        prefCode: selectedRegionValue.prefCode,
        prefName: selectedRegionValue.prefName,
        cityCode: cityCode,
        cityName: ''
      }
      setSelectedRegionValue(updateRegionValue)
    }
  }

  useEffect(() => {
    //レンダリング毎に実行
    console.log('再レンダリングされるたび実行')
  })

  return (
    <ResasTemplate
      inputId={inputId}
      regionTable={regionTable}
      regionTrendLines={populationPerYearTrendLines}
      selectedRegionKey={selectedRegionValue}
      onChangePrefecture={onChangePrefecture}
      onChangeCity={onChangeCity}
    ></ResasTemplate>
  )
}
