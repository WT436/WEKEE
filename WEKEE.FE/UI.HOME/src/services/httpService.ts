import { L } from "../lib/abpUtility";
import { notification } from "antd";
import axios from "axios";

const qs = require("qs");

declare var abp: any;

const http = axios.create({
  baseURL: abp.appServiceUrl,
  timeout: 1800000,
  paramsSerializer: function (params) {
    return qs.stringify(params, {
      encode: false,
    });
  },
});

http.interceptors.request.use(
  function (config) {
    if (!!abp.auth.getToken()) {
      config.headers.common["Authorization"] = abp.auth.getToken();
      config.headers.common["Supplier"] = abp.auth.getTokenSupplier();
    }
    return config;
  },
  function (error) {
    return Promise.reject(error);
  }
);

http.interceptors.response.use(
  (response) => {
    return response;
  },
  (error) => {
    if (
      typeof error.response !== "undefined" &&
      typeof error.response.config !== "undefined" &&
      typeof error.response.config.url !== "undefined"
    ) {
      var arrPath = error.response.config.url.split("/");
      if (arrPath.length > 0 && arrPath[arrPath.length - 1] === "checkToken") {
        localStorage.clear();
        sessionStorage.clear();
        abp.auth.clearToken();
        window.location.href = "/login";
      }
    }

    let errorShowMessage = false;
    let errorDirectionalURL = false;
    if (typeof error.response !== "undefined") {
      errorShowMessage =
        error.response.status === 400 ||
        error.response.status === 401 ||
        error.response.status === 415 ||
        error.response.status === 422 ||
        error.response.status === 404;

      errorDirectionalURL =
        error.response.status === 403 ||
        error.response.status === 405 ||
        error.response.status === 410 ||
        error.response.status === 429 ||
        error.response.status === 500 ||
        error.response.status === 501 ||
        error.response.status === 502 ||
        error.response.status === 503 ||
        error.response.status === 504 ||
        error.response.status === 405;
    }

    if (
      !!error.response &&
      !!error.response.data.error &&
      !!error.response.data.error.message &&
      error.response.data.error.details
    ) {
      localStorage.setItem("request-err", error.response.data.error.details);
      notification.error({
        message: error.response.data.error.message,
        description: error.response.data.error.details,
        placement: "bottomRight",
      });
    }

    if (!!error.response && error.response.status === 401) {
      localStorage.setItem("request-err", error.response.data);
      localStorage.clear();
      sessionStorage.clear();
      abp.auth.clearToken();
    } else if (
      !!error.response &&
      !!error.response.data.error &&
      !!error.response.data.error.message
    ) {
      localStorage.setItem("request-err", error.response.data.error.message);
      notification.error({
        message: L("error", "common"),
        description: error.response.data.error.message,
        placement: "bottomRight",
      });
    }

    if (!!error.response && errorShowMessage) {
      localStorage.setItem("request-err", error.response.data);
      notification.error({
        message: L("error", "common"),
        description: error.response.data,
        placement: "bottomRight",
      });
    } else if (!!error.response && errorDirectionalURL) {
      localStorage.setItem("request-err", error.response.data);
      window.location.href =
        "/error?status=" +
        error.response.status +
        "&&message=" +
        error.response.data;
    } else {
      if (error.response !== undefined) {
        localStorage.setItem("request-err", error.response.data.message);
        notification.error({
          message: L("error", "common"),
          description: error.response.data,
          placement: "bottomRight",
        });
      }
    }

    return false;
    //return Promise.reject(error);
  }
);

export default http;
