import React, { useState, useEffect } from 'react'
import Highcharts from 'highcharts'
import HighchartsReact from 'highcharts-react-official'
import styled from 'styled-components'
import axios from 'axios'
import {
  TableBody,
  TableCell,
  TableRow,
  Table,
  TableHeader,
  TableHeaderCell,
  TableCellLayout,
  PresenceBadgeStatus,
  Avatar,
  makeStyles,
  shorthands,
  Tab,
  TabList,
  useId,
  Input,
  Label,
  Combobox,
  Button,
  Option
} from '@fluentui/react-components'
import type {
  SelectTabData,
  SelectTabEvent,
  TabValue,
  InputProps,
  ButtonProps,
  ComboboxProps
} from '@fluentui/react-components'
import usePopulationPerYearTrendLines from '../../stores/resas/hooks/usePopulationPerYearTrendLines'
import useSelectedRegionState from './hooks/useSelectedRegionState'
import { IRegionKey } from '../../stores/resas/types/IRegionKey'
import { ITableColumn } from './types/ITableColumn'
import { useStyles } from './hooks/useStyles'
import useRegionTableLines from '../../stores/resas/hooks/useRegionTableLines'
import { useInputId } from '../../domains/inputs/hooks/useInputId'
import useHighChartTrendLines from './hooks/useHighChartTrendLines'
import useTableColumns from './hooks/useTableColumns'
import { RegionTable } from './RegionTable'
import { RegionTab } from './RegionTab'
import { TrendLineChart } from './TrendLineChart'
import { RegionComboBox } from './RegionComboBox'
import { IRegionCode } from './types/IRegionCode'

export const ResasPage: React.FunctionComponent = () => {
  const styles = useStyles()
  const inputId = useInputId()
  const regionTable = useRegionTableLines()
  const initRegionCode: IRegionCode = { pref: 11, city: 11362 }
  const [selectedRegionValue, setSelectedRegionValue] = useSelectedRegionState(
    regionTable,
    initRegionCode
  )
  const populationPerYearTrendLines =
    usePopulationPerYearTrendLines(selectedRegionValue)

  const onChangePrefecture: InputProps['onChange'] = (ev, data) => {
    if (data.value.length <= 20) {
      const prefCode = Number(data.value)
      const updateRegionValue: IRegionKey = {
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
      const updateRegionValue: IRegionKey = {
        prefCode: selectedRegionValue.prefCode,
        prefName: selectedRegionValue.prefName,
        cityCode: cityCode,
        cityName: ''
      }
      setSelectedRegionValue(updateRegionValue)
    }
  }

  const onClickApply = () => {}

  useEffect(() => {
    //レンダリング毎に実行
    console.log('再レンダリングされるたび実行')
  })

  return (
    <div className={styles.root}>
      <div>
        <Label htmlFor={inputId} style={{ paddingInlineEnd: '12px' }}>
          都道府県コード
        </Label>
        <Input
          id={inputId}
          value={String(selectedRegionValue.prefCode)}
          onChange={onChangePrefecture}
        />
        <RegionComboBox
          regionValue={selectedRegionValue}
          tableLines={regionTable}
        />
        <Label htmlFor={inputId} style={{ paddingInlineEnd: '12px' }}>
          都市コード
        </Label>
        <Input
          id={inputId}
          value={String(selectedRegionValue.cityCode)}
          onChange={onChangeCity}
        />
        <Button onClick={onClickApply}></Button>
      </div>
      <h2>トレンドグラフ</h2>
      <TrendLineChart trendLines={populationPerYearTrendLines} />
      <RegionTab regionTableLines={regionTable} />
    </div>
  )
}
