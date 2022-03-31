import { createSelector } from "reselect";

import { ApplicationRootState } from "../../../redux/types";
import { initialState } from "./reducer";

const select = (state: ApplicationRootState) => state.aspecicate || initialState;
const makeSelectLoading = () => createSelector(select, (substate) => substate.loading);
const makeSelectCompleted = () => createSelector(select, (substate) => substate.completed);
const makeSelectPageIndex = () => createSelector(select, (substate) => substate.pageIndex);
const makeSelectPageSize = () => createSelector(select, (substate) => substate.pageSize);
const makeSelectTotalCount = () => createSelector(select, (substate) => substate.totalCount);
const makeSelectTotalPages = () => createSelector(select, (substate) => substate.totalPages);
const makeSelectcategorySelectDto = () => createSelector(select, (substate) => substate.categorySelectDto);
const makeSelectnameKey = () => createSelector(select, (substate) => substate.nameKey);
const makeSelectClassifyValues = () => createSelector(select, (substate) => substate.classifyValues);
const makeSelectSpecificationsCategoryDto = () => createSelector(select, (substate) => substate.specificationsCategoryDto);
const makeSelectCategoryMapDtos = () => createSelector(select, substate => substate.optionsCategory);
const makeSelectspecificationAttributeReadDto = () => createSelector(select, substate => substate.specificationAttributeReadDto);

export {
  makeSelectLoading,
  makeSelectCompleted,
  makeSelectPageIndex,
  makeSelectPageSize,
  makeSelectTotalCount,
  makeSelectTotalPages,
  makeSelectcategorySelectDto,
  makeSelectnameKey,
  makeSelectClassifyValues,
  makeSelectSpecificationsCategoryDto,
  makeSelectCategoryMapDtos,
  makeSelectspecificationAttributeReadDto
  
};
