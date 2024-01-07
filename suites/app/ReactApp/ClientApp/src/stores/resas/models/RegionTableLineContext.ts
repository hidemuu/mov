import React from 'react'
import axios from 'axios'
import { IRegionTable } from '../types/tables/IRegionTable'
import { ITableItem } from '../types/tables/ITableItem'

const API_KEY_PREFECTURE = 'api/TableLine/prefecture'
const API_KEY_CITY = 'api/TableLine/city'

export class RegionTableLineContext {
  private static current: RegionTableLineContext

  public static get instance(): RegionTableLineContext {
    if (!this.current) this.current = new RegionTableLineContext()
    return this.current
  }

  private constructor() {
    this.update()
  }

  private context: React.Context<IRegionTable | null> =
    React.createContext<IRegionTable | null>(null)
  private prefectureTableItems: ITableItem[] = []
  private cityTableItems: ITableItem[] = []

  public getContext(): React.Context<IRegionTable | null> {
    return this.context
  }

  private update() {
    axios
      .get(API_KEY_PREFECTURE, {})
      .then((results) => {
        this.prefectureTableItems = results.data
      })
      // eslint-disable-next-line @typescript-eslint/no-empty-function
      .catch((error) => {})
    axios
      .get(API_KEY_CITY, {})
      .then((results) => {
        this.cityTableItems = results.data
      })
      // eslint-disable-next-line @typescript-eslint/no-empty-function
      .catch((error) => {})

    const response: IRegionTable = {
      pref: this.prefectureTableItems,
      city: this.cityTableItems
    }

    this.context.Provider.bind(response)
  }
}
