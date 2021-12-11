import { call, put, takeLatest, race } from 'redux-saga/effects';
import {
    ActionAssignmentGetListDataCompeleted, ActionAssignmentGetListDataError,
    ActionAssignmentInsertOrUpdateCompeleted, ActionAssignmentInsertOrUpdateError,
    ActionCreateCompleted, ActionCreateError, ActionEditCompleted, ActionEditError,
    ActionRemoveCompleted, ActionRemoveError, AtomicgetListCompleted, AtomicgetListError,
    listFormActionCompleted, listFormPermissionCompleted, listFormPermissionError,
    listFormResourceCompleted, listFormRoleCompleted, listFormRoleError,
    PermissionAssignmentGetListDataCompeleted,
    PermissionAssignmentGetListDataError,
    PermissionAssignmentInsertOrUpdateCompeleted,
    PermissionAssignmentInsertOrUpdateError,
    PermissionAssignmentInsertOrUpdateStart,
    PermissionCreateCompleted, PermissionCreateError, PermissionEditCompleted,
    PermissionEditError, PermissionRemoveCompleted, PermissionRemoveError,
    ResourceActionGetListDataCompeleted, ResourceActionGetListDataError,
    ResourceActionInsertOrUpdateCompeleted, ResourceActionInsertOrUpdateError,
    ResourceCreateCompleted, ResourceCreateError, ResourceEditCompleted,
    ResourceEditError, ResourceEditStatusCompleted, ResourceEditStatusError, ResourceRemoveCompleted, ResourceRemoveError,
    RoleCreateCompleted, RoleCreateError, RoleEditCompleted, RoleEditError,
    RoleRemoveCompleted, RoleRemoveError, watchPageError
} from './actions';
import ActionTypes from './constants';
import service from './services';

export default function* watchLoginRequestStart() {

    //#region Resource
    yield takeLatest(
        ActionTypes.LIST_FORM_RESOURCE_START,
        requestGetListResource

    );
    yield takeLatest(
        ActionTypes.RESOURCE_CREATE_ITEM_START,
        createResource

    );
    yield takeLatest(
        ActionTypes.RESOURCE_EDIT_ITEM_START,
        editResource

    );
    yield takeLatest(
        ActionTypes.RESOURCE_REMOVE_START,
        DeleteResource
    );

    yield takeLatest(
        ActionTypes.RESOURCE_EDIT_STATUS_START,
        EditStatusResource
    );
    //#endregion

    //#region Atomic
    yield takeLatest(
        ActionTypes.ATOMIC_LIST_START,
        getListAtomic
    );
    //#endregion

    //#region Action
    yield takeLatest(
        ActionTypes.ACTION_LIST_FORM_START,
        requestGetListAction

    );
    yield takeLatest(
        ActionTypes.ACTION_CREATE_ITEM_START,
        createAction

    );
    yield takeLatest(
        ActionTypes.ACTION_EDIT_ITEM_START,
        editAction

    );
    yield takeLatest(
        ActionTypes.ACTION_REMOVE_START,
        DeleteAction
    );
    //#endregion

    //#region Permission
    yield takeLatest(
        ActionTypes.PERMISSION_LIST_FORM_START,
        requestGetListPermission

    );
    yield takeLatest(
        ActionTypes.PERMISSION_CREATE_ITEM_START,
        createPermission

    );
    yield takeLatest(
        ActionTypes.PERMISSION_EDIT_ITEM_START,
        editPermission

    );
    yield takeLatest(
        ActionTypes.PERMISSION_REMOVE_START,
        DeletePermission
    );
    //#endregion

    //#region Role
    yield takeLatest(
        ActionTypes.ROLE_LIST_FORM_START,
        requestGetListRole

    );
    yield takeLatest(
        ActionTypes.ROLE_CREATE_ITEM_START,
        createRole

    );
    yield takeLatest(
        ActionTypes.ROLE_EDIT_ITEM_START,
        editRole

    );
    yield takeLatest(
        ActionTypes.ROLE_REMOVE_START,
        DeleteRole
    );
    //#endregion

    //#region  Resource Action 
    yield takeLatest(
        ActionTypes.RESOURCE_ACTION_GET_LIST_DATA_START,
        resourceActionGetListData
    );
    yield takeLatest(
        ActionTypes.RESOURCE_ACTION_INSERT_OR_UPDATE_START,
        resourceActionInsertOrUpdate
    );
    //#endregion

    //#region  action Assignment
    yield takeLatest(
        ActionTypes.ACTION_ASSIGNMENT_GET_LIST_DATA_START,
        actionAssignmentGetListData
    );
    yield takeLatest(
        ActionTypes.ACTION_ASSIGNMENT_INSERT_OR_UPDATE_START,
        actionAssignmentInsertOrUpdate
    );
    //#endregion

    //#region  PERMISSION Assignment
    yield takeLatest(
        ActionTypes.PERMISSION_ASSIGNMENT_GET_LIST_DATA_START,
        permissionAssignmentGetListData
    );
    yield takeLatest(
        ActionTypes.PERMISSION_ASSIGNMENT_INSERT_OR_UPDATE_START,
        permissionAssignmentInsertOrUpdate
    );
    //#endregion
}

//#region Resource
function* requestGetListResource(input: any) {
    try {
        const { output } = yield race({
            output: call(service.listResourceBasic, input.payload)
        });
        if (output) {
            yield put(listFormResourceCompleted(output));
        }
        else {
            yield put(watchPageError());
        }
    } catch (error) {
        yield put(watchPageError());
    }
}
function* createResource(input: any) {
    try {
        const { output } = yield race({
            output: call(service.createResourceBasic, input.payload)
        });
        if (output) {
            yield put(ResourceCreateCompleted());
        }
        else {
            yield put(ResourceCreateError());
        }
    } catch (error) {
        yield put(ResourceCreateError());
    }
}
function* editResource(input: any) {
    try {
        const { output } = yield race({
            output: call(service.editResourceBasic, input.payload)
        });
        if (output) {
            yield put(ResourceEditCompleted());
        }
        else {
            yield put(ResourceEditError());
        }
    } catch (error) {
        yield put(ResourceEditError());
    }
}
function* DeleteResource(input: any) {
    try {
        const { output } = yield race({
            output: call(service.deleteResourceBasic, input.payload)
        });
        if (output) {
            yield put(ResourceRemoveCompleted(output));
        }
        else {
            yield put(ResourceRemoveError());
        }
    } catch (error) {
        yield put(ResourceRemoveError());
    }

}
function* EditStatusResource(input: any) {
    try {
        const { output } = yield race({
            output: call(service.EditStatusResourceBasic, input.payload)
        });
        if (output) {
            yield put(ResourceEditStatusCompleted(output));
        }
        else {
            yield put(ResourceEditStatusError());
        }
    } catch (error) {
        yield put(ResourceEditStatusError());
    }

}
//#endregion

//#region  Atomic
function* getListAtomic() {
    try {
        const { output } = yield race({
            output: call(service.listAtomic)
        });
        if (output) {
            yield put(AtomicgetListCompleted(output));
        }
        else {
            yield put(AtomicgetListError());
        }
    } catch (error) {
        yield put(AtomicgetListError());
    }

}
//#endregion

//#region Action
function* requestGetListAction(input: any) {
    try {
        const { output } = yield race({
            output: call(service.listActionBasic, input.payload)
        });
        if (output) {
            yield put(listFormActionCompleted(output));
        }
        else {
            yield put(watchPageError());
        }
    } catch (error) {
        yield put(watchPageError());
    }
}
function* createAction(input: any) {
    try {
        const { output } = yield race({
            output: call(service.createActionBasic, input.payload)
        });
        if (output) {
            yield put(ActionCreateCompleted());
        }
        else {
            yield put(ActionCreateError());
        }
    } catch (error) {
        yield put(ActionCreateError());
    }
}
function* editAction(input: any) {
    try {
        const { output } = yield race({
            output: call(service.editActionBasic, input.payload)
        });
        if (output) {
            yield put(ActionEditCompleted());
        }
        else {
            yield put(ActionEditError());
        }
    } catch (error) {
        yield put(ActionEditError());
    }
}
function* DeleteAction(input: any) {
    try {
        const { output } = yield race({
            output: call(service.deleteActionBasic, input.payload)
        });
        if (output) {
            yield put(ActionRemoveCompleted(output));
        }
        else {
            yield put(ActionRemoveError());
        }
    } catch (error) {
        yield put(ActionRemoveError());
    }

}

//#endregion

//#region Permission
function* requestGetListPermission(input: any) {
    try {
        const { output } = yield race({
            output: call(service.listPermissionBasic, input.payload)
        });
        if (output) {
            yield put(listFormPermissionCompleted(output));
        }
        else {
            yield put(listFormPermissionError());
        }
    } catch (error) {
        yield put(listFormPermissionError());
    }
}
function* createPermission(input: any) {
    try {
        const { output } = yield race({
            output: call(service.createPermissionBasic, input.payload)
        });
        if (output) {
            yield put(PermissionCreateCompleted());
        }
        else {
            yield put(PermissionCreateError());
        }
    } catch (error) {
        yield put(PermissionCreateError());
    }
}
function* editPermission(input: any) {
    try {
        const { output } = yield race({
            output: call(service.editPermissionBasic, input.payload)
        });
        if (output) {
            yield put(PermissionEditCompleted());
        }
        else {
            yield put(PermissionEditError());
        }
    } catch (error) {
        yield put(PermissionEditError());
    }
}
function* DeletePermission(input: any) {
    try {
        const { output } = yield race({
            output: call(service.deletePermissionBasic, input.payload)
        });
        if (output) {
            yield put(PermissionRemoveCompleted(output));
        }
        else {
            yield put(PermissionRemoveError());
        }
    } catch (error) {
        yield put(PermissionRemoveError());
    }
}
//#endregion

//#region Role
function* requestGetListRole(input: any) {
    try {
        const { output } = yield race({
            output: call(service.listRoleBasic, input.payload)
        });
        if (output) {
            yield put(listFormRoleCompleted(output));
        }
        else {
            yield put(listFormRoleError());
        }
    } catch (error) {
        yield put(listFormRoleError());
    }
}
function* createRole(input: any) {
    try {
        const { output } = yield race({
            output: call(service.createRoleBasic, input.payload)
        });
        if (output) {
            yield put(RoleCreateCompleted());
        }
        else {
            yield put(RoleCreateError());
        }
    } catch (error) {
        yield put(RoleCreateError());
    }
}
function* editRole(input: any) {
    try {
        const { output } = yield race({
            output: call(service.editRoleBasic, input.payload)
        });
        if (output) {
            yield put(RoleEditCompleted());
        }
        else {
            yield put(RoleEditError());
        }
    } catch (error) {
        yield put(RoleEditError());
    }
}
function* DeleteRole(input: any) {
    try {
        const { output } = yield race({
            output: call(service.deleteRoleBasic, input.payload)
        });
        if (output) {
            yield put(RoleRemoveCompleted(output));
        }
        else {
            yield put(RoleRemoveError());
        }
    } catch (error) {
        yield put(RoleRemoveError());
    }
}
//#endregion

//#region ResourceAction
function* resourceActionGetListData(input: any) {
    try {
        const { output } = yield race({
            output: call(service.getResourceActionBasic, input.payload)
        });
        if (output) {
            yield put(ResourceActionGetListDataCompeleted(output));
        }
        else {
            yield put(ResourceActionGetListDataError());
        }
    } catch (error) {
        yield put(ResourceActionGetListDataError());
    }
}

function* resourceActionInsertOrUpdate(input: any) {
    try {
        const { output } = yield race({
            output: call(service.insertOrUpdateResourceActionBasic, input.payload)
        });
        if (output) {
            yield put(ResourceActionInsertOrUpdateCompeleted(output));
        }
        else {
            yield put(ResourceActionInsertOrUpdateError());
        }
    } catch (error) {
        yield put(ResourceActionInsertOrUpdateError());
    }
}
//#endregion

//#region ActionAssignment
function* actionAssignmentGetListData(input: any) {
    try {
        const { output } = yield race({
            output: call(service.getActionAssignmentBasic, input.payload)
        });
        if (output) {
            yield put(ActionAssignmentGetListDataCompeleted(output));
        }
        else {
            yield put(ActionAssignmentGetListDataError());
        }
    } catch (error) {
        yield put(ActionAssignmentGetListDataError());
    }
}

function* actionAssignmentInsertOrUpdate(input: any) {
    try {
        const { output } = yield race({
            output: call(service.insertOrUpdateActionAssignmentBasic, input.payload)
        });
        if (output) {
            yield put(ActionAssignmentInsertOrUpdateCompeleted(output));
        }
        else {
            yield put(ActionAssignmentInsertOrUpdateError());
        }
    } catch (error) {
        yield put(ActionAssignmentInsertOrUpdateError());
    }
}
//#endregion

//#region PermissionAssignment
function* permissionAssignmentGetListData(input: any) {
    try {
        const { output } = yield race({
            output: call(service.getPermissionAssignmentBasic, input.payload)
        });
        if (output) {
            yield put(PermissionAssignmentGetListDataCompeleted(output));
        }
        else {
            yield put(PermissionAssignmentGetListDataError());
        }
    } catch (error) {
        yield put(PermissionAssignmentGetListDataError());
    }
}

function* permissionAssignmentInsertOrUpdate(input: any) {
    try {
        const { output } = yield race({
            output: call(service.insertOrUpdatePermissionAssignmentBasic, input.payload)
        });
        if (output) {
            yield put(PermissionAssignmentInsertOrUpdateCompeleted(output));
        }
        else {
            yield put(PermissionAssignmentInsertOrUpdateError());
        }
    } catch (error) {
        yield put(PermissionAssignmentInsertOrUpdateError());
    }
}
//#endregion
