import { Dispatch, SetStateAction } from "react";
import { AxiosResponse } from "axios";
import { writeLogs } from "utils/services/logger";
import { apiAdapter } from "./apiAdapter";

export function fetchData<T>(
  path: string,
  setStateAction: Dispatch<SetStateAction<T[]>>
) {
  console.log(path);
  apiAdapter
    .get(path)
    .then((response: AxiosResponse) => {
      const status = response.status;
      if (status === 200) {
        const data = response.data;
        const results: T[] = data.results;
        writeLogs(results);
        setStateAction(results);
      } else {
        throw new Error();
      }
    })
    .catch((error) => {
      console.error("--- fetch error " + path + "---");
      console.error(error);
      console.log("message:" + error.message + "\nstack:" + error.stack);
    });
}

export function get<T>(path: string): T[] {
  console.log(path);
  const asyncFunc = async () => {
    try {
      const response = await apiAdapter.get(path);
      const status = response.status;
      if (status === 200) {
        const data = response.data;
        const results: T[] = data.results;
        writeLogs(results);
        return results;
      } else {
        throw new Error();
      }
    } catch (error) {
      console.error("--- fetch error " + path + "---", error);
    }
  };
  return [];
}
