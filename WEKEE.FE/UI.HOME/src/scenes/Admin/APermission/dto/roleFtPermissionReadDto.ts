import { PermissionReadDto } from "./permissionReadDto";

export interface RoleFtPermissionReadDto extends PermissionReadDto{
    isGranted: boolean;
}