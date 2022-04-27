import { ActionType } from 'typesafe-actions';
import * as actions from './actions';
import { AtomicReadDto } from './dto/atomicReadDto';
import { ResourceReadDto } from './dto/resourceReadDto';

export interface APermissionState { // day
    //#region  PROPERTY Resource
    readonly loadingAllResource: boolean;
    readonly loadingTableResource: boolean;
    readonly completedAllResource: boolean;
    readonly loadingButtonResource : boolean;
    readonly pageIndexResource: number;
    readonly pageSizeResource: number;
    readonly totalCountResource: number;
    readonly totalPagesResource: number;
    readonly resourceReads : ResourceReadDto[];
    //#endregion

    //#region  PROPERTY Atomic
    readonly loadingAllAtomic: boolean;
    readonly loadingTableAtomic: boolean;
    readonly completedAllAtomic: boolean;
    readonly loadingButtonAtomic : boolean;
    readonly pageIndexAtomic: number;
    readonly pageSizeAtomic: number;
    readonly totalCountAtomic: number;
    readonly totalPagesAtomic: number;
    readonly atomicReads : AtomicReadDto[];
    //#endregion
}

export type APermissionActions = ActionType<typeof actions>; // day