import { ActionType } from "typesafe-actions";
import * as actions from "./actions";
import { CategorySelectDto } from "./dtos/categorySelectDto";
import { FeatureProductDtos } from "./dtos/featureProductDtos";
import { ImageProductDtos } from "./dtos/imageProductDtos";
import { ProductDtos } from "./dtos/productDtos";
import { SpecificationsCategoryDto } from "./dtos/specificationsCategoryDto";
import { SpecificationsCategoryUnitDto } from "./dtos/specificationsCategoryUnitDto";
export interface SuNewProductState {
  readonly loading: boolean;
  readonly completed: boolean;
  readonly pageIndex: number;
  readonly pageSize: number;
  readonly totalCount: number;
  readonly totalPages: number;

  readonly categorySelectDto: CategorySelectDto[];
  readonly albumProduct: string[];
  readonly specificationsCategoryDto: SpecificationsCategoryDto[];
  readonly specificationsCategoryUnitDto: SpecificationsCategoryUnitDto[];
  readonly productDto: ProductDtos;
}

export type SuNewProductActions = ActionType<typeof actions>;
