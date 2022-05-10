import { call, put, takeLatest, race } from 'redux-saga/effects';
import http from '../../../services/httpService';

import { loginAouthGoogleCompleted, loginAouthGoogleError, loginRequestLoginCompleted, loginRequestLoginError, registrationAccountBasicCompleted, registrationAccountBasicError } from './actions';
import ActionTypes from './constants';
import { AuthenticationResult } from './dtos/authenticationResult';
import { AuthenV2ReadDto } from './dtos/authenV2ReadDto';
import { UserProfileInsertDto } from './dtos/userProfileInsertDto';
import loginService from './services';

export default function* watchLoginRequestStart() {

    yield takeLatest(
        ActionTypes.LOGIN_REQUEST_LOGIN_START,
        requestLogin
    );
    //#region REGISTRATION_ACCOUNT_BASIC
    yield takeLatest(
        ActionTypes.REGISTRATION_ACCOUNT_BASIC_START,
        function* (input: any) {
            try {
                const { output } = yield race({
                    output: call(async (data: UserProfileInsertDto = input.payload): Promise<boolean> => {
                        let rs = await http.post('/UserAccount/LoginAccount', data);
                        return rs ? rs.data : rs;
                    })
                });
                if (output) {
                    yield put(registrationAccountBasicCompleted(output));
                }
                else {
                    yield put(registrationAccountBasicError());
                }
            } catch (error) {
                yield put(registrationAccountBasicError());
            }
        });
    //#endregion
    //#region LOGIN_OAUTH_GOOGLE
    yield takeLatest(
        ActionTypes.LOGIN_OAUTH_GOOGLE_START,
        function* (input: any) {
            try {
                const { output } = yield race({
                    output: call(async (data: AuthenV2ReadDto = input.payload): Promise<AuthenticationResult> => {
                        let rs = await http.post('/AuthenV2Google/Login',data);
                        return rs ? rs.data : rs;
                    })
                });
                if (output) {
                    yield put(loginAouthGoogleCompleted(output));
                }
                else {
                    yield put(loginAouthGoogleError());
                }
            } catch (error) {
                yield put(loginAouthGoogleError());
            }
        });
    //#endregion
}

function* requestLogin(input: any) {
    try {
        const { output } = yield race({
            output: call(loginService.authenticate, input.payload)
        });
        if (output) {
            yield put(loginRequestLoginCompleted(output));
        }
        else {
            yield put(loginRequestLoginError());
        }
    } catch (error) {
        yield put(loginRequestLoginError());
    }
}