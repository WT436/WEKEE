import { call, put, takeLatest, race } from 'redux-saga/effects';
import http from '../../../services/httpService';

import { loginRequestLoginCompleted, loginRequestLoginError, registrationAccountBasicCompleted, registrationAccountBasicError } from './actions';
import ActionTypes from './constants';
import { AuthenticationResult } from './dtos/authenticationResult';
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
    }});
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