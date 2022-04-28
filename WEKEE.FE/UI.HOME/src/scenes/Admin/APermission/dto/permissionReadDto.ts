export interface PermissionReadDto {
    id: number;
    name: string;
    description: string;
    atomicId: number;
    atomicName: string;
    levelPermition: number;
    permissionId: number;
    permissionName: string;
    isActive: boolean | null;
    createBy: number;
    createByName: string;
    createdOnUtc: string;
    updatedOnUtc: string;
}