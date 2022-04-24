import { call, put, takeLatest, race } from 'redux-saga/effects';
import ActionTypes from './constants';
import http from '../../../services/httpService';
import { getResourceCompleted, getResourceError } from './actions';
import { PagedListOutput } from '../../../services/dto/pagedListOutput';
import { ResourceReadDto } from './dto/resourceReadDto';

export default function* CallApiService() {

    yield takeLatest(
        ActionTypes.GET_RESOURCE_START,
        function* (input: any) {
            try {
                const { output } = yield race({
                    output: call(async (): Promise<PagedListOutput<ResourceReadDto>> => {
                        let rs = await http.get('/admin-resource',{params:{input: input.payload}});
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
        }
    );
}
