import { call, put, takeLatest, race } from "redux-saga/effects";
import {
  createCategoryAdminCompleted,
  createCategoryAdminError,
  getCategoryAdminCompleted,
  getCategoryAdminError,
  watchPageError,
} from "./actions";
import ActionTypes from "./constants";
import service from "./services";

export default function* watchLoginRequestStart() {
  yield takeLatest(ActionTypes.WATCH_PAGE_START, requestLogin);

  yield takeLatest(
    ActionTypes.CREATE_CATEGORY_ADMIN_START,
    createCategoryAdminStart
  );

  yield takeLatest(ActionTypes.GET_CATEGORY_ADMIN_START, getCategoryAdminStart);
}

function* getCategoryAdminStart(input: any) {
  try {
    const { output } = yield race({
      output: call(
        service.getCategoryAdminStart,
        input.payload.level,
        input.payload.categorymain,
        input.payload.orderNumber
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

function* createCategoryAdminStart(input: any) {
  try {
    const { output } = yield race({
      output: call(service.createCategoryAdminStart, input.payload),
    });
    if (output) {
      yield put(createCategoryAdminCompleted(output));
    } else {
      yield put(createCategoryAdminError());
    }
  } catch (error) {
    yield put(createCategoryAdminError());
  }
}

function* requestLogin(input: any) {
  try {
  } catch (error) {
    yield put(watchPageError());
  }
}
