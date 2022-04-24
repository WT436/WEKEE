export interface ResourceReadDto {
    id: number;
    name: string;
    typesRsc: number;
    typesRscName: string;
    description: string;
    isActive: boolean | null;
    createBy: number;
    createByName: string;
    createdOnUtc: string;
    updatedOnUtc: string;
}