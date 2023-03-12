import { Route, Routes } from "react-router-dom";

import { Products } from "./Products";

export function ProductRoutes() {
  return (
    <Routes>
      <Route path="" element={<Products />} />
    </Routes>
  );
}
