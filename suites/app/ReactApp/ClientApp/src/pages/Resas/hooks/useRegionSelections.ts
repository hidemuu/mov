import { useEffect, useState } from "react";
import { RegionSelections } from "../models/RegionSelections";
import { RegionTableLines } from "../models/RegionTableLines";
import { TableLine } from "../models/TableLine";
import { RegionValue } from "../models/RegionValue";


export default function useRegionSelections(regionValue: RegionValue, regionTableLines: RegionTableLines) : RegionSelections {
    const [regionSelections, setRegionSelections] = useState<RegionSelections>({ selected : { pref:0, prefCode:'', city:0, cityCode:'' }, prefSelections: [] , citySelections: [] });

    useEffect(() => {
        const prefs = regionTableLines.pref.map(x => x.content);
        const cities = regionTableLines.city.map(x => x.content);
        setRegionSelections({ selected: regionValue, prefSelections: prefs, citySelections: cities })
    },[regionValue, regionTableLines])

    return regionSelections;
}