import { ActionType } from 'typesafe-actions';
import * as actions from './actions';
import { CateProReadIdAndNameDto } from './dtos/cateProReadIdAndNameDto';
import { ProductAttributeReadDto } from './dtos/productAttributeReadDto';

export interface AttributeProductState { // day
    readonly loading: boolean;
    readonly completed: boolean;
    readonly pageIndex: number;
    readonly pageSize: number;
    readonly totalCount: number;
    readonly totalPages: number;
    readonly productAttributeReadDto : ProductAttributeReadDto[]
    readonly cateProReadIdAndNameDto : CateProReadIdAndNameDto[]
    readonly optionCreateByCate : CateProReadIdAndNameDto[]
}

export type AttributeProductActions = ActionType<typeof actions>; // day