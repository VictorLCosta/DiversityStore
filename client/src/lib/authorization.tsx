/* eslint-disable react/jsx-no-useless-fragment */
import { observer } from "mobx-react-lite";
import React from "react";

import { useStore } from "@/stores";

export enum ROLES {
  Administrator = "Administrator",
  Customer = "Customer",
}

type RoleTypes = keyof typeof ROLES;

export const useAuthorization = () => {
  const {
    authStore: { currentAuthUser },
  } = useStore();

  if (!currentAuthUser) {
    throw Error("User does not exist!");
  }

  const checkAccess = React.useCallback(
    ({ allowedRoles }: { allowedRoles: RoleTypes[] }) => {
      if (allowedRoles && allowedRoles.length > 0) {
        return allowedRoles?.includes(currentAuthUser.role);
      }

      return true;
    },
    [currentAuthUser.role],
  );

  return { checkAccess, role: currentAuthUser.role };
};

type AuthorizationProps = {
  forbiddenFallback?: React.ReactNode;
  children: React.ReactNode;
} & (
  | {
      allowedRoles: RoleTypes[];
    }
  | {
      allowedRoles?: never;
    }
);

export const Authorization = observer(
  ({
    allowedRoles,
    forbiddenFallback = null,
    children,
  }: AuthorizationProps) => {
    const { checkAccess } = useAuthorization();

    let canAccess = false;

    if (allowedRoles) {
      canAccess = checkAccess({ allowedRoles });
    }

    return <>{canAccess ? children : forbiddenFallback}</>;
  },
);
