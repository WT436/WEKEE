import { CategoryProductAddProductDto } from "./categoryProductAddProductDto";
import { ProductInsertDto } from "./productInsertDto";
import { SpecificationProductInsertDto } from "./specificationProductInsertDto";
import { FeatureProductInsertDtos } from "./featureProductInsertDtos";
export interface ProductContainerInsertDto {
    productInsertDto: ProductInsertDto
    productTagDtos: String[]
    imageRoot: String[]
    specificationProductDtos: SpecificationProductInsertDto[]
    categoryProduct: CategoryProductAddProductDto
    featureProductInsertDtos: FeatureProductInsertDtos[]
}