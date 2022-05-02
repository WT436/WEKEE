import { ActionType } from 'typesafe-actions';
import * as actions from './actions';
import { AtomicReadDto } from './dto/atomicReadDto';
import { AtomicSummaryReadDto } from './dto/atomicSummaryReadDto';
import { FtPermissionReadDto } from './dto/ftPermissionReadDto';
import { PermissionFtReourceReadDto } from './dto/permissionFtReourceReadDto';
import { PermissionReadDto } from './dto/permissionReadDto';
import { PermissionSummaryReadDto } from './dto/permissionSummaryReadDto';
import { ResourceReadDto } from './dto/resourceReadDto';
import { RoleFtPermissionReadDto } from './dto/roleFtPermissionReadDto';
import { RoleReadDto } from './dto/roleReadDto';
import { RoleSummaryReadDto } from './dto/roleSummaryReadDto';
import { SubjectReadDto } from './dto/subjectReadDto';
import { UserProfileCompactReadDto } from './dto/userProfileCompactReadDto';

export interface APermissionState { // day

    //#region  User Profile 
    readonly userProfile : UserProfileCompactReadDto[];
    //#endregion

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
    readonly atomicSummaryRead: AtomicSummaryReadDto[];
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
    readonly permissionSummaryRead: PermissionSummaryReadDto[];
    readonly loadingTablePermissionFtResource: boolean;
    readonly permissionFtResourceRead : FtPermissionReadDto[];
    readonly pageIndexPermissionFtResource: number;
    readonly pageSizePermissionFtResource: number;
    readonly totalCountPermissionFtResource: number;
    readonly totalPagesPermissionFtResource: number;
    //#endregion

    //#region  PROPERTY Role
    readonly loadingAllRole: boolean;
    readonly loadingTableRole: boolean;
    readonly completedAllRole: boolean;
    readonly loadingButtonRole: boolean;
    readonly pageIndexRole: number;
    readonly pageSizeRole: number;
    readonly totalCountRole: number;
    readonly totalPagesRole: number;
    readonly roleReads: RoleReadDto[];
    readonly roleSummaryRead: RoleSummaryReadDto[];
    readonly loadingTableRoleFtPermission: boolean;
    readonly pageIndexRoleFtPermission: number;
    readonly pageSizeRoleFtPermission: number;
    readonly totalCountRoleFtPermission: number;
    readonly totalPagesRoleFtPermission: number;
    readonly roleFtPermissionRead : RoleFtPermissionReadDto[];
    //#endregion
   
    //#region  PROPERTY Subject
    readonly loadingAllSubject: boolean;
    readonly loadingTableSubject: boolean;
    readonly completedAllSubject: boolean;
    readonly loadingButtonSubject: boolean;
    readonly pageIndexSubject: number;
    readonly pageSizeSubject: number;
    readonly totalCountSubject: number;
    readonly totalPagesSubject: number;
    readonly subjectReads: SubjectReadDto[];
    //#endregion

}

export type APermissionActions = ActionType<typeof actions>; // day