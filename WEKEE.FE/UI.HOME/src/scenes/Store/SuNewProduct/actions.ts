//#region Import 
import { action } from "typesafe-actions";
import { SpecificationsCategoryDto } from "./dtos/specificationsCategoryDto";
import ActionTypes from "./constants";
import { CategoryProductReadMapDto } from "./dtos/categoryProductReadMapDto";
import { ProductDtos } from "./dtos/productDtos";
import { CreateProductDtos } from "./dtos/createProductDtos";
import { ProductAttributeReadTypesDto } from "./dtos/productAttributeReadTypesDto";
import { ProductContainerInsertDto } from "./dtos/productContainerInsertDto";
//#endregion

//#region INSERT_PRODUCT_FULL
export const InsertProductFullStart = (input: ProductContainerInsertDto) =>
  action(ActionTypes.INSERT_PRODUCT_FULL_START, input);
export const InsertProductFullCompleted = (output: boolean) =>
  action(ActionTypes.INSERT_PRODUCT_FULL_COMPLETED, output);
export const InsertProductFullError = () =>
  action(ActionTypes.INSERT_PRODUCT_FULL_ERROR);
//#endregion

//#region PRO_ATTR_TYPE_UNIT
export const proAttrTypesUnitStart = (input: Number) =>
  action(ActionTypes.PRO_ATTR_TYPE_UNIT_START, input);
export const proAttrTypesUnitCompleted = (output: ProductAttributeReadTypesDto[]) =>
  action(ActionTypes.PRO_ATTR_TYPE_UNIT_COMPLETED, output);
export const proAttrTypesTradeMarkCompleted = (output: ProductAttributeReadTypesDto[]) =>
  action(ActionTypes.PRO_ATTR_TYPE_TRADEMARK_COMPLETED, output);
export const proAttrTypesAttributeCompleted = (output: ProductAttributeReadTypesDto[]) =>
  action(ActionTypes.PRO_ATTR_TYPE_ATTRIBUTE_COMPLETED, output);
export const proAttrTypesUnitError = () =>
  action(ActionTypes.PRO_ATTR_TYPE_UNIT_ERROR);
//#endregion

//#region GET_CATEGORY_MAIN 
export const getCategotyMainStart = () =>
  action(ActionTypes.GET_CATEGORY_MAIN_START);
export const getCategotyMainCompleted = (output: CategoryProductReadMapDto[]) =>
  action(ActionTypes.GET_CATEGORY_MAIN_COMPLETED, output);
export const getCategotyMainError = () =>
  action(ActionTypes.GET_CATEGORY_MAIN_ERROR);
//#endregion

//#region READ_FULL_ALBUM_PRODUCT 
export const readFullAlbumProductStart = () =>
  action(ActionTypes.READ_FULL_ALBUM_PRODUCT_START);
export const readFullAlbumProductCompleted = (output: string[]) =>
  action(ActionTypes.READ_FULL_ALBUM_PRODUCT_COMPLETED, output);
export const readFullAlbumProductError = () =>
  action(ActionTypes.READ_FULL_ALBUM_PRODUCT_ERROR);
//#endregion

//#region GET_SPECIFI_CATEGORY 
export const getSpecifiCategoryStart = (input: number) =>
  action(ActionTypes.GET_SPECIFI_CATEGORY_START, input);
export const getSpecifiCategoryCompleted = (
  output: SpecificationsCategoryDto[]
) => action(ActionTypes.GET_SPECIFI_CATEGORY_COMPLETED, output);
export const getSpecifiCategoryError = () =>
  action(ActionTypes.GET_SPECIFI_CATEGORY_ERROR);
//#endregion

//#region SET_PRODUCT_DTOS 
export const setProductsStart = (input: ProductDtos) =>
  action(ActionTypes.SET_PRODUCT_DTOS, input);
//#endregion

//#region CREATE_PRODUCT 
export const createProductsStart = (input: CreateProductDtos) =>
  action(ActionTypes.CREATE_PRODUCT_START, input);
export const createProductsCompleted = () =>
  action(ActionTypes.CREATE_PRODUCT_COMPLETED);
export const createProductsError = () =>
  action(ActionTypes.CREATE_PRODUCT_ERROR);
//#endregion

//#region CONTAINER_CREATE_PRODUCT
export const ContainerCreateProductStart = (input: ProductContainerInsertDto) =>
  action(ActionTypes.CONTAINER_CREATE_PRODUCT_START, input);
//#endregion
