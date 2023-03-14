import { useInfiniteQuery } from "react-query";

import { axios } from "@/lib/axios";
import type { ExtractFnReturnType } from "@/lib/react-query";
import type { PaginatedList } from "@/types";

import type { DashboardEntryDto } from "../types";

export const getDashboard = (
  pageNumber: number,
): Promise<PaginatedList<DashboardEntryDto>> =>
  axios.get("/products/dashboard", { params: { pageNumber } });

type QueryFnType = typeof getDashboard;

type UseDashboardOptions = {
  pageNumber: number;
};

export const useDashboard = ({ pageNumber }: UseDashboardOptions) =>
  useInfiniteQuery<ExtractFnReturnType<QueryFnType>>({
    retry: true,
    queryKey: ["dashboard", pageNumber],
    getNextPageParam: (prevPage) =>
      prevPage.hasNextPage ? prevPage.pageNumber + 1 : undefined,
    queryFn: ({ pageParam = 1 }) => getDashboard(pageParam),
  });
