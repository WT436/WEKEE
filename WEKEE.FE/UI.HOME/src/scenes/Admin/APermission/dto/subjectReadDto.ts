export interface SubjectReadDto {
    id: number;
    userId: number;
    userName: string;
    gorupId: number | null;
    gorupName: string;
    isActive: boolean | null;
    createBy: number;
    createByName: string;
    createdOnUtc: string;
    updatedOnUtc: string;
}