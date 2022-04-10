import { ActionType } from "typesafe-actions";
import * as actions from "./actions";
import { CategoryProductReadMapDto } from "./dtos/categoryProductReadMapDto";
import { ProductAttributeReadTypesDto } from "./dtos/productAttributeReadTypesDto";
import { ProductAttributeValueReadDto } from "./dtos/productAttributeValueReadDto";
import { ProductContainerInsertDto } from "./dtos/productContainerInsertDto";
import { ProductDtos } from "./dtos/productDtos";
import { SpecificationsCategoryDto } from "./dtos/specificationsCategoryDto";
export interface SuNewProductState {
  readonly loading: boolean;
  readonly completed: boolean;
  readonly pageIndex: number;
  readonly pageSize: number;
  readonly totalCount: number;
  readonly totalPages: number;

  readonly categorySelectDto: CategoryProductReadMapDto[];
  readonly albumProduct: string[];
  readonly specificationsCategoryDto: SpecificationsCategoryDto[];
  readonly productAttributeReadTypesDto: ProductAttributeReadTypesDto[];
  readonly productAttributeReadTrademarkDto: ProductAttributeReadTypesDto[];
  readonly productAttributeReadAttributeDto: ProductAttributeReadTypesDto[];
  readonly productDto: ProductDtos;
  readonly productContainer : ProductContainerInsertDto;
  readonly attributeValueOne : ProductAttributeValueReadDto[];
  readonly attributeValueTwo : ProductAttributeValueReadDto[];
}

export type SuNewProductActions = ActionType<typeof actions>;
