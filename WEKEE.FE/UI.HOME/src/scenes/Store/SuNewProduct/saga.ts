import { call, put, takeLatest, race } from "redux-saga/effects";
import {
  createProductsCompleted,
  createProductsError,
  getCategotyMainCompleted,
  getCategotyMainError,
  getSpecifiCategoryCompleted,
  getSpecifiCategoryError,
  InsertProductFullCompleted,
  InsertProductFullError,
  loadCategoryValueCompleted,
  loadCategoryValueError,
  loadKeyGroupCompleted,
  loadKeyGroupError,
  nameGroupSpecCompleted,
  nameGroupSpecError,
  proAttrTypesAttributeCompleted,
  proAttrTypesTradeMarkCompleted,
  proAttrTypesUnitCompleted,
  proAttrTypesUnitError,
  readFullAlbumProductCompleted,
  readFullAlbumProductError
} from "./actions";
import ActionTypes from "./constants";
import service from "./services";

export default function* watchLoginRequestStart() {
  yield takeLatest(ActionTypes.GET_CATEGORY_MAIN_START, getCategotyMainStart);
  yield takeLatest(ActionTypes.READ_FULL_ALBUM_PRODUCT_START, readFullAlbumProductStart);
  yield takeLatest(ActionTypes.GET_SPECIFI_CATEGORY_START, getSpecifiCategoryStart);
  yield takeLatest(ActionTypes.CREATE_PRODUCT_START, createProductsStart);
  //#region PRO_ATTR_TYPE_UNIT 
  yield takeLatest(ActionTypes.PRO_ATTR_TYPE_UNIT_START, proAttrTypesUnit);
  //#endregion
  //#region INSERT_PRODUCT_FULL
  yield takeLatest(ActionTypes.INSERT_PRODUCT_FULL_START, InsertProductFull);
  //#endregion
  //#region LOAD_CATEGORY_VALUE
  yield takeLatest(ActionTypes.LOAD_CATEGORY_VALUE_START, loadCategoryValue);
  //#endregion
  //#region NAME_GROUP_SPEC
  yield takeLatest(ActionTypes.NAME_GROUP_SPEC_START, nameGroupSpec);
  //#endregion
  //#region LOAD_KEY_GROUP
  yield takeLatest(ActionTypes.LOAD_KEY_GROUP_START, loadKeyGroup);
  //#endregion
}
//#region LOAD_KEY_GROUP
function* loadKeyGroup(input: any) {
  console.log(input);
  try {
    const { output } = yield race({
      output: call(service.loadKeyGroupService, input.payload, input.meta),
    });
    if (output) {
      yield put(loadKeyGroupCompleted(output));
    } else {
      yield put(loadKeyGroupError());
    }
  } catch (error) {
    yield put(loadKeyGroupError());
  }
}
//#endregion

//#region NAME_GROUP_SPEC
function* nameGroupSpec(input: any) {
  try {
    const { output } = yield race({
      output: call(service.nameGroupSpecService, input.payload),
    });
    if (output) {
      yield put(nameGroupSpecCompleted(output));
    } else {
      yield put(nameGroupSpecError());
    }
  } catch (error) {
    yield put(nameGroupSpecError());
  }
}
//#endregion
//#region LOAD_CATEGORY_VALUE
function* loadCategoryValue(input: any) {
  try {
    const { output } = yield race({
      output: call(service.loadCategoryValueService, input.payload),
    });
    if (output) {
      yield put(loadCategoryValueCompleted(output, input.meta));
    } else {
      yield put(loadCategoryValueError());
    }
  } catch (error) {
    yield put(loadCategoryValueError());
  }
}
//#endregion
//#region INSERT_PRODUCT_FULL
function* InsertProductFull(input: any) {
  try {
    const { output } = yield race({
      output: call(service.InsertProductFullService, input.payload),
    });
    if (output) {
      yield put(InsertProductFullCompleted(output));
    } else {
      yield put(InsertProductFullError());
    }
  } catch (error) {
    yield put(InsertProductFullError());
  }
}
//#endregion
//#region PRO_ATTR_TYPE_UNIT 
function* proAttrTypesUnit(input: any) {
  try {
    const { output } = yield race({
      output: call(service.proAttrTypesUnitService, input.payload, input.meta),
    });
    if (output) {
      if (input.payload === 0) {
        yield put(proAttrTypesAttributeCompleted(output));
      }
      if (input.payload === 1) {
        yield put(proAttrTypesUnitCompleted(output));
      }
      if (input.payload === 3) {
        yield put(proAttrTypesTradeMarkCompleted(output));
      }
    } else {
      yield put(proAttrTypesUnitError());
    }
  } catch (error) {
    yield put(proAttrTypesUnitError());
  }
}
//#endregion

function* createProductsStart(input: any) {
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

function* getCategotyMainStart(input: any) {
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