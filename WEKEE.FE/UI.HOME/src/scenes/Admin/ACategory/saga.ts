import { call, put, takeLatest, race } from "redux-saga/effects";
import {
  CategoryMapCompleted,
  CategoryMapError,
  createCategoryAdminCompleted,
  createCategoryAdminError,
  getCategoryAdminCompleted,
  getCategoryAdminError,
} from "./actions";
import ActionTypes from "./constants";
import service from "./services";

export default function* watchLoginRequestStart() {

  yield takeLatest(
    ActionTypes.CREATE_CATEGORY_ADMIN_START,
    createCategoryAdminStart
  );

  yield takeLatest(ActionTypes.GET_CATEGORY_ADMIN_START, getCategoryAdminStart);

  yield takeLatest(ActionTypes.CATEGORY_MAP_START, getCategoryMap);
}

function* getCategoryMap(){
  try {
    const { output } = yield race({
      output: call(service.getCategoryMapService),
    });
    console.log(output)
    if (output) {
      yield put(CategoryMapCompleted(output));
    } else {
      yield put(CategoryMapError());
    }
    
  } catch (error) {
    yield put(CategoryMapError());
  }
}

function* getCategoryAdminStart(input: any) {
  try {
    const { output } = yield race({
      output: call(
        service.getCategoryAdminStart, input.payload
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
