import { call, put, takeLatest, race } from "redux-saga/effects";
import {
  createSpecificationsCompleted,
  createSpecificationsError,
  getCategotyMainCompleted,
  getCategotyMainError,
  getNameClassifyValuesSpecificationsCompleted,
  getNameClassifyValuesSpecificationsError,
  getNameKeySpecificationsCompleted,
  getNameKeySpecificationsError,
  searchSpecificationsCompleted,
  searchSpecificationsError,
  watchPageCompleted,
  watchPageError,
} from "./actions";
import ActionTypes from "./constants";
import service from "./services";

export default function* watchLoginRequestStart() {
  yield takeLatest(ActionTypes.WATCH_PAGE_START, requestLogin);

  yield takeLatest(ActionTypes.GET_CATEGORY_MAIN_START, getCategotyMainStart);

  yield takeLatest(
    ActionTypes.CREATE_SPECIFICATIONS_START,
    createSpecificationsStart
  );

  yield takeLatest(
    ActionTypes.GET_NAME_KEY_SPECIFICATIONS_START,
    getNameKeySpecificationsStart
  );

  yield takeLatest(
    ActionTypes.GET_NAME_VALUES_SPECIFICATIONS_START,
    getNameClassifyValuesSpecificationsStart
  );

  yield takeLatest(
    ActionTypes.SEARCH_SPECIFICATIONS_START,
    searchSpecificationsStart
  );
}

function* searchSpecificationsStart(input: any) {
  try {
    const { output } = yield race({
      output: call(
        service.searchSpecificationsStart,
        input.payload.key,
        input.payload.values
      ),
    });
    if (output) {
      yield put(searchSpecificationsCompleted(output));
    } else {
      yield put(searchSpecificationsError());
    }
  } catch (error) {
    yield put(searchSpecificationsError());
  }
}

function* getNameClassifyValuesSpecificationsStart(input: any) {
  try {
    const { output } = yield race({
      output: call(
        service.getNameClassifyValuesSpecificationsStart,
        input.payload
      ),
    });
    if (output) {
      yield put(getNameClassifyValuesSpecificationsCompleted(output));
    } else {
      yield put(getNameClassifyValuesSpecificationsError());
    }
  } catch (error) {
    yield put(getNameClassifyValuesSpecificationsError());
  }
}

function* getNameKeySpecificationsStart() {
  try {
    const { output } = yield race({
      output: call(service.getNameKeySpecificationsStart),
    });
    if (output) {
      yield put(getNameKeySpecificationsCompleted(output));
    } else {
      yield put(getNameKeySpecificationsError());
    }
  } catch (error) {
    yield put(getNameKeySpecificationsError());
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
