import { ActionType } from 'typesafe-actions';
import * as actions from './actions';
import { ProductAttributeReadDto } from './dtos/productAttributeReadDto';

export interface AttributeProductState { // day
    readonly loading: boolean;
    readonly completed: boolean;
    readonly pageIndex: number;
    readonly pageSize: number;
    readonly totalCount: number;
    readonly totalPages: number;
    readonly productAttributeReadDto : ProductAttributeReadDto[]
}

export type AttributeProductActions = ActionType<typeof actions>; // day