export default function fetchData(
  basepath: string,
  setStateAction: React.Dispatch<React.SetStateAction<any>>
) {
  console.log(basepath);
  fetch(basepath)
    .then((response) => {
      if (response.status === 200) {
        return response.json();
      } else {
        throw new Error();
      }
    })
    .then((json) => {
      console.log(json);
      setStateAction({
        data: json,
      });
      return json;
    })
    .catch((error) => {
      console.error("--- fetch error " + basepath + "---");
      console.error(error);
      setStateAction(error.message);
    });
}
