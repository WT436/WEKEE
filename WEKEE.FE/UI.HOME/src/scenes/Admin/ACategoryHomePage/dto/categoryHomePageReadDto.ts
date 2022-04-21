export interface CategoryHomePageReadDto {
    id: number;
    categoryId: string;
    nameCategory: string;
    urlCategory: string;
    iconCategory: string;
    categoryMain: number | null;
    categoryMainName : string;
    numberOrder: number;
    isEnabled: boolean;
    isComponent: number;
    createBy: number;
    createdOnUtc: string;
    updatedOnUtc: string;
}