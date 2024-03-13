import React from 'react'
import axios from 'axios'
import { IRegionTable } from '../types/tables/IRegionTable'

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

  private context: React.Context<IRegionTable> =
    React.createContext<IRegionTable>({ pref: [], city: [] })

  public regionTable: IRegionTable = { pref: [], city: [] }

  public getContext(): React.Context<IRegionTable> {
    return this.context
  }

  private update() {
    axios
      .get(API_KEY_PREFECTURE, {})
      .then((results) => {
        this.regionTable.pref = results.data
      })
      .catch((error) => {
        console.log(error)
      })
    axios
      .get(API_KEY_CITY, {})
      .then((results) => {
        this.regionTable.city = results.data
      })
      .catch((error) => {
        console.log(error)
      })

    //this.context.Provider.bind(this.regionTable)
  }
}
