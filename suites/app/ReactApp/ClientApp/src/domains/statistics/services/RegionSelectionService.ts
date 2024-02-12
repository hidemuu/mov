import { IRegionValue } from 'stores/resas/types/IRegionValue'
import { IRegionTable } from 'stores/resas/types/tables/IRegionTable'
import { IRegionSelections } from '../types/IRegionSelections'

export function getRegionSelections(
  regionValue: IRegionValue,
  regionTable: IRegionTable
): IRegionSelections {
  const regionSelections: IRegionSelections = {
    selected: regionValue,
    prefSelections: regionTable.pref.map((x) => x.content),
    citySelections: regionTable.city.map((x) => x.content)
  }
  return regionSelections
}
