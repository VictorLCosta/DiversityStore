/* eslint-disable react/jsx-no-useless-fragment */
import { observer } from "mobx-react-lite";
import { useEffect } from "react";

import { useStore } from "@/stores";
import { lazyImport } from "@/utils/lazyImport";

import { ProtectedRoutes } from "./protected";

const { AuthRoutes } = lazyImport(
  () => import("@/features/auth"),
  "AuthRoutes",
);

export const AppRoutes = observer(() => {
  const {
    authStore: { isLoggedIn, token, getCurrentUser },
  } = useStore();

  useEffect(() => {
    if (token) {
      getCurrentUser().finally();
    }
  }, [getCurrentUser, token]);

  return <>{isLoggedIn ? <ProtectedRoutes /> : <AuthRoutes />}</>;
});
