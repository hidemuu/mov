import { ILineData } from "./ILineData";

export interface ILineSeries {
  name: string;
  data: ILineData[];
  color?: string;
  borderWdth?: number;
}
