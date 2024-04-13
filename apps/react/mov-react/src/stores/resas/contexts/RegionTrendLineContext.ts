import React from 'react'
import { IRegionTrend } from '../types/trends/IRegionTrend'

export class RegionTrendLineContext {
  private static current: RegionTrendLineContext

  public static get instance(): RegionTrendLineContext {
    if (!this.current) this.current = new RegionTrendLineContext()
    return this.current
  }

  // eslint-disable-next-line @typescript-eslint/no-empty-function
  private constructor() {}

  private context = React.createContext<IRegionTrend[] | null>(null)

  getContext(): React.Context<IRegionTrend[] | null> {
    return this.context
  }
}
