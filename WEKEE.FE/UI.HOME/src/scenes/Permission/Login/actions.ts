//#region import
import { action } from 'typesafe-actions';
import { AuthenticationInput } from './dtos/authenticationInput';
import { AuthenticationResult } from './dtos/authenticationResult';
import ActionTypes from './constants';
import { UserProfileInsertDto } from './dtos/userProfileInsertDto';
//#endregion

// request login
export const loginRequestLoginStart = (input: AuthenticationInput) =>
    action(ActionTypes.LOGIN_REQUEST_LOGIN_START, input);
export const loginRequestLoginCompleted = (output: AuthenticationResult) =>
    action(ActionTypes.LOGIN_REQUEST_LOGIN_COMPLETED, output);
export const loginRequestLoginError = () =>
    action(ActionTypes.LOGIN_REQUEST_LOGIN_ERROR);

//#region REGISTRATION_ACCOUNT_BASIC
export const registrationAccountBasicStart = (input: UserProfileInsertDto) =>
    action(ActionTypes.REGISTRATION_ACCOUNT_BASIC_START, input);
export const registrationAccountBasicCompleted = (output: boolean) =>
    action(ActionTypes.REGISTRATION_ACCOUNT_BASIC_COMPLETED, output);
export const registrationAccountBasicError = () =>
    action(ActionTypes.REGISTRATION_ACCOUNT_BASIC_ERROR);
//#endregion