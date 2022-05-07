"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
function fetchData(basepath, data) {
    console.log(basepath);
    fetch(basepath)
        .then(function (response) {
        if (response.status === 200) {
            return response.json();
        }
        else {
            throw new Error();
        }
    })
        .then(function (json) {
        console.log(json);
        data.setState({
            data: json,
        });
        return json;
    })
        .catch(function (error) {
        console.error('--- fetch error ' + basepath + '---');
        console.error(error);
    });
}
exports.default = fetchData;
//# sourceMappingURL=fetchData.js.map