import { Flex } from "@chakra-ui/react";

export function Footer() {
  return (
    <Flex
      as="footer"
      w="full"
      justify="center"
      textColor="white"
      bgGradient="linear(to-r, #1A2980, #26D0CE)"
      p={3}
    >
      By Victor Lima Costa
    </Flex>
  );
}
