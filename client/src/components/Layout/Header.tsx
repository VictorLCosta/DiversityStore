import { Flex, HStack, Heading, Icon, Text } from "@chakra-ui/react";
import { MdMenu } from "react-icons/md";
import { Link } from "react-router-dom";

import { useAuthorization } from "@/lib/authorization";

export function Header() {
  const { role } = useAuthorization();

  return (
    <Flex
      as="header"
      bgGradient="linear(to-r, #1A2980, #26D0CE)"
      padding={6}
      textColor="white"
      justify="space-between"
      justifyItems="center"
    >
      <Heading as="h2">Diversity Store</Heading>
      {role === "Administrator" && (
        <HStack as={Link} to="/products/dashboard">
          <Text textColor="white" fontSize="lg">Admin Dashboard</Text>
          <Icon as={MdMenu} fontSize="xl" />
        </HStack>
      )}
    </Flex>
  );
}
