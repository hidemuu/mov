import { useState, useEffect } from 'react'
import axios from 'axios'
import { ITableItem } from '../types/tables/ITableItem'
import { IRegionTable } from '../types/tables/IRegionTable'

export default function useRegionTableLines(): IRegionTable {
  const API_KEY_PREFECTURE = 'api/TableLine/prefecture'
  const API_KEY_CITY = 'api/TableLine/city'
  const [prefectureTableLines, setPrefectureTableLines] = useState<
    ITableItem[]
  >([])
  const [cityTableLines, setCityTableLines] = useState<ITableItem[]>([])

  useEffect(() => {
    axios
      .get(API_KEY_PREFECTURE, {})
      .then((results) => {
        setPrefectureTableLines(results.data)
      })
      // eslint-disable-next-line @typescript-eslint/no-empty-function
      .catch((error) => {})
    axios
      .get(API_KEY_CITY, {})
      .then((results) => {
        setCityTableLines(results.data)
      })
      // eslint-disable-next-line @typescript-eslint/no-empty-function
      .catch((error) => {})
  }, [])

  const regionTable: IRegionTable = {
    pref: prefectureTableLines,
    city: cityTableLines
  }
  return regionTable
}
