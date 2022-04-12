export interface SpecificationProductInsertDto {
    customValue: string;
    specificationKey: string;
    SpecificationGroup: string | undefined;
    allowFiltering: boolean;
    showOnProductPage: boolean;
    displayOrder: number;
    index: number;
}