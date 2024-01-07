import { Dispatch, SetStateAction, useState } from 'react'
import { IRegionValue } from '../../../stores/resas/types/IRegionValue'
import { IRegionTable } from '../../../stores/resas/types/tables/IRegionTable'
import { IRegionKeyCode } from '../../../stores/resas/types/IRegionKeyCode'

export default function useSelectedRegionState(
  regionTable: IRegionTable,
  regionCode: IRegionKeyCode
): [IRegionValue, Dispatch<SetStateAction<IRegionValue>>] {
  const [selectedRegionValue, setSelectedRegionValue] = useState<IRegionValue>({
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
