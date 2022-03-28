import { createSelector } from 'reselect';

import { ApplicationRootState } from '../../../redux/types';
import { initialState } from './reducer';

const select = (state: ApplicationRootState) => state.apermission || initialState;
// Common - dùng chung
const makeSelectLoading = () => createSelector(select, substate => substate.loading);
const makeSelectCompleted = () => createSelector(select, substate => substate.completed);
const makeSelectPageIndex = () => createSelector(select, substate => substate.pageIndex);
const makeSelectPageSize = () => createSelector(select, substate => substate.pageSize);
const makeSelectTotalCount = () => createSelector(select, substate => substate.totalCount);
const makeSelectTotalPages = () => createSelector(select, substate => substate.totalPages);
const makeSelectPageIndexSub = () => createSelector(select, substate => substate.pageIndexSub);
const makeSelectPageSizeSub = () => createSelector(select, substate => substate.pageSizeSub);
const makeSelectTotalCountSub = () => createSelector(select, substate => substate.totalCountSub);
const makeSelectTotalPagesSub = () => createSelector(select, substate => substate.totalPagesSub);
// resource 
const makeSelectDataResource = () => createSelector(select, substate => substate.dataResource);
const makeSelectDataAtomic = () => createSelector(select, substate => substate.dataAtomic);
const makeSelectDataAction = () => createSelector(select, substate => substate.dataAction);
const makeSelectDataPermission = () => createSelector(select, substate => substate.dataPermission);
const makeSelectDataRole = () => createSelector(select, substate => substate.dataRole);
const makeSelectDataRemoveResource = () => createSelector(select, substate => substate.dataRemoveResource);
const makeSelectDataRemoveAtomic = () => createSelector(select, substate => substate.dataRemoveAtomic);
const makeSelectDataRemoveAction = () => createSelector(select, substate => substate.dataRemoveAction);
const makeSelectDataRemovePermission = () => createSelector(select, substate => substate.dataRemovePermission);
const makeSelectDataRemoveRole = () => createSelector(select, substate => substate.dataRemoveRole);
const makeSelectDataResourceAction = () => createSelector(select, substate => substate.dataResourceAction);
const makeSelectInsertOrUpdateResourceAction = () => createSelector(select, substate => substate.insertOrUpdateResourceAction);
const makeSelectDataActionAssignment = () => createSelector(select, substate => substate.dataActionAssignment);
const makeSelectInsertOrUpdateActionAssignment = () => createSelector(select, substate => substate.insertOrUpdateActionAssignment);
const makeSelectDataPermissionAssignment = () => createSelector(select, substate => substate.dataPermissionAssignment);
const makeSelectInsertOrUpdatePermissionAssignment = () => createSelector(select, substate => substate.insertOrUpdatePermissionAssignment);
const makeSelectdataActionResourceDto = () => createSelector(select,substate =>substate.dataActionResourceDto);

export {
    makeSelectLoading,makeSelectCompleted,makeSelectPageIndex,makeSelectPageSize,
    makeSelectTotalCount,makeSelectTotalPages,makeSelectDataResource,makeSelectDataAtomic,
    makeSelectDataAction,makeSelectDataPermission,makeSelectDataRole,makeSelectDataRemoveResource,
    makeSelectDataRemoveAction,makeSelectDataRemovePermission,makeSelectDataRemoveRole,makeSelectDataResourceAction,
    makeSelectInsertOrUpdateResourceAction,makeSelectPageIndexSub,makeSelectPageSizeSub,makeSelectTotalCountSub,
    makeSelectTotalPagesSub,makeSelectInsertOrUpdateActionAssignment,makeSelectDataActionAssignment,
    makeSelectDataPermissionAssignment,makeSelectInsertOrUpdatePermissionAssignment,makeSelectDataRemoveAtomic,
    makeSelectdataActionResourceDto
};