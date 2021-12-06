import { call, put, takeLatest, race } from 'redux-saga/effects';

import { loginRequestLoginCompleted, loginRequestLoginError } from './actions';
import ActionTypes from './constants';
import loginService from './services';

export default function* watchLoginRequestStart() {

    yield takeLatest(
        ActionTypes.LOGIN_REQUEST_LOGIN_START,
        requestLogin
    );
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