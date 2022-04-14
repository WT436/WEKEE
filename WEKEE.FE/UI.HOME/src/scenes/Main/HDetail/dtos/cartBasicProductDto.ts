import { SpecificationAttributeDto } from "./specificationAttributeDto";

export interface CartBasicProductDto {
    name: string;
    trademark : string,
    fullDescription: string;
    shortDescription: string;
    hasUserAgreement: boolean;
    orderMinimumQuantity: number;
    orderMaximumQuantity: number;
    shipSeparately: boolean;
    isFreeShipping: boolean;
    backorderModeId: number;
    disableWishlistButton: boolean;
    wishlistNumber: number;
    markAsNew: boolean;
    markAsNewStartDateTimeUtc: string | null;
    markAsNewEndDateTimeUtc: string | null;
    specificationAttributeDtos : SpecificationAttributeDto[]
}