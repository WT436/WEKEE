export interface PermissionFtReourceReadDto {
    id: number;
    resourceId: number;
    resourceName: string;
    permissionId: number;
    permissionName: string;
    isActive: boolean | null;
    createBy: number;
    createName: string;
    createdOnUtc: string;
    updatedOnUtc: string;
}