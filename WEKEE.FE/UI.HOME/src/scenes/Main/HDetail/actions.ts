import { action } from "typesafe-actions";
import ActionTypes from "./constants";
import { CartBasicProductDto } from "./dtos/cartBasicProductDto";
import { CategoryBreadcrumbDtos } from "./dtos/categoryBreadcrumbDtos";
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
