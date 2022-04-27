import { Key } from 'react';
import { action } from 'typesafe-actions';
import { PagedListOutput } from '../../services/dto/pagedListOutput';
import { SearchOrderPageInput } from '../../services/dto/searchOrderPageInput';
import ActionTypes from './constants';
import { ResourceLstChangeDto } from './dto/resourceLstChangeDto';
import { ResourceReadDto } from './dto/resourceReadDto';

//#region GET_RESOURCE
export const getResourceStart = (input: SearchOrderPageInput) =>
    action(ActionTypes.GET_RESOURCE_START, input);
export const getResourceCompleted = (output: PagedListOutput<ResourceReadDto>) =>
    action(ActionTypes.GET_RESOURCE_COMPLETED, output);
export const getResourceError = () =>
    action(ActionTypes.GET_RESOURCE_ERROR);
//#endregion
//#region DELETE_RESOURCE
export const deleteResourceStart = (input: Key[]) =>
    action(ActionTypes.DELETE_RESOURCE_START, input);
export const deleteResourceCompleted = (output: number) =>
    action(ActionTypes.DELETE_RESOURCE_COMPLETED, output);
export const deleteResourceError = () =>
    action(ActionTypes.DELETE_RESOURCE_ERROR);
//#endregion
//#region EDIT_STATUS_RESOURCE
export const editStatusResourceStart = (input: ResourceLstChangeDto) =>
    action(ActionTypes.EDIT_STATUS_RESOURCE_START, input);
export const editStatusResourceCompleted = (output: number) =>
    action(ActionTypes.EDIT_STATUS_RESOURCE_COMPLETED, output);
export const editStatusResourceError = () =>
    action(ActionTypes.EDIT_STATUS_RESOURCE_ERROR);
//#endregion
//#region INSERT_OR_UPDATE_RESOURCE
export const insertOrUpdateResourceStart = (input: ResourceReadDto) =>
    action(ActionTypes.INSERT_OR_UPDATE_RESOURCE_START, input);
export const insertOrUpdateResourceCompleted = (output: number) =>
    action(ActionTypes.INSERT_OR_UPDATE_RESOURCE_COMPLETED, output);
export const insertOrUpdateResourceError = () =>
    action(ActionTypes.INSERT_OR_UPDATE_RESOURCE_ERROR);
//#endregion