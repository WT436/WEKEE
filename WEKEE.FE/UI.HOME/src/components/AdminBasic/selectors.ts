import { createSelector } from 'reselect';

import { ApplicationRootState } from '../../redux/types';
import { initialState } from './reducer';

const select = (state: ApplicationRootState) => state.adminBasic || initialState; // day

//#region  GETTING START
const makeLoading = () => createSelector(select, substate => substate.loadingAll);
const makeLoadingTable = () => createSelector(select, substate => substate.loadingTable);
const makeLoadingButton = () => createSelector(select, substate => substate.loadingButton);
const makeCompleted = () => createSelector(select, substate => substate.completedAll);
const makePageIndex = () => createSelector(select, substate => substate.pageIndex);
const makePageSize = () => createSelector(select, substate => substate.pageSize);
const makeTotalCount = () => createSelector(select, substate => substate.totalCount);
const makeTotalPages = () => createSelector(select, substate => substate.totalPages);
//#endregion

//#region  Individual
const makeResourceReads = () => createSelector(select, substate => substate.resourceReads);

//#endregion

export {
    makeLoading,makeLoadingButton, makeCompleted, makePageIndex, makePageSize, makeTotalCount, makeTotalPages
    ,makeResourceReads,makeLoadingTable
};