import axios from "axios";

export default axios.create({
  baseURL: "https://localhost:7139/api",
  headers: {
    "Access-Control-Allow-Origin": "*",
    "Content-type": "application/json",
  },
});
