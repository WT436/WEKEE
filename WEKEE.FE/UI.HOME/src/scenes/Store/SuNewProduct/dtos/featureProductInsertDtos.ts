import { ProductAttributeValueInsertDtos } from "./productAttributeValueInsertDtos"

export interface FeatureProductInsertDtos {
  id: Number
  productId: Number
  weightAdjustment: Number,
  lengthAdjustment: Number,
  widthAdjustment: Number,
  heightAdjustment: Number,
  price: Number,
  quantity: Number,
  displayOrder: Number,
  pictureString: String,
  mainProduct: boolean,
  productAttributeValueInsertDtos : ProductAttributeValueInsertDtos[]
}
