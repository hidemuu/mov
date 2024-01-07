import { useEffect, useState } from 'react'
import { IRegionSelections } from '../types/IRegionSelections'
import { IRegionTable } from '../../../stores/resas/types/tables/IRegionTable'
import { IRegionValue } from '../../../stores/resas/types/IRegionValue'

export default function useRegionSelections(
  regionValue: IRegionValue,
  regionTableLines: IRegionTable
): IRegionSelections {
  const [regionSelections, setRegionSelections] = useState<IRegionSelections>({
    selected: { prefCode: 0, prefName: '', cityCode: 0, cityName: '' },
    prefSelections: [],
    citySelections: []
  })

  useEffect(() => {
    const prefs = regionTableLines.pref.map((x) => x.content)
    const cities = regionTableLines.city.map((x) => x.content)
    setRegionSelections({
      selected: regionValue,
      prefSelections: prefs,
      citySelections: cities
    })
  }, [regionValue, regionTableLines])

  return regionSelections
}
