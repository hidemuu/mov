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
  const targetPref = regionTable.pref.filter(
    (x) => x.id === regionKey.prefCode
  )[0]
  const targetCity = regionTable.city.filter(
    (x) => x.id === regionKey.cityCode
  )[0]
  if (targetPref === undefined || targetCity === undefined) {
    return {
      prefCode: regionKey.prefCode,
      prefName: '',
      cityCode: regionKey.cityCode,
      cityName: ''
    }
  }
  const updateCity =
    Number(targetCity.label) === targetPref.id
      ? targetCity
      : regionTable.city.filter((x) => Number(x.label) === targetPref.id)[0] ??
        targetCity
  const updateRegionValue: IRegionValue = {
    prefCode: targetPref.id,
    prefName: targetPref?.content ?? '',
    cityCode: updateCity.id,
    cityName: updateCity?.content ?? ''
  }
  return updateRegionValue
}
