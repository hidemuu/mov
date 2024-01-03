import React, { Dispatch, SetStateAction, useState } from 'react';
import { IRegionValue } from '../../../features/resas/types/IRegionValue';
import { IRegionTableLines } from '../../../features/resas/types/IRegionTableLines';
import { IRegionCode } from '../types/IRegionCode';

export default function useSelectedRegionState(regionTable : IRegionTableLines, regionCode: IRegionCode) 
    : [IRegionValue, Dispatch<SetStateAction<IRegionValue>>]
{
    const [selectedRegionValue, setSelectedRegionValue] = useState<IRegionValue>({
         prefCode : regionCode.pref,
         prefName : regionTable.pref.filter(x => x.id === regionCode.pref)[0]?.content ?? '',  
         cityCode : regionCode.city,
         cityName : regionTable.city.filter(x => x.id === regionCode.city)[0]?.content ?? '',
        });
    return [selectedRegionValue, setSelectedRegionValue];
}