import { Dispatch, SetStateAction, useState } from 'react'
import { IRegionValue } from '../../../stores/resas/types/IRegionValue'
import { IRegionTable } from '../../../stores/resas/types/tables/IRegionTable'
import { IRegionKey } from '../../../stores/resas/types/IRegionKey'

export default function useSelectedRegionState(
  regionTable: IRegionTable,
  regionCode: IRegionKey
): [IRegionValue, Dispatch<SetStateAction<IRegionValue>>] {
  const [selectedRegionValue, setSelectedRegionValue] = useState<IRegionValue>({
    prefCode: regionCode.prefCode,
    prefName:
      regionTable.pref.filter((x) => x.id === regionCode.prefCode)[0]
        ?.content ?? '',
    cityCode: regionCode.cityCode,
    cityName:
      regionTable.city.filter((x) => x.id === regionCode.cityCode)[0]
        ?.content ?? ''
  })
  return [selectedRegionValue, setSelectedRegionValue]
}
