import React from 'react'
import { IRegionTrendLines } from '../types/trends/IRegionTrends'

export class RegionTrendLineContext {
  private static current: RegionTrendLineContext

  public static get instance(): RegionTrendLineContext {
    if (!this.current) this.current = new RegionTrendLineContext()
    return this.current
  }

  // eslint-disable-next-line @typescript-eslint/no-empty-function
  private constructor() {}

  private context = React.createContext<IRegionTrendLines[] | null>(null)

  getContext(): React.Context<IRegionTrendLines[] | null> {
    return this.context
  }

  useContext(): IRegionTrendLines[] | null {
    return React.useContext(this.context)
  }
}