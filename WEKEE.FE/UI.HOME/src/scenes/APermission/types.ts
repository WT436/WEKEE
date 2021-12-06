import { ActionType } from 'typesafe-actions';
import * as actions from './actions';
import { ResourceDto } from './dtos/resourceDto';
import { AtomicDto } from './dtos/atomicDto';
import { ActionDto } from './dtos/actionDto';
import { PermissionDto } from './dtos/permissionDto';
import { RoleDto } from './dtos/roleDto';
import { ResourceActionDto } from './dtos/resourceActionDto';
import { ActionAssignmentDto } from './dtos/actionAssignmentDto';
import { PermissionAssignmentDto } from './dtos/permissionAssignmentDto';

export interface APermissionState {
     // common - chung
     readonly loading: boolean;
     readonly completed: boolean;
     readonly pageIndex: number;
     readonly pageSize: number;
     readonly totalCount: number;
     readonly totalPages: number;

     readonly pageIndexSub: number;
     readonly pageSizeSub: number;
     readonly totalCountSub: number;
     readonly totalPagesSub: number;


     // individually - riêng lẻ
     //readonly data: ResourceDto[]|AtomicDto[]|ActionDto[]
     readonly dataResource: ResourceDto[]
     readonly dataAtomic: AtomicDto[]
     readonly dataAction: ActionDto[]
     readonly dataPermission: PermissionDto[]
     readonly dataRole: RoleDto[]
     readonly dataResourceAction: ResourceActionDto[]
     readonly insertOrUpdateResourceAction : ResourceActionDto
     readonly dataActionAssignment: ActionAssignmentDto[]
     readonly insertOrUpdateActionAssignment: ActionAssignmentDto
     readonly dataPermissionAssignment: PermissionAssignmentDto[]
     readonly insertOrUpdatePermissionAssignment: PermissionAssignmentDto
     readonly dataRemoveResource: Number[]
     readonly dataRemoveAction: Number[]
     readonly dataRemovePermission: Number[]
     readonly dataRemoveRole: Number[]
}

export type APermissionActions = ActionType<typeof actions>;