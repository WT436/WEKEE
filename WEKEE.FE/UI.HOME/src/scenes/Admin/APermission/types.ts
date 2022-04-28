import { ActionType } from 'typesafe-actions';
import * as actions from './actions';
import { AtomicReadDto } from './dto/atomicReadDto';
import { AtomicSummaryReadDto } from './dto/atomicSummaryReadDto';
import { PermissionReadDto } from './dto/permissionReadDto';
import { PermissionSummaryReadDto } from './dto/permissionSummaryReadDto';
import { ResourceReadDto } from './dto/resourceReadDto';

export interface APermissionState { // day
    //#region  PROPERTY Resource
    readonly loadingAllResource: boolean;
    readonly loadingTableResource: boolean;
    readonly completedAllResource: boolean;
    readonly loadingButtonResource: boolean;
    readonly pageIndexResource: number;
    readonly pageSizeResource: number;
    readonly totalCountResource: number;
    readonly totalPagesResource: number;
    readonly resourceReads: ResourceReadDto[];
    //#endregion

    //#region  PROPERTY Atomic
    readonly loadingAllAtomic: boolean;
    readonly loadingTableAtomic: boolean;
    readonly completedAllAtomic: boolean;
    readonly loadingButtonAtomic: boolean;
    readonly pageIndexAtomic: number;
    readonly pageSizeAtomic: number;
    readonly totalCountAtomic: number;
    readonly totalPagesAtomic: number;
    readonly atomicReads: AtomicReadDto[];
    readonly atomicSummaryRead : AtomicSummaryReadDto[];
    //#endregion

    //#region  PROPERTY Permission
    readonly loadingAllPermission: boolean;
    readonly loadingTablePermission: boolean;
    readonly completedAllPermission: boolean;
    readonly loadingButtonPermission: boolean;
    readonly pageIndexPermission: number;
    readonly pageSizePermission: number;
    readonly totalCountPermission: number;
    readonly totalPagesPermission: number;
    readonly permissionReads: PermissionReadDto[];
    readonly permissionSummaryRead : PermissionSummaryReadDto[];
    //#endregion

}

export type APermissionActions = ActionType<typeof actions>; // day