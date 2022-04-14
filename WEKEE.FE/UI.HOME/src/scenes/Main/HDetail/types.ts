import { ActionType } from "typesafe-actions";
import { ImageProductDtos } from "../../Store/SuNewProduct/dtos/imageProductDtos";
import * as actions from "./actions";
import { CartBasicProductDto } from "./dtos/cartBasicProductDto";
import { CategoryBreadcrumbDtos } from "./dtos/categoryBreadcrumbDtos";

export interface HDetailState {
  readonly loading: boolean;
  readonly completed: boolean;
  readonly categoryBreadcrumbDtos: CategoryBreadcrumbDtos[];
  readonly basicProduct : CartBasicProductDto;

}

export type HDetailActions = ActionType<typeof actions>;
