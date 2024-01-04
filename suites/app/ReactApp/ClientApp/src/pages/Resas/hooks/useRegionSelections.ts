import { useEffect, useState } from "react";
import { IRegionSelections } from "../types/IRegionSelections";
import { IRegionTableLines } from "../../../stores/resas/types/tables/IRegionTableLines";
import { IRegionKey } from "../../../stores/resas/types/IRegionKey";


export default function useRegionSelections(regionValue: IRegionKey, regionTableLines: IRegionTableLines) : IRegionSelections {
    const [regionSelections, setRegionSelections] = useState<IRegionSelections>({ selected : { prefCode:0, prefName:'', cityCode:0, cityName:'' }, prefSelections: [] , citySelections: [] });

    useEffect(() => {
        const prefs = regionTableLines.pref.map(x => x.content);
        const cities = regionTableLines.city.map(x => x.content);
        setRegionSelections({ selected: regionValue, prefSelections: prefs, citySelections: cities })
    },[regionValue, regionTableLines])

    return regionSelections;
}