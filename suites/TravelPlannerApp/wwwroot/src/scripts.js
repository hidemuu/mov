window.addEventListener('beforeunload', () => {
    if (window.updateLocalStorage) {
        window.updateLocalStorage();
    }
});

function setUpdateLocalStorage(dotNetObject) {
    window.updateLocalStorage = function () {
        dotNetObject.invokeMethodAsync('UpdateLocalStorage');
    };
}