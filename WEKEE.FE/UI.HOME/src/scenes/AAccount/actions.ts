import { action } from 'typesafe-actions';
import { SearchOrderPageInput } from '../../services/dto/searchOrderPageInput';
import { PagedListOutput } from '../../services/dto/pagedListOutput';

import ActionTypes from './constants';
import { AccountAdminCreate } from './dtos/accountAdminCreate';
import { AccountShowDtos } from './dtos/accountShowDtos';
import { SubjectDtos } from './dtos/subjectDtos';
import { SubjectAssignmentDto } from './dtos/subjectAssignmentDto';
// open page login
export const watchPageStart = () =>
    action(ActionTypes.WATCH_PAGE_START);
export const watchPageCompleted = () =>
    action(ActionTypes.WATCH_PAGE_COMPLETED);
export const watchPageError = () =>
    action(ActionTypes.WATCH_PAGE_ERROR);
export const removeAvatarUploadStart = (input: String) =>
    action(ActionTypes.REMOVE_AVATAR_UPLOAD_START, input);

//#region  create account
export const createAccountAdminStart = (input: AccountAdminCreate) =>
    action(ActionTypes.CREATE_ACCOUNT_ADMIN_START, input);
export const createAccountAdminComplete = (input: number) =>
    action(ActionTypes.CREATE_ACCOUNT_ADMIN_COMPLETED, input);
export const createAccountAdminError = () =>
    action(ActionTypes.CREATE_ACCOUNT_ADMIN_ERROR);

export const listAccountAdminStart = (input: SearchOrderPageInput) =>
    action(ActionTypes.LIST_ACCOUNT_ADMIN_START, input);
export const listAccountAdminComplete = (input: PagedListOutput<AccountShowDtos>) =>
    action(ActionTypes.LIST_ACCOUNT_ADMIN_COMPLETED, input);
export const listAccountAdminError = () =>
    action(ActionTypes.LIST_ACCOUNT_ADMIN_ERROR);

export const listSubjectStart = (input: Number) =>
    action(ActionTypes.LIST_SUBJECT_ID_ACCOUNT_START, input);
export const listSubjecComplete = (input: SubjectDtos[]) =>
    action(ActionTypes.LIST_SUBJECT_ID_ACCOUNT_COMPLETED, input);
export const listSubjecError = () =>
    action(ActionTypes.LIST_SUBJECT_ID_ACCOUNT_ERROR);

export const listSubjectAssignStart = (input: Number) =>
    action(ActionTypes.LIST_SUBJECT_ASSIGN_DTO_START, input);
export const listSubjectAssignComplete = (input: PagedListOutput<SubjectAssignmentDto>) =>
    action(ActionTypes.LIST_SUBJECT_ASSIGN_DTO_COMPLETED, input);
export const listSubjectAssignError = () =>
    action(ActionTypes.LIST_SUBJECT_ASSIGN_DTO_ERROR);

export const changPermissionAccountStart = (idSubject: Number, idRole: Number) =>
    action(ActionTypes.CHANGE_PERMISSION_ACCOUNT_START, { idSubject, idRole });
export const changPermissionAccountComplete = (inSubject: Number, idRole: Number) =>
    action(ActionTypes.CHANGE_PERMISSION_ACCOUNT_COMPLETED, { inSubject, idRole });
export const changPermissionAccountError = () =>
    action(ActionTypes.CHANGE_PERMISSION_ACCOUNT_ERROR);

export const deleteAccountStart = (id: Number) =>
    action(ActionTypes.DELETE_ACCOUNT_START, id);
export const deleteAccountComplete = (id: Number) =>
    action(ActionTypes.DELETE_ACCOUNT_COMPLETED,id);
export const deleteAccountError = () =>
    action(ActionTypes.DELETE_ACCOUNT_ERROR);
//#endregion
