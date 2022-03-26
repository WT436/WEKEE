export interface CategoryProductReadChildrenDto {
    id: number,
    nameCategory: String,
    urlCategory: String,
    iconCategory: String,
    levelCategory: number
    categoryMain: number
    categoryMainName: String,
    numberOrder: number,
    isEnabled: boolean,
    createdOnUtc: Date,
    updatedOnUtc: Date,
    children: CategoryProductReadChildrenDto

}