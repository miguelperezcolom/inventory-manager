import axios, { AxiosInstance } from "axios";
const apiClient: AxiosInstance = axios.create({
  baseURL: "http://localhost:7098/api/v1",
  headers: {
    "Content-type": "application/json",
  },
  auth: {
    username: "admin",
    password: "admin",
  },
});
export default apiClient;
