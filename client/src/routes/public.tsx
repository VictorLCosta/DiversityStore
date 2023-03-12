import { lazyImport } from "@/utils/lazyImport";

import type { RouteObject } from "react-router-dom";

const { AuthRoutes } = lazyImport(
  () => import("@/features/auth"),
  "AuthRoutes",
);

export const publicRoutes: RouteObject[] = [
  {
    index: true,
    element: <AuthRoutes />,
  },
];