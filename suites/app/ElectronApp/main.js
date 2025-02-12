const { app, BrowserWindow } = require("electron");
const path = require("path");
const url = require("url");

let mainWindow;

app.whenReady().then(() => {
  mainWindow = new BrowserWindow({
    width: 1280,
    height: 800,
    webPreferences: {
      nodeIntegration: false,
    },
  });

  // Blazor WebAssembly の `wwwroot/index.html` をロード
  //const startUrl = url.pathToFileURL(path.resolve(__dirname, "wwwroot", "index.html")).href;
  const startUrl = `file://${path.join(__dirname, "wwwroot/index.html")}`;
  console.log(`Loading URL: ${startUrl}`); // デバッグ用に表示
  mainWindow.loadURL(startUrl).catch((error) => {
    console.error("Failed to load URL:", error);
  });

  mainWindow.on("closed", () => {
    mainWindow = null;
  });
});

app.on("window-all-closed", () => {
  if (process.platform !== "darwin") {
    app.quit();
  }
});
