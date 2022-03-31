import { action } from "typesafe-actions";
import { PagedListOutput } from "../../../services/dto/pagedListOutput";
import { SearchOrderPageInput } from "../../../services/dto/searchOrderPageInput";

import ActionTypes from "./constants";
import { CategoryProductReadMapDto } from "./dtos/CategoryProductReadMapDto";
import { SpecificationAttributeInsertDto } from "./dtos/SpecificationAttributeInsertDto";
import { SpecificationAttributeReadDto } from "./dtos/SpecificationAttributeReadDto";

//#region Create Spec 
export const createSpecificationsStart = (input: SpecificationAttributeInsertDto) =>
  action(ActionTypes.CREATE_SPECIFICATIONS_START, input);
export const createSpecificationsCompleted = (output: number) =>
  action(ActionTypes.CREATE_SPECIFICATIONS_COMPLETED, output);
export const createSpecificationsError = () =>
  action(ActionTypes.CREATE_SPECIFICATIONS_ERROR);
 //#endregion

//#region  Category map  
export const CategoryMapStart = () =>
  action(ActionTypes.CATEGORY_MAP_START)
export const CategoryMapCompleted = (output: CategoryProductReadMapDto[]) =>
  action(ActionTypes.CATEGORY_MAP_COMPLETED, output)
export const CategoryMapError = () =>
  action(ActionTypes.CATEGORY_MAP_ERROR)
//#endregion

//#region SPECIFICATIONS_GET_PAGE_LIST 
export const GetPageListSpecificationStart = (input: SearchOrderPageInput) =>
  action(ActionTypes.SPECIFICATIONS_GET_PAGE_LIST_START, input);
export const GetPageListSpecificationCompleted = (output: PagedListOutput<SpecificationAttributeReadDto>) =>
  action(ActionTypes.SPECIFICATIONS_GET_PAGE_LIST_COMPLETED, output);
export const GetPageListSpecificationError = () =>
  action(ActionTypes.SPECIFICATIONS_GET_PAGE_LIST_ERROR);
//#endregion