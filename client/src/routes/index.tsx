/* eslint-disable react/jsx-no-useless-fragment */
import { useRoutes } from "react-router-dom";

import { useStore } from "@/stores";

import { protectedRoutes } from "./protected";
import { publicRoutes } from "./public";

export function AppRoutes() {
  const {
    authStore: { isLoggedIn },
  } = useStore();

  // const commonRoutes = [{ path: "/", element: <Login /> }];

  const routes = isLoggedIn ? protectedRoutes : publicRoutes;

  const element = useRoutes([...routes]);

  return <>{element}</>;
}
