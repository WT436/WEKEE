import { createSelector } from 'reselect';

import { ApplicationRootState } from '../../../redux/types';
import { initialState } from './reducer';

const select = (state: ApplicationRootState) => state.apermission || initialState; // day

//#region  GETTING RESOURCE
const makeLoadingResource = () => createSelector(select, substate => substate.loadingAllResource);
const makeLoadingTableResource = () => createSelector(select, substate => substate.loadingTableResource);
const makeLoadingButtonResource = () => createSelector(select, substate => substate.loadingButtonResource);
const makeCompletedResource = () => createSelector(select, substate => substate.completedAllResource);
const makePageIndexResource = () => createSelector(select, substate => substate.pageIndexResource);
const makePageSizeResource = () => createSelector(select, substate => substate.pageSizeResource);
const makeTotalCountResource = () => createSelector(select, substate => substate.totalCountResource);
const makeTotalPagesResource = () => createSelector(select, substate => substate.totalPagesResource);
const makeResourceReads = () => createSelector(select, substate => substate.resourceReads);
//#endregion
//#region  GETTING ATOMIC
const makeLoadingAtomic = () => createSelector(select, substate => substate.loadingAllAtomic);
const makeLoadingTableAtomic = () => createSelector(select, substate => substate.loadingTableAtomic);
const makeLoadingButtonAtomic = () => createSelector(select, substate => substate.loadingButtonAtomic);
const makeCompletedAtomic = () => createSelector(select, substate => substate.completedAllAtomic);
const makePageIndexAtomic = () => createSelector(select, substate => substate.pageIndexAtomic);
const makePageSizeAtomic = () => createSelector(select, substate => substate.pageSizeAtomic);
const makeTotalCountAtomic = () => createSelector(select, substate => substate.totalCountAtomic);
const makeTotalPagesAtomic = () => createSelector(select, substate => substate.totalPagesAtomic);
const makeAtomicReads = () => createSelector(select, substate => substate.atomicReads);
const makeAtomicSummaryRead = () => createSelector(select, substate => substate.atomicSummaryRead);
//#endregion
//#region  GETTING PERMISSION
const makeLoadingPermission = () => createSelector(select, substate => substate.loadingAllPermission);
const makeLoadingTablePermission = () => createSelector(select, substate => substate.loadingTablePermission);
const makeLoadingButtonPermission = () => createSelector(select, substate => substate.loadingButtonPermission);
const makeCompletedPermission = () => createSelector(select, substate => substate.completedAllPermission);
const makePageIndexPermission = () => createSelector(select, substate => substate.pageIndexPermission);
const makePageSizePermission = () => createSelector(select, substate => substate.pageSizePermission);
const makeTotalCountPermission = () => createSelector(select, substate => substate.totalCountPermission);
const makeTotalPagesPermission = () => createSelector(select, substate => substate.totalPagesPermission);
const makePermissionReads = () => createSelector(select, substate => substate.permissionReads);
const makepermissionSummaryRead = () => createSelector(select, substate => substate.permissionSummaryRead);
//#endregion

export {
    makeLoadingResource,makeLoadingButtonResource, makeCompletedResource, makePageIndexResource, makePageSizeResource, makeTotalCountResource, makeTotalPagesResource
    ,makeResourceReads,makeLoadingTableResource

    ,makeLoadingAtomic,makeLoadingButtonAtomic, makeCompletedAtomic, makePageIndexAtomic, makePageSizeAtomic, makeTotalCountAtomic, makeTotalPagesAtomic
    ,makeAtomicReads,makeLoadingTableAtomic,makeAtomicSummaryRead

    ,makeLoadingPermission,makeLoadingButtonPermission, makeCompletedPermission, makePageIndexPermission, makePageSizePermission, makeTotalCountPermission, makeTotalPagesPermission
    ,makePermissionReads,makeLoadingTablePermission,makepermissionSummaryRead
};