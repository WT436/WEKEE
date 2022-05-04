export interface UserProfileInsertDto {
    userName: string;
    email?: string;
    numberPhone?: string;
    password?: string;
    isAcceptTerm: boolean;
    address?: string;
}