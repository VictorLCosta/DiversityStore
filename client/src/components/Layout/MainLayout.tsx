import { Box } from "@chakra-ui/react";

import { Footer } from "./Footer";
import { Header } from "./Header";

type MainLayoutProps = {
  children: React.ReactNode;
};

export function MainLayout({ children }: MainLayoutProps) {
  return (
    <>
      <Header />
      <Box as="main" py={6} px={4}>
        {children}
      </Box>
      <Footer />
    </>
  );
}
