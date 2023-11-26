import React, { Dispatch, SetStateAction, useState } from 'react';
import { RegionValue } from '../models/RegionValue';

export default function useRegionState(initPrefectureCode: string, initCityCode: string) : [RegionValue, Dispatch<SetStateAction<RegionValue>>]{
    const [regionValue, setRegionValue] = useState<RegionValue>({
         pref : initPrefectureCode,  
         city : initCityCode
        });
    return [regionValue, setRegionValue];
}