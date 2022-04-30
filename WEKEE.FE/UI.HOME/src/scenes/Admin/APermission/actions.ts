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
import { RoleLstChangeDto } from './dto/roleLstChangeDto';
import { RoleReadDto } from './dto/roleReadDto';
import { RoleSummaryReadDto } from './dto/roleSummaryReadDto';
import { SubjectLstChangeDto } from './dto/subjectLstChangeDto';
import { SubjectReadDto } from './dto/subjectReadDto';
import { UserProfileCompactReadDto } from './dto/userProfileCompactReadDto';

//#region GET_USER_PROFILE
export const getUserProfileStart = (input: SearchTextInput) =>
    action(ActionTypes.GET_USER_PROFILE_START, input);
export const getUserProfileCompleted = (output: UserProfileCompactReadDto[]) =>
    action(ActionTypes.GET_USER_PROFILE_COMPLETED, output);
export const getUserProfileError = () =>
    action(ActionTypes.GET_USER_PROFILE_ERROR);
//#endregion

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

//#region GET_ROLE
export const getRoleStart = (input: SearchOrderPageInput) =>
    action(ActionTypes.GET_ROLE_START, input);
export const getRoleCompleted = (output: PagedListOutput<RoleReadDto>) =>
    action(ActionTypes.GET_ROLE_COMPLETED, output);
export const getRoleError = () =>
    action(ActionTypes.GET_ROLE_ERROR);
//#endregion
//#region DELETE_ROLE
export const deleteRoleStart = (input: Key[]) =>
    action(ActionTypes.DELETE_ROLE_START, input);
export const deleteRoleCompleted = (output: number) =>
    action(ActionTypes.DELETE_ROLE_COMPLETED, output);
export const deleteRoleError = () =>
    action(ActionTypes.DELETE_ROLE_ERROR);
//#endregion
//#region EDIT_STATUS_ROLE
export const editStatusRoleStart = (input: RoleLstChangeDto) =>
    action(ActionTypes.EDIT_STATUS_ROLE_START, input);
export const editStatusRoleCompleted = (output: number) =>
    action(ActionTypes.EDIT_STATUS_ROLE_COMPLETED, output);
export const editStatusRoleError = () =>
    action(ActionTypes.EDIT_STATUS_ROLE_ERROR);
//#endregion
//#region INSERT_OR_UPDATE_ROLE
export const insertOrUpdateRoleStart = (input: RoleReadDto) =>
    action(ActionTypes.INSERT_OR_UPDATE_ROLE_START, input);
export const insertOrUpdateRoleCompleted = (output: number) =>
    action(ActionTypes.INSERT_OR_UPDATE_ROLE_COMPLETED, output);
export const insertOrUpdateRoleError = () =>
    action(ActionTypes.INSERT_OR_UPDATE_ROLE_ERROR);
//#endregion
//#region SEARCH_SUMMARY_ROLE
export const searchSummaryRoleStart = (input: SearchTextInput) =>
    action(ActionTypes.SEARCH_SUMMARY_ROLE_START, input);
export const searchSummaryRoleCompleted = (output: RoleSummaryReadDto[]) =>
    action(ActionTypes.SEARCH_SUMMARY_ROLE_COMPLETED, output);
export const searchSummaryRoleError = () =>
    action(ActionTypes.SEARCH_SUMMARY_ROLE_ERROR);
//#endregion

//#region GET_SUBJECT
export const getSubjectStart = (input: SearchOrderPageInput) =>
    action(ActionTypes.GET_SUBJECT_START, input);
export const getSubjectCompleted = (output: PagedListOutput<SubjectReadDto>) =>
    action(ActionTypes.GET_SUBJECT_COMPLETED, output);
export const getSubjectError = () =>
    action(ActionTypes.GET_SUBJECT_ERROR);
//#endregion
//#region DELETE_SUBJECT
export const deleteSubjectStart = (input: Key[]) =>
    action(ActionTypes.DELETE_SUBJECT_START, input);
export const deleteSubjectCompleted = (output: number) =>
    action(ActionTypes.DELETE_SUBJECT_COMPLETED, output);
export const deleteSubjectError = () =>
    action(ActionTypes.DELETE_SUBJECT_ERROR);
//#endregion
//#region EDIT_STATUS_SUBJECT
export const editStatusSubjectStart = (input: SubjectLstChangeDto) =>
    action(ActionTypes.EDIT_STATUS_SUBJECT_START, input);
export const editStatusSubjectCompleted = (output: number) =>
    action(ActionTypes.EDIT_STATUS_SUBJECT_COMPLETED, output);
export const editStatusSubjectError = () =>
    action(ActionTypes.EDIT_STATUS_SUBJECT_ERROR);
//#endregion
//#region INSERT_OR_UPDATE_SUBJECT
export const insertOrUpdateSubjectStart = (input: SubjectReadDto) =>
    action(ActionTypes.INSERT_OR_UPDATE_SUBJECT_START, input);
export const insertOrUpdateSubjectCompleted = (output: number) =>
    action(ActionTypes.INSERT_OR_UPDATE_SUBJECT_COMPLETED, output);
export const insertOrUpdateSubjectError = () =>
    action(ActionTypes.INSERT_OR_UPDATE_SUBJECT_ERROR);
//#endregion
