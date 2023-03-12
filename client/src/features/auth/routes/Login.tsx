import { Box, Flex, Text } from "@chakra-ui/react";
import { useNavigate } from "react-router-dom";

import { Head } from "@/components/Head";

import { LoginForm } from "../components/LoginForm";

export function Login() {
  const navigate = useNavigate();

  return (
    <>
      <Head title="Log in to your account" />
      <Flex
        flexDirection="column"
        gap="3rem"
        height="100vh"
        alignItems="center"
        justifyContent="center"
        bgGradient="linear(to-r, #1A2980, #26D0CE)"
      >
        <LoginForm onSuccess={() => navigate("/products")} />
        <Box textColor="white">
          <Text align="center">
            Para acessar como Administrador - Email: admin@example.com Password:
            sistema123
          </Text>
          <br />
          <Text align="center">
            Para acessar como Cliente - Email: user1@example.com Password:
            sistema123
          </Text>
        </Box>
      </Flex>
    </>
  );
}
