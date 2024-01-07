import React from 'react'
import {
  Input,
  Label,
  makeStyles,
  shorthands
} from '@fluentui/react-components'
import type { InputProps } from '@fluentui/react-components'
import { IRegionKey } from '../../stores/resas/types/IRegionKey'
import { RegionTab } from './contents/RegionTab'
import { TrendLineChart } from './contents/RegionTrendLineChart'
import { RegionComboBox } from './contents/RegionComboBox'
import { IRegionTable } from 'stores/resas/types/tables/IRegionTable'
import { IRegionTrend } from 'stores/resas/types/trends/IRegionTrend'

const useStyles = makeStyles({
  root: {
    alignItems: 'flex-start',
    display: 'flex',
    flexDirection: 'column',
    justifyContent: 'flex-start',
    ...shorthands.padding('50px', '20px'),
    rowGap: '20px'
  },
  grid: {
    ...shorthands.gap('16px'),
    display: 'flex',
    flexDirection: 'column'
  },
  combobox: {
    // Stack the label above the field with a gap
    display: 'grid',
    gridTemplateRows: 'repeat(1fr)',
    justifyItems: 'start',
    ...shorthands.gap('2px'),
    maxWidth: '400px'
  }
})

export type ResasTemplateProps = {
  inputId: string
  regionTable: IRegionTable
  regionTrendLines: IRegionTrend[]
  selectedRegionKey: IRegionKey
  onChangePrefecture: InputProps['onChange']
  onChangeCity: InputProps['onChange']
}

export const ResasTemplate = ({
  inputId,
  regionTable,
  regionTrendLines,
  selectedRegionKey,
  onChangePrefecture,
  onChangeCity
}: ResasTemplateProps) => {
  const styles = useStyles()

  return (
    <div className={styles.root}>
      <div>
        <Label htmlFor={inputId} style={{ paddingInlineEnd: '12px' }}>
          都道府県コード
        </Label>
        <Input
          id={inputId}
          value={String(selectedRegionKey.prefCode)}
          onChange={onChangePrefecture}
        />
        <RegionComboBox
          regionValue={selectedRegionKey}
          tableLines={regionTable}
        />
        <Label htmlFor={inputId} style={{ paddingInlineEnd: '12px' }}>
          都市コード
        </Label>
        <Input
          id={inputId}
          value={String(selectedRegionKey.cityCode)}
          onChange={onChangeCity}
        />
      </div>
      <h2>トレンドグラフ</h2>
      <TrendLineChart trendLines={regionTrendLines} />
      <RegionTab regionTableLines={regionTable} />
    </div>
  )
}
