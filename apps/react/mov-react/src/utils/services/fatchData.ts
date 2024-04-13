import axios, { AxiosResponse } from "axios";

axios.defaults.baseURL = "http://localhost:5257";
axios.defaults.headers.post["Content-Type"] = "application/json;charset=utf-8";
axios.defaults.headers.post["Access-Control-Allow-Origin"] = "*";

export default function fetchData(
  basepath: string,
  setStateAction: React.Dispatch<React.SetStateAction<any>>
) {
  console.log(basepath);
  axios
    .get(basepath)
    .then((response) => {
      if (response.status === 200) {
        const results = response.data.results;
        for (const result of results) {
          console.log(result);
        }
        setStateAction({
          data: results,
        });
        return results;
      } else {
        throw new Error();
      }
    })
    .catch((error) => {
      console.error("--- fetch error " + basepath + "---");
      console.error(error);
      setStateAction("message:" + error.message + "\nstack:" + error.stack);
    });
}
