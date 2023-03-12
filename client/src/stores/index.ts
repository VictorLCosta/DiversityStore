import { createContext, useContext } from "react";

import { AuthStore } from "@/features/auth";

interface Store {
  authStore: AuthStore;
}

export const store: Store = {
  authStore: new AuthStore(),
};

export const StoreContext = createContext(store);

export function useStore() {
  return useContext(StoreContext);
}
