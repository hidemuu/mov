import React from 'react'
import {
  Input,
  Label,
  makeStyles,
  shorthands
} from '@fluentui/react-components'
import type { ComboboxProps } from '@fluentui/react-components'
import { IRegionValue } from '../../stores/resas/types/IRegionValue'
import { RegionTab } from './templates/RegionTab'
import { TrendLineChart } from './templates/RegionTrendLineChart'
import { PrefComboBox } from './templates/PrefComboBox'
import { IRegionTable } from 'stores/resas/types/tables/IRegionTable'
import { IRegionTrend } from 'stores/resas/types/trends/IRegionTrend'
import { IRegionSelections } from '../../domains/statistics/types/IRegionSelections'
import { CityComboBox } from './templates/CityComboBox'

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
  selectedRegionKey: IRegionValue
  regionSelections: IRegionSelections
  onChangeSelectedPrefecture: ComboboxProps['onOptionSelect']
  onChangeSelectedCity: ComboboxProps['onOptionSelect']
}

export const ResasTemplate = ({
  inputId,
  regionTable,
  regionTrendLines,
  selectedRegionKey,
  regionSelections,
  onChangeSelectedPrefecture,
  onChangeSelectedCity
}: ResasTemplateProps) => {
  const styles = useStyles()

  return (
    <div className={styles.root}>
      <div>
        <Label htmlFor={inputId} style={{ paddingInlineEnd: '12px' }}>
          都道府県コード
        </Label>
        <PrefComboBox
          regionSelections={regionSelections}
          onOptionSelect={onChangeSelectedPrefecture}
        />
        <br />
        <Label htmlFor={inputId} style={{ paddingInlineEnd: '12px' }}>
          都市コード
        </Label>
        <CityComboBox
          regionSelections={regionSelections}
          onOptionSelect={onChangeSelectedCity}
        />
      </div>
      <h2>トレンドグラフ</h2>
      <TrendLineChart trendLines={regionTrendLines} />
      <RegionTab regionTableLines={regionTable} />
    </div>
  )
}
