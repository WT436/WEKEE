import { call, put, takeLatest, race } from 'redux-saga/effects';
import {
    changPermissionAccountComplete,
    changPermissionAccountError,
    createAccountAdminComplete, createAccountAdminError, deleteAccountComplete, deleteAccountError, listAccountAdminComplete,
    listAccountAdminError, listSubjecComplete, listSubjecError, listSubjectAssignComplete, listSubjectAssignError, watchPageCompleted, watchPageError
} from './actions';
import ActionTypes from './constants';
import service from './services';

export default function* watchLoginRequestStart() {

    yield takeLatest(
        ActionTypes.WATCH_PAGE_START,
        requestLogin
    );

    yield takeLatest(
        ActionTypes.REMOVE_AVATAR_UPLOAD_START,
        removeAvatarUploadStart
    );

    yield takeLatest(
        ActionTypes.CREATE_ACCOUNT_ADMIN_START,
        createAccountAdminStart
    );

    yield takeLatest(
        ActionTypes.LIST_ACCOUNT_ADMIN_START,
        listAccountAdminStart
    );

    yield takeLatest(
        ActionTypes.LIST_SUBJECT_ID_ACCOUNT_START,
        listSubjectIdAccountStart
    );

    yield takeLatest(
        ActionTypes.LIST_SUBJECT_ASSIGN_DTO_START,
        listSubjectAssignStart
    );

    yield takeLatest(
        ActionTypes.CHANGE_PERMISSION_ACCOUNT_START,
        changePermissionAccountStart
    );

    yield takeLatest(
        ActionTypes.DELETE_ACCOUNT_START,
        deleteAccountStart
    );
}

function* deleteAccountStart(input: any) {  
    try {
        const { output } = yield race({
            output: call(service.deleteAccountStart,input.payload)
        });
        if (output) {
            yield put(deleteAccountComplete(output));
        }
        else {
            yield put(deleteAccountError());
        }
    } catch (error) {
        yield put(deleteAccountError());
    }
}

function* changePermissionAccountStart(input: any) {
    try {
        const { output } = yield race({
            output: call(service.changePermissionAccountStart,input.payload.idSubject,input.payload.idRole)
        });
        if (output) {
            alert("s")
            yield put(changPermissionAccountComplete(input.payload.idSubject,input.payload.idRole));
        }
        else {
            alert("e"+ output)

            yield put(changPermissionAccountError());
        }
    } catch (error) {
        alert("e")

        yield put(changPermissionAccountError());
    }
}

function* listSubjectAssignStart(input: any) {
    try {
        const { output } = yield race({
            output: call(service.listSubjectAssignStart, input.payload)
        });
        if (output) {
            yield put(listSubjectAssignComplete(output));
        }
        else {
            yield put(listSubjectAssignError());
        }
    } catch (error) {
        yield put(listSubjectAssignError());
    }
}

function* requestLogin(input: any) {
    try {
        const { output } = yield race({
            output: call(service.authenticate)
        });
        if (output) {
            yield put(watchPageCompleted());
        }
        else {
            yield put(watchPageError());
        }
    } catch (error) {
        yield put(watchPageError());
    }
}


function* removeAvatarUploadStart(input: any) {
    try {
        yield race({
            output: call(service.removeAvatarUpload, input.payload)
        });
    } catch (error) { }
}

function* createAccountAdminStart(input: any) {
    try {
        const { output } = yield race({
            output: call(service.createAccountAdmin, input.payload)
        });
        if (output) {
            yield put(createAccountAdminComplete(output));
        }
        else {
            yield put(createAccountAdminError());
        }
    } catch (error) {
        yield put(createAccountAdminError());
    }
}

function* listAccountAdminStart(input: any) {
    try {
        const { output } = yield race({
            output: call(service.listAccountAdmin, input.payload)
        });
        if (output) {
            yield put(listAccountAdminComplete(output));
        }
        else {
            yield put(listAccountAdminError());
        }
    } catch (error) {
        yield put(listAccountAdminError());
    }
}

function* listSubjectIdAccountStart(input: any) {
    try {
        const { output } = yield race({
            output: call(service.listSubjectAccount, input.payload)
        });
        if (output) {
            yield put(listSubjecComplete(output));
        }
        else {
            yield put(listSubjecError());
        }
    } catch (error) {
        yield put(listSubjecError());
    }
}