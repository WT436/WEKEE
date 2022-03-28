import { action } from "typesafe-actions";
import { SpecificationsCategoryDto } from "./dtos/specificationsCategoryDto";

import ActionTypes from "./constants";
import { CategorySelectDto } from "./dtos/categorySelectDto";
import { ProductDtos } from "./dtos/productDtos";
import { CreateProductDtos } from "./dtos/createProductDtos";
/////////////////////////////////////////////////////////////////////////////////
export const watchPageStart = () => action(ActionTypes.WATCH_PAGE_START);
export const watchPageCompleted = () =>
  action(ActionTypes.WATCH_PAGE_COMPLETED);
export const watchPageError = () => action(ActionTypes.WATCH_PAGE_ERROR);
//////////////////////////////////////////////////////////////////////////////////
export const getCategotyMainStart = () =>
  action(ActionTypes.GET_CATEGORY_MAIN_START);
export const getCategotyMainCompleted = (output: CategorySelectDto[]) =>
  action(ActionTypes.GET_CATEGORY_MAIN_COMPLETED, output);
export const getCategotyMainError = () =>
  action(ActionTypes.GET_CATEGORY_MAIN_ERROR);

//////////////////////////////////////////////////////////////////////////////////
export const readFullAlbumProductStart = () =>
  action(ActionTypes.READ_FULL_ALBUM_PRODUCT_START);
export const readFullAlbumProductCompleted = (output: string[]) =>
  action(ActionTypes.READ_FULL_ALBUM_PRODUCT_COMPLETED, output);
export const readFullAlbumProductError = () =>
  action(ActionTypes.READ_FULL_ALBUM_PRODUCT_ERROR);

//////////////////////////////////////////////////////////////////////////////////
export const getSpecifiCategoryStart = (input: number) =>
  action(ActionTypes.GET_SPECIFI_CATEGORY_START, input);
export const getSpecifiCategoryCompleted = (
  output: SpecificationsCategoryDto[]
) => action(ActionTypes.GET_SPECIFI_CATEGORY_COMPLETED, output);
export const getSpecifiCategoryError = () =>
  action(ActionTypes.GET_SPECIFI_CATEGORY_ERROR);

//////////////////////////////////////////////////////////////////////////////////
export const getSpecifiCategoryUnitStart = () =>
  action(ActionTypes.GET_SPECIFI_CATEGORY_UNIT_START);
export const getSpecifiCategoryUnitCompleted = (
  output: SpecificationsCategoryDto[]
) => action(ActionTypes.GET_SPECIFI_CATEGORY_UNIT_COMPLETED, output);
export const getSpecifiCategoryUnitError = () =>
  action(ActionTypes.GET_SPECIFI_CATEGORY_UNIT_ERROR);

/////////////////////////////////////////////////////////////////////////////////
export const setProductsStart = (input: ProductDtos) =>
  action(ActionTypes.SET_PRODUCT_DTOS, input);

/////////////////////////////////////////////////////////////////////////////////
export const createProductsStart = (input: CreateProductDtos) =>
  action(ActionTypes.CREATE_PRODUCT_START, input);
export const createProductsCompleted = () =>
  action(ActionTypes.CREATE_PRODUCT_COMPLETED);
export const createProductsError = () =>
  action(ActionTypes.CREATE_PRODUCT_ERROR);
