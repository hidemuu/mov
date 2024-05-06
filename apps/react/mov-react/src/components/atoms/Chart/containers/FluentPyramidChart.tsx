import React from "react";
import {
  DataVizPalette,
  HorizontalBarChart,
  IChartProps,
  getColorFromToken,
} from "@fluentui/react-charting";

const FluentPyramidChart = () => {
  const malePopulation = [
    { age: "0-4", population: 1000 },
    { age: "5-9", population: 1500 },
    // 他の年齢層のデータも続く...
  ];

  const femalePopulation = [
    { age: "0-4", population: 1200 },
    { age: "5-9", population: 1400 },
    // 他の年齢層のデータも続く...
  ];

  const data: IChartProps[] = [
    {
      chartTitle: "male",
      chartData: malePopulation.map((item) => ({
        legend: "male",
        horizontalBarChartdata: { x: item.population, y: 15000 },
        color: getColorFromToken(DataVizPalette.color1),
        xAxisCalloutData: item.age,
        yAxisCalloutData: "10%",
      })),
    },
    {
      chartTitle: "female",
      chartData: femalePopulation.map((item) => ({
        legend: "female",
        horizontalBarChartdata: { x: item.population, y: 15000 },
        color: getColorFromToken(DataVizPalette.color2),
        xAxisCalloutData: item.age,
        yAxisCalloutData: "10%",
      })),
    },
  ];

  return <HorizontalBarChart data={data} />;
};

export default FluentPyramidChart;
