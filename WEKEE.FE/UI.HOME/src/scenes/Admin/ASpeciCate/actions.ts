import { action } from "typesafe-actions";

import ActionTypes from "./constants";
import { CategorySelectDto } from "./dtos/categorySelectDto";
import { SpecificationsCategoryDto } from "./dtos/specificationsCategoryDto";
// open page login
export const watchPageStart = () => action(ActionTypes.WATCH_PAGE_START);
export const watchPageCompleted = () =>
  action(ActionTypes.WATCH_PAGE_COMPLETED);
export const watchPageError = () => action(ActionTypes.WATCH_PAGE_ERROR);

export const getCategotyMainStart = () =>
  action(ActionTypes.GET_CATEGORY_MAIN_START);
export const getCategotyMainCompleted = (output: CategorySelectDto[]) =>
  action(ActionTypes.GET_CATEGORY_MAIN_COMPLETED, output);
export const getCategotyMainError = () =>
  action(ActionTypes.GET_CATEGORY_MAIN_ERROR);

export const createSpecificationsStart = (input: SpecificationsCategoryDto) =>
  action(ActionTypes.CREATE_SPECIFICATIONS_START, input);
export const createSpecificationsCompleted = (output: number) =>
  action(ActionTypes.CREATE_SPECIFICATIONS_COMPLETED, output);
export const createSpecificationsError = () =>
  action(ActionTypes.CREATE_SPECIFICATIONS_ERROR);

export const getNameKeySpecificationsStart = () =>
  action(ActionTypes.GET_NAME_KEY_SPECIFICATIONS_START);
export const getNameKeySpecificationsCompleted = (output: string[]) =>
  action(ActionTypes.GET_NAME_KEY_SPECIFICATIONS_COMPLETED, output);
export const getNameKeySpecificationsError = () =>
  action(ActionTypes.GET_NAME_KEY_SPECIFICATIONS_ERROR);

export const getNameClassifyValuesSpecificationsStart = (input: string) =>
  action(ActionTypes.GET_NAME_VALUES_SPECIFICATIONS_START, input);
export const getNameClassifyValuesSpecificationsCompleted = (
  output: string[]
) => action(ActionTypes.GET_NAME_VALUES_SPECIFICATIONS_COMPLETED, output);
export const getNameClassifyValuesSpecificationsError = () =>
  action(ActionTypes.GET_NAME_VALUES_SPECIFICATIONS_ERROR);

export const searchSpecificationsStart = (key: string, values: string) =>
  action(ActionTypes.SEARCH_SPECIFICATIONS_START, { key, values });
export const searchSpecificationsCompleted = (
  output: SpecificationsCategoryDto[]
) => action(ActionTypes.SEARCH_SPECIFICATIONS_COMPLETED, output);
export const searchSpecificationsError = () =>
  action(ActionTypes.SEARCH_SPECIFICATIONS_ERROR);
