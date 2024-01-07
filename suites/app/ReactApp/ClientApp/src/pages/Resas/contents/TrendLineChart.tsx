import Highcharts from 'highcharts'
import HighchartsReact from 'highcharts-react-official'
import React, { FC } from 'react'
import useHighChartTrendLines from '../hooks/useHighChartTrendLines'
import { IRegionTrendLines } from '../../../stores/resas/types/trends/IRegionTrendLines'

const Styles: { [key: string]: React.CSSProperties } = {
  graph: {
    padding: '12px'
  }
}

export declare type TrendLineChartProps = {
  trendLines: IRegionTrendLines[]
}

export const TrendLineChart: FC<TrendLineChartProps> = ({ trendLines }) => {
  const chartOptions = useHighChartTrendLines(trendLines)
  return (
    <div style={Styles.graph}>
      <HighchartsReact highcharts={Highcharts} options={chartOptions} />
    </div>
  )
}
