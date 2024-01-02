import { RegionValue } from "../../../features/models/RegionValue";

export interface RegionSelections {
    selected: RegionValue;
    prefSelections: string[];
    citySelections: string[];
}