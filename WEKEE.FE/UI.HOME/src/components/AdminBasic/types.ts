import { ActionType } from 'typesafe-actions';
import * as actions from './actions';
import { ResourceReadDto } from './dto/resourceReadDto';

export interface AdminBasicState { // day
    //#region  PROPERTY DEFAULT
    readonly loadingAll: boolean;
    readonly loadingTable: boolean;
    readonly completedAll: boolean;
    readonly loadingButton : boolean;
    readonly pageIndex: number;
    readonly pageSize: number;
    readonly totalCount: number;
    readonly totalPages: number;
    //#endregion

    //#region  Individual
    readonly resourceReads : ResourceReadDto[];
    
    //#endregion
}

export type AdminBasicActions = ActionType<typeof actions>; // day