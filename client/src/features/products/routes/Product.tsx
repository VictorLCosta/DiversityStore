import {
  Grid,
  GridItem,
  Heading,
  HStack,
  Image,
  NumberIncrementStepper,
  NumberDecrementStepper,
  NumberInputStepper,
  NumberInput,
  NumberInputField,
  Stack,
  Text,
  Button,
  useDisclosure,
  AlertDialog,
  AlertDialogBody,
  AlertDialogCloseButton,
  AlertDialogContent,
  AlertDialogFooter,
  AlertDialogHeader,
  AlertDialogOverlay,
  useToast,
} from "@chakra-ui/react";
import { createRef, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";

import { createSale } from "../api/createSale";
import { useProduct } from "../api/getProduct";

export function Product() {
  const toast = useToast();
  const navigate = useNavigate();

  const [nummericStepperValue, setNummericStepperValue] = useState(1);

  const { isOpen, onOpen, onClose } = useDisclosure();
  const cancelRef = createRef<HTMLButtonElement>();

  const { slug } = useParams<{ slug: string }>();

  const { data } = useProduct({ slug });

  if (!data) return null;

  function handleClick() {
    createSale([{ productId: data!.id, quantity: nummericStepperValue }]);
    toast({
      title: "Purchase Made.",
      description: "Your purchase has been completed.",
      status: "success",
      duration: 9000,
      isClosable: true,
      position: "bottom-right",
    });
    navigate("/products");
  }

  return (
    <>
      <Grid templateColumns="repeat(2, 1fr)">
        <GridItem>
          <Image src={data.pictureUrl} />
        </GridItem>
        <GridItem>
          <Stack>
            <Heading as="h2" fontSize="3xl">
              {data.name}
            </Heading>
            <Text color="blue.600" fontSize="2xl">
              R$ {data.price}
            </Text>
            <Text>{data.description}</Text>
            <HStack pt={4}>
              <NumberInput
                size="md"
                maxW={20}
                defaultValue={1}
                min={1}
                max={data.quantityInStock}
                onChange={(val) => setNummericStepperValue(+val)}
              >
                <NumberInputField />
                <NumberInputStepper>
                  <NumberIncrementStepper />
                  <NumberDecrementStepper />
                </NumberInputStepper>
              </NumberInput>
              <Button
                textTransform="capitalize"
                colorScheme="blue"
                onClick={onOpen}
              >
                confirm purchase
              </Button>
            </HStack>
          </Stack>
        </GridItem>
      </Grid>
      <AlertDialog
        motionPreset="slideInBottom"
        leastDestructiveRef={cancelRef}
        onClose={onClose}
        isOpen={isOpen}
        isCentered
      >
        <AlertDialogOverlay />

        <AlertDialogContent>
          <AlertDialogHeader>Confirm Purchase?</AlertDialogHeader>
          <AlertDialogCloseButton />
          <AlertDialogBody>
            Are you sure you want to finish your purchase?
          </AlertDialogBody>
          <AlertDialogFooter>
            <Button ref={cancelRef} onClick={onClose}>
              No
            </Button>
            <Button colorScheme="green" ml={3} onClick={() => handleClick()}>
              Yes
            </Button>
          </AlertDialogFooter>
        </AlertDialogContent>
      </AlertDialog>
    </>
  );
}
