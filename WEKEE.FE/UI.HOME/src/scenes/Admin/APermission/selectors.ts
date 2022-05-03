import { createSelector } from 'reselect';

import { ApplicationRootState } from '../../../redux/types';
import { initialState } from './reducer';

const select = (state: ApplicationRootState) => state.apermission || initialState; // day

//#region  UserProfile
const makeuserProfile = () => createSelector(select, substate => substate.userProfile);
//#endregion

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
const makepermissionFtReourceRead = () => createSelector(select, substate => substate.permissionFtResourceRead);
const makeLoadingTablePermissionFtResource = () => createSelector(select, substate => substate.loadingTablePermissionFtResource);
const makePageIndexPermissionFtResource = () => createSelector(select, substate => substate.pageIndexPermissionFtResource);
const makePageSizePermissionFtResource = () => createSelector(select, substate => substate.pageSizePermissionFtResource);
const makeTotalCountPermissionFtResource = () => createSelector(select, substate => substate.totalCountPermissionFtResource);
const makeTotalPagesPermissionFtResource = () => createSelector(select, substate => substate.totalPagesPermissionFtResource);

//#endregion

//#region  GETTING ROLE
const makeLoadingRole = () => createSelector(select, substate => substate.loadingAllRole);
const makeLoadingTableRole = () => createSelector(select, substate => substate.loadingTableRole);
const makeLoadingButtonRole = () => createSelector(select, substate => substate.loadingButtonRole);
const makeCompletedRole = () => createSelector(select, substate => substate.completedAllRole);
const makePageIndexRole = () => createSelector(select, substate => substate.pageIndexRole);
const makePageSizeRole = () => createSelector(select, substate => substate.pageSizeRole);
const makeTotalCountRole = () => createSelector(select, substate => substate.totalCountRole);
const makeTotalPagesRole = () => createSelector(select, substate => substate.totalPagesRole);
const makeRoleReads = () => createSelector(select, substate => substate.roleReads);
const makeroleSummaryRead = () => createSelector(select, substate => substate.roleSummaryRead);

const makeLoadingTableRoleFtPermission = () => createSelector(select, substate => substate.loadingTableRoleFtPermission);
const makePageIndexRoleFtPermission = () => createSelector(select, substate => substate.pageIndexRoleFtPermission);
const makePageSizeRoleFtPermission = () => createSelector(select, substate => substate.pageSizeRoleFtPermission);
const makeTotalCountRoleFtPermission = () => createSelector(select, substate => substate.totalCountRoleFtPermission);
const makeTotalPagesRoleFtPermission = () => createSelector(select, substate => substate.totalPagesRoleFtPermission);
const makeroleFtPermissionRead = () => createSelector(select, substate => substate.roleFtPermissionRead);

//#endregion

//#region  GETTING SUBJECT
const makeLoadingSubject = () => createSelector(select, substate => substate.loadingAllSubject);
const makeLoadingTableSubject = () => createSelector(select, substate => substate.loadingTableSubject);
const makeLoadingButtonSubject = () => createSelector(select, substate => substate.loadingButtonSubject);
const makeCompletedSubject = () => createSelector(select, substate => substate.completedAllSubject);
const makePageIndexSubject = () => createSelector(select, substate => substate.pageIndexSubject);
const makePageSizeSubject = () => createSelector(select, substate => substate.pageSizeSubject);
const makeTotalCountSubject = () => createSelector(select, substate => substate.totalCountSubject);
const makeTotalPagesSubject = () => createSelector(select, substate => substate.totalPagesSubject);
const makeSubjectReads = () => createSelector(select, substate => substate.subjectReads);

const makesubjectFtRoleRead = () => createSelector(select, substate => substate.subjectFtRoleRead);
const makePageIndexSubjectFtRole = () => createSelector(select, substate => substate.pageIndexSubjectFtRole);
const makePageSizeSubjectFtRole = () => createSelector(select, substate => substate.pageSizeSubjectFtRole);
const makeTotalCountSubjectFtRole = () => createSelector(select, substate => substate.totalCountSubjectFtRole);
const makeTotalPagesSubjectFtRole = () => createSelector(select, substate => substate.totalPagesSubjectFtRole);

//#endregion

export {
    makeuserProfile,

    makeLoadingResource, makeLoadingButtonResource, makeCompletedResource, makePageIndexResource, makePageSizeResource, makeTotalCountResource, makeTotalPagesResource
    , makeResourceReads, makeLoadingTableResource

    , makeLoadingAtomic, makeLoadingButtonAtomic, makeCompletedAtomic, makePageIndexAtomic, makePageSizeAtomic, makeTotalCountAtomic, makeTotalPagesAtomic
    , makeAtomicReads, makeLoadingTableAtomic, makeAtomicSummaryRead

    , makeLoadingPermission, makeLoadingButtonPermission, makeCompletedPermission, makePageIndexPermission, makePageSizePermission, makeTotalCountPermission, makeTotalPagesPermission
    , makePermissionReads, makeLoadingTablePermission, makepermissionSummaryRead, makepermissionFtReourceRead, makeLoadingTablePermissionFtResource
    , makePageIndexPermissionFtResource, makePageSizePermissionFtResource, makeTotalCountPermissionFtResource, makeTotalPagesPermissionFtResource

    , makeLoadingRole, makeLoadingButtonRole, makeCompletedRole, makePageIndexRole, makePageSizeRole, makeTotalCountRole, makeTotalPagesRole
    , makeRoleReads, makeLoadingTableRole, makeroleSummaryRead, makeLoadingTableRoleFtPermission, makePageIndexRoleFtPermission, makePageSizeRoleFtPermission
    , makeTotalPagesRoleFtPermission, makeTotalCountRoleFtPermission,makeroleFtPermissionRead

    , makeLoadingSubject, makeLoadingButtonSubject, makeCompletedSubject, makePageIndexSubject, makePageSizeSubject, makeTotalCountSubject, makeTotalPagesSubject
    , makeSubjectReads, makeLoadingTableSubject,makesubjectFtRoleRead,makePageIndexSubjectFtRole,makePageSizeSubjectFtRole,makeTotalCountSubjectFtRole,makeTotalPagesSubjectFtRole
};