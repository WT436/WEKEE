import { action } from 'typesafe-actions';
import { CategoryDtos } from './dtos/categoryDtos'

import ActionTypes from './constants';
// open page login
export const watchPageStart = () => action(ActionTypes.WATCH_PAGE_START);
export const watchPageCompleted = () => action(ActionTypes.WATCH_PAGE_COMPLETED);
export const watchPageError = () => action(ActionTypes.WATCH_PAGE_ERROR);

export const createCategoryAdminStart = (input:CategoryDtos) =>
action(ActionTypes.CREATE_CATEGORY_ADMIN_START,input)
export const createCategoryAdminCompleted  = (output:number) =>
action(ActionTypes.CREATE_CATEGORY_ADMIN_COMPLETED,output)
export const createCategoryAdminError = () =>
action(ActionTypes.CREATE_CATEGORY_ADMIN_ERROR)

export const getCategoryAdminStart = (level:Number,categorymain:Number,orderNumber:Number) =>
action(ActionTypes.GET_CATEGORY_ADMIN_START,{level,categorymain,orderNumber})
export const getCategoryAdminCompleted  = (output:CategoryDtos[]) =>
action(ActionTypes.GET_CATEGORY_ADMIN_COMPLETED,output)
export const getCategoryAdminError = () =>
action(ActionTypes.GET_CATEGORY_ADMIN_ERROR)