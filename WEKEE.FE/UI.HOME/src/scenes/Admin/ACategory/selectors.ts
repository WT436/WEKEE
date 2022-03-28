import { createSelector } from 'reselect';

import { ApplicationRootState } from '../../../redux/types';
import { initialState } from './reducer';

const select = (state: ApplicationRootState) => state.acategory || initialState;
const makeSelectLoading = () => createSelector(select, substate => substate.loading);
const makeSelectCompleted = () => createSelector(select, substate => substate.completed);
const makeSelectPageIndex = () => createSelector(select, substate => substate.pageIndex);
const makeSelectPageSize = () => createSelector(select, substate => substate.pageSize);
const makeSelectTotalCount = () => createSelector(select, substate => substate.totalCount);
const makeSelectTotalPages = () => createSelector(select, substate => substate.totalPages);
const makeSelectCategoryDtos = () => createSelector(select, substate => substate.categoryDtos);
const makeSelectCategoryMapDtos = () => createSelector(select, substate => substate.optionsCategory);

export {
    makeSelectLoading, makeSelectCompleted, makeSelectPageIndex, makeSelectPageSize,
    makeSelectTotalCount, makeSelectTotalPages,makeSelectCategoryDtos,makeSelectCategoryMapDtos
};