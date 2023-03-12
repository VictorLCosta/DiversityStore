import { Flex } from "@chakra-ui/react";

import { Head } from "@/components/Head";

import { LoginForm } from "../components/LoginForm";

export function Login() {
  return (
    <>
      <Head title="Log in to your account" />
      <Flex
        height="100vh"
        alignItems="center"
        justifyContent="center"
        bgGradient="linear(to-r, #1A2980, #26D0CE)"
      >
        <LoginForm />
      </Flex>
    </>
  );
}
