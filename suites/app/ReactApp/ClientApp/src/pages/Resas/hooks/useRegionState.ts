import React, { Dispatch, SetStateAction, useState } from 'react';
import { RegionValue } from '../models/RegionValue';

export default function useRegionState(initPrefectureCode: number, initCityCode: number) : [RegionValue, Dispatch<SetStateAction<RegionValue>>]{
    const [regionValue, setRegionValue] = useState<RegionValue>({
         prefNumber : initPrefectureCode,
         prefCode : '',  
         cityNumber : initCityCode,
         cityCode : '',
        });
    return [regionValue, setRegionValue];
}