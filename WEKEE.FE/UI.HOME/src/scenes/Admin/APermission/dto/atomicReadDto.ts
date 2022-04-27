export interface AtomicReadDto {
    id: number;
    name: string;
    typesRsc: number;
    description: string;
    isActive: boolean | null;
    createBy: number;
    createByName: string;
    createdOnUtc: string;
    updatedOnUtc: string;
}