import { RegionValue } from "../../../features/resas/models/RegionValue";

export interface RegionSelections {
    selected: RegionValue;
    prefSelections: string[];
    citySelections: string[];
}