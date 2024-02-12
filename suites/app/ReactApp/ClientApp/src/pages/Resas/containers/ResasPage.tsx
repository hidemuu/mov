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
  regionKey: IRegionKey
): [IRegionValue, Dispatch<SetStateAction<IRegionValue>>] {
  const [selectedRegionValue, setSelectedRegionValue] = useState<IRegionValue>(
    getRegionValue(regionTable, regionKey)
  )

  useEffect(() => {
    const update = getRegionValue(regionTable, regionKey)
    setSelectedRegionValue(update)
  }, [regionKey])

  return [selectedRegionValue, setSelectedRegionValue]
}

function getRegionValue(
  regionTable: IRegionTable,
  regionKey: IRegionKey
): IRegionValue {
  const updateRegionValue: IRegionValue = {
    prefCode: regionKey.prefCode,
    prefName:
      regionTable.pref.filter((x) => x.id === regionKey.prefCode)[0]?.content ??
      '',
    cityCode: regionKey.cityCode,
    cityName:
      regionTable.city.filter((x) => x.id === regionKey.cityCode)[0]?.content ??
      ''
  }
  return updateRegionValue
}

function getRegionSelections(
  regionValue: IRegionValue,
  regionTable: IRegionTable
): IRegionSelections {
  const regionSelections: IRegionSelections = {
    selected: regionValue,
    prefSelections: regionTable.pref.map((x) => x.content),
    citySelections: regionTable.city.map((x) => x.content)
  }
  return regionSelections
}

function getPrefectureCode(name: string, regionTable: IRegionTable): number {
  return regionTable.pref.filter((x) => x.content === name)[0].id ?? 0
}

function getCityCode(name: string, regionTable: IRegionTable): number {
  return regionTable.city.filter((x) => x.content === name)[0].id ?? 0
}

export const ResasPage: React.FunctionComponent = () => {
  const inputId = useInputId()
  const regionTable = useRegionTableLines()
  const [selectedRegionKey, setSelectedRegionKey] = useState<IRegionKey>({
    prefCode: 11,
    cityCode: 11362
  })
  const [selectedRegionValue, setSelectedRegionValue] = useSelectedRegionState(
    regionTable,
    selectedRegionKey
  )
  const populationPerYearTrendLines =
    usePopulationPerYearTrendLines(selectedRegionValue)

  const regionSelections = getRegionSelections(selectedRegionValue, regionTable)

  const onChangePrefecture: InputProps['onChange'] = (ev, data) => {
    if (data.value.length <= 20) {
      const prefCode = Number(data.value)
      const updateRegionValue: IRegionValue = {
        prefCode: prefCode,
        prefName: '',
        cityCode: selectedRegionValue.cityCode,
        cityName: selectedRegionValue.cityName
      }
      //setSelectedRegionValue(updateRegionValue)
    }
  }

  const onChangeSelectedPrefecture: ComboboxProps['onOptionSelect'] = (
    ev,
    data
  ) => {
    const prefName = data.optionValue
    const updateRegionKey: IRegionKey = {
      prefCode: getPrefectureCode(prefName ?? '', regionTable),
      cityCode: selectedRegionValue.cityCode
    }
    setSelectedRegionKey(updateRegionKey)
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
      //setSelectedRegionValue(updateRegionValue)
    }
  }

  const onChangeSelectedCity: ComboboxProps['onOptionSelect'] = (ev, data) => {
    const cityName = data.optionValue
    const updateRegionKey: IRegionKey = {
      prefCode: selectedRegionValue.prefCode,
      cityCode: getCityCode(cityName ?? '', regionTable)
    }
    setSelectedRegionKey(updateRegionKey)
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
