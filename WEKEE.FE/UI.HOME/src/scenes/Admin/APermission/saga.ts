import { call, put, takeLatest, race } from 'redux-saga/effects';
import ActionTypes from './constants';
import http from '../../../services/httpService';
import { deleteAtomicCompleted, deleteAtomicError, deletePermissionCompleted, deletePermissionError, deleteResourceCompleted, deleteResourceError, deleteRoleCompleted, deleteRoleError, deleteSubjectCompleted, deleteSubjectError, editStatusAtomicCompleted, editStatusAtomicError, editStatusPermissionCompleted, editStatusPermissionError, editStatusResourceCompleted, editStatusResourceError, editStatusRoleCompleted, editStatusRoleError, editStatusSubjectCompleted, editStatusSubjectError, getAtomicCompleted, getAtomicError, getPermissionCompleted, getPermissionError, getResourceCompleted, getResourceError, getRoleCompleted, getRoleError, getSubjectCompleted, getSubjectError, getUserProfileCompleted, getUserProfileError, insertOrUpdateAtomicCompleted, insertOrUpdateAtomicError, insertOrUpdatePermissionCompleted, insertOrUpdatePermissionError, insertOrUpdateResourceCompleted, insertOrUpdateResourceError, insertOrUpdateRoleCompleted, insertOrUpdateRoleError, insertOrUpdateSubjectCompleted, insertOrUpdateSubjectError, permessionFtResourceCompleted, permessionFtResourceError, savePermissionFtResourceCompleted, savePermissionFtResourceError, searchSummaryPermissionCompleted, searchSummaryPermissionError, searchSummaryRoleCompleted, searchSummaryRoleError, summaryAtomicCompleted, summaryAtomicError } from './actions';
import { PagedListOutput } from '../../../services/dto/pagedListOutput';
import { ResourceReadDto } from './dto/resourceReadDto';
import { ResourceLstChangeDto } from './dto/resourceLstChangeDto';
import { AtomicReadDto } from './dto/atomicReadDto';
import { AtomicLstChangeDto } from './dto/atomicLstChangeDto';
import { PermissionReadDto } from './dto/permissionReadDto';
import { PermissionLstChangeDto } from './dto/permissionLstChangeDto';
import { AtomicSummaryReadDto } from './dto/atomicSummaryReadDto';
import { SearchTextInput } from '../../../services/dto/searchTextInput';
import { PermissionSummaryReadDto } from './dto/permissionSummaryReadDto';
import { RoleLstChangeDto } from './dto/roleLstChangeDto';
import { RoleReadDto } from './dto/roleReadDto';
import { RoleSummaryReadDto } from './dto/roleSummaryReadDto';
import { SubjectReadDto } from './dto/subjectReadDto';
import { SubjectLstChangeDto } from './dto/subjectLstChangeDto';
import { UserProfileCompactReadDto } from './dto/userProfileCompactReadDto';
import { PermissionFtReourceReadDto } from './dto/permissionFtReourceReadDto';
import { FtPermissionReadDto } from './dto/ftPermissionReadDto';

export default function* CallApiService() {
    //#region GET_USER_PROFILE
    yield takeLatest(
        ActionTypes.GET_USER_PROFILE_START,
        function* (input: any) {
            try {
                const { output } = yield race({
                    output: call(async (data: SearchTextInput = input.payload): Promise<UserProfileCompactReadDto> => {
                        let rs = await http.get('/UserProfileAdminApi/AdminCompactUserProfile', { params: data });
                        return rs ? rs.data : rs;
                    })
                });
                if (output) {
                    yield put(getUserProfileCompleted(output));
                }
                else {
                    yield put(getUserProfileError());
                }
            } catch (error) {
                yield put(getUserProfileError());
            }
        });
    //#endregion

    //#region GET_RESOURCE
    yield takeLatest(
        ActionTypes.GET_RESOURCE_START,
        function* (input: any) {
            try {
                const { output } = yield race({
                    output: call(async (): Promise<PagedListOutput<ResourceReadDto>> => {
                        let rs = await http.get('/ResourceApi/AdminResource', { params: input.payload });
                        return rs ? rs.data : rs;
                    })
                });
                if (output) {
                    yield put(getResourceCompleted(output));
                }
                else {
                    yield put(getResourceError());
                }
            } catch (error) {
                yield put(getResourceError());
            }
        });
    //#endregion
    //#region DELETE_RESOURCE
    yield takeLatest(
        ActionTypes.DELETE_RESOURCE_START,
        function* (input: any) {
            try {
                const { output } = yield race({
                    output: call(async (data: number[] = input.payload): Promise<number> => {
                        let rs = await http.delete('/ResourceApi/AdminResource', { params: { ids: data } });
                        return rs ? rs.data : rs;
                    })
                });
                if (output) {
                    yield put(deleteResourceCompleted(output));
                }
                else {
                    yield put(deleteResourceError());
                }
            } catch (error) {
                yield put(deleteResourceError());
            }
        });
    //#endregion
    //#region EDIT_STATUS_RESOURCE
    yield takeLatest(
        ActionTypes.EDIT_STATUS_RESOURCE_START,
        function* (input: any) {
            try {
                const { output } = yield race({
                    output: call(async (data: ResourceLstChangeDto = input.payload): Promise<number> => {
                        let rs = await http.patch('/ResourceApi/AdminResource', data);
                        return rs ? rs.data : rs;
                    })
                });
                if (output) {
                    yield put(editStatusResourceCompleted(output));
                }
                else {
                    yield put(editStatusResourceError());
                }
            } catch (error) {
                yield put(editStatusResourceError());
            }
        });
    //#endregion
    //#region INSERT_OR_UPDATE_RESOURCE
    yield takeLatest(
        ActionTypes.INSERT_OR_UPDATE_RESOURCE_START,
        function* (input: any) {
            try {
                const { output } = yield race({
                    output: call(async (data: ResourceLstChangeDto = input.payload): Promise<number> => {
                        let rs = await http.post('/ResourceApi/AdminResource', data);
                        return rs ? rs.data : rs;
                    })
                });
                if (output) {
                    yield put(insertOrUpdateResourceCompleted(output));
                }
                else {
                    yield put(insertOrUpdateResourceError());
                }
            } catch (error) {
                yield put(insertOrUpdateResourceError());
            }
        });
    //#endregion

    //#region GET_ATOMIC
    yield takeLatest(
        ActionTypes.GET_ATOMIC_START,
        function* (input: any) {
            try {
                const { output } = yield race({
                    output: call(async (): Promise<PagedListOutput<AtomicReadDto>> => {
                        let rs = await http.get('/AtomicAdminApi/AdminAtomic', { params: input.payload });
                        return rs ? rs.data : rs;
                    })
                });
                if (output) {
                    yield put(getAtomicCompleted(output));
                }
                else {
                    yield put(getAtomicError());
                }
            } catch (error) {
                yield put(getAtomicError());
            }
        });
    //#endregion
    //#region DELETE_ATOMIC
    yield takeLatest(
        ActionTypes.DELETE_ATOMIC_START,
        function* (input: any) {
            try {
                const { output } = yield race({
                    output: call(async (data: number[] = input.payload): Promise<number> => {
                        let rs = await http.delete('/AtomicAdminApi/AdminAtomic', { params: { ids: data } });
                        return rs ? rs.data : rs;
                    })
                });
                if (output) {
                    yield put(deleteAtomicCompleted(output));
                }
                else {
                    yield put(deleteAtomicError());
                }
            } catch (error) {
                yield put(deleteAtomicError());
            }
        });
    //#endregion
    //#region EDIT_STATUS_ATOMIC
    yield takeLatest(
        ActionTypes.EDIT_STATUS_ATOMIC_START,
        function* (input: any) {
            try {
                const { output } = yield race({
                    output: call(async (data: AtomicLstChangeDto = input.payload): Promise<number> => {
                        let rs = await http.patch('/AtomicAdminApi/AdminAtomic', data);
                        return rs ? rs.data : rs;
                    })
                });
                if (output) {
                    yield put(editStatusAtomicCompleted(output));
                }
                else {
                    yield put(editStatusAtomicError());
                }
            } catch (error) {
                yield put(editStatusAtomicError());
            }
        });
    //#endregion
    //#region INSERT_OR_UPDATE_ATOMIC
    yield takeLatest(
        ActionTypes.INSERT_OR_UPDATE_ATOMIC_START,
        function* (input: any) {
            try {
                const { output } = yield race({
                    output: call(async (data: AtomicLstChangeDto = input.payload): Promise<number> => {
                        let rs = await http.post('/AtomicAdminApi/AdminAtomic', data);
                        return rs ? rs.data : rs;
                    })
                });
                if (output) {
                    yield put(insertOrUpdateAtomicCompleted(output));
                }
                else {
                    yield put(insertOrUpdateAtomicError());
                }
            } catch (error) {
                yield put(insertOrUpdateAtomicError());
            }
        });
    //#endregion
    //#region SUMMARY_ATOMIC
    yield takeLatest(
        ActionTypes.SUMMARY_ATOMIC_START,
        function* (input: any) {
            try {
                const { output } = yield race({
                    output: call(async (): Promise<AtomicSummaryReadDto> => {
                        let rs = await http.get('/AtomicAdminApi/AdminSummaryAtomic');
                        return rs ? rs.data : rs;
                    })
                });
                if (output) {
                    yield put(summaryAtomicCompleted(output));
                }
                else {
                    yield put(summaryAtomicError());
                }
            } catch (error) {
                yield put(summaryAtomicError());
            }
        });
    //#endregion

    //#region GET_PERMISSION
    yield takeLatest(
        ActionTypes.GET_PERMISSION_START,
        function* (input: any) {
            try {
                const { output } = yield race({
                    output: call(async (): Promise<PagedListOutput<PermissionReadDto>> => {
                        let rs = await http.get('/PermissionAdminApi/AdminPermission', { params: input.payload });
                        return rs ? rs.data : rs;
                    })
                });
                if (output) {
                    yield put(getPermissionCompleted(output));
                }
                else {
                    yield put(getPermissionError());
                }
            } catch (error) {
                yield put(getPermissionError());
            }
        });
    //#endregion
    //#region DELETE_PERMISSION
    yield takeLatest(
        ActionTypes.DELETE_PERMISSION_START,
        function* (input: any) {
            try {
                const { output } = yield race({
                    output: call(async (data: number[] = input.payload): Promise<number> => {
                        let rs = await http.delete('/PermissionAdminApi/AdminPermission', { params: { ids: data } });
                        return rs ? rs.data : rs;
                    })
                });
                if (output) {
                    yield put(deletePermissionCompleted(output));
                }
                else {
                    yield put(deletePermissionError());
                }
            } catch (error) {
                yield put(deletePermissionError());
            }
        });
    //#endregion
    //#region EDIT_STATUS_PERMISSION
    yield takeLatest(
        ActionTypes.EDIT_STATUS_PERMISSION_START,
        function* (input: any) {
            try {
                const { output } = yield race({
                    output: call(async (data: PermissionLstChangeDto = input.payload): Promise<number> => {
                        let rs = await http.patch('/PermissionAdminApi/AdminPermission', data);
                        return rs ? rs.data : rs;
                    })
                });
                if (output) {
                    yield put(editStatusPermissionCompleted(output));
                }
                else {
                    yield put(editStatusPermissionError());
                }
            } catch (error) {
                yield put(editStatusPermissionError());
            }
        });
    //#endregion
    //#region INSERT_OR_UPDATE_PERMISSION
    yield takeLatest(
        ActionTypes.INSERT_OR_UPDATE_PERMISSION_START,
        function* (input: any) {
            try {
                const { output } = yield race({
                    output: call(async (data: PermissionLstChangeDto = input.payload): Promise<number> => {
                        let rs = await http.post('/PermissionAdminApi/AdminPermission', data);
                        return rs ? rs.data : rs;
                    })
                });
                if (output) {
                    yield put(insertOrUpdatePermissionCompleted(output));
                }
                else {
                    yield put(insertOrUpdatePermissionError());
                }
            } catch (error) {
                yield put(insertOrUpdatePermissionError());
            }
        });
    //#endregion
    //#region SEARCH_SUMMARY_PERMISSION
    yield takeLatest(
        ActionTypes.SEARCH_SUMMARY_PERMISSION_START,
        function* (input: any) {
            try {
                const { output } = yield race({
                    output: call(async (data: SearchTextInput = input.payload): Promise<PermissionSummaryReadDto> => {
                        let rs = await http.get('/PermissionAdminApi/AdminSummaryPermission', { params: data });
                        return rs ? rs.data : rs;
                    })
                });
                if (output) {
                    yield put(searchSummaryPermissionCompleted(output));
                }
                else {
                    yield put(searchSummaryPermissionError());
                }
            } catch (error) {
                yield put(searchSummaryPermissionError());
            }
        });
    //#endregion

    //#region GET_ROLE
    yield takeLatest(
        ActionTypes.GET_ROLE_START,
        function* (input: any) {
            try {
                const { output } = yield race({
                    output: call(async (): Promise<PagedListOutput<RoleReadDto>> => {
                        let rs = await http.get('/RoleAdminApi/AdminRole', { params: input.payload });
                        return rs ? rs.data : rs;
                    })
                });
                if (output) {
                    yield put(getRoleCompleted(output));
                }
                else {
                    yield put(getRoleError());
                }
            } catch (error) {
                yield put(getRoleError());
            }
        });
    //#endregion
    //#region DELETE_ROLE
    yield takeLatest(
        ActionTypes.DELETE_ROLE_START,
        function* (input: any) {
            try {
                const { output } = yield race({
                    output: call(async (data: number[] = input.payload): Promise<number> => {
                        let rs = await http.delete('/RoleAdminApi/AdminRole', { params: { ids: data } });
                        return rs ? rs.data : rs;
                    })
                });
                if (output) {
                    yield put(deleteRoleCompleted(output));
                }
                else {
                    yield put(deleteRoleError());
                }
            } catch (error) {
                yield put(deleteRoleError());
            }
        });
    //#endregion
    //#region EDIT_STATUS_ROLE
    yield takeLatest(
        ActionTypes.EDIT_STATUS_ROLE_START,
        function* (input: any) {
            try {
                const { output } = yield race({
                    output: call(async (data: RoleLstChangeDto = input.payload): Promise<number> => {
                        let rs = await http.patch('/RoleAdminApi/AdminRole', data);
                        return rs ? rs.data : rs;
                    })
                });
                if (output) {
                    yield put(editStatusRoleCompleted(output));
                }
                else {
                    yield put(editStatusRoleError());
                }
            } catch (error) {
                yield put(editStatusRoleError());
            }
        });
    //#endregion
    //#region INSERT_OR_UPDATE_ROLE
    yield takeLatest(
        ActionTypes.INSERT_OR_UPDATE_ROLE_START,
        function* (input: any) {
            try {
                const { output } = yield race({
                    output: call(async (data: RoleLstChangeDto = input.payload): Promise<number> => {
                        let rs = await http.post('/RoleAdminApi/AdminRole', data);
                        return rs ? rs.data : rs;
                    })
                });
                if (output) {
                    yield put(insertOrUpdateRoleCompleted(output));
                }
                else {
                    yield put(insertOrUpdateRoleError());
                }
            } catch (error) {
                yield put(insertOrUpdateRoleError());
            }
        });
    //#endregion
    //#region SEARCH_SUMMARY_ROLE
    yield takeLatest(
        ActionTypes.SEARCH_SUMMARY_ROLE_START,
        function* (input: any) {
            try {
                const { output } = yield race({
                    output: call(async (data: SearchTextInput = input.payload): Promise<RoleSummaryReadDto> => {
                        let rs = await http.get('/RoleAdminApi/AdminSummaryRole', { params: data });
                        return rs ? rs.data : rs;
                    })
                });
                if (output) {
                    yield put(searchSummaryRoleCompleted(output));
                }
                else {
                    yield put(searchSummaryRoleError());
                }
            } catch (error) {
                yield put(searchSummaryRoleError());
            }
        });
    //#endregion

    //#region GET_SUBJECT
    yield takeLatest(
        ActionTypes.GET_SUBJECT_START,
        function* (input: any) {
            try {
                const { output } = yield race({
                    output: call(async (): Promise<PagedListOutput<SubjectReadDto>> => {
                        let rs = await http.get('/SubjectAdminApi/AdminSubject', { params: input.payload });
                        return rs ? rs.data : rs;
                    })
                });
                if (output) {
                    yield put(getSubjectCompleted(output));
                }
                else {
                    yield put(getSubjectError());
                }
            } catch (error) {
                yield put(getSubjectError());
            }
        });
    //#endregion
    //#region DELETE_SUBJECT
    yield takeLatest(
        ActionTypes.DELETE_SUBJECT_START,
        function* (input: any) {
            try {
                const { output } = yield race({
                    output: call(async (data: number[] = input.payload): Promise<number> => {
                        let rs = await http.delete('/SubjectAdminApi/AdminSubject', { params: { ids: data } });
                        return rs ? rs.data : rs;
                    })
                });
                if (output) {
                    yield put(deleteSubjectCompleted(output));
                }
                else {
                    yield put(deleteSubjectError());
                }
            } catch (error) {
                yield put(deleteSubjectError());
            }
        });
    //#endregion
    //#region EDIT_STATUS_SUBJECT
    yield takeLatest(
        ActionTypes.EDIT_STATUS_SUBJECT_START,
        function* (input: any) {
            try {
                const { output } = yield race({
                    output: call(async (data: SubjectLstChangeDto = input.payload): Promise<number> => {
                        let rs = await http.patch('/SubjectAdminApi/AdminSubject', data);
                        return rs ? rs.data : rs;
                    })
                });
                if (output) {
                    yield put(editStatusSubjectCompleted(output));
                }
                else {
                    yield put(editStatusSubjectError());
                }
            } catch (error) {
                yield put(editStatusSubjectError());
            }
        });
    //#endregion
    //#region INSERT_OR_UPDATE_SUBJECT
    yield takeLatest(
        ActionTypes.INSERT_OR_UPDATE_SUBJECT_START,
        function* (input: any) {
            try {
                const { output } = yield race({
                    output: call(async (data: SubjectLstChangeDto = input.payload): Promise<number> => {
                        let rs = await http.post('/SubjectAdminApi/AdminSubject', data);
                        return rs ? rs.data : rs;
                    })
                });
                if (output) {
                    yield put(insertOrUpdateSubjectCompleted(output));
                }
                else {
                    yield put(insertOrUpdateSubjectError());
                }
            } catch (error) {
                yield put(insertOrUpdateSubjectError());
            }
        });
    //#endregion

    //#region PERMISSION_FT_RESOURCE
    yield takeLatest(
        ActionTypes.PERMISSION_FT_RESOURCE_START,
        function* (input: any) {
            try {
                const { output } = yield race({
                    output: call(async (): Promise<PagedListOutput<FtPermissionReadDto>> => {
                        let rs = await http.get('/ResourceApi/AdminResourceFtPermission', { params: input.payload });
                        return rs ? rs.data : rs;
                    })
                });
                if (output) {
                    yield put(permessionFtResourceCompleted(output));
                }
                else {
                    yield put(permessionFtResourceError());
                }
            } catch (error) {
                yield put(permessionFtResourceError());
            }
        });
    //#endregion
    //#region SAVE_PERMISSION_FT_RESOURCE
    yield takeLatest(
        ActionTypes.SAVE_PERMISSION_FT_RESOURCE_START,
        function* (input: any) {
            try {
                const { output } = yield race({
                    output: call(async (data: ResourceLstChangeDto = input.payload): Promise<PagedListOutput<ResourceReadDto>> => {
                        let rs = await http.post('/PermissionAdminApi/AdminAddResourceFtPermission', data);
                        return rs ? rs.data : rs;
                    })
                });
                if (output) {
                    yield put(savePermissionFtResourceCompleted(output));
                }
                else {
                    yield put(savePermissionFtResourceError());
                }
            } catch (error) {
                yield put(savePermissionFtResourceError());
            }
        });
    //#endregion
}
