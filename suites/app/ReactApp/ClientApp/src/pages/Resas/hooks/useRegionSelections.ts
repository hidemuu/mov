import { useEffect, useState } from "react";
import { RegionSelections } from "../models/RegionSelections";
import { RegionTableLines } from "../models/RegionTableLines";
import { TableLine } from "../models/TableLine";


export default function useRegionSelections(regionValue: string, tableLines: TableLine[]) : RegionSelections {
    const [regionSelections, setRegionSelections] = useState<RegionSelections>({ selected : '', selections: [] });

    useEffect(() => {
        const contents = tableLines.map(x => x.content);
        const selected = regionValue === '' ? 
            contents.length === 0 ? 
                '' : contents[0] : 
            regionValue;
        setRegionSelections({ selected: selected, selections: contents })
    },[regionValue, tableLines])

    return regionSelections;
}