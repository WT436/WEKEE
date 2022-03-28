export interface CategoryProductReadDto {
    id: number,
    nameCategory: string,
    urlCategory: string,
    iconCategory: string,
    levelCategory: number,
    categoryMain: number,
    categoryMainName: string,
    numberOrder: number,
    isEnabled: boolean,
    createdOnUtc: Date,
    updatedOnUtc: Date
}