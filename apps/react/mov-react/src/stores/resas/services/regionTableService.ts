import { IRegionKey } from "../types/IRegionKey";
import { IRegionValue } from "../types/IRegionValue";
import { IRegionTable } from "../types/tables/IRegionTable";
import { ITableItem } from "../types/tables/ITableItem";

export function getPrefCities(
  prefCode: number,
  regionTable: IRegionTable
): ITableItem[] {
  return regionTable.city.filter((x) => Number(x.label) === prefCode);
}

export function getRegionValue(
  regionTable: IRegionTable,
  regionKey: IRegionKey
): IRegionValue {
  const targetPref = regionTable.pref.filter(
    (x) => x.id === regionKey.prefCode
  )[0];
  const targetCity = regionTable.city.filter(
    (x) => x.id === regionKey.cityCode
  )[0];
  if (targetPref === undefined || targetCity === undefined) {
    return {
      prefCode: regionKey.prefCode,
      prefName: "",
      cityCode: regionKey.cityCode,
      cityName: "",
    };
  }
  const updateCity =
    Number(targetCity.label) === targetPref.id
      ? targetCity
      : getPrefCities(targetPref.id, regionTable)[0] ?? targetCity;
  const updateRegionValue: IRegionValue = {
    prefCode: targetPref.id,
    prefName: targetPref?.content ?? "",
    cityCode: updateCity.id,
    cityName: updateCity?.content ?? "",
  };
  return updateRegionValue;
}
