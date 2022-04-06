import { ImageProductDtos } from "./imageProductDtos";
import { ProductDtos } from "./productDtos";

export interface CreateProductDtos {
  productDto: ProductDtos;
  //featureProductDtos: FeatureProductDtos[];
  imageProductDtos: ImageProductDtos[];
  //highlightProductDtos: HighlightProductDtos[];
}
