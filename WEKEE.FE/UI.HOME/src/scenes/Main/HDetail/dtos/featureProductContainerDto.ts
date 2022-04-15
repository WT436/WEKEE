import { AttributeValueReadCartDto } from "./attributeValueReadCartDto";
import { ImageWithValueAttributeDto } from "./imageWithValueAttributeDto";
import { ProductReadForCartDto } from "./productReadForCartDto";

export interface FeatureProductContainerDto {
    productReadForCartDto: ProductReadForCartDto[];
    keyValuesName: AttributeValueReadCartDto[];
    renderImage: ImageWithValueAttributeDto[];
}