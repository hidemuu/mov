import { useEffect, useState } from "react";
import { IRegionSelections } from "../types/IRegionSelections";
import { IRegionTableLines } from "../../../features/resas/types/IRegionTableLines";
import { IRegionValue } from "../../../features/resas/types/IRegionValue";


export default function useRegionSelections(regionValue: IRegionValue, regionTableLines: IRegionTableLines) : IRegionSelections {
    const [regionSelections, setRegionSelections] = useState<IRegionSelections>({ selected : { prefCode:0, prefName:'', cityCode:0, cityName:'' }, prefSelections: [] , citySelections: [] });

    useEffect(() => {
        const prefs = regionTableLines.pref.map(x => x.content);
        const cities = regionTableLines.city.map(x => x.content);
        setRegionSelections({ selected: regionValue, prefSelections: prefs, citySelections: cities })
    },[regionValue, regionTableLines])

    return regionSelections;
}