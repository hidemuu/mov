import React from 'react'
import { Chart } from '../index'
import { ILineChartOption } from '../types/ILineChartOption'

type LineChartProps = {
  option: ILineChartOption
}

export const LineChart = (props: LineChartProps) => {
  const { option } = props

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
        ? [{ type: 'line', name: '', data: [] }]
        : option.series.map((x) => ({
            type: 'line',
            name: x.name,
            data: x.data
          }))
  }

  return <Chart chartOptions={chartOptions} />
}
