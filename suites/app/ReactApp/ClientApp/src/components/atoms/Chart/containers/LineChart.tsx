import React, { useState } from 'react'
import { Chart } from '../index'
import { ILineSeries } from '../types/ILineSeries'
import { ILineAxis } from '../types/ILineAxis'

type LineChartProps = {
  title: string
  series: ILineSeries
  xAxis: ILineAxis
  yAxis: ILineAxis
}

export const LineChart = (props: LineChartProps) => {
  const { title, series, xAxis, yAxis } = props

  const [chartOptions, setChartOptions] = useState<Highcharts.Options>({
    series: []
  })

  setChartOptions({
    title: {
      text: title
    },
    xAxis: {
      title: {
        text: xAxis.title
      },
      categories: xAxis.categories
    },
    yAxis: {
      title: {
        text: yAxis.title
      }
    },
    series: [{ type: 'line', name: series.name, data: series.data }]
  })

  return <Chart chartOptions={chartOptions} />
}
