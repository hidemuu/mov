import { ILineAxis } from "./ILineAxis";
import { ILineSeries } from "./ILineSeries";

export interface ILineChartOption {
  title: string;
  series: ILineSeries[];
  xAxis: ILineAxis;
  yAxis: ILineAxis;
}
