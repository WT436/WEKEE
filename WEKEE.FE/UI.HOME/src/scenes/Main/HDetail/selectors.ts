import { createSelector } from "reselect";
import { ApplicationRootState } from "../../../redux/types";
import { initialState } from "./reducer";

const select = (state: ApplicationRootState) => state.hdetail || initialState;

const makeSelectLoading = () => createSelector(select, (substate) => substate.loading);
const makeSelectCompleted = () => createSelector(select, (substate) => substate.completed);
const makeSelectcategoryBreadcrumbDtos = () => createSelector(select, (substate) => substate.categoryBreadcrumbDtos);
const makeSelectbasicProduct = () => createSelector(select, (substate) => substate.basicProduct);
const makeSelectimageForProduct = () => createSelector(select, (substate) => substate.imageForProduct);
const makeSelectfeatureCartProduct = () => createSelector(select, (substate) => substate.featureProductContainer);

export {
  makeSelectLoading,
  makeSelectCompleted,
  makeSelectcategoryBreadcrumbDtos,
  makeSelectbasicProduct, makeSelectimageForProduct,makeSelectfeatureCartProduct
};
