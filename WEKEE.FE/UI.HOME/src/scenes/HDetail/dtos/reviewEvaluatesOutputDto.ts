import { ReviewAccountEvaluatesOutputDto } from "./reviewAccountEvaluatesOutputDto";
import { ImageEvaluatesDtos } from "./imageEvaluatesDtos";
import { RepCommentEvaluatesOutputDto } from "./repCommentEvaluatesOutputDto";

export interface ReviewEvaluatesOutputDto {
  accountReview: ReviewAccountEvaluatesOutputDto;
  idReview: number;
  content: string;
  starNumber: number;
  pinFeeling: string;
  image: ImageEvaluatesDtos[];
  dateReview: Date;
  likeReview: number;
  dislikeReview: number;
  commentReview: number;
  // you and comment
  youLike: boolean;
  youDisLike: boolean;
  // rep comment
  repCommentEvaluates: RepCommentEvaluatesOutputDto[];
}
