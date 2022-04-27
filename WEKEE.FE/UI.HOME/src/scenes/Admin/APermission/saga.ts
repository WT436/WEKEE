import { call, put, takeLatest, race } from 'redux-saga/effects';
import ActionTypes from './constants';
import http from '../../../services/httpService';
import { deleteAtomicCompleted, deleteAtomicError, deleteResourceCompleted, deleteResourceError, editStatusAtomicCompleted, editStatusAtomicError, editStatusResourceCompleted, editStatusResourceError, getAtomicCompleted, getAtomicError, getResourceCompleted, getResourceError, insertOrUpdateAtomicCompleted, insertOrUpdateAtomicError, insertOrUpdateResourceCompleted, insertOrUpdateResourceError } from './actions';
import { PagedListOutput } from '../../../services/dto/pagedListOutput';
import { ResourceReadDto } from './dto/resourceReadDto';
import { ResourceLstChangeDto } from './dto/resourceLstChangeDto';
import { AtomicReadDto } from './dto/atomicReadDto';
import { AtomicLstChangeDto } from './dto/atomicLstChangeDto';

export default function* CallApiService() {
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

}
