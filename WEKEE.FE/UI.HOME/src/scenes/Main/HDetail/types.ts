import { ActionType } from "typesafe-actions";
import { ImageProductDtos } from "../../Store/SuNewProduct/dtos/imageProductDtos";
import * as actions from "./actions";
import { CategoryBreadcrumbDtos } from "./dtos/categoryBreadcrumbDtos";
import { EvaluatesProductDto } from "./dtos/evaluatesProductDto";
import { GetEvaluatesProductDto } from "./dtos/getEvaluatesProductDto";
import { ImageProductCardDtos } from "./dtos/imageProductCardDtos";
import { ReviewEvaluatesInputDto } from "./dtos/reviewEvaluatesInputDto";
import { ReviewEvaluatesOutputDto } from "./dtos/reviewEvaluatesOutputDto";
import { UnitCardDtos } from "./dtos/unitCardDtos";

export interface HDetailState {
  readonly loading: boolean;
  readonly completed: boolean;
  readonly categoryBreadcrumbDtos: CategoryBreadcrumbDtos[];
  readonly unitCardProduct: UnitCardDtos;
  readonly imageS80x80: ImageProductCardDtos[];
  readonly imageS340x340: ImageProductCardDtos[];
  readonly imageS1360x1360: ImageProductCardDtos[];
  readonly startKey1: string[];
  readonly startKey2: string[];
  readonly startValues1: { value: string; img: number }[];
  readonly startValues2: { value: string; img: number }[];
  readonly evaluatesProductDto: EvaluatesProductDto;
  readonly getEvaluatesProductDto: GetEvaluatesProductDto;
  readonly reviewEvaluatesOutputDto: ReviewEvaluatesOutputDto[];
}

export type HDetailActions = ActionType<typeof actions>;
