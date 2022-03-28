import { ActionType } from "typesafe-actions";
import * as actions from "./actions";
import { CategorySelectDto } from "./dtos/categorySelectDto";
import { SpecificationsCategoryDto } from "./dtos/specificationsCategoryDto";

export interface ASpeciCateState {
  readonly loading: boolean;
  readonly completed: boolean;
  readonly pageIndex: number;
  readonly pageSize: number;
  readonly totalCount: number;
  readonly totalPages: number;
  readonly categorySelectDto: CategorySelectDto[];
  readonly nameKey: string[];
  readonly classifyValues: string[];
  readonly specificationsCategoryDto: SpecificationsCategoryDto[];
}

export type ASpeciCateActions = ActionType<typeof actions>;
