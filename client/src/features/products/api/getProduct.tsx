import { useQuery } from "react-query";

import { axios } from "@/lib/axios";
import type { ExtractFnReturnType, QueryConfig } from "@/lib/react-query";

import type { ProductDto } from "../types";

export const getProduct = (slug?: string): Promise<ProductDto> =>
  axios.get(`/products/${slug}`);

type QueryFnType = typeof getProduct;

type UseProductOptions = {
  slug?: string;
  config?: QueryConfig<QueryFnType>;
};

export const useProduct = ({ slug, config }: UseProductOptions) =>
  useQuery<ExtractFnReturnType<QueryFnType>>({
    ...config,
    retry: true,
    queryKey: ["product", slug],
    queryFn: () => getProduct(slug),
  });
