export type AuthUser = {
  id: string;
  email: string;
  displayName: string;
  userName: string;
  pictureUrl: string;
  role: "Administrator" | "Customer";
};

export type UserResponse = {
  token: string;
  user: AuthUser;
};
