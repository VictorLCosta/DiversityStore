/* eslint-disable react/jsx-no-useless-fragment */
import { observer } from "mobx-react-lite";
import { useRoutes } from "react-router-dom";

import { useStore } from "@/stores";

import { protectedRoutes } from "./protected";
import { publicRoutes } from "./public";

export const AppRoutes = observer(() => {
  const {
    authStore: { isLoggedIn },
  } = useStore();

  const routes = isLoggedIn ? protectedRoutes : publicRoutes;

  const element = useRoutes([...routes]);

  return <>{element}</>;
});
