import { Dispatch, SetStateAction, useState } from 'react'
import { IRegionKey } from '../../../stores/resas/types/IRegionKey'
import { IRegionTable } from '../../../stores/resas/types/tables/IRegionTable'
import { IRegionKeyCode } from '../../../stores/resas/types/IRegionKeyCode'

export default function useSelectedRegionState(
  regionTable: IRegionTable,
  regionCode: IRegionKeyCode
): [IRegionKey, Dispatch<SetStateAction<IRegionKey>>] {
  const [selectedRegionValue, setSelectedRegionValue] = useState<IRegionKey>({
    prefCode: regionCode.pref,
    prefName:
      regionTable.pref.filter((x) => x.id === regionCode.pref)[0]?.content ??
      '',
    cityCode: regionCode.city,
    cityName:
      regionTable.city.filter((x) => x.id === regionCode.city)[0]?.content ?? ''
  })
  return [selectedRegionValue, setSelectedRegionValue]
}
