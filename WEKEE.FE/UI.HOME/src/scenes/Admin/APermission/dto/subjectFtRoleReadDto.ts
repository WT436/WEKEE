import { RoleReadDto } from "./roleReadDto";

export interface SubjectFtRoleReadDto extends RoleReadDto{
    isGranted: boolean;

}