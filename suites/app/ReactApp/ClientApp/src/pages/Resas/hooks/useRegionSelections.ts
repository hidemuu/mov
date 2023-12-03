import { useState } from "react";
import { RegionSelections } from "../models/RegionSelections";
import { RegionTableLines } from "../models/RegionTableLines";


export default function useRegionSelections(regionTableLines: RegionTableLines) : RegionSelections {
    const [regionSelections, setRegionSelections] = useState<RegionSelections>({ selected : '', selections: [] });

    return regionSelections;
}