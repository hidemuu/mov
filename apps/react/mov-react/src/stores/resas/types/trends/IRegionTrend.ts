import { IRegionValue } from '../IRegionValue'
import { ITrendItem } from './ITrendItem'

export interface IRegionTrend {
  region: IRegionValue
  trendLines: ITrendItem[]
}
