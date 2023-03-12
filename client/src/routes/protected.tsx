import { Navigate, Outlet } from "react-router-dom";

import { MainLayout } from "@/components/Layout/MainLayout";
import { lazyImport } from "@/utils/lazyImport";

import type { RouteObject } from "react-router-dom";

const { ProductRoutes } = lazyImport(
  () => import("@/features/products"),
  "ProductRoutes",
);

function App() {
  return (
    <MainLayout>
      <Outlet />
    </MainLayout>
  );
}

export const protectedRoutes: RouteObject[] = [
  {
    path: "/app/*",
    element: <App />,
    children: [
      { path: "/products/*", element: <ProductRoutes /> },
      { path: "*", element: <Navigate to="." /> },
    ],
  },
];
