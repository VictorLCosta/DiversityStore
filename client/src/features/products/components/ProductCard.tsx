import {
  Button,
  Card,
  CardBody,
  CardFooter,
  Divider,
  Heading,
  Image,
  Stack,
  Text,
} from "@chakra-ui/react";

import type { ProductBriefDto } from "../types";

type ProductCardProps = {
  product: ProductBriefDto;
};

export function ProductCard({ product }: ProductCardProps) {
  return (
    <Card>
      <CardBody>
        <Image src={product.pictureUrl} alt={product.name} />
        <Stack mt="6" spacing="3">
          <Heading size="md" noOfLines={2}>
            {product.name}
          </Heading>
          <Text color="blue.600" fontSize="2xl">
            R$ {product.price}
          </Text>
        </Stack>
      </CardBody>
      <Divider borderColor="gray.400" />
      <CardFooter>
        <Button variant="solid" colorScheme="blue">
          Buy now
        </Button>
      </CardFooter>
    </Card>
  );
}
