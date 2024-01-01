import React, { Dispatch, SetStateAction, useState } from 'react';
import { RegionValue } from '../../../models/RegionValue';

export default function useSelectedRegionState(initPrefectureCode: number, initCityCode: number) : [RegionValue, Dispatch<SetStateAction<RegionValue>>]{
    const [selectedRegionValue, setSelectedRegionValue] = useState<RegionValue>({
         prefCode : initPrefectureCode,
         prefName : '',  
         cityCode : initCityCode,
         cityName : '',
        });
    return [selectedRegionValue, setSelectedRegionValue];
}