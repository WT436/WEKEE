import { call, put, takeLatest, race } from 'redux-saga/effects';
import { getCategoryAdminCompleted, getCategoryAdminError } from './actions';
import ActionTypes from './constants';
import service from './services';

export default function* watchLoginRequestStart() {

    //#region  GET_CATEGORY_ADMIN
    yield takeLatest(ActionTypes.GET_CATEGORY_ADMIN_START, getCategoryAdminStart);
    //#endregion
}

function* getCategoryAdminStart(input: any) {
    try {
        const { output } = yield race({
            output: call(
                service.getCategoryAdminStart, input.payload
            ),
        });
        if (output) {
            yield put(getCategoryAdminCompleted(output));
        } else {
            yield put(getCategoryAdminError());
        }
    } catch (error) {
        yield put(getCategoryAdminError());
    }
}