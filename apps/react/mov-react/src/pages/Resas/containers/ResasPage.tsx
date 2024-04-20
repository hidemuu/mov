import React, { useEffect, useState } from "react";
import type { ComboboxProps } from "@fluentui/react-components";
import { useInputId } from "domains/inputs/hooks/useInputId";
import { IRegionKey } from "stores/resas/types/IRegionKey";
import { ResasTemplate } from "..";
import { useRegionTableContext } from "stores/resas/contexts/RegionTableContext";
import { useRegionTrendContext } from "stores/resas/contexts/RegionTrendContext";
import { RegionSelection } from "domains/selections/models/RegionSelection";

export const ResasPage: React.FunctionComponent = () => {
  const inputId: string = useInputId();
  const regionTrendStore = useRegionTrendContext();
  const regionTableStore = useRegionTableContext();
  const [selectedRegionKey, setSelectedRegionKey] = useState<IRegionKey>({
    prefCode: 11,
    cityCode: 11362,
  });

  const selection = new RegionSelection(regionTableStore);

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
      cityCode: selection.getSelectedValue(selectedRegionKey).cityCode,
    };
    setSelectedRegionKey(updateRegionKey);
    regionTrendStore.updatePopulationPerYears(
      selection.getSelectedValue(selectedRegionKey)
    );
  };

  const onChangeSelectedCity: ComboboxProps["onOptionSelect"] = (ev, data) => {
    const cityName = data.optionValue;
    const updateRegionKey: IRegionKey = {
      prefCode: selection.getSelectedValue(selectedRegionKey).prefCode,
      cityCode: regionTableStore.getCityCode(cityName ?? ""),
    };
    setSelectedRegionKey(updateRegionKey);
    regionTrendStore.updatePopulationPerYears(
      selection.getSelectedValue(selectedRegionKey)
    );
  };

  return (
    <ResasTemplate
      inputId={inputId}
      regionTable={regionTableStore.getTable()}
      regionTrendLines={regionTrendStore.getTrend()}
      selectedRegionKey={selection.getSelectedValue(selectedRegionKey)}
      regionSelections={selection.getSelections(selectedRegionKey)}
      onChangeSelectedPrefecture={onChangeSelectedPrefecture}
      onChangeSelectedCity={onChangeSelectedCity}
    ></ResasTemplate>
  );
};
