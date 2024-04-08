import axios, { AxiosResponse } from "axios";

export default function fetchData(
  basepath: string,
  setStateAction: React.Dispatch<React.SetStateAction<any>>
) {
  console.log(basepath);
  axios
    .get(basepath, {
      withCredentials: true, // CORS設定
      headers: {
        Accept: "application/json, */*",
        "Content-Type": "application/json",
        "Content-Encoding": "gzip, deflate, br",
        Connection: "keep-alive",
      },
    })
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
