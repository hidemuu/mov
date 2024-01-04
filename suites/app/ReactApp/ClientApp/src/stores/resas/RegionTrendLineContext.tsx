import React , { useContext } from 'react'
import { IRegionTrendLines } from './types/trends/IRegionTrendLines'

export const RegionTrendLineContext = React.createContext<IRegionTrendLines[] | null>(null)