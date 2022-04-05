import { call, put, takeLatest, race } from 'redux-saga/effects';
import { createAttributeProductCompleted, createAttributeProductError, getDataAttibuteProductError, watchPageCompleted, watchPageError } from './actions';
import ActionTypes from './constants';
import service from './services';
import { getDataAttibuteProductCompleted } from './actions'

export default function* watchLoginRequestStart() {

    yield takeLatest(
        ActionTypes.WATCH_PAGE_START,
        requestLogin
    );
    //#region GET_DATA_ATTRIBUTE_PRODUCT
    yield takeLatest(ActionTypes.GET_DATA_ATTRIBUTE_PRODUCT_START, getDataAttributeProduct);
    //#endregion

    //#region CREATE_ATTRIBUTE_PRODUCT
    yield takeLatest(ActionTypes.CREATE_ATTRIBUTE_PRODUCT_START, createAttributeProduct);
    //#endregion

}


//#region CREATE_ATTRIBUTE_PRODUCT
function* createAttributeProduct(input: any) {
    try {
        const { output } = yield race({
            output: call(service.createAttributeProductService, input.payload),
        });
        if (output) {
            yield put(createAttributeProductCompleted(output));
        } else {
            yield put(createAttributeProductError());
        }
    } catch (error) {
        yield put(createAttributeProductError());
    }
}
//#endregion

//#region GET_DATA_ATTRIBUTE_PRODUCT
function* getDataAttributeProduct(input: any) {
    try {
        const { output } = yield race({
            output: call(service.getDataAttributeProductService, input.payload),
        });
        if (output) {
            yield put(getDataAttibuteProductCompleted(output));
        } else {
            yield put(getDataAttibuteProductError());
        }
    } catch (error) {
        yield put(getDataAttibuteProductError());
    }
}
//#endregion

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