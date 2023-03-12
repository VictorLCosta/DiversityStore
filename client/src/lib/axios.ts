import Axios from "axios";

import cookies from "@/utils/cookies";

import type { AxiosError, InternalAxiosRequestConfig } from "axios";

function authRequestInterceptor(config: InternalAxiosRequestConfig) {
  const token = cookies.get("jwt");

  if (token && config.headers) {
    // eslint-disable-next-line no-param-reassign
    config.headers.Authorization = `Bearer ${token}`;
  }

  return config;
}

export const axios = Axios.create({
  baseURL: "http://localhost:5154/api",
  headers: {
    "Content-type": "application/json",
  },
});

axios.interceptors.request.use(authRequestInterceptor);

axios.interceptors.response.use(
  async (response) => response.data,
  (error: AxiosError) => Promise.reject(error),
);
