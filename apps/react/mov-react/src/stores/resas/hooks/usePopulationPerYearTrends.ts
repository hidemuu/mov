import { useState, useEffect } from "react";
import axios from "axios";
import { IRegionValue } from "../types/IRegionValue";
import { IRegionTrend } from "../types/trends/IRegionTrend";

export default function usePopulationPerYearTrends(
  region: IRegionValue
): IRegionTrend[] {
  const API_KEY = "api/analizers/regions/TrendLine/population_per_years";
  console.log(API_KEY + " " + region.prefCode + " " + region.cityCode);
  const [populationPerYears, setPopulationPerYears] = useState<IRegionTrend[]>(
    []
  );

  useEffect(() => {
    let endpoint: string;
    if (region.cityCode === 0 && region.prefCode === 0) {
      endpoint = "";
    } else if (region.cityCode === 0) {
      endpoint = API_KEY + "/" + String(region.prefCode);
    } else {
      endpoint =
        API_KEY + "/" + String(region.prefCode) + "/" + String(region.cityCode);
    }

    if (endpoint !== "") {
      axios
        .get(endpoint)
        .then((results) => {
          const regionTrendLines: IRegionTrend[] = [];
          for (const data of results.data) {
            const regionTrendLine: IRegionTrend = {
              region: {
                cityCode: data.region.cityCode,
                cityName: data.region.cityName,
                prefCode: data.region.prefCode,
                prefName: data.region.prefName,
              },
              trendLines: data.data,
            };
            regionTrendLines.push(regionTrendLine);
          }
          setPopulationPerYears(regionTrendLines);
        })
        .catch((error) => {
          console.log(error);
        });
    }
  }, [region]);
  return populationPerYears;
}
