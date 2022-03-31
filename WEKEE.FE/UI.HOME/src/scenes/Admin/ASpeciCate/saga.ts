import { call, put, takeLatest, race } from "redux-saga/effects";
import {
  CategoryMapCompleted,
  CategoryMapError,
  createSpecificationsCompleted,
  createSpecificationsError,
  GetPageListSpecificationCompleted,
  GetPageListSpecificationError
} from "./actions";
import ActionTypes from "./constants";
import service from "./services";

export default function* watchLoginRequestStart() {

  yield takeLatest(
    ActionTypes.CREATE_SPECIFICATIONS_START,
    createSpecificationsStart
  );

  yield takeLatest(ActionTypes.CATEGORY_MAP_START, getCategoryMap);

  //#region SPECIFICATIONS_GET_PAGE_LIST
  yield takeLatest(ActionTypes.SPECIFICATIONS_GET_PAGE_LIST_START, GetPageListSpecification);
  //#endregion

}



//#region SPECIFICATIONS_GET_PAGE_LIST
function* GetPageListSpecification(input: any) {
  try {
    const { output } = yield race({
      output: call(service.GetPageListSpecificationService, input.payload),
    });
    if (output) {
      yield put(GetPageListSpecificationCompleted(output));
    } else {
      yield put(GetPageListSpecificationError());
    }
  } catch (error) {
    yield put(GetPageListSpecificationError());
  }
}
//#endregion

function* getCategoryMap() {
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

function* createSpecificationsStart(input: any) {
  try {
    const { output } = yield race({
      output: call(service.createSpecificationsStart, input.payload),
    });
    if (output) {
      yield put(createSpecificationsCompleted(output));
    } else {
      yield put(createSpecificationsError());
    }
  } catch (error) {
    yield put(createSpecificationsError());
  }
}