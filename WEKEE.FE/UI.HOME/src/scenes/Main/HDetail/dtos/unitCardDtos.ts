import { FeatureProductCardDtos } from "./featureProductCardDtos";
import { HighlightProductCardDtos } from "./highlightProductCardDtos";
import { ImageProductCardDtos } from "./imageProductCardDtos";
import { ProductCardDtos } from "./productCardDtos";

export interface UnitCardDtos {
  productCardDtos: ProductCardDtos;
  featureProductCardDtos: FeatureProductCardDtos[];
  imageProductCardDtos: ImageProductCardDtos[];
  highlightProductCardDtos: HighlightProductCardDtos[];
}
