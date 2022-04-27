import { createSelector } from 'reselect';

import { ApplicationRootState } from '../../../redux/types';
import { initialState } from './reducer';

const select = (state: ApplicationRootState) => state.apermission || initialState; // day

//#region  GETTING START
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
//#region  GETTING START
const makeLoadingAtomic = () => createSelector(select, substate => substate.loadingAllAtomic);
const makeLoadingTableAtomic = () => createSelector(select, substate => substate.loadingTableAtomic);
const makeLoadingButtonAtomic = () => createSelector(select, substate => substate.loadingButtonAtomic);
const makeCompletedAtomic = () => createSelector(select, substate => substate.completedAllAtomic);
const makePageIndexAtomic = () => createSelector(select, substate => substate.pageIndexAtomic);
const makePageSizeAtomic = () => createSelector(select, substate => substate.pageSizeAtomic);
const makeTotalCountAtomic = () => createSelector(select, substate => substate.totalCountAtomic);
const makeTotalPagesAtomic = () => createSelector(select, substate => substate.totalPagesAtomic);
const makeAtomicReads = () => createSelector(select, substate => substate.atomicReads);
//#endregion


export {
    makeLoadingResource,makeLoadingButtonResource, makeCompletedResource, makePageIndexResource, makePageSizeResource, makeTotalCountResource, makeTotalPagesResource
    ,makeResourceReads,makeLoadingTableResource,

    makeLoadingAtomic,makeLoadingButtonAtomic, makeCompletedAtomic, makePageIndexAtomic, makePageSizeAtomic, makeTotalCountAtomic, makeTotalPagesAtomic
    ,makeAtomicReads,makeLoadingTableAtomic
};