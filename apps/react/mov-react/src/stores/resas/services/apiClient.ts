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
      setResponse<T>(response, setStateAction);
    })
    .catch((error) => {
      writeAssertLog(path, error);
    });
}

export async function getAsync<T>(
  path: string,
  setStateAction: Dispatch<SetStateAction<T[]>>
) {
  console.log(path);
  try {
    const response = await apiAdapter.get(path);
    setResponse<T>(response, setStateAction);
  } catch (error) {
    writeAssertLog(path, error);
  }
}

function setResponse<T>(
  response: AxiosResponse,
  setStateAction: Dispatch<SetStateAction<T[]>>
) {
  const status = response.status;
  if (status === 200) {
    const data = response.data;
    const results: T[] = data.results;
    writeLogs(results);
    setStateAction(results);
  } else {
    throw new Error();
  }
}

function writeAssertLog(path: string, error: any) {
  console.error("--- fetch error " + path + "---", error);
  console.log("message:" + error.message + "\nstack:" + error.stack);
}
