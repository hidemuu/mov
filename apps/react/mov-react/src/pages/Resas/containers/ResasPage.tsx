import React, { useEffect, useState } from "react";
import type { ComboboxProps } from "@fluentui/react-components";
import usePopulationPerYearTrendLines from "stores/resas/hooks/usePopulationPerYearTrends";
import { useInputId } from "domains/inputs/hooks/useInputId";
import { IRegionKey } from "stores/resas/types/IRegionKey";
import { ResasTemplate } from "..";
import { getRegionSelections } from "domains/statistics/services/RegionSelectionService";
import { IRegionValue } from "stores/resas/types/IRegionValue";
import { IRegionTrend } from "stores/resas/types/trends/IRegionTrend";
import { IRegionSelections } from "domains/statistics/types/IRegionSelections";
import useSelectedRegionValue from "domains/statistics/hooks/useSelectedRegionValue";
import { useRegionTableContext } from "stores/resas/contexts/RegionTableLineContext";
import { RegionTableLine } from "stores/resas/models/RegionTableLine";

export const ResasPage: React.FunctionComponent = () => {
  const inputId: string = useInputId();
  const regionTableContext = useRegionTableContext();
  const regionTableLine: RegionTableLine = new RegionTableLine(
    regionTableContext
  );
  const [selectedRegionKey, setSelectedRegionKey] = useState<IRegionKey>({
    prefCode: 11,
    cityCode: 11362,
  });
  const selectedRegionValue: IRegionValue = useSelectedRegionValue(
    regionTableLine.getTable(),
    selectedRegionKey
  );
  const populationPerYearTrendLines: IRegionTrend[] =
    usePopulationPerYearTrendLines(selectedRegionValue);

  const regionSelections: IRegionSelections = getRegionSelections(
    selectedRegionValue,
    regionTableLine.getTable()
  );

  useEffect(() => {
    console.log("初回実行");
  }, []);

  useEffect(() => {
    //レンダリング毎に実行
    console.log("再レンダリングされるたび実行");
  });

  const onChangeSelectedPrefecture: ComboboxProps["onOptionSelect"] = (
    ev,
    data
  ) => {
    const prefName = data.optionValue;
    const updateRegionKey: IRegionKey = {
      prefCode: regionTableLine.getPrefectureCode(prefName ?? ""),
      cityCode: selectedRegionValue.cityCode,
    };
    setSelectedRegionKey(updateRegionKey);
  };

  const onChangeSelectedCity: ComboboxProps["onOptionSelect"] = (ev, data) => {
    const cityName = data.optionValue;
    const updateRegionKey: IRegionKey = {
      prefCode: selectedRegionValue.prefCode,
      cityCode: regionTableLine.getCityCode(cityName ?? ""),
    };
    setSelectedRegionKey(updateRegionKey);
  };

  return (
    <ResasTemplate
      inputId={inputId}
      regionTable={regionTableLine.getTable()}
      regionTrendLines={populationPerYearTrendLines}
      selectedRegionKey={selectedRegionValue}
      regionSelections={regionSelections}
      onChangeSelectedPrefecture={onChangeSelectedPrefecture}
      onChangeSelectedCity={onChangeSelectedCity}
    ></ResasTemplate>
  );
};
