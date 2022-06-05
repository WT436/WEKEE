//#region import
import { action } from 'typesafe-actions';
import { AuthenticationInput } from './dtos/authenticationInput';
import { AuthenticationResult } from './dtos/authenticationResult';
import ActionTypes from './constants';
import { UserProfileInsertDto } from './dtos/userProfileInsertDto';
import { AuthenV2ReadDto } from './dtos/authenV2ReadDto';
//#endregion

// request login
export const loginRequestLoginStart = (input: AuthenticationInput) =>
    action(ActionTypes.LOGIN_REQUEST_LOGIN_START, input);
export const loginRequestLoginCompleted = (output: AuthenticationResult) =>
    action(ActionTypes.LOGIN_REQUEST_LOGIN_COMPLETED, output);
export const loginRequestLoginError = (error: string) =>
    action(ActionTypes.LOGIN_REQUEST_LOGIN_ERROR, error);

//#region REGISTRATION_ACCOUNT_BASIC
export const registrationAccountBasicStart = (input: UserProfileInsertDto) =>
    action(ActionTypes.REGISTRATION_ACCOUNT_BASIC_START, input);
export const registrationAccountBasicCompleted = (output: boolean) =>
    action(ActionTypes.REGISTRATION_ACCOUNT_BASIC_COMPLETED, output);
export const registrationAccountBasicError = () =>
    action(ActionTypes.REGISTRATION_ACCOUNT_BASIC_ERROR);
//#endregion

//#region LOGIN_OAUTH_GOOGLE
export const loginAouthGoogleStart = (input: AuthenV2ReadDto) =>
    action(ActionTypes.LOGIN_OAUTH_GOOGLE_START, input);
export const loginAouthGoogleCompleted = (output: AuthenticationResult) =>
    action(ActionTypes.LOGIN_OAUTH_GOOGLE_COMPLETED, output);
export const loginAouthGoogleError = () =>
    action(ActionTypes.LOGIN_OAUTH_GOOGLE_ERROR);
//#endregion