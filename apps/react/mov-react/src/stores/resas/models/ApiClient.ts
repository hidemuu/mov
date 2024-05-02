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

  public async getAsync<T>(
    path: string,
    setStateAction: Dispatch<SetStateAction<T[]>>
  ) {
    getAsync<T>(`${this.endpoint}${path}`, setStateAction);
  }
}

function get<T>(path: string, setStateAction: Dispatch<SetStateAction<T[]>>) {
  console.log(path);
  httpAdapter
    .get(path)
    .then((response: AxiosResponse) => {
      setResponse<T>(response, setStateAction);
    })
    .catch((error) => {
      writeAssertLog(path, error);
    });
}

async function getAsync<T>(
  path: string,
  setStateAction: Dispatch<SetStateAction<T[]>>
) {
  console.log(path);
  try {
    const response = await httpAdapter.get(path);
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
