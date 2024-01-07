import Highcharts from 'highcharts'
import HighchartsReact from 'highcharts-react-official'
import React, { FC } from 'react'
import useRegionTrendLineChart from 'domains/statistics/hooks/useRegionTrendLineChart'
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
  const option = useRegionTrendLineChart(trendLines)
  const chartOptions: Highcharts.Options = {
    title: {
      text: option.title
    },
    xAxis: {
      title: {
        text: option.xAxis.title
      },
      categories: option.xAxis.categories
    },
    yAxis: {
      title: {
        text: option.yAxis.title
      }
    },
    series:
      option.series.length === 0
        ? [{ type: 'line', name: '都道府県名', data: [] }]
        : [
            {
              type: 'line',
              name: option.series[0].name,
              data: option.series[0].data
            }
          ]
  }

  return (
    <div style={Styles.graph}>
      <HighchartsReact highcharts={Highcharts} options={chartOptions} />
    </div>
  )
}
