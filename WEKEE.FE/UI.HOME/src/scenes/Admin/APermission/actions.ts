import { Key } from 'react';
import { action } from 'typesafe-actions';
import { PagedListOutput } from '../../../services/dto/pagedListOutput';
import { SearchOrderPageInput } from '../../../services/dto/searchOrderPageInput';
import ActionTypes from './constants';
import { AtomicLstChangeDto } from './dto/atomicLstChangeDto';
import { AtomicReadDto } from './dto/atomicReadDto';
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
//#region GET_RESOURCE
export const getAtomicStart = (input: SearchOrderPageInput) =>
    action(ActionTypes.GET_ATOMIC_START, input);
export const getAtomicCompleted = (output: PagedListOutput<AtomicReadDto>) =>
    action(ActionTypes.GET_ATOMIC_COMPLETED, output);
export const getAtomicError = () =>
    action(ActionTypes.GET_ATOMIC_ERROR);
//#endregion
//#region DELETE_ATOMIC
export const deleteAtomicStart = (input: Key[]) =>
    action(ActionTypes.DELETE_ATOMIC_START, input);
export const deleteAtomicCompleted = (output: number) =>
    action(ActionTypes.DELETE_ATOMIC_COMPLETED, output);
export const deleteAtomicError = () =>
    action(ActionTypes.DELETE_ATOMIC_ERROR);
//#endregion
//#region EDIT_STATUS_ATOMIC
export const editStatusAtomicStart = (input: AtomicLstChangeDto) =>
    action(ActionTypes.EDIT_STATUS_ATOMIC_START, input);
export const editStatusAtomicCompleted = (output: number) =>
    action(ActionTypes.EDIT_STATUS_ATOMIC_COMPLETED, output);
export const editStatusAtomicError = () =>
    action(ActionTypes.EDIT_STATUS_ATOMIC_ERROR);
//#endregion
//#region INSERT_OR_UPDATE_ATOMIC
export const insertOrUpdateAtomicStart = (input: AtomicReadDto) =>
    action(ActionTypes.INSERT_OR_UPDATE_ATOMIC_START, input);
export const insertOrUpdateAtomicCompleted = (output: number) =>
    action(ActionTypes.INSERT_OR_UPDATE_ATOMIC_COMPLETED, output);
export const insertOrUpdateAtomicError = () =>
    action(ActionTypes.INSERT_OR_UPDATE_ATOMIC_ERROR);
//#endregion
