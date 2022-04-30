export interface RoleReadDto {
    id: number;
    createBy: number;
    createByName: string;
    createdOnUtc: string;
    updatedOnUtc: string;
    name: string;
    description: string;
    levelRole: number;
    roleManageId: number;
    roleManageName: string;
    isDelete: boolean;
    isActive: boolean | null;
}