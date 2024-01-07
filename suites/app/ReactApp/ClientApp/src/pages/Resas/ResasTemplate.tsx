import React, { useEffect } from 'react'
import { Input, Label } from '@fluentui/react-components'
import type { InputProps } from '@fluentui/react-components'
import { IRegionKey } from '../../stores/resas/types/IRegionKey'
import { useStyles } from './hooks/useStyles'
import { RegionTab } from './contents/RegionTab'
import { TrendLineChart } from './contents/TrendLineChart'
import { RegionComboBox } from './contents/RegionComboBox'
import { IRegionTableLines } from 'stores/resas/types/tables/IRegionTableLines'
import { IRegionTrendLines } from 'stores/resas/types/trends/IRegionTrendLines'

export type ResasTemplateProps = {
  inputId: string
  regionTable: IRegionTableLines
  regionTrendLines: IRegionTrendLines[]
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
