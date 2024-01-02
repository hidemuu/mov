import React, { Dispatch, SetStateAction, useState } from 'react';
import { RegionValue } from '../../../features/resas/models/RegionValue';
import { RegionTableLines } from '../../../features/resas/models/RegionTableLines';
import { RegionCode } from '../models/RegionCode';

export default function useSelectedRegionState(regionTable : RegionTableLines, regionCode: RegionCode) 
    : [RegionValue, Dispatch<SetStateAction<RegionValue>>]
{
    const [selectedRegionValue, setSelectedRegionValue] = useState<RegionValue>({
         prefCode : regionCode.pref,
         prefName : regionTable.pref.filter(x => x.id === regionCode.pref)[0]?.content ?? '',  
         cityCode : regionCode.city,
         cityName : regionTable.city.filter(x => x.id === regionCode.city)[0]?.content ?? '',
        });
    return [selectedRegionValue, setSelectedRegionValue];
}