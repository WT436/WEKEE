import { createSelector } from 'reselect';

import { ApplicationRootState } from '../../../redux/types';
import { initialState } from './reducer';

const select = (state: ApplicationRootState) => state.attributeproduct || initialState; // day
const makeSelectLoading = () => createSelector(select, substate => substate.loading);
const makeSelectCompleted = () => createSelector(select, substate => substate.completed);
const makeSelectPageIndex = () => createSelector(select, substate => substate.pageIndex);
const makeSelectPageSize = () => createSelector(select, substate => substate.pageSize);
const makeSelectTotalCount = () => createSelector(select, substate => substate.totalCount);
const makeSelectTotalPages = () => createSelector(select, substate => substate.totalPages);
const makeSelectproductAttributeReadDto = () => createSelector(select, substate => substate.productAttributeReadDto);
const makeSelectcateProReadIdAndNameDto = () => createSelector(select, substate => substate.cateProReadIdAndNameDto);
const makeSelectoptionCreateByCate = () => createSelector(select, substate => substate.optionCreateByCate);

export {
    makeSelectLoading, makeSelectCompleted, makeSelectPageIndex, makeSelectPageSize,
    makeSelectTotalCount, makeSelectTotalPages, makeSelectproductAttributeReadDto
    , makeSelectcateProReadIdAndNameDto,makeSelectoptionCreateByCate
};