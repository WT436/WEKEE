import { Key } from 'react';
import { action } from 'typesafe-actions';
import { PagedListOutput } from '../../../services/dto/pagedListOutput';
import { SearchOrderPageInput } from '../../../services/dto/searchOrderPageInput';
import { SearchTextInput } from '../../../services/dto/searchTextInput';
import ActionTypes from './constants';
import { AtomicLstChangeDto } from './dto/atomicLstChangeDto';
import { AtomicReadDto } from './dto/atomicReadDto';
import { AtomicSummaryReadDto } from './dto/atomicSummaryReadDto';
import { PermissionLstChangeDto } from './dto/permissionLstChangeDto';
import { PermissionReadDto } from './dto/permissionReadDto';
import { PermissionSummaryReadDto } from './dto/permissionSummaryReadDto';
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

//#region GET_ATOMIC
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
//#region SUMMARY_ATOMIC
export const summaryAtomicStart = () =>
    action(ActionTypes.SUMMARY_ATOMIC_START);
export const summaryAtomicCompleted = (output: AtomicSummaryReadDto[]) =>
    action(ActionTypes.SUMMARY_ATOMIC_COMPLETED, output);
export const summaryAtomicError = () =>
    action(ActionTypes.SUMMARY_ATOMIC_ERROR);
//#endregion

//#region GET_PERMISSION
export const getPermissionStart = (input: SearchOrderPageInput) =>
    action(ActionTypes.GET_PERMISSION_START, input);
export const getPermissionCompleted = (output: PagedListOutput<PermissionReadDto>) =>
    action(ActionTypes.GET_PERMISSION_COMPLETED, output);
export const getPermissionError = () =>
    action(ActionTypes.GET_PERMISSION_ERROR);
//#endregion
//#region DELETE_PERMISSION
export const deletePermissionStart = (input: Key[]) =>
    action(ActionTypes.DELETE_PERMISSION_START, input);
export const deletePermissionCompleted = (output: number) =>
    action(ActionTypes.DELETE_PERMISSION_COMPLETED, output);
export const deletePermissionError = () =>
    action(ActionTypes.DELETE_PERMISSION_ERROR);
//#endregion
//#region EDIT_STATUS_PERMISSION
export const editStatusPermissionStart = (input: PermissionLstChangeDto) =>
    action(ActionTypes.EDIT_STATUS_PERMISSION_START, input);
export const editStatusPermissionCompleted = (output: number) =>
    action(ActionTypes.EDIT_STATUS_PERMISSION_COMPLETED, output);
export const editStatusPermissionError = () =>
    action(ActionTypes.EDIT_STATUS_PERMISSION_ERROR);
//#endregion
//#region INSERT_OR_UPDATE_PERMISSION
export const insertOrUpdatePermissionStart = (input: PermissionReadDto) =>
    action(ActionTypes.INSERT_OR_UPDATE_PERMISSION_START, input);
export const insertOrUpdatePermissionCompleted = (output: number) =>
    action(ActionTypes.INSERT_OR_UPDATE_PERMISSION_COMPLETED, output);
export const insertOrUpdatePermissionError = () =>
    action(ActionTypes.INSERT_OR_UPDATE_PERMISSION_ERROR);
//#endregion
//#region SEARCH_SUMMARY_PERMISSION
export const searchSummaryPermissionStart = (input: SearchTextInput) =>
    action(ActionTypes.SEARCH_SUMMARY_PERMISSION_START, input);
export const searchSummaryPermissionCompleted = (output: PermissionSummaryReadDto[]) =>
    action(ActionTypes.SEARCH_SUMMARY_PERMISSION_COMPLETED, output);
export const searchSummaryPermissionError = () =>
    action(ActionTypes.SEARCH_SUMMARY_PERMISSION_ERROR);
//#endregion

