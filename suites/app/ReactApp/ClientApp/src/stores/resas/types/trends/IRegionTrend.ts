import { IRegionKey } from '../IRegionKey'
import { ITrendItem } from './ITrendItem'

export interface IRegionTrend {
  region: IRegionKey
  trendLines: ITrendItem[]
}
