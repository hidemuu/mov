import Highcharts from 'highcharts'
import HighchartsReact from 'highcharts-react-official'
import React, { FC } from 'react'
import useHighChartTrendLines from 'domains/statistics/hooks/useHighChartTrendLines'
import { IRegionTrend } from 'stores/resas/types/trends/IRegionTrend'

const Styles: { [key: string]: React.CSSProperties } = {
  graph: {
    padding: '12px'
  }
}

export declare type TrendLineChartProps = {
  trendLines: IRegionTrend[]
}

export const TrendLineChart: FC<TrendLineChartProps> = ({ trendLines }) => {
  const chartOptions = useHighChartTrendLines(trendLines)
  return (
    <div style={Styles.graph}>
      <HighchartsReact highcharts={Highcharts} options={chartOptions} />
    </div>
  )
}
