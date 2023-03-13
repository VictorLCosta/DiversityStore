import { Navigate, Route, Routes } from "react-router-dom";

import { Products } from "./Products";

export function ProductRoutes() {
  return (
    <Routes>
      <Route path="/products" element={<Products />} />
      <Route path="*" element={<Navigate to="/products" />} />
    </Routes>
  );
}
