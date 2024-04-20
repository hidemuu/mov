import { useEffect, useState } from 'react'
import { getRegionValue } from 'stores/resas/services/regionTableService'
import { IRegionKey } from 'stores/resas/types/IRegionKey'
import { IRegionValue } from 'stores/resas/types/IRegionValue'
import { IRegionTable } from 'stores/resas/types/tables/IRegionTable'

export default function useSelectedRegionValue(
  regionTable: IRegionTable,
  regionKey: IRegionKey
): IRegionValue {
  const [selectedRegionValue, setSelectedRegionValue] = useState<IRegionValue>(
    getRegionValue(regionTable, regionKey)
  )

  useEffect(() => {
    const update = getRegionValue(regionTable, regionKey)
    setSelectedRegionValue(update)
  }, [regionKey])

  return selectedRegionValue
}
