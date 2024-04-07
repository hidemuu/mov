import axios, { AxiosResponse } from "axios";

export default function fetchData(
  basepath: string,
  setStateAction: React.Dispatch<React.SetStateAction<any>>
) {
  console.log(basepath);
  axios
    .get(basepath, {
      withCredentials: true, // CORS設定
    })
    .then((response) => {
      if (response.status === 200) {
        return response.data;
      } else {
        throw new Error();
      }
    })
    .then((data) => {
      console.log(data);
      setStateAction({
        data: data,
      });
      return data;
    })
    .catch((error) => {
      console.error("--- fetch error " + basepath + "---");
      console.error(error);
      setStateAction("message:" + error.message + "\nstack:" + error.stack);
    });
}
