import { call, put, takeLatest, race } from "redux-saga/effects";
import {
  getBasicCartProductCompleted,
  getBasicCartProductError,
  getCategoryBreadcrumbCompleted,
  getCategoryBreadcrumbError,
  getFeatureProductCartCompleted,
  getFeatureProductCartError,
  getImageProductCompleted,
  getImageProductError
} from "./actions";
import ActionTypes from "./constants";
import service from "./services";

export default function* watchLoginRequestStart() {
  //#region GET_FEATURE_CART_PRODUCT
  yield takeLatest(ActionTypes.GET_FEATURE_CART_PRODUCT_START, getFeatureCartProduct);
  //#endregion
  //#region GET_CATEGORY_BREADCRUMB  
  yield takeLatest(
    ActionTypes.GET_CATEGORY_BREADCRUMB_START,
    getCategoryBreadcrumbStart
  );
  //#endregion
  //#region GET_BASIC_PRODUCT_CART
  yield takeLatest(ActionTypes.GET_BASIC_PRODUCT_CART_START, getBasicProductCart);
  //#endregion
  //#region GET_IMAGE_PRODUCT
  yield takeLatest(ActionTypes.GET_IMAGE_PRODUCT_START, getImageProduct);
  //#endregion
}


//#region GET_FEATURE_CART_PRODUCT
function* getFeatureCartProduct(input: any) {
  try {
    const { output } = yield race({
      output: call(service.getFeatureCartProductService, input.payload),
    });
    if (output) {
      yield put(getFeatureProductCartCompleted(output));
    } else {
      yield put(getFeatureProductCartError());
    }
  } catch (error) {
    yield put(getFeatureProductCartError());
  }
}
//#endregion
//#region GET_IMAGE_PRODUCT
function* getImageProduct(input: any) {
  try {
    const { output } = yield race({
      output: call(service.getImageProductService, input.payload),
    });
    if (output) {
      yield put(getImageProductCompleted(output));
    } else {
      yield put(getImageProductError());
    }
  } catch (error) {
    yield put(getImageProductError());
  }
}
//#endregion
//#region GET_BASIC_PRODUCT_CART
function* getBasicProductCart(input: any) {
  try {
    const { output } = yield race({
      output: call(service.getBasicProductCartService, input.payload),
    });
    if (output) {
      yield put(getBasicCartProductCompleted(output));
    } else {
      yield put(getBasicCartProductError());
    }
  } catch (error) {
    yield put(getBasicCartProductError());
  }
}
//#endregion
//#region GET_CATEGORY_BREADCRUMB 
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
 //#endregion
