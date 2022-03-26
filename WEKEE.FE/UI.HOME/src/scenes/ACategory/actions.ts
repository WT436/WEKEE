import { action } from 'typesafe-actions';
import { CategoryProductReadDto } from './dtos/CategoryProductReadDto'

import ActionTypes from './constants';
import { CategoryProductReadMapDto } from './dtos/CategoryProductReadMapDto';
import {SearchOrderPageInput} from '../../services/dto/searchOrderPageInput'
import { PagedListOutput } from '../../services/dto/pagedListOutput';
import { CategoryProductInsertDto } from './dtos/CategoryProductInsertDto';
// open page login
export const watchPageStart = () => action(ActionTypes.WATCH_PAGE_START);
export const watchPageCompleted = () => action(ActionTypes.WATCH_PAGE_COMPLETED);
export const watchPageError = () => action(ActionTypes.WATCH_PAGE_ERROR);

export const createCategoryAdminStart = (input:CategoryProductInsertDto) =>
action(ActionTypes.CREATE_CATEGORY_ADMIN_START,input)
export const createCategoryAdminCompleted  = (output:number) =>
action(ActionTypes.CREATE_CATEGORY_ADMIN_COMPLETED,output)
export const createCategoryAdminError = () =>
action(ActionTypes.CREATE_CATEGORY_ADMIN_ERROR)

//#region Get category
export const getCategoryAdminStart = (input : SearchOrderPageInput) =>
action(ActionTypes.GET_CATEGORY_ADMIN_START,input)
export const getCategoryAdminCompleted  = (output: PagedListOutput<CategoryProductReadDto>) =>
action(ActionTypes.GET_CATEGORY_ADMIN_COMPLETED,output)
export const getCategoryAdminError = () =>
action(ActionTypes.GET_CATEGORY_ADMIN_ERROR)
//#endregion

//#region  Category map  
export const CategoryMapStart = () =>
action(ActionTypes.CATEGORY_MAP_START)
export const CategoryMapCompleted  = (output:CategoryProductReadMapDto[]) =>
action(ActionTypes.CATEGORY_MAP_COMPLETED,output)
export const CategoryMapError = () =>
action(ActionTypes.CATEGORY_MAP_ERROR)
//#endregion