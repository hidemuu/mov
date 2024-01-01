import React, { Dispatch, SetStateAction, useState } from 'react';
import { RegionValue } from '../../../models/RegionValue';
import { RegionTableLines } from '../../../models/RegionTableLines';

export default function useSelectedRegionState(regionTable : RegionTableLines, initPrefectureCode: number, initCityCode: number) 
    : [RegionValue, Dispatch<SetStateAction<RegionValue>>]
{
    const [selectedRegionValue, setSelectedRegionValue] = useState<RegionValue>({
         prefCode : initPrefectureCode,
         prefName : regionTable.pref.filter(x => x.id === initPrefectureCode)[0]?.content ?? '',  
         cityCode : initCityCode,
         cityName : regionTable.city.filter(x => x.id === initCityCode)[0]?.content ?? '',
        });
    return [selectedRegionValue, setSelectedRegionValue];
}