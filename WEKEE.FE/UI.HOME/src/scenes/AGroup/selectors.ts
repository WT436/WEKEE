import { createSelector } from 'reselect';

import { ApplicationRootState } from '../../redux/types';
import { initialState } from './reducer';

const selectHome = (state: ApplicationRootState) => state.home || initialState;

const makeSelectLoading = () => createSelector(selectHome, substate => substate.loading);
const makeSelectCompleted = () => createSelector(selectHome, substate => substate.completed);

export { 
    makeSelectLoading, 
    makeSelectCompleted 
};