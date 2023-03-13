import { Navigate, Route, Routes } from "react-router-dom";

import { Product } from "./Product";
import { Products } from "./Products";

export function ProductRoutes() {
  return (
    <Routes>
      <Route path="/products" element={<Products />} />
      <Route path="/products/:slug" element={<Product />} />
      <Route path="*" element={<Navigate to="/products" />} />
    </Routes>
  );
}
