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

  const defaultSelectRegionKey: IRegionKey = { prefCode: 11, cityCode: 11362 };
  const [latestSelectRegionKey, setlatestSelectRegionKey] =
    useState<IRegionKey>(defaultSelectRegionKey);
  const [selectedRegionKeys, setSelectedRegionKeys] = useState<IRegionKey[]>([
    defaultSelectRegionKey,
  ]);
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
      if (selectedRegionKeys.length > 0) {
        await regionTrendStore.updateMultiPopulationPerYearsAsync(selectedRegionKeys);
      } else {
        await regionTrendStore.updatePopulationPerYearsAsync(latestSelectRegionKey);
      }
    };
    update();
    console.log("ResasPage - Store更新されるたび実行");
  }, [latestSelectRegionKey]);

  const onChangeSelectedPrefecture: ComboboxProps["onOptionSelect"] = (ev, data) => {
    const selectPrefName = data.optionValue;
    const updateSelectRegionKey: IRegionKey = {
      prefCode: regionTableStore.getPrefectureCode(selectPrefName ?? ""),
      cityCode: selection.getLatestSelectKeyValue().cityCode,
    };
    setlatestSelectRegionKey(updateSelectRegionKey);

    const selectedPrefNames = data.selectedOptions;
    const updateSelectedRegionKeys: IRegionKey[] = [];
    for (const prefName of selectedPrefNames) {
      const updatePrefCode = regionTableStore.getPrefectureCode(prefName ?? "");
      if (selectedRegionKeys.filter((x) => x.prefCode === updatePrefCode)) {
        continue;
      }
      updateSelectedRegionKeys.push(regionTableStore.getDefaultPrefKeyValue(updatePrefCode));
    }
    setSelectedRegionKeys(updateSelectedRegionKeys);
  };

  const onChangeSelectedCity: ComboboxProps["onOptionSelect"] = (ev, data) => {
    const selectCityName = data.optionValue;
    const updateSelectRegionKey: IRegionKey = {
      prefCode: selection.getLatestSelectKeyValue().prefCode,
      cityCode: regionTableStore.getCityCode(selectCityName ?? ""),
    };
    setlatestSelectRegionKey(updateSelectRegionKey);

    const selectedCityNames = data.selectedOptions;
    const updateSelectedRegionKeys: IRegionKey[] = [];
    const latestPrefCode = latestSelectRegionKey.prefCode;
    for (const cityName of selectedCityNames) {
      const updateCityCode = regionTableStore.getCityCode(cityName ?? "");
      if (
        updateSelectedRegionKeys.filter(
          (x) => x.prefCode === latestPrefCode && x.cityCode === updateCityCode,
        ).length > 0
      ) {
        continue;
      }
      updateSelectedRegionKeys.push({
        prefCode: latestPrefCode,
        cityCode: updateCityCode,
      });
    }
    for (const selectedRegionKey of selectedRegionKeys) {
      if (selectedRegionKey.prefCode !== latestPrefCode) {
        updateSelectedRegionKeys.push(selectedRegionKey);
      }
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
