import { createSelector } from "reselect";

import { ApplicationRootState } from "../../../redux/types";
import { initialState } from "./reducer";

const select = (state: ApplicationRootState) => state.hdetail || initialState;

const makeSelectLoading = () =>
  createSelector(select, (substate) => substate.loading);
const makeSelectCompleted = () =>
  createSelector(select, (substate) => substate.completed);
const makeSelectcategoryBreadcrumbDtos = () =>
  createSelector(select, (substate) => substate.categoryBreadcrumbDtos);
const makeSelectunitCardProduct = () =>
  createSelector(select, (substate) => substate.unitCardProduct);
const makeSelectimageS80x80 = () =>
  createSelector(select, (substate) => substate.imageS80x80);
const makeSelectimageS340x340 = () =>
  createSelector(select, (substate) => substate.imageS340x340);
const makeSelectimageS1360x1360 = () =>
  createSelector(select, (substate) => substate.imageS1360x1360);
const makeSelectstartKey1 = () =>
  createSelector(select, (substate) => substate.startKey1);
const makeSelectstartKey2 = () =>
  createSelector(select, (substate) => substate.startKey2);
const makeSelectstartValues1 = () =>
  createSelector(select, (substate) => substate.startValues1);
const makeSelectstartValues2 = () =>
  createSelector(select, (substate) => substate.startValues2);
const makeSelectgetEvaluatesProductDto = () =>
  createSelector(select, (substate) => substate.getEvaluatesProductDto);
const makeSelectreviewEvaluatesOutputDto = () =>
  createSelector(select, (substate) => substate.reviewEvaluatesOutputDto);

export {
  makeSelectLoading,
  makeSelectCompleted,
  makeSelectcategoryBreadcrumbDtos,
  makeSelectunitCardProduct,
  makeSelectimageS80x80,
  makeSelectimageS340x340,
  makeSelectimageS1360x1360,
  makeSelectstartKey1,
  makeSelectstartKey2,
  makeSelectstartValues1,
  makeSelectstartValues2,
  makeSelectgetEvaluatesProductDto,
  makeSelectreviewEvaluatesOutputDto,
};
