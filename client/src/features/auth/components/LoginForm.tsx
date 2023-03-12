import {
  Box,
  Button,
  Center,
  FormControl,
  FormErrorMessage,
  FormLabel,
  Heading,
  Icon,
  Input,
  InputGroup,
  InputLeftElement,
} from "@chakra-ui/react";
import { Formik, Form } from "formik";
import { motion } from "framer-motion";
import { MdOutlinePersonOutline, MdOutlineLock } from "react-icons/md";
import * as yup from "yup";

import { useStore } from "@/stores";

const schema = yup.object({
  email: yup
    .string()
    .email("Invalid email address")
    .required("Invalid email address"),
  password: yup.string().required("Inform your password"),
});

type LoginFormProps = {
  onSuccess: () => void;
};

export function LoginForm({ onSuccess }: LoginFormProps) {
  const {
    authStore: { login },
  } = useStore();

  return (
    <motion.div
      initial={{ opacity: 0, scale: 0 }}
      animate={{ opacity: 1, scale: 1 }}
    >
      <Formik
        initialValues={{ email: "admin@example.com", password: "sistema123" }}
        validationSchema={schema}
        onSubmit={async (values) => {
          await login({ email: values.email, password: values.password });
          onSuccess();
        }}
      >
        {({ errors, dirty, isSubmitting }) => (
          <Box
            as={Form}
            backgroundColor="white"
            width="sm"
            padding="7"
            borderRadius="lg"
            autoComplete="off"
          >
            <Center p={4}>
              <Heading as="h2" size="lg" mb={2}>
                Login
              </Heading>
            </Center>
            <FormControl mb={3}>
              <FormLabel>Email</FormLabel>
              <InputGroup>
                <InputLeftElement fontSize="1.4rem" pointerEvents="none">
                  <Icon as={MdOutlinePersonOutline} color="gray.300" />
                </InputLeftElement>
                <Input
                  name="email"
                  placeholder="Type your email"
                  variant="flushed"
                />
              </InputGroup>
              {errors.email && (
                <FormErrorMessage>{errors.email}</FormErrorMessage>
              )}
            </FormControl>
            <FormControl>
              <FormLabel>Password</FormLabel>
              <InputGroup>
                <InputLeftElement fontSize="1.4rem" pointerEvents="none">
                  <Icon as={MdOutlineLock} color="gray.300" />
                </InputLeftElement>
                <Input
                  name="password"
                  type="password"
                  placeholder="Type your password"
                  variant="flushed"
                />
              </InputGroup>
              {errors.password && (
                <FormErrorMessage>{errors.password}</FormErrorMessage>
              )}
            </FormControl>
            <Button
              type="submit"
              mt={14}
              width="full"
              textColor="white"
              textTransform="uppercase"
              borderRadius="3xl"
              bgGradient="linear(to-r, #1A2980, #26D0CE)"
              isLoading={isSubmitting}
              _disabled={{ opacity: 0.75, pointerEvents: "none" }}
            >
              login
            </Button>
          </Box>
        )}
      </Formik>
    </motion.div>
  );
}
