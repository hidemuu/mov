import axios from "axios";
import { BASE_URL } from "stores/storeConstants";

export const apiAdapter = axios.create({
  baseURL: BASE_URL,
  responseType: "json",
  headers: {
    "Content-Type": "application/json;charset=utf-8",
    "Access-Control-Allow-Origin": "*",
  },
});
