import { useEffect, useState } from "react";
import { RegionSelections } from "../models/RegionSelections";
import { RegionTableLines } from "../models/RegionTableLines";
import { TableLine } from "../models/TableLine";
import { RegionValue } from "../models/RegionValue";


export default function useRegionSelections(regionValue: RegionValue, regionTableLines: RegionTableLines) : RegionSelections {
    const [regionSelections, setRegionSelections] = useState<RegionSelections>({ selected : { prefCode:0, prefName:'', cityCode:0, cityName:'' }, prefSelections: [] , citySelections: [] });

    useEffect(() => {
        const prefs = regionTableLines.pref.map(x => x.content);
        const cities = regionTableLines.city.map(x => x.content);
        setRegionSelections({ selected: regionValue, prefSelections: prefs, citySelections: cities })
    },[regionValue, regionTableLines])

    return regionSelections;
}