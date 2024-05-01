import axios, { AxiosResponse } from "axios";
import { BASE_URL } from "stores/storeConstants";
import { writeLogs } from "utils/services/logger";

axios.defaults.baseURL = BASE_URL;
axios.defaults.headers.post["Content-Type"] = "application/json;charset=utf-8";
axios.defaults.headers.post["Access-Control-Allow-Origin"] = "*";

export default function fetchData<T>(
  basepath: string,
  setStateAction: React.Dispatch<React.SetStateAction<T[]>>
) {
  console.log(basepath);
  axios
    .get(basepath)
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
      console.error("--- fetch error " + basepath + "---");
      console.error(error);
      console.log("message:" + error.message + "\nstack:" + error.stack);
    });
}

export function getData<T>(basepath: string): T[] {
  console.log(basepath);
  const asyncFunc = async () => {
    try {
      const response = await axios.get(basepath);
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
      console.error("--- fetch error " + basepath + "---", error);
    }
  };
  return [];
}
