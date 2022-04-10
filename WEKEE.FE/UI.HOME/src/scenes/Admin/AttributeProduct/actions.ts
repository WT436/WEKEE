//#region Import 
import { action } from 'typesafe-actions';
import { PagedListOutput } from '../../../services/dto/pagedListOutput';
import { SearchOrderPageInput } from '../../../services/dto/searchOrderPageInput';
import { ProductAttributeReadDto } from './dtos/productAttributeReadDto';
//#endregion

import ActionTypes from './constants';
import { ProductAttributeInsertDto } from './dtos/productAttributeInsertDto';
import { CateProReadIdAndNameDto } from './dtos/cateProReadIdAndNameDto';
// open page login
export const watchPageStart = () => action(ActionTypes.WATCH_PAGE_START);
export const watchPageCompleted = () => action(ActionTypes.WATCH_PAGE_COMPLETED);
export const watchPageError = () => action(ActionTypes.WATCH_PAGE_ERROR);

//#region GET_DATA_ATTRIBUTE_PRODUCT
export const getDataAttibuteProductStart = (input: SearchOrderPageInput) =>
    action(ActionTypes.GET_DATA_ATTRIBUTE_PRODUCT_START, input);
export const getDataAttibuteProductCompleted = (output: PagedListOutput<ProductAttributeReadDto>) =>
    action(ActionTypes.GET_DATA_ATTRIBUTE_PRODUCT_COMPLETED, output);
export const getDataAttibuteProductError = () =>
    action(ActionTypes.GET_DATA_ATTRIBUTE_PRODUCT_ERROR);
//#endregion

//#region CREATE_ATTRIBUTE_PRODUCT
export const createAttributeProductStart = (input: ProductAttributeInsertDto) =>
action(ActionTypes.CREATE_ATTRIBUTE_PRODUCT_START, input);
export const createAttributeProductCompleted = (output: Number) =>
action(ActionTypes.CREATE_ATTRIBUTE_PRODUCT_COMPLETED, output);
export const createAttributeProductError = () =>
action(ActionTypes.CREATE_ATTRIBUTE_PRODUCT_ERROR);
//#endregion

//#region LOAD_CATE_PRO
export const loadCateProStart = () =>
action(ActionTypes.LOAD_CATE_PRO_START);
export const loadCateProCompleted = (output: CateProReadIdAndNameDto[]) =>
action(ActionTypes.LOAD_CATE_PRO_COMPLETED, output);
export const loadCateProError = () =>
action(ActionTypes.LOAD_CATE_PRO_ERROR);
//#endregion

//#region LOAD_CREATE_BY_CATE
export const loadCreateByCateStart = () =>
action(ActionTypes.LOAD_CREATE_BY_CATE_START);
export const loadCreateByCateCompleted = (output: CateProReadIdAndNameDto[]) =>
action(ActionTypes.LOAD_CREATE_BY_CATE_COMPLETED, output);
export const loadCreateByCateError = () =>
action(ActionTypes.LOAD_CREATE_BY_CATE_ERROR);
//#endregion