import { ActionType } from "typesafe-actions";
import * as actions from "./actions";
import { CartBasicProductDto } from "./dtos/cartBasicProductDto";
import { CategoryBreadcrumbDtos } from "./dtos/categoryBreadcrumbDtos";
import { FeatureProductContainerDto } from "./dtos/featureProductContainerDto";
import { ImageForProductDto } from "./dtos/imageForProductDto";
import { MainFeatureCheck } from "./dtos/mainFeatureCheckDto";
import { ProductReadForCartDto } from "./dtos/productReadForCartDto";

export interface HDetailState {
  readonly loading: boolean;
  readonly completed: boolean;
  readonly categoryBreadcrumbDtos: CategoryBreadcrumbDtos[];
  readonly basicProduct: CartBasicProductDto;
  readonly imageForProduct: ImageForProductDto[];
  readonly featureCartProduct: ProductReadForCartDto[];
  readonly featureProductContainer: FeatureProductContainerDto;
  readonly mainFeatureCheck : ProductReadForCartDto[];

}

export type HDetailActions = ActionType<typeof actions>;
