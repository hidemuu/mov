import React, { useEffect, useState } from "react";
import type { ComboboxProps } from "@fluentui/react-components";
import { useInputId } from "domains/inputs/hooks/useInputId";
import { IRegionKey } from "stores/resas/types/keys/IRegionKey";
import { Resas } from "..";
import { useRegionTableContext } from "stores/resas/contexts/RegionTableContext";
import { useRegionTrendContext } from "stores/resas/contexts/RegionTrendContext";
import { RegionSelection } from "domains/selections/models/RegionSelection";

export const ResasPage: React.FunctionComponent = () => {
  const inputId: string = useInputId();
  const regionTrendStore = useRegionTrendContext();
  const regionTableStore = useRegionTableContext();
  const [latestSelectRegionKey, setlatestSelectRegionKey] = useState<IRegionKey>({
    prefCode: 11,
    cityCode: 11362,
  });
  const [selectedRegionKeys, setSelectedRegionKeys] = useState<IRegionKey[]>([]);
  const selection = new RegionSelection(
    latestSelectRegionKey,
    selectedRegionKeys,
    regionTableStore,
  );

  useEffect(() => {
    //初回のみ実行
    console.log("ResasPage - 初回実行");
    setlatestSelectRegionKey({ prefCode: 11, cityCode: 11362 });
  }, []);

  useEffect(() => {
    //レンダリング毎に実行
    console.log("ResasPage - 再レンダリングされるたび実行");
  });

  useEffect(() => {
    //store更新時に実行
    const update = async () => {
      await regionTrendStore.updatePopulationPerYearsAsync(latestSelectRegionKey);
    };
    update();
  }, [latestSelectRegionKey]);

  const onChangeSelectedPrefecture: ComboboxProps["onOptionSelect"] = (ev, data) => {
    const selectPrefName = data.optionValue;
    const updateSelectRegionKey: IRegionKey = {
      prefCode: regionTableStore.getPrefectureCode(selectPrefName ?? ""),
      cityCode: selection.getSelectedValue().cityCode,
    };
    setlatestSelectRegionKey(updateSelectRegionKey);
    const selectedPrefNames = data.selectedOptions;
    const updateSelectedRegionKeys: IRegionKey[] = [];
    for (const prefName of selectedPrefNames) {
      updateSelectedRegionKeys.push({
        prefCode: regionTableStore.getPrefectureCode(prefName ?? ""),
        cityCode: -1,
      });
    }
    setSelectedRegionKeys(updateSelectedRegionKeys);
  };

  const onChangeSelectedCity: ComboboxProps["onOptionSelect"] = (ev, data) => {
    const selectCityName = data.optionValue;
    const updateSelectRegionKey: IRegionKey = {
      prefCode: selection.getSelectedValue().prefCode,
      cityCode: regionTableStore.getCityCode(selectCityName ?? ""),
    };
    setlatestSelectRegionKey(updateSelectRegionKey);
    const selectedCityNames = data.selectedOptions;
    const updateSelectedRegionKeys: IRegionKey[] = [];
    for (const cityName of selectedCityNames) {
      updateSelectedRegionKeys.push({
        prefCode: -1,
        cityCode: regionTableStore.getCityCode(cityName ?? ""),
      });
    }
    setSelectedRegionKeys(updateSelectedRegionKeys);
  };

  return (
    <Resas
      inputId={inputId}
      regionTable={regionTableStore.getPrefCitiesTable(latestSelectRegionKey)}
      regionTrendLines={regionTrendStore.getTrend()}
      regionSelections={selection.getSelections()}
      onChangeSelectedPrefecture={onChangeSelectedPrefecture}
      onChangeSelectedCity={onChangeSelectedCity}
    ></Resas>
  );
};
