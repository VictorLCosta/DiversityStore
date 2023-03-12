import { Navigate, Outlet } from "react-router-dom";

import { MainLayout } from "@/components/Layout/MainLayout";

import type { RouteObject } from "react-router-dom";

function App() {
  return (
    <MainLayout>
      <Outlet />
    </MainLayout>
  );
}

export const protectedRoutes: RouteObject[] = [
  {
    path: "/*",
    element: <App />,
    children: [{ path: "*", element: <Navigate to="." /> }],
  },
];
