﻿import axios, { AxiosResponse } from "axios";

axios.defaults.baseURL = "http://localhost:5257";
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
        for (const result of results) {
          console.log(result);
        }
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