import ActionTypes from "./constants";
import { FeatureProductCardDtos } from "./dtos/featureProductCardDtos";
import { ImageProductCardDtos } from "./dtos/imageProductCardDtos";
import { RepCommentEvaluatesOutputDto } from "./dtos/repCommentEvaluatesOutputDto";
import { ReviewEvaluatesOutputDto } from "./dtos/reviewEvaluatesOutputDto";
import { HDetailState, HDetailActions } from "./types";

declare var abp: any;

export const initialState: HDetailState = {
  loading: false,
  completed: true,
  categoryBreadcrumbDtos: [
    { nameCategory: "", urlCategory: "", levelCategory: 0 },
  ],
  unitCardProduct: {
    productCardDtos: {
      id: 0,
      name: "",
      nameUnitProduct: "",
      fragile: true,
      origin: "",
      trademark: 0,
      nameTrademark: "",
      introduce: "",
      tag: "",
      supplier: 0,
    },
    featureProductCardDtos: [],
    imageProductCardDtos: [],
    highlightProductCardDtos: [],
  },

  imageS80x80: [],
  imageS340x340: [],
  imageS1360x1360: [],

  startKey1: [],
  startKey2: [],
  startValues1: [],
  startValues2: [],
  evaluatesProductDto: {
    id: 0,
    content: "",
    starNumber: 0,
    pinFeeling: [],
    image: [],
    product: 0,
    levelEvaluates: 0,
  },
  getEvaluatesProductDto: {
    numberStarFive: 0,
    numberStarFour: 0,
    numberStarThree: 0,
    numberStarTwo: 0,
    numberStarOne: 0,
    imageReview: [],
  },
  reviewEvaluatesOutputDto: [],
};

function hDetailReducer(
  state: HDetailState = initialState,
  action: HDetailActions
) {
  switch (action.type) {
    case ActionTypes.GET_CATEGORY_BREADCRUMB_START:
      return {
        ...state,
        loading: true,
      };
    case ActionTypes.GET_CATEGORY_BREADCRUMB_COMPLETED:
      return {
        ...state,
        loading: false,
        completed: true,
        categoryBreadcrumbDtos: action.payload,
      };
    case ActionTypes.GET_CATEGORY_BREADCRUMB_ERROR:
      return {
        ...state,
        loading: false,
      };

    case ActionTypes.GET_PRODUCT_CARD_START:
      return {
        ...state,
        loading: true,
      };
    case ActionTypes.GET_PRODUCT_CARD_COMPLETED:
      var localKey1: string[] = [];
      var localKey2: string[] = [];
      var localValues1: { value: string; img: number }[] = [];
      var localValues2: string[] = [];

      action.payload.imageProductCardDtos.forEach(
        (element: ImageProductCardDtos) => {
          if (element.size === "S80x80") {
            state.imageS80x80.push(element);
          }

          if (element.size === "S340x340") {
            state.imageS340x340.push(element);
          }

          if (element.size === "S1360x1360") {
            state.imageS1360x1360.push(element);
          }
        }
      );

      action.payload.featureProductCardDtos.forEach(
        (element: FeatureProductCardDtos) => {
          localKey1.push(element.nameKey1);
          localValues1.push({ value: element.properties1, img: element.image });
          localKey2.push(element.nameKey2);
          localValues2.push(element.properties2);
        }
      );

      return {
        ...state,
        loading: false,
        completed: true,
        unitCardProduct: action.payload,
        startKey1: localKey1.filter((value, index, self) => {
          return self.indexOf(value) === index;
        }),
        startKey2: localKey2.filter((value, index, self) => {
          return self.indexOf(value) === index;
        }),
        startValues1: Array.from(
          new Map(localValues1.map((item) => [item.value, item])).values()
        ),
        startValues2: localValues2.filter((value, index, self) => {
          return self.indexOf(value) === index;
        }),
      };
    case ActionTypes.GET_PRODUCT_CARD_ERROR:
      return {
        ...state,
        loading: false,
      };

    case ActionTypes.CREATE_YOU_ASSESSMENT_START:
      return {
        ...state,
        loading: true,
      };
    case ActionTypes.CREATE_YOU_ASSESSMENT_COMPLETED:
      return {
        ...state,
        loading: false,
      };
    case ActionTypes.CREATE_YOU_ASSESSMENT_ERROR:
      return {
        ...state,
        loading: false,
      };

    case ActionTypes.GET_OVERVIEW_EVALUATES_PRODUCT_START:
      return {
        ...state,
        loading: true,
      };
    case ActionTypes.GET_OVERVIEW_EVALUATES_PRODUCT_COMPLETED:
      return {
        ...state,
        loading: false,
        getEvaluatesProductDto: action.payload,
      };
    case ActionTypes.GET_OVERVIEW_EVALUATES_PRODUCT_ERROR:
      return {
        ...state,
        loading: false,
      };

    case ActionTypes.GET_REVIEW_EVALUATES_PRODUCT_START:
      return {
        ...state,
        loading: true,
      };
    case ActionTypes.GET_REVIEW_EVALUATES_PRODUCT_COMPLETED:
      return {
        ...state,
        loading: false,
        reviewEvaluatesOutputDto: action.payload,
      };
    case ActionTypes.GET_REVIEW_EVALUATES_PRODUCT_ERROR:
      return {
        ...state,
        loading: false,
      };

    case ActionTypes.LIKE_EVALUATES_PRODUCT_START:
      return {
        ...state,
        loading: true,
      };
    case ActionTypes.LIKE_EVALUATES_PRODUCT_COMPLETED:
      return {
        ...state,
        loading: false,
      };
    case ActionTypes.LIKE_EVALUATES_PRODUCT_ERROR:
      return {
        ...state,
        loading: false,
      };

    case ActionTypes.DISLIKE_EVALUATES_PRODUCT_START:
      return {
        ...state,
        loading: true,
      };
    case ActionTypes.DISLIKE_EVALUATES_PRODUCT_COMPLETED:
      return {
        ...state,
        loading: false,
      };
    case ActionTypes.DISLIKE_EVALUATES_PRODUCT_ERROR:
      return {
        ...state,
        loading: false,
      };

    case ActionTypes.REPCOMMENT_EVALUATES_PRODUCT_START:
      return {
        ...state,
        loading: true,
      };
    case ActionTypes.REPCOMMENT_EVALUATES_PRODUCT_COMPLETED:
      return {
        ...state,
        loading: false,
      };
    case ActionTypes.REPCOMMENT_EVALUATES_PRODUCT_ERROR:
      return {
        ...state,
        loading: false,
      };

    case ActionTypes.GET_REPCOMMENT_EVALUATES_PRODUCT_START:
      return {
        ...state,
        loading: true,
      };
    case ActionTypes.GET_REPCOMMENT_EVALUATES_PRODUCT_COMPLETED:
      var dataChange = state.reviewEvaluatesOutputDto;
      if (action.payload.level == 0) {
      }

      if (action.payload.level == 1) {
        dataChange.forEach((itemlv1: ReviewEvaluatesOutputDto) => {
          if (itemlv1.idReview === action.payload.id) {
            if (itemlv1.repCommentEvaluates.length === 1) {
              itemlv1.repCommentEvaluates = action.payload.output;
            } else {
              itemlv1.repCommentEvaluates = itemlv1.repCommentEvaluates.concat(
                action.payload.output
              );
            }
          }
        });
      }

      if (action.payload.level == 2) {
        dataChange.forEach((itemlv1: ReviewEvaluatesOutputDto) => {
          itemlv1.repCommentEvaluates.forEach(
            (itemlv2: RepCommentEvaluatesOutputDto) => {
              if (itemlv2.id === action.payload.id) {
                if (itemlv2.repCommentEvaluates.length === 1) {
                  itemlv2.repCommentEvaluates = action.payload.output;
                } else {
                  itemlv2.repCommentEvaluates =
                    itemlv2.repCommentEvaluates.concat(action.payload.output);
                }
              }
            }
          );
        });
      }
      return {
        ...state,
        loading: false,
        reviewEvaluatesOutputDto: dataChange,
      };
    case ActionTypes.GET_REPCOMMENT_EVALUATES_PRODUCT_ERROR:
      return {
        ...state,
        loading: false,
      };

    default:
      return state;
  }
}

export default hDetailReducer;
