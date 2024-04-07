const { createProxyMiddleware } = require("http-proxy-middleware");

const target = "http://localhost:5257";

const context = [
  "/api/TrendLine",
  "/api/TableLine",
  "/api/analizers/regions/resas/ResasPrefecture",
];

const onError = (err, req, resp, target) => {
  console.error(`${err.message}`);
};

module.exports = function (app) {
  const appProxy = createProxyMiddleware(context, {
    target: target,
    changeOrigin: true,
    onError: onError,
    secure: false,
    headers: {
      Connection: "Keep-Alive",
    },
  });

  app.use(appProxy);
};
