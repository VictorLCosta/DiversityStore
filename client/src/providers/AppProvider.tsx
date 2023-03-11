import { ChakraProvider } from "@chakra-ui/react";
import { ErrorBoundary } from "react-error-boundary";
import { HelmetProvider } from "react-helmet-async";
import { QueryClientProvider } from "react-query";
import { BrowserRouter as Router } from "react-router-dom";

import { ErrorFallback } from "@/components/Error";
import { queryClient } from "@/lib/react-query";
import { StoreContext, store } from "@/stores";

type AppProviderProps = {
  children: React.ReactNode;
};

export default function AppProvider({ children }: AppProviderProps) {
  return (
    <ErrorBoundary FallbackComponent={ErrorFallback}>
      <HelmetProvider>
        <QueryClientProvider client={queryClient}>
          <StoreContext.Provider value={store}>
            <Router>
              <ChakraProvider>{children}</ChakraProvider>
            </Router>
          </StoreContext.Provider>
        </QueryClientProvider>
      </HelmetProvider>
    </ErrorBoundary>
  );
}
