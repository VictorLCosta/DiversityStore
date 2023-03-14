import { useMutation } from "react-query";

import { axios } from "@/lib/axios";
import type { MutationConfig } from "@/lib/react-query";
import { queryClient } from "@/lib/react-query";

export const deleteProduct = (productId: string): Promise<boolean> =>
  axios.delete(`/products/${productId}`);

type UseDeleteProductOptions = {
  config?: MutationConfig<typeof deleteProduct>;
};

export const useDeleteProduct = ({ config }: UseDeleteProductOptions) =>
  useMutation({
    onSuccess: () => {
      queryClient.invalidateQueries("dashboard");
    },
    ...config,
    mutationFn: deleteProduct,
  });
