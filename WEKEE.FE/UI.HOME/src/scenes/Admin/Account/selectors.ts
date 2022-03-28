import { createSelector } from 'reselect';

import { ApplicationRootState } from '../../../redux/types';
import { initialState } from './reducer';

const select = (state: ApplicationRootState) => state.aaccount || initialState;

const makeSelectLoading = () => createSelector(select, substate => substate.loading);
const makeSelectCompleted = () => createSelector(select, substate => substate.completed);
const makeSelectPageIndex = () => createSelector(select, substate => substate.pageIndex);
const makeSelectPageSize = () => createSelector(select, substate => substate.pageSize);
const makeSelectTotalCount = () => createSelector(select, substate => substate.totalCount);
const makeSelectTotalPages = () => createSelector(select, substate => substate.totalPages);

const makeSelectUploadImage = () => createSelector(select, substate => substate.uploadImage);
const makeSelectAccountAdminCreate = () => createSelector(select, substate => substate.accountAdminCreate);
const makeSelectAccountAdminList = () => createSelector(select, substate => substate.accountShowDtos);
const makeSelectSubjectDtos = () => createSelector(select, substate => substate.subjectDtos);
const makeSelectSubjectAssignmentDto = () => createSelector(select, substate => substate.subjectAssignmentDto);
const makeSelectId = () => createSelector(select, substate => substate.id);

export {
    makeSelectLoading,makeSelectCompleted,makeSelectUploadImage,makeSelectAccountAdminCreate,
    makeSelectPageIndex,makeSelectPageSize,makeSelectTotalCount,makeSelectTotalPages,
    makeSelectAccountAdminList,makeSelectId,makeSelectSubjectDtos,makeSelectSubjectAssignmentDto
};