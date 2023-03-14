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
        initialValues={{ email: "", password: "" }}
        validationSchema={schema}
        enableReinitialize
        onSubmit={async (values) => {
          await login({ email: values.email, password: values.password });
          onSuccess();
        }}
      >
        {({
          dirty,
          errors,
          values,
          isSubmitting,
          isValid,
          handleChange,
          handleSubmit,
        }) => (
          <Box backgroundColor="white" width="sm" padding="7" borderRadius="lg">
            <Form onSubmit={handleSubmit} autoComplete="off">
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
                    value={values.email}
                    onChange={handleChange}
                    variant="flushed"
                  />
                </InputGroup>
                {errors.email && (
                  <FormErrorMessage>{errors.email}</FormErrorMessage>
                )}
              </FormControl>
              <FormControl mb={3}>
                <FormLabel>Password</FormLabel>
                <InputGroup>
                  <InputLeftElement fontSize="1.4rem" pointerEvents="none">
                    <Icon as={MdOutlineLock} color="gray.300" />
                  </InputLeftElement>
                  <Input
                    name="password"
                    type="password"
                    value={values.password}
                    onChange={handleChange}
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
                isDisabled={!isValid || !dirty}
                _disabled={{ opacity: 0.75, pointerEvents: "none" }}
              >
                login
              </Button>
            </Form>
          </Box>
        )}
      </Formik>
    </motion.div>
  );
}
