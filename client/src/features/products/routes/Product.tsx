import { Grid, GridItem, Heading, Image, Stack, Text } from "@chakra-ui/react";
import { useParams } from "react-router-dom";

import { useProduct } from "../api/getProduct";

export function Product() {
  const { slug } = useParams<{ slug: string }>();

  const { data } = useProduct({ slug });

  if (!data) return null;

  return (
    <Grid templateColumns="repeat(2, 1fr)">
      <GridItem>
        <Image src={data.pictureUrl} />
      </GridItem>
      <GridItem>
        <Stack>
          <Heading as="h2">{data.name}</Heading>
          <Text>{data.description}</Text>
        </Stack>
      </GridItem>
    </Grid>
  );
}
