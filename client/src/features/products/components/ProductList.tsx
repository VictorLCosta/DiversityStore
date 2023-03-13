import { Grid, GridItem, Spinner } from "@chakra-ui/react";

import { InfiniteScroll } from "@/components/InfiniteScroll";

import { useProducts } from "../api/getProducts";

import { ProductCard } from "./ProductCard";

function LoadingComponent() {
  return (
    <div className="h-full w-full flex items-center justify-center col-span-1 sm:col-span-4">
      <Spinner size="xl" />
    </div>
  );
}

export function ProductList() {
  const { data, hasNextPage, isFetchingNextPage, fetchNextPage } = useProducts({
    pageNumber: 1,
  });

  return (
    <Grid
      as={InfiniteScroll}
      hasNextPage={hasNextPage}
      loading={isFetchingNextPage}
      loader={<LoadingComponent />}
      onLoadMore={fetchNextPage}
      templateColumns={{ sm: "repeat(2, 1fr)", lg: "repeat(4, 1fr)" }}
    >
      {data?.pages
        .flatMap((pages) => pages.items)
        .map((product) => (
          <GridItem key={product.id} p={6} columnGap={2}>
            <ProductCard product={product} />
          </GridItem>
        ))}
    </Grid>
  );
}
