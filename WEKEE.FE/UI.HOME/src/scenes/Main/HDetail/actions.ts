import { action } from "typesafe-actions";
import ActionTypes from "./constants";
import { CategoryBreadcrumbDtos } from "./dtos/categoryBreadcrumbDtos";
// open page login
export const getCategoryBreadcrumbStart = (id: number) =>
  action(ActionTypes.GET_CATEGORY_BREADCRUMB_START, id);
export const getCategoryBreadcrumbCompleted = (
  output: CategoryBreadcrumbDtos[]
) => action(ActionTypes.GET_CATEGORY_BREADCRUMB_COMPLETED, output);
export const getCategoryBreadcrumbError = () =>
  action(ActionTypes.GET_CATEGORY_BREADCRUMB_ERROR);