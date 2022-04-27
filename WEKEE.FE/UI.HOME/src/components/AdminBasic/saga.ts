import { call, put, takeLatest, race } from 'redux-saga/effects';
import ActionTypes from './constants';
import http from '../../services/httpService';
import { deleteResourceCompleted, deleteResourceError, editStatusResourceCompleted, editStatusResourceError, getResourceCompleted, getResourceError, insertOrUpdateResourceCompleted, insertOrUpdateResourceError } from './actions';
import { PagedListOutput } from '../../services/dto/pagedListOutput';
import { ResourceReadDto } from './dto/resourceReadDto';
import { ResourceLstChangeDto } from './dto/resourceLstChangeDto';

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
    }});
    //#endregion
}
