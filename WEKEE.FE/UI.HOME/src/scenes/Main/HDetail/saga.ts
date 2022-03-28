import { call, put, takeLatest, race } from "redux-saga/effects";
import {
  createYouAssessmentCompleted,
  createYouAssessmentError,
  dislikeEvaluatesProductCompleted,
  dislikeEvaluatesProductError,
  getCategoryBreadcrumbCompleted,
  getCategoryBreadcrumbError,
  getProductCardCompleted,
  getProductCardError,
  getRepcommentAssessmentCompleted,
  getRepcommentAssessmentError,
  likeEvaluatesProductCompleted,
  likeEvaluatesProductError,
  overviewEvaluatesProductCompleted,
  overviewEvaluatesProductError,
  removeYouAssessmentCompleted,
  removeYouAssessmentError,
  repcommentAssessmentCompleted,
  repcommentAssessmentError,
  reviewEvaluatesProductCompleted,
  reviewEvaluatesProductError,
} from "./actions";
import ActionTypes from "./constants";
import service from "./services";

export default function* watchLoginRequestStart() {
  yield takeLatest(
    ActionTypes.GET_CATEGORY_BREADCRUMB_START,
    getCategoryBreadcrumbStart
  );

  yield takeLatest(ActionTypes.GET_PRODUCT_CARD_START, getProductCardStart);
  yield takeLatest(
    ActionTypes.REMOVE_YOU_ASSESSMENT_START,
    removeYouAssessmentStart
  );
  yield takeLatest(
    ActionTypes.CREATE_YOU_ASSESSMENT_START,
    createYouAssessmentStart
  );

  yield takeLatest(
    ActionTypes.GET_OVERVIEW_EVALUATES_PRODUCT_START,
    overviewEvaluatesProductStart
  );

  yield takeLatest(
    ActionTypes.GET_REVIEW_EVALUATES_PRODUCT_START,
    reviewEvaluatesProductStart
  );
  yield takeLatest(
    ActionTypes.LIKE_EVALUATES_PRODUCT_START,
    likeEvaluatesProductStart
  );
  yield takeLatest(
    ActionTypes.DISLIKE_EVALUATES_PRODUCT_START,
    dislikeEvaluatesProductStart
  );
  yield takeLatest(
    ActionTypes.REPCOMMENT_EVALUATES_PRODUCT_START,
    repcommentAssessmentStart
  );
  yield takeLatest(
    ActionTypes.GET_REPCOMMENT_EVALUATES_PRODUCT_START,
    getRepcommentAssessmentStart
  );
}

function* getRepcommentAssessmentStart(input: any) {
  try {
    const { output } = yield race({
      output: call(
        service.getRepcommentAssessmentStart,
        input.payload.id,
        input.payload.level,
        input.payload.page
      ),
    });
    if (output) {
      var level = input.payload.level;
      var id = input.payload.id;
      yield put(getRepcommentAssessmentCompleted(output, level, id));
    } else {
      yield put(getRepcommentAssessmentError());
    }
  } catch (error) {
    yield put(getRepcommentAssessmentError());
  }
}

function* repcommentAssessmentStart(input: any) {
  try {
    const { output } = yield race({
      output: call(service.repcommentAssessmentStart, input.payload),
    });
    if (output) {
      yield put(repcommentAssessmentCompleted());
    } else {
      yield put(repcommentAssessmentError());
    }
  } catch (error) {
    yield put(repcommentAssessmentError());
  }
}

function* dislikeEvaluatesProductStart(input: any) {
  try {
    const { output } = yield race({
      output: call(
        service.dislikeEvaluatesProductStart,
        input.payload.levelEvaluates,
        input.payload.idEvaluates
      ),
    });
    if (output) {
      yield put(dislikeEvaluatesProductCompleted());
    } else {
      yield put(dislikeEvaluatesProductError());
    }
  } catch (error) {
    yield put(dislikeEvaluatesProductError());
  }
}

function* likeEvaluatesProductStart(input: any) {
  try {
    const { output } = yield race({
      output: call(
        service.likeEvaluatesProductStart,
        input.payload.levelEvaluates,
        input.payload.idEvaluates
      ),
    });
    if (output) {
      yield put(likeEvaluatesProductCompleted());
    } else {
      yield put(likeEvaluatesProductError());
    }
  } catch (error) {
    yield put(likeEvaluatesProductError());
  }
}

function* reviewEvaluatesProductStart(input: any) {
  try {
    const { output } = yield race({
      output: call(service.reviewEvaluatesProductStart, input.payload),
    });
    if (output) {
      yield put(reviewEvaluatesProductCompleted(output));
    } else {
      yield put(reviewEvaluatesProductError());
    }
  } catch (error) {
    yield put(reviewEvaluatesProductError());
  }
}

function* overviewEvaluatesProductStart(input: any) {
  try {
    const { output } = yield race({
      output: call(service.overviewEvaluatesProductStart, input.payload),
    });
    if (output) {
      yield put(overviewEvaluatesProductCompleted(output));
    } else {
      yield put(overviewEvaluatesProductError());
    }
  } catch (error) {
    yield put(overviewEvaluatesProductError());
  }
}

function* createYouAssessmentStart(input: any) {
  try {
    const { output } = yield race({
      output: call(service.createYouAssessmentStart, input.payload),
    });
    if (output) {
      yield put(createYouAssessmentCompleted());
    } else {
      yield put(createYouAssessmentError());
    }
  } catch (error) {
    yield put(createYouAssessmentError());
  }
}

function* removeYouAssessmentStart(input: any) {
  try {
    const { output } = yield race({
      output: call(service.removeYouAssessmentStart, input.payload),
    });
    if (output) {
      yield put(removeYouAssessmentCompleted());
    } else {
      yield put(removeYouAssessmentError());
    }
  } catch (error) {
    yield put(removeYouAssessmentError());
  }
}

function* getProductCardStart(input: any) {
  try {
    const { output } = yield race({
      output: call(service.getProductCardStart, input.payload),
    });
    if (output) {
      yield put(getProductCardCompleted(output));
    } else {
      yield put(getProductCardError());
    }
  } catch (error) {
    yield put(getProductCardError());
  }
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
