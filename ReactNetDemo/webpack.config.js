const path = require("path");
const BrowserSyncPlugin = require("browser-sync-webpack-plugin");

module.exports = {
  entry: ["./React/server.jsx"],
  output: {
    path: path.resolve(__dirname, "./wwwroot/static/js"),
    filename: "react.bundle.js"
  },
  module: {
    rules: [
      {
        test: /\.(js|jsx)$/,
        exclude: /node_modules/,
        loader: "babel-loader"
      }
    ]
  },
  devtool: "source-map",
  plugins: [new BrowserSyncPlugin()],
  resolve: {
    extensions: [".js", ".jsx"]
  }
};
