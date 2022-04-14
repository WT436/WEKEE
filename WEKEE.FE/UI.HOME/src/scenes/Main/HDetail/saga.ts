import { call, put, takeLatest, race } from "redux-saga/effects";
import {
  getCategoryBreadcrumbCompleted,
  getCategoryBreadcrumbError
} from "./actions";
import ActionTypes from "./constants";
import service from "./services";

export default function* watchLoginRequestStart() {
  yield takeLatest(
    ActionTypes.GET_CATEGORY_BREADCRUMB_START,
    getCategoryBreadcrumbStart
  );
}

function* getCategoryBreadcrumbStart(input: any) {
  try {
    const { output } = yield race({
      output: call(service.getCategoryBreadcrumbStart, input.payload),
    });
    if (output) {
      yield put(getCategoryBreadcrumbCompleted(output));
    } else {
      yield put(getCategoryBreadcrumbError());
    }
  } catch (error) {
    yield put(getCategoryBreadcrumbError());
  }
}
