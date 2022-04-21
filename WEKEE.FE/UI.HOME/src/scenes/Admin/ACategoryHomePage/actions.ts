import { action } from 'typesafe-actions';
import { PagedListOutput } from '../../../services/dto/pagedListOutput';
import { SearchOrderPageInput } from '../../../services/dto/searchOrderPageInput';
import { CategoryHomePageReadDto } from './dto/categoryHomePageReadDto';
import ActionTypes from './constants';

//#region Get category
export const getCategoryAdminStart = (input : SearchOrderPageInput) =>
action(ActionTypes.GET_CATEGORY_ADMIN_START,input)
export const getCategoryAdminCompleted  = (output: PagedListOutput<CategoryHomePageReadDto>) =>
action(ActionTypes.GET_CATEGORY_ADMIN_COMPLETED,output)
export const getCategoryAdminError = () =>
action(ActionTypes.GET_CATEGORY_ADMIN_ERROR)

//#endregion