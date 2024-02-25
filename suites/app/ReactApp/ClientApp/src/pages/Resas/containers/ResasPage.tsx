import React, { useEffect, useState } from 'react'
import type { ComboboxProps } from '@fluentui/react-components'
import usePopulationPerYearTrendLines from 'stores/resas/hooks/usePopulationPerYearTrends'
import useRegionTableLines from 'stores/resas/hooks/useRegionTable'
import { useInputId } from 'domains/inputs/hooks/useInputId'
import { IRegionKey } from 'stores/resas/types/IRegionKey'
import { ResasTemplate } from '..'
import {
  getCityCode,
  getPrefectureCode
} from 'stores/resas/services/regionTableService'
import { getRegionSelections } from 'domains/statistics/services/RegionSelectionService'
import { IRegionValue } from 'stores/resas/types/IRegionValue'
import { IRegionTrend } from 'stores/resas/types/trends/IRegionTrend'
import { IRegionSelections } from 'domains/statistics/types/IRegionSelections'
import useSelectedRegionValue from 'domains/statistics/hooks/useSelectedRegionValue'
import { RegionTableLineContext } from 'stores/resas/models/RegionTableLineContext'

export const ResasPage: React.FunctionComponent = () => {
  const inputId: string = useInputId()
  const regionTableContext = RegionTableLineContext.instance
  const [selectedRegionKey, setSelectedRegionKey] = useState<IRegionKey>({
    prefCode: 11,
    cityCode: 11362
  })
  const selectedRegionValue: IRegionValue = useSelectedRegionValue(
    regionTableContext.regionTable,
    selectedRegionKey
  )
  const populationPerYearTrendLines: IRegionTrend[] =
    usePopulationPerYearTrendLines(selectedRegionValue)

  const regionSelections: IRegionSelections = getRegionSelections(
    selectedRegionValue,
    regionTableContext.regionTable
  )

  useEffect(() => {
    console.log('初回実行')
  }, [])

  useEffect(() => {
    //レンダリング毎に実行
    console.log('再レンダリングされるたび実行')
  })

  const onChangeSelectedPrefecture: ComboboxProps['onOptionSelect'] = (
    ev,
    data
  ) => {
    const prefName = data.optionValue
    const updateRegionKey: IRegionKey = {
      prefCode: getPrefectureCode(
        prefName ?? '',
        regionTableContext.regionTable
      ),
      cityCode: selectedRegionValue.cityCode
    }
    setSelectedRegionKey(updateRegionKey)
  }

  const onChangeSelectedCity: ComboboxProps['onOptionSelect'] = (ev, data) => {
    const cityName = data.optionValue
    const updateRegionKey: IRegionKey = {
      prefCode: selectedRegionValue.prefCode,
      cityCode: getCityCode(cityName ?? '', regionTableContext.regionTable)
    }
    setSelectedRegionKey(updateRegionKey)
  }

  return (
    <ResasTemplate
      inputId={inputId}
      regionTable={regionTableContext.regionTable}
      regionTrendLines={populationPerYearTrendLines}
      selectedRegionKey={selectedRegionValue}
      regionSelections={regionSelections}
      onChangeSelectedPrefecture={onChangeSelectedPrefecture}
      onChangeSelectedCity={onChangeSelectedCity}
    ></ResasTemplate>
  )
}
