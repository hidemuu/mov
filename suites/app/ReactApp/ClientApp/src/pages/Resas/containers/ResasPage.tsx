import React, { useEffect, useState } from 'react'
import type { ComboboxProps } from '@fluentui/react-components'
import usePopulationPerYearTrendLines from 'stores/resas/hooks/usePopulationPerYearTrends'
import { IRegionValue } from 'stores/resas/types/IRegionValue'
import useRegionTableLines from 'stores/resas/hooks/useRegionTable'
import { useInputId } from 'domains/inputs/hooks/useInputId'
import { IRegionKey } from 'stores/resas/types/IRegionKey'
import { ResasTemplate } from '..'
import { IRegionTable } from 'stores/resas/types/tables/IRegionTable'
import {
  getCityCode,
  getPrefectureCode,
  getRegionValue
} from 'stores/resas/services/regionTableService'
import { getRegionSelections } from 'domains/statistics/services/RegionSelectionService'

function useSelectedRegionValue(
  regionTable: IRegionTable,
  regionKey: IRegionKey
): IRegionValue {
  const [selectedRegionValue, setSelectedRegionValue] = useState<IRegionValue>(
    getRegionValue(regionTable, regionKey)
  )

  useEffect(() => {
    const update = getRegionValue(regionTable, regionKey)
    setSelectedRegionValue(update)
  }, [regionKey, regionTable])

  return selectedRegionValue
}

export const ResasPage: React.FunctionComponent = () => {
  const inputId = useInputId()
  const regionTable = useRegionTableLines()
  const [selectedRegionKey, setSelectedRegionKey] = useState<IRegionKey>({
    prefCode: 11,
    cityCode: 11362
  })
  const selectedRegionValue = useSelectedRegionValue(
    regionTable,
    selectedRegionKey
  )
  const populationPerYearTrendLines =
    usePopulationPerYearTrendLines(selectedRegionValue)

  const regionSelections = getRegionSelections(selectedRegionValue, regionTable)

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
      onChangeSelectedPrefecture={onChangeSelectedPrefecture}
      onChangeSelectedCity={onChangeSelectedCity}
    ></ResasTemplate>
  )
}
