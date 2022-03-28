import { call, put, takeLatest, race } from 'redux-saga/effects';
import { fixErrorSystemCompleted, fixErrorSystemError, getListErrorSystemCompleted, getListErrorSystemError } from './actions';
import ActionTypes from './constants';
import Service from './services';

export default function* watchLoginRequestStart() {

    yield takeLatest(
        ActionTypes.GET_LIST_ERROR_SYSTEM_START,
        getListErrorSystemStart
    );

    yield takeLatest(
        ActionTypes.FIX_ERROR_SYSTEM_START,
        fixErrorSystemStart
    );
}

function* fixErrorSystemStart(input: any) {
    try {
        const { output } = yield race({
            output: call(Service.fixErrorSystemStart,input.payload)
        });
        if (output) {
            yield put(fixErrorSystemCompleted(output));
        }
        else {
            yield put(fixErrorSystemError());
        }
    } catch (error) {
        yield put(fixErrorSystemError());
    }
}

function* getListErrorSystemStart(input: any) {
    try {
        const { output } = yield race({
            output: call(Service.getListErrorSystemStart,input.payload)
        });
        if (output) {
            yield put(getListErrorSystemCompleted(output));
        }
        else {
            yield put(getListErrorSystemError());
        }
    } catch (error) {
        yield put(getListErrorSystemError());
    }
}