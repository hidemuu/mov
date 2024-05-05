import { Dispatch, SetStateAction } from "react";
import { AxiosResponse } from "axios";
import { writeLogs } from "utils/services/logger";
import { httpAdapter } from "../services/httpAdapter";

export class ApiClient<T> {
  private endpoint: string;

  constructor(endpoint: string) {
    this.endpoint = endpoint;
  }

  public get(path: string, setStateAction: Dispatch<SetStateAction<T[]>>) {
    get<T>(`${this.endpoint}${path}`, setStateAction);
  }

  public async getAsync<T>(path: string, setStateAction: Dispatch<SetStateAction<T[]>>) {
    await getAsync<T>(`${this.endpoint}${path}`, setStateAction);
  }

  public async getsAsync<T>(paths: string[], setStateAction: Dispatch<SetStateAction<T[]>>) {
    const fullPaths: string[] = [];
    for (const path of paths) {
      fullPaths.push(`${this.endpoint}${path}`);
    }
    await getsAsync<T>(fullPaths, setStateAction);
  }
}

function get<T>(path: string, setStateAction: Dispatch<SetStateAction<T[]>>) {
  console.log(path);
  httpAdapter
    .get(path)
    .then((response: AxiosResponse) => {
      setStateAction(setResponse<T>(response));
    })
    .catch((error) => {
      writeAssertLog(path, error);
    });
}

async function getAsync<T>(path: string, setStateAction: Dispatch<SetStateAction<T[]>>) {
  console.log(path);
  try {
    const response = await httpAdapter.get(path);
    setStateAction(setResponse<T>(response));
  } catch (error) {
    writeAssertLog(path, error);
  }
}

async function getsAsync<T>(paths: string[], setStateAction: Dispatch<SetStateAction<T[]>>) {
  const result: T[] = [];
  for (const path of paths) {
    console.log(path);
    try {
      const response = await httpAdapter.get(path);
      const data = setResponse<T>(response);
      result.push(...data);
    } catch (error) {
      writeAssertLog(path, error);
    }
  }
  setStateAction(result);
}

function setResponse<T>(response: AxiosResponse): T[] {
  const status = response.status;
  if (status === 200) {
    const data = response.data;
    const results: T[] = data.results;
    writeLogs(results);
    return results;
  } else {
    throw new Error();
    return [];
  }
}

function writeAssertLog(path: string, error: any) {
  console.error("--- fetch error " + path + "---", error);
  console.log("message:" + error.message + "\nstack:" + error.stack);
}
