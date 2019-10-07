import React from "react";
import ReactDOM from "react-dom";
import ReactDOMServer from "react-dom/server";
import CommentBox from "./index";
import RouterExample from "./routerExample";

global.React = React;
global.ReactDOM = ReactDOM;
global.ReactDOMServer = ReactDOMServer;
global.RouterExample = RouterExample;

global.CommentBox = CommentBox;
