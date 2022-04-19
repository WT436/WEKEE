import { action } from "typesafe-actions";
import ActionTypes from "./constants";
import { CartBasicProductDto } from "./dtos/cartBasicProductDto";
import { CategoryBreadcrumbDtos } from "./dtos/categoryBreadcrumbDtos";
import { FeatureProductContainerDto } from "./dtos/featureProductContainerDto";
import { ImageForProductDto } from "./dtos/imageForProductDto";
import { MainFeatureCheck } from "./dtos/mainFeatureCheckDto";
import { ProductReadForCartDto } from "./dtos/productReadForCartDto";

//#region KEY
export const MainCheckFeatureStart = (input: ProductReadForCartDto[]) =>
action(ActionTypes.MAIN_CHECK_FEATURE_START, input);
//#endregion
//#region GET_FEATURE_CART_PRODUCT 
export const getFeatureProductCartStart = (input: number) =>
  action(ActionTypes.GET_FEATURE_CART_PRODUCT_START, input);
export const getFeatureProductCartCompleted = (output: FeatureProductContainerDto[]) =>
  action(ActionTypes.GET_FEATURE_CART_PRODUCT_COMPLETED, output);
export const getFeatureProductCartError = () =>
  action(ActionTypes.GET_FEATURE_CART_PRODUCT_ERROR);
//#endregion
//#region GET_IMAGE_PRODUCT
export const getImageProductStart = (input: number) =>
  action(ActionTypes.GET_IMAGE_PRODUCT_START, input);
export const getImageProductCompleted = (output: ImageForProductDto[]) =>
  action(ActionTypes.GET_IMAGE_PRODUCT_COMPLETED, output);
export const getImageProductError = () =>
  action(ActionTypes.GET_IMAGE_PRODUCT_ERROR);
//#endregion
//#region GET_BASIC_PRODUCT_CART
export const getBasicCartProductStart = (input: number) =>
  action(ActionTypes.GET_BASIC_PRODUCT_CART_START, input);
export const getBasicCartProductCompleted = (output: CartBasicProductDto) =>
  action(ActionTypes.GET_BASIC_PRODUCT_CART_COMPLETED, output);
export const getBasicCartProductError = () =>
  action(ActionTypes.GET_BASIC_PRODUCT_CART_ERROR);
//#endregion
//#region GET_CATEGORY_BREADCRUMB 
export const getCategoryBreadcrumbStart = (id: number) =>
  action(ActionTypes.GET_CATEGORY_BREADCRUMB_START, id);
export const getCategoryBreadcrumbCompleted = (
  output: CategoryBreadcrumbDtos[]
) => action(ActionTypes.GET_CATEGORY_BREADCRUMB_COMPLETED, output);
export const getCategoryBreadcrumbError = () =>
  action(ActionTypes.GET_CATEGORY_BREADCRUMB_ERROR);
 //#endregion
