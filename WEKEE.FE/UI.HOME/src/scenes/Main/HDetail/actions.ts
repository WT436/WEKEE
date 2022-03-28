import { action } from "typesafe-actions";

import ActionTypes from "./constants";
import { CategoryBreadcrumbDtos } from "./dtos/categoryBreadcrumbDtos";
import { UnitCardDtos } from "./dtos/unitCardDtos";
import { EvaluatesProductDto } from "./dtos/evaluatesProductDto";
import { GetEvaluatesProductDto } from "./dtos/getEvaluatesProductDto";
import { ReviewEvaluatesInputDto } from "./dtos/reviewEvaluatesInputDto";
import { ReviewEvaluatesOutputDto } from "./dtos/reviewEvaluatesOutputDto";
import { RepCommentEvaluatesOutputDto } from "./dtos/repCommentEvaluatesOutputDto";
// open page login
export const getCategoryBreadcrumbStart = (id: number) =>
  action(ActionTypes.GET_CATEGORY_BREADCRUMB_START, id);
export const getCategoryBreadcrumbCompleted = (
  output: CategoryBreadcrumbDtos[]
) => action(ActionTypes.GET_CATEGORY_BREADCRUMB_COMPLETED, output);
export const getCategoryBreadcrumbError = () =>
  action(ActionTypes.GET_CATEGORY_BREADCRUMB_ERROR);

export const getProductCardStart = (id: number) =>
  action(ActionTypes.GET_PRODUCT_CARD_START, id);
export const getProductCardCompleted = (output: UnitCardDtos) =>
  action(ActionTypes.GET_PRODUCT_CARD_COMPLETED, output);
export const getProductCardError = () =>
  action(ActionTypes.GET_PRODUCT_CARD_ERROR);

export const removeYouAssessmentStart = (url: string) =>
  action(ActionTypes.REMOVE_YOU_ASSESSMENT_START, url);
export const removeYouAssessmentCompleted = () =>
  action(ActionTypes.REMOVE_YOU_ASSESSMENT_COMPLETED);
export const removeYouAssessmentError = () =>
  action(ActionTypes.REMOVE_YOU_ASSESSMENT_ERROR);

export const createYouAssessmentStart = (
  evaluatesProductDto: EvaluatesProductDto
) => action(ActionTypes.CREATE_YOU_ASSESSMENT_START, evaluatesProductDto);
export const createYouAssessmentCompleted = () =>
  action(ActionTypes.CREATE_YOU_ASSESSMENT_COMPLETED);
export const createYouAssessmentError = () =>
  action(ActionTypes.CREATE_YOU_ASSESSMENT_ERROR);

export const overviewEvaluatesProductStart = (id: number) =>
  action(ActionTypes.GET_OVERVIEW_EVALUATES_PRODUCT_START, id);
export const overviewEvaluatesProductCompleted = (
  output: GetEvaluatesProductDto
) => action(ActionTypes.GET_OVERVIEW_EVALUATES_PRODUCT_COMPLETED, output);
export const overviewEvaluatesProductError = () =>
  action(ActionTypes.GET_OVERVIEW_EVALUATES_PRODUCT_ERROR);

export const reviewEvaluatesProductStart = (
  reviewEvaluatesInputDto: ReviewEvaluatesInputDto
) =>
  action(
    ActionTypes.GET_REVIEW_EVALUATES_PRODUCT_START,
    reviewEvaluatesInputDto
  );
export const reviewEvaluatesProductCompleted = (
  output: ReviewEvaluatesOutputDto[]
) => action(ActionTypes.GET_REVIEW_EVALUATES_PRODUCT_COMPLETED, output);
export const reviewEvaluatesProductError = () =>
  action(ActionTypes.GET_REVIEW_EVALUATES_PRODUCT_ERROR);

export const likeEvaluatesProductStart = (
  levelEvaluates: number,
  idEvaluates: number
) =>
  action(ActionTypes.LIKE_EVALUATES_PRODUCT_START, {
    levelEvaluates,
    idEvaluates,
  });
export const likeEvaluatesProductCompleted = () =>
  action(ActionTypes.LIKE_EVALUATES_PRODUCT_COMPLETED);
export const likeEvaluatesProductError = () =>
  action(ActionTypes.LIKE_EVALUATES_PRODUCT_ERROR);

export const dislikeEvaluatesProductStart = (
  levelEvaluates: number,
  idEvaluates: number
) =>
  action(ActionTypes.DISLIKE_EVALUATES_PRODUCT_START, {
    levelEvaluates,
    idEvaluates,
  });
export const dislikeEvaluatesProductCompleted = () =>
  action(ActionTypes.DISLIKE_EVALUATES_PRODUCT_COMPLETED);
export const dislikeEvaluatesProductError = () =>
  action(ActionTypes.DISLIKE_EVALUATES_PRODUCT_ERROR);

export const repcommentAssessmentStart = (
  evaluatesProductDto: EvaluatesProductDto
) =>
  action(ActionTypes.REPCOMMENT_EVALUATES_PRODUCT_START, evaluatesProductDto);
export const repcommentAssessmentCompleted = () =>
  action(ActionTypes.REPCOMMENT_EVALUATES_PRODUCT_COMPLETED);
export const repcommentAssessmentError = () =>
  action(ActionTypes.REPCOMMENT_EVALUATES_PRODUCT_ERROR);

export const getRepcommentAssessmentStart = (
  id: number,
  level: number,
  page: number
) =>
  action(ActionTypes.GET_REPCOMMENT_EVALUATES_PRODUCT_START, {
    id,
    level,
    page,
  });
export const getRepcommentAssessmentCompleted = (
  output: RepCommentEvaluatesOutputDto[],
  level: number,
  id: number
) =>
  action(ActionTypes.GET_REPCOMMENT_EVALUATES_PRODUCT_COMPLETED, {
    output,
    level,
    id,
  });
export const getRepcommentAssessmentError = () =>
  action(ActionTypes.GET_REPCOMMENT_EVALUATES_PRODUCT_ERROR);
