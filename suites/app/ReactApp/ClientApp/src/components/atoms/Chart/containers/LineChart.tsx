import React, { useState } from 'react'
import { Chart } from '../index'
import { ILineChartOption } from '../types/ILineChartOption'

type LineChartProps = {
  option: ILineChartOption
}

export const LineChart = (props: LineChartProps) => {
  const { option } = props

  const [chartOptions, setChartOptions] = useState<Highcharts.Options>({
    series: []
  })

  setChartOptions({
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
    series: [
      { type: 'line', name: option.series.name, data: option.series.data }
    ]
  })

  return <Chart chartOptions={chartOptions} />
}
