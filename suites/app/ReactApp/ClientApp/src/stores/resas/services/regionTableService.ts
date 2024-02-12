import { IRegionKey } from '../types/IRegionKey'
import { IRegionValue } from '../types/IRegionValue'
import { IRegionTable } from '../types/tables/IRegionTable'

export function getPrefectureCode(
  name: string,
  regionTable: IRegionTable
): number {
  return regionTable.pref.filter((x) => x.content === name)[0].id ?? 0
}

export function getCityCode(name: string, regionTable: IRegionTable): number {
  return regionTable.city.filter((x) => x.content === name)[0].id ?? 0
}

export function getRegionValue(
  regionTable: IRegionTable,
  regionKey: IRegionKey
): IRegionValue {
  const updateRegionValue: IRegionValue = {
    prefCode: regionKey.prefCode,
    prefName:
      regionTable.pref.filter((x) => x.id === regionKey.prefCode)[0]?.content ??
      '',
    cityCode: regionKey.cityCode,
    cityName:
      regionTable.city.filter((x) => x.id === regionKey.cityCode)[0]?.content ??
      ''
  }
  return updateRegionValue
}
