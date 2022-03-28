import { ActionType } from 'typesafe-actions';
import * as actions from './actions';
import { AccountAdminCreate } from './dtos/accountAdminCreate';
import { AccountShowDtos } from './dtos/accountShowDtos';
import { SubjectAssignmentDto } from './dtos/subjectAssignmentDto';
import { SubjectDtos } from './dtos/subjectDtos';
import { UploadImage } from './dtos/uploadImage'

export interface AAccountState {
    readonly loading: boolean;
    readonly completed: boolean;
    readonly pageIndex: number;
    readonly pageSize: number;
    readonly totalCount: number;
    readonly totalPages: number;

    //#region UploadImage
    readonly uploadImage: UploadImage
    readonly accountAdminCreate: AccountAdminCreate
    readonly accountShowDtos: AccountShowDtos[];
    readonly subjectDtos:SubjectDtos[];
    readonly subjectAssignmentDto:SubjectAssignmentDto[];
    readonly id : Number[]
    //#endregion
}

export type AAccountActions = ActionType<typeof actions>;