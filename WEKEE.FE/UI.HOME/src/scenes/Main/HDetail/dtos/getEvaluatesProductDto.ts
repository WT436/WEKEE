import { ImageEvaluatesDtos } from "./imageEvaluatesDtos";

export interface GetEvaluatesProductDto {
  numberStarFive: number;
  numberStarFour: number;
  numberStarThree: number;
  numberStarTwo: number;
  numberStarOne: number;
  imageReview: ImageEvaluatesDtos[];
}
