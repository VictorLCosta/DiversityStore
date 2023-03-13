import { axios } from "@/lib/axios";

import type { SaleItemDto } from "../types";

export const createSale = (items: SaleItemDto[]): Promise<void> =>
  axios.post("/sales/create", items);
