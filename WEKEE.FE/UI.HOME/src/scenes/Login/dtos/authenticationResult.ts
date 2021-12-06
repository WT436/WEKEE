export interface AuthenticationResult {
  id: String;
  tokens: { token: String };
  roles: string[];
  picture: String;
  fullName: String;
}
