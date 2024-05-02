import React, { useEffect, useMemo, useState } from "react";
import type { ComboboxProps } from "@fluentui/react-components";
import { useInputId } from "domains/inputs/hooks/useInputId";
import { IRegionKey } from "stores/resas/types/keys/IRegionKey";
import { ResasTemplate } from "../templates";
import { useRegionTableContext } from "stores/resas/contexts/RegionTableContext";
import { useRegionTrendContext } from "stores/resas/contexts/RegionTrendContext";
import { RegionSelection } from "domains/selections/models/RegionSelection";

export const ResasPage: React.FunctionComponent = () => {
  const inputId: string = useInputId();
  const regionTrendStore = useRegionTrendContext();
  const regionTableStore = useRegionTableContext();
  const [regionKey, setRegionKey] = useState<IRegionKey>({
    prefCode: 11,
    cityCode: 11362,
  });
  const selection = new RegionSelection(regionKey, regionTableStore);

  useEffect(() => {
    //初回のみ実行
    console.log("初回実行");
  }, []);

  useEffect(() => {
    //レンダリング毎に実行
    console.log("再レンダリングされるたび実行");
  });

  useEffect(() => {
    //store更新時に実行
    const update = async () => {
      await regionTrendStore.updatePopulationPerYearsAsync(regionKey);
    };
    update();
  }, [regionKey]);

  const onChangeSelectedPrefecture: ComboboxProps["onOptionSelect"] = (
    ev,
    data
  ) => {
    const prefName = data.optionValue;
    const updateRegionKey: IRegionKey = {
      prefCode: regionTableStore.getPrefectureCode(prefName ?? ""),
      cityCode: selection.getSelectedValue().cityCode,
    };
    setRegionKey(updateRegionKey);
  };

  const onChangeSelectedCity: ComboboxProps["onOptionSelect"] = (ev, data) => {
    const cityName = data.optionValue;
    const updateRegionKey: IRegionKey = {
      prefCode: selection.getSelectedValue().prefCode,
      cityCode: regionTableStore.getCityCode(cityName ?? ""),
    };
    setRegionKey(updateRegionKey);
  };

  return (
    <ResasTemplate
      inputId={inputId}
      regionTable={regionTableStore.getTable()}
      regionTrendLines={regionTrendStore.getTrend()}
      regionSelections={selection.getSelections()}
      onChangeSelectedPrefecture={onChangeSelectedPrefecture}
      onChangeSelectedCity={onChangeSelectedCity}
    ></ResasTemplate>
  );
};
