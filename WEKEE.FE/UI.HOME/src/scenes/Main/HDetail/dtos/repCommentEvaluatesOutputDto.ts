export interface RepCommentEvaluatesOutputDto {
  id: number;
  idAccount: number;
  avatarAccount: string;
  nameAccount: string;
  comment: string;
  numberLike: number;
  numberDisLike: number;
  numberComment: number;
  numberRepost: number;
  dateComment: Date;
  youLike: boolean;
  youDisLike: boolean;
  repCommentEvaluates: RepCommentEvaluatesOutputDto[];
}
