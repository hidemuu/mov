import { useEffect, useState } from 'react'
import Highcharts from 'highcharts'
import { IRegionTrendLines } from 'stores/resas/types/trends/IRegionTrendLines'

export default function useHighChartTrendLines(
  regionTrendLines: IRegionTrendLines[]
): Highcharts.Options {
  const [chartOptions, setChartOptions] = useState<Highcharts.Options>({
    series: []
  })

  useEffect(() => {
    const series: Highcharts.SeriesOptionsType[] = []
    const categories = []
    let count = 0
    for (const regionTrendLine of regionTrendLines) {
      const data = []
      for (const trendLine of regionTrendLine.trendLines) {
        if (count === 0) {
          categories.push(String(trendLine.number))
        }
        data.push(trendLine.value)
      }
      const prefName = regionTrendLine.region.prefName
      const cityName = regionTrendLine.region.cityName
      series.push({
        type: 'line',
        name: prefName + '-' + cityName,
        data: data
      })
      count++
    }

    setChartOptions({
      title: {
        text: '総人口推移'
      },
      xAxis: {
        title: {
          text: '年度'
        },
        categories: categories
      },
      yAxis: {
        title: {
          text: '人口数'
        }
      },
      // 都道府県を一つも選んでいない場合との分岐条件
      series:
        series.length === 0
          ? [{ type: 'line', name: '都道府県名', data: [] }]
          : series
    })
  }, [regionTrendLines])

  return chartOptions
}
