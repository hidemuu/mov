import React, { Dispatch, SetStateAction, useEffect, useState } from 'react'
import type { ComboboxProps, InputProps } from '@fluentui/react-components'
import usePopulationPerYearTrendLines from 'stores/resas/hooks/usePopulationPerYearTrends'
import { IRegionValue } from 'stores/resas/types/IRegionValue'
import useRegionTableLines from 'stores/resas/hooks/useRegionTable'
import { useInputId } from 'domains/inputs/hooks/useInputId'
import { IRegionKey } from 'stores/resas/types/IRegionKey'
import { ResasTemplate } from '..'
import { IRegionTable } from 'stores/resas/types/tables/IRegionTable'
import { IRegionSelections } from '../../../domains/statistics/types/IRegionSelections'

function useSelectedRegionState(
  regionTable: IRegionTable,
  regionCode: IRegionKey
): [IRegionValue, Dispatch<SetStateAction<IRegionValue>>] {
  const [selectedRegionValue, setSelectedRegionValue] = useState<IRegionValue>({
    prefCode: regionCode.prefCode,
    prefName:
      regionTable.pref.filter((x) => x.id === regionCode.prefCode)[0]
        ?.content ?? '',
    cityCode: regionCode.cityCode,
    cityName:
      regionTable.city.filter((x) => x.id === regionCode.cityCode)[0]
        ?.content ?? ''
  })
  return [selectedRegionValue, setSelectedRegionValue]
}

function useRegionSelections(
  regionValue: IRegionValue,
  regionTableLines: IRegionTable
): IRegionSelections {
  const regionSelections: IRegionSelections = {
    selected: regionValue,
    prefSelections: regionTableLines.pref.map((x) => x.content),
    citySelections: regionTableLines.city.map((x) => x.content)
  }
  return regionSelections
}

export const ResasPage: React.FunctionComponent = () => {
  const inputId = useInputId()
  const regionTable = useRegionTableLines()
  const initRegionCode: IRegionKey = { prefCode: 11, cityCode: 11362 }
  const [selectedRegionValue, setSelectedRegionValue] = useSelectedRegionState(
    regionTable,
    initRegionCode
  )
  const populationPerYearTrendLines =
    usePopulationPerYearTrendLines(selectedRegionValue)

  const regionSelections = useRegionSelections(selectedRegionValue, regionTable)

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

  const onChangeSelectedPrefecture: ComboboxProps['onOptionSelect'] = (
    ev,
    data
  ) => {
    const prefName = data.optionValue
    const updateRegionValue: IRegionValue = {
      prefCode: selectedRegionValue.prefCode,
      prefName: prefName ?? '',
      cityCode: selectedRegionValue.cityCode,
      cityName: selectedRegionValue.cityName
    }
    setSelectedRegionValue(updateRegionValue)
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

  const onChangeSelectedCity: ComboboxProps['onOptionSelect'] = (ev, data) => {
    const cityName = data.optionValue
    const updateRegionValue: IRegionValue = {
      prefCode: selectedRegionValue.prefCode,
      prefName: selectedRegionValue.prefName,
      cityCode: selectedRegionValue.cityCode,
      cityName: cityName ?? ''
    }
    setSelectedRegionValue(updateRegionValue)
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
      regionSelections={regionSelections}
      onChangePrefecture={onChangePrefecture}
      onChangeSelectedPrefecture={onChangeSelectedPrefecture}
      onChangeCity={onChangeCity}
      onChangeSelectedCity={onChangeSelectedCity}
    ></ResasTemplate>
  )
}
