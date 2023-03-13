import { MainLayout } from "@/components/Layout/MainLayout";
import { lazyImport } from "@/utils/lazyImport";

const { ProductRoutes } = lazyImport(
  () => import("@/features/products"),
  "ProductRoutes",
);

export function ProtectedRoutes() {
  return (
    <MainLayout>
      <ProductRoutes />
    </MainLayout>
  );
}
