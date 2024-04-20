import { IRegionValue } from 'stores/resas/types/IRegionValue'
import { IRegionTable } from 'stores/resas/types/tables/IRegionTable'
import { IRegionSelections } from '../types/IRegionSelections'
import { getPrefCities } from 'stores/resas/services/regionTableService'

export function getRegionSelections(
  regionValue: IRegionValue,
  regionTable: IRegionTable
): IRegionSelections {
  const prefCities = getPrefCities(regionValue.prefCode, regionTable)
  const regionSelections: IRegionSelections = {
    selected: regionValue,
    prefSelections: regionTable.pref.map((x) => x.content),
    citySelections: prefCities.map((x) => x.content)
  }
  return regionSelections
}
