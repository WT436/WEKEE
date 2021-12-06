import { call, put, takeLatest, race } from "redux-saga/effects";
import {
  createProductsCompleted,
  createProductsError,
  getCategotyMainCompleted,
  getCategotyMainError,
  getSpecifiCategoryCompleted,
  getSpecifiCategoryError,
  getSpecifiCategoryUnitCompleted,
  getSpecifiCategoryUnitError,
  readFullAlbumProductCompleted,
  readFullAlbumProductError,
  watchPageCompleted,
  watchPageError,
} from "./actions";
import ActionTypes from "./constants";
import service from "./services";

export default function* watchLoginRequestStart() {
  yield takeLatest(ActionTypes.WATCH_PAGE_START, requestLogin);
  yield takeLatest(ActionTypes.GET_CATEGORY_MAIN_START, getCategotyMainStart);
  yield takeLatest(
    ActionTypes.READ_FULL_ALBUM_PRODUCT_START,
    readFullAlbumProductStart
  );
  yield takeLatest(
    ActionTypes.GET_SPECIFI_CATEGORY_START,
    getSpecifiCategoryStart
  );
  yield takeLatest(
    ActionTypes.GET_SPECIFI_CATEGORY_UNIT_START,
    getSpecifiCategoryUnitStart
  );
  yield takeLatest(ActionTypes.CREATE_PRODUCT_START, createProductsStart);
}

function* createProductsStart(input: any) {
  console.log(input);
  try {
    const { output } = yield race({
      output: call(service.createProductStart, input.payload),
    });
    if (output) {
      yield put(createProductsCompleted());
    } else {
      yield put(createProductsError());
    }
  } catch (error) {
    yield put(createProductsError());
  }
}

function* getSpecifiCategoryUnitStart() {
  try {
    const { output } = yield race({
      output: call(service.getSpecifiCategoryUnitStart),
    });
    if (output) {
      yield put(getSpecifiCategoryUnitCompleted(output));
    } else {
      yield put(getSpecifiCategoryUnitError());
    }
  } catch (error) {
    yield put(getSpecifiCategoryUnitError());
  }
}

function* getSpecifiCategoryStart(input: any) {
  try {
    const { output } = yield race({
      output: call(service.getSpecifiCategoryStart, input.payload),
    });
    if (output) {
      yield put(getSpecifiCategoryCompleted(output));
    } else {
      yield put(getSpecifiCategoryError());
    }
  } catch (error) {
    yield put(getSpecifiCategoryError());
  }
}

function* readFullAlbumProductStart() {
  try {
    const { output } = yield race({
      output: call(service.readFullAlbumProductStart),
    });
    if (output) {
      yield put(readFullAlbumProductCompleted(output));
    } else {
      yield put(readFullAlbumProductError());
    }
  } catch (error) {
    yield put(readFullAlbumProductError());
  }
}

function* getCategotyMainStart() {
  try {
    const { output } = yield race({
      output: call(service.getCategotyMainStart),
    });
    if (output) {
      yield put(getCategotyMainCompleted(output));
    } else {
      yield put(getCategotyMainError());
    }
  } catch (error) {
    yield put(getCategotyMainError());
  }
}

function* requestLogin(input: any) {
  try {
    const { output } = yield race({
      output: call(service.authenticate),
    });
    if (output) {
      yield put(watchPageCompleted());
    } else {
      yield put(watchPageError());
    }
  } catch (error) {
    yield put(watchPageError());
  }
}
