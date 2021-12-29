import { action } from 'typesafe-actions';
import { OrderByListInput } from '../../services/dto/orderByListInput';
import { PagedListOutput } from '../../services/dto/pagedListOutput';
import { IdPagedListInput } from '../../services/dto/idPagedListInput';

import ActionTypes from './constants';
import { ActionDto } from './dtos/actionDto';
import { AtomicDto } from './dtos/atomicDto';
import { PermissionDto } from './dtos/permissionDto';
import { ResourceActionDto } from './dtos/resourceActionDto';
import { ResourceDto } from './dtos/resourceDto';
import { RoleDto } from './dtos/roleDto';
import { ActionAssignmentDto } from './dtos/actionAssignmentDto';
import { PermissionAssignmentDto } from './dtos/permissionAssignmentDto';
import { SearchOrderPageInput } from '../../services/dto/searchOrderPageInput';

//#region Tải dữ liệu ban đầu
export const watchPageError = () =>
    action(ActionTypes.WATCH_PAGE_ERROR);
//#endregion

//#region resource
export const listFormResourceStart = (input: SearchOrderPageInput) =>
    action(ActionTypes.LIST_FORM_RESOURCE_START, input);
export const listFormResourceCompleted = (output: PagedListOutput<ResourceDto>) =>
    action(ActionTypes.LIST_FORM_RESOURCE_COMPLETED, output);
export const listFormResourceError = () =>
    action(ActionTypes.LIST_FORM_RESOURCE_ERROR);

export const ResourceCreateStart = (input: ResourceDto) =>
    action(ActionTypes.RESOURCE_CREATE_ITEM_START, input);
export const ResourceCreateCompleted = () =>
    action(ActionTypes.RESOURCE_CREATE_ITEM_COMPLETED);
export const ResourceCreateError = () =>
    action(ActionTypes.RESOURCE_CREATE_ITEM_ERROR);

export const ResourceEditStart = (input: ResourceDto) =>
    action(ActionTypes.RESOURCE_EDIT_ITEM_START, input);
export const ResourceEditCompleted = () =>
    action(ActionTypes.RESOURCE_EDIT_ITEM_COMPLETED);
export const ResourceEditError = () =>
    action(ActionTypes.RESOURCE_EDIT_ITEM_ERROR);

export const ResourceRemoveFeStart = (id: Number, types: number) =>
    action(ActionTypes.RESOURCE_REMOVE_FE_ITEM_START, { id, types });
export const ResourceRemoveFeCancel = () =>
    action(ActionTypes.RESOURCE_REMOVE_FE_ITEM_CANCEL);

export const ResourceRemoveStart = (ids: Number[], types: Number) => {
    if(ids.length===0)
    {
        return action(ActionTypes.RESOURCE_REMOVE_FE_ITEM_CANCEL);
    }
    
    if (types == 1) {
        return action(ActionTypes.RESOURCE_REMOVE_START, ids);
    }
    if(types==2)
    {
        return action(ActionTypes.RESOURCE_EDIT_STATUS_START, ids);
    }
    return action(ActionTypes.RESOURCE_REMOVE_FE_ITEM_CANCEL);
}
export const ResourceRemoveCompleted = (output: Number) =>
    action(ActionTypes.RESOURCE_REMOVE_COMPLETED, output);
export const ResourceRemoveError = () =>
    action(ActionTypes.RESOURCE_REMOVE_ERROR);

export const ResourceEditStatusCompleted = (output: Number) =>
    action(ActionTypes.RESOURCE_EDIT_STATUS_COMPLETED, output);
export const ResourceEditStatusError = () =>
    action(ActionTypes.RESOURCE_EDIT_STATUS_ERROR);

//#endregion

//#region  Atomic
export const AtomicgetListStart = (input : SearchOrderPageInput) =>
    action(ActionTypes.ATOMIC_LIST_START, input);
export const AtomicgetListCompleted = (output: PagedListOutput<AtomicDto>) =>
    action(ActionTypes.ATOMIC_LIST_COMPLETED, output);
export const AtomicgetListError = () =>
    action(ActionTypes.ATOMIC_LIST_ERROR);
//#endregion

//#region Action
export const listFormActionStart = (input: SearchOrderPageInput) =>
    action(ActionTypes.ACTION_LIST_FORM_START, input);
export const listFormActionCompleted = (output: PagedListOutput<ActionDto>) =>
    action(ActionTypes.ACTION_LIST_FORM_COMPLETED, output);
export const listFormActionError = () =>
    action(ActionTypes.ACTION_LIST_FORM_ERROR);

export const ActionCreateStart = (input: ActionDto) =>
    action(ActionTypes.ACTION_CREATE_ITEM_START, input);
export const ActionCreateCompleted = () =>
    action(ActionTypes.ACTION_CREATE_ITEM_COMPLETED);
export const ActionCreateError = () =>
    action(ActionTypes.ACTION_CREATE_ITEM_ERROR);

export const ActionEditStart = (input: ActionDto) =>
    action(ActionTypes.ACTION_EDIT_ITEM_START, input);
export const ActionEditCompleted = () =>
    action(ActionTypes.ACTION_EDIT_ITEM_COMPLETED);
export const ActionEditError = () =>
    action(ActionTypes.ACTION_EDIT_ITEM_ERROR);

export const ActionRemoveFeStart = (id: Number) =>
    action(ActionTypes.ACTION_REMOVE_FE_ITEM_START, id);
export const ActionRemoveFeCancel = () =>
    action(ActionTypes.ACTION_REMOVE_FE_ITEM_CANCEL);

export const ActionRemoveStart = (ids: Number[]) =>
    action(ActionTypes.ACTION_REMOVE_START, ids);
export const ActionRemoveCompleted = (output: Number) =>
    action(ActionTypes.ACTION_REMOVE_COMPLETED, output);
export const ActionRemoveError = () =>
    action(ActionTypes.ACTION_REMOVE_ERROR);

//#endregion

//#region Permission
export const listFormPermissionStart = (input: SearchOrderPageInput) =>
    action(ActionTypes.PERMISSION_LIST_FORM_START, input);
export const listFormPermissionCompleted = (output: PagedListOutput<PermissionDto>) =>
    action(ActionTypes.PERMISSION_LIST_FORM_COMPLETED, output);
export const listFormPermissionError = () =>
    action(ActionTypes.PERMISSION_LIST_FORM_ERROR);

export const PermissionCreateStart = (input: PermissionDto) =>
    action(ActionTypes.PERMISSION_CREATE_ITEM_START, input);
export const PermissionCreateCompleted = () =>
    action(ActionTypes.PERMISSION_CREATE_ITEM_COMPLETED);
export const PermissionCreateError = () =>
    action(ActionTypes.PERMISSION_CREATE_ITEM_ERROR);

export const PermissionEditStart = (input: PermissionDto) =>
    action(ActionTypes.PERMISSION_EDIT_ITEM_START, input);
export const PermissionEditCompleted = () =>
    action(ActionTypes.PERMISSION_EDIT_ITEM_COMPLETED);
export const PermissionEditError = () =>
    action(ActionTypes.PERMISSION_EDIT_ITEM_ERROR);

export const PermissionRemoveFeStart = (id: Number) =>
    action(ActionTypes.PERMISSION_REMOVE_FE_ITEM_START, id);
export const PermissionRemoveFeCancel = () =>
    action(ActionTypes.PERMISSION_REMOVE_FE_ITEM_CANCEL);

export const PermissionRemoveStart = (ids: Number[]) =>
    action(ActionTypes.PERMISSION_REMOVE_START, ids);
export const PermissionRemoveCompleted = (output: Number) =>
    action(ActionTypes.PERMISSION_REMOVE_COMPLETED, output);
export const PermissionRemoveError = () =>
    action(ActionTypes.PERMISSION_REMOVE_ERROR);

//#endregion

//#region Role
export const listFormRoleStart = (input: SearchOrderPageInput) =>
    action(ActionTypes.ROLE_LIST_FORM_START, input);
export const listFormRoleCompleted = (output: PagedListOutput<RoleDto>) =>
    action(ActionTypes.ROLE_LIST_FORM_COMPLETED, output);
export const listFormRoleError = () =>
    action(ActionTypes.ROLE_LIST_FORM_ERROR);

export const RoleCreateStart = (input: RoleDto) =>
    action(ActionTypes.ROLE_CREATE_ITEM_START, input);
export const RoleCreateCompleted = () =>
    action(ActionTypes.ROLE_CREATE_ITEM_COMPLETED);
export const RoleCreateError = () =>
    action(ActionTypes.ROLE_CREATE_ITEM_ERROR);

export const RoleEditStart = (input: RoleDto) =>
    action(ActionTypes.ROLE_EDIT_ITEM_START, input);
export const RoleEditCompleted = () =>
    action(ActionTypes.ROLE_EDIT_ITEM_COMPLETED);
export const RoleEditError = () =>
    action(ActionTypes.ROLE_EDIT_ITEM_ERROR);

export const RoleRemoveFeStart = (id: Number) =>
    action(ActionTypes.ROLE_REMOVE_FE_ITEM_START, id);
export const RoleRemoveFeCancel = () =>
    action(ActionTypes.ROLE_REMOVE_FE_ITEM_CANCEL);

export const RoleRemoveStart = (ids: Number[]) =>
    action(ActionTypes.ROLE_REMOVE_START, ids);
export const RoleRemoveCompleted = (output: Number) =>
    action(ActionTypes.ROLE_REMOVE_COMPLETED, output);
export const RoleRemoveError = () =>
    action(ActionTypes.ROLE_REMOVE_ERROR);

//#endregion

//#region  Resource-Action
export const ResourceActionGetListDataStart = (input: IdPagedListInput) =>
    action(ActionTypes.ACTION_RESOURCE_LIST_START, input);
export const ResourceActionGetListDataCompeleted = (output: PagedListOutput<ResourceActionDto>) =>
    action(ActionTypes.ACTION_RESOURCE_LIST_COMPELETED, output);
export const ResourceActionGetListDataError = () =>
    action(ActionTypes.ACTION_RESOURCE_LIST_ERROR);

export const ResourceActionInsertOrUpdateStart = (input: ResourceActionDto) =>
    action(ActionTypes.RESOURCE_ACTION_INSERT_OR_UPDATE_START, input);
export const ResourceActionInsertOrUpdateCompeleted = (output: ResourceActionDto) =>
    action(ActionTypes.RESOURCE_ACTION_INSERT_OR_UPDATE_COMPELETED, output);
export const ResourceActionInsertOrUpdateError = () =>
    action(ActionTypes.RESOURCE_ACTION_INSERT_OR_UPDATE_ERROR);
//#endregion

//#region  ActionAssignment
export const ActionAssignmentGetListDataStart = (input: IdPagedListInput) =>
    action(ActionTypes.ACTION_ASSIGNMENT_GET_LIST_DATA_START, input);
export const ActionAssignmentGetListDataCompeleted = (output: PagedListOutput<ActionAssignmentDto>) =>
    action(ActionTypes.ACTION_ASSIGNMENT_GET_LIST_DATA_COMPELETED, output);
export const ActionAssignmentGetListDataError = () =>
    action(ActionTypes.ACTION_ASSIGNMENT_GET_LIST_DATA_ERROR);

export const ActionAssignmentInsertOrUpdateStart = (input: ActionAssignmentDto) =>
    action(ActionTypes.ACTION_ASSIGNMENT_INSERT_OR_UPDATE_START, input);
export const ActionAssignmentInsertOrUpdateCompeleted = (output: ActionAssignmentDto) =>
    action(ActionTypes.ACTION_ASSIGNMENT_INSERT_OR_UPDATE_COMPELETED, output);
export const ActionAssignmentInsertOrUpdateError = () =>
    action(ActionTypes.ACTION_ASSIGNMENT_INSERT_OR_UPDATE_ERROR);
//#endregion

//#region  PermissionAssignment
export const PermissionAssignmentGetListDataStart = (input: IdPagedListInput) =>
    action(ActionTypes.PERMISSION_ASSIGNMENT_GET_LIST_DATA_START, input);
export const PermissionAssignmentGetListDataCompeleted = (output: PagedListOutput<PermissionAssignmentDto>) =>
    action(ActionTypes.PERMISSION_ASSIGNMENT_GET_LIST_DATA_COMPELETED, output);
export const PermissionAssignmentGetListDataError = () =>
    action(ActionTypes.PERMISSION_ASSIGNMENT_GET_LIST_DATA_ERROR);

export const PermissionAssignmentInsertOrUpdateStart = (input: PermissionAssignmentDto) =>
    action(ActionTypes.PERMISSION_ASSIGNMENT_INSERT_OR_UPDATE_START, input);
export const PermissionAssignmentInsertOrUpdateCompeleted = (output: PermissionAssignmentDto) =>
    action(ActionTypes.PERMISSION_ASSIGNMENT_INSERT_OR_UPDATE_COMPELETED, output);
export const PermissionAssignmentInsertOrUpdateError = () =>
    action(ActionTypes.PERMISSION_ASSIGNMENT_INSERT_OR_UPDATE_ERROR);
//#endregion