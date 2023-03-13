import { Flex, Heading } from "@chakra-ui/react";

export function Header() {
  return (
    <Flex
      as="header"
      bgGradient="linear(to-r, #1A2980, #26D0CE)"
      padding={6}
      textColor="white"
    >
      <Heading as="h2">Diversity Store</Heading>
    </Flex>
  );
}
