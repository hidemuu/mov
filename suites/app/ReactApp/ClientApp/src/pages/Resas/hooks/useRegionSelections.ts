import { useEffect, useState } from "react";
import { RegionSelections } from "../models/RegionSelections";
import { RegionTableLines } from "../models/RegionTableLines";
import { TableLine } from "../models/TableLine";


export default function useRegionSelections(tableLines: TableLine[]) : RegionSelections {
    const [regionSelections, setRegionSelections] = useState<RegionSelections>({ selected : '', selections: [] });

    useEffect(() => {
        const contents = tableLines.map(x => x.content);
        const selected = contents.length === 0 ? '' : contents[0];
        setRegionSelections({ selected: selected, selections: contents })
    },[tableLines])

    return regionSelections;
}