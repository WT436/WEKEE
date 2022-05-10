export interface AuthenticationResult {
  status: number;
  message: string;
  data: Data;
}

export interface Data {
  id: number;
  tokens: string;
  access: string;
  roles: string[];
  picture: string;
  fullName: string;
}