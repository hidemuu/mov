import { useState, useEffect } from 'react'
import axios from 'axios'
import { IRegionKey } from '../types/IRegionKey'
import { IRegionTrend } from '../types/trends/IRegionTrend'

export default function usePopulationPerYearTrendLines(
  region: IRegionKey
): IRegionTrend[] {
  const API_KEY = 'api/TrendLine/population_per_years'
  const prefectureCode = region.prefCode
  const cityCode = region.cityCode
  console.log(API_KEY + ' ' + prefectureCode + ' ' + cityCode)
  const [populationPerYears, setPopulationPerYears] = useState<IRegionTrend[]>(
    []
  )

  useEffect(() => {
    let endpoint: string
    if (cityCode === 0 && prefectureCode === 0) {
      endpoint = ''
    } else if (cityCode === 0) {
      endpoint = API_KEY + '/' + String(prefectureCode)
    } else {
      endpoint = API_KEY + '/' + String(prefectureCode) + '/' + String(cityCode)
    }

    if (endpoint !== '') {
      axios
        .get(endpoint)
        .then((results) => {
          const regionTrendLines: IRegionTrend[] = []
          for (const data of results.data) {
            const regionTrendLine: IRegionTrend = {
              region: {
                cityCode: data.region.cityCode,
                cityName: data.region.cityName,
                prefCode: data.region.prefCode,
                prefName: data.region.prefName
              },
              trendLines: data.data
            }
            regionTrendLines.push(regionTrendLine)
          }
          setPopulationPerYears(regionTrendLines)
        })
        // eslint-disable-next-line @typescript-eslint/no-empty-function
        .catch((error) => {})
    }
  }, [cityCode, prefectureCode, region])
  return populationPerYears
}
