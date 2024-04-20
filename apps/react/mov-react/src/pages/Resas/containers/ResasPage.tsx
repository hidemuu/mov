import React, { useEffect, useState } from "react";
import type { ComboboxProps } from "@fluentui/react-components";
import { useInputId } from "domains/inputs/hooks/useInputId";
import { IRegionKey } from "stores/resas/types/IRegionKey";
import { ResasTemplate } from "..";
import { getRegionSelections } from "domains/statistics/services/RegionSelectionService";
import { IRegionValue } from "stores/resas/types/IRegionValue";
import { IRegionSelections } from "domains/statistics/types/IRegionSelections";
import useSelectedRegionValue from "domains/statistics/hooks/useSelectedRegionValue";
import { useRegionTableContext } from "stores/resas/contexts/RegionTableContext";
import { useRegionTrendContext } from "stores/resas/contexts/RegionTrendContext";

export const ResasPage: React.FunctionComponent = () => {
  const inputId: string = useInputId();
  const regionTrendStore = useRegionTrendContext();
  const regionTableStore = useRegionTableContext();
  const [selectedRegionKey, setSelectedRegionKey] = useState<IRegionKey>({
    prefCode: 11,
    cityCode: 11362,
  });
  const selectedRegionValue: IRegionValue = useSelectedRegionValue(
    regionTableStore.getTable(),
    selectedRegionKey
  );

  const regionSelections: IRegionSelections = getRegionSelections(
    selectedRegionValue,
    regionTableStore.getTable()
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
      prefCode: regionTableStore.getPrefectureCode(prefName ?? ""),
      cityCode: selectedRegionValue.cityCode,
    };
    setSelectedRegionKey(updateRegionKey);
    regionTrendStore.updatePopulationPerYears(selectedRegionValue);
  };

  const onChangeSelectedCity: ComboboxProps["onOptionSelect"] = (ev, data) => {
    const cityName = data.optionValue;
    const updateRegionKey: IRegionKey = {
      prefCode: selectedRegionValue.prefCode,
      cityCode: regionTableStore.getCityCode(cityName ?? ""),
    };
    setSelectedRegionKey(updateRegionKey);
    regionTrendStore.updatePopulationPerYears(selectedRegionValue);
  };

  return (
    <ResasTemplate
      inputId={inputId}
      regionTable={regionTableStore.getTable()}
      regionTrendLines={regionTrendStore.getTrend()}
      selectedRegionKey={selectedRegionValue}
      regionSelections={regionSelections}
      onChangeSelectedPrefecture={onChangeSelectedPrefecture}
      onChangeSelectedCity={onChangeSelectedCity}
    ></ResasTemplate>
  );
};
