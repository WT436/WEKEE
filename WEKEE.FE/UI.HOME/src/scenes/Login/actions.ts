//#region import
import { action } from 'typesafe-actions';
import { AuthenticationInput } from './dtos/authenticationInput';
import { AuthenticationResult } from './dtos/authenticationResult';
import ActionTypes from './constants';
//#endregion


// open page login
export const loginShowStart = () =>
    action(ActionTypes.LOGIN_SHOW_START);
export const loginShowCompleted = () =>
    action(ActionTypes.LOGIN_SHOW_COMPLETED);
export const loginShowError = () =>
    action(ActionTypes.LOGIN_SHOW_ERROR);

// request login
export const loginRequestLoginStart = (input: AuthenticationInput) =>
    action(ActionTypes.LOGIN_REQUEST_LOGIN_START, input);
export const loginRequestLoginCompleted = (output: AuthenticationResult) =>
    action(ActionTypes.LOGIN_REQUEST_LOGIN_COMPLETED, output);
export const loginRequestLoginError = () =>
    action(ActionTypes.LOGIN_REQUEST_LOGIN_ERROR);