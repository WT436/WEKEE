import { notification } from 'antd';
import ActionTypes from './constants';
import { AccountShowDtos } from './dtos/accountShowDtos';
import { AAccountState, AAccountActions } from './types';

declare var abp: any;

export const initialState: AAccountState = {
    loading: false,
    completed: true,
    pageIndex: 0,
    pageSize: 0,
    totalCount: 0,
    totalPages: 0,
    //#region  UploadImage
    uploadImage: {
        uid: '',
        name: '',
        status: '',
        url: '',
    },
    accountAdminCreate: {
        id: 0,
        firstName: '',
        lastName: '',
        acceptTermOfService: false,
        timeZone: '',
        facebookId: false,
        googleId: false,
        zaloId: false,
        userName: '',
        email: '',
        numberPhone: '',
        password: '',
        isStatus: 0,
        adressLine1: '',
        adressLine2: '',
        adressLine3: '',
        descriptionAdress: '',
        isActive: false,
        coordinates: '',
        picture: '',
        gender: '',
        description: ''
    },
    accountShowDtos: [],
    subjectDtos: [],
    subjectAssignmentDto: [],
    id: []
    //#endregion
};

function aAccountReducer(
    state: AAccountState = initialState,
    action: AAccountActions
) {
    switch (action.type) {
        // OPEN PAGE
        case ActionTypes.WATCH_PAGE_START:
            return {
                ...state,
                loading: true
            };

        case ActionTypes.WATCH_PAGE_COMPLETED:
            return {
                ...state,
                loading: false,
                completed: true
            };

        case ActionTypes.WATCH_PAGE_ERROR:
            return {
                ...state,
                loading: false
            };
        //#region Account
        case ActionTypes.CREATE_ACCOUNT_ADMIN_START:
            return {
                ...state,
                loading: true
            };

        case ActionTypes.CREATE_ACCOUNT_ADMIN_COMPLETED:
            notification.success({
                message: "Thành Công",
                description: "Khởi tạo Thành Công 1 tài khoản!",
                placement: 'bottomRight'
            });
            return {
                ...state,
                loading: false,
                completed: true
            };

        case ActionTypes.CREATE_ACCOUNT_ADMIN_ERROR:
            return {
                ...state,
                loading: false
            };

        case ActionTypes.LIST_ACCOUNT_ADMIN_START:
            return {
                ...state,
                loading: true
            };

        case ActionTypes.LIST_ACCOUNT_ADMIN_COMPLETED:
            return {
                ...state,
                loading: false,
                completed: true,
                accountShowDtos: action.payload.items,
                pageIndex: action.payload.pageIndex,
                pageSize: action.payload.pageSize,
                totalCount: action.payload.totalCount,
                totalPages: action.payload.totalPages,
            };

        case ActionTypes.LIST_ACCOUNT_ADMIN_ERROR:
            return {
                ...state,
                loading: false
            };
        case ActionTypes.LIST_SUBJECT_ID_ACCOUNT_START:
            return {
                ...state,
                loading: true,
                subjectAssignmentDto: [],
                subjectDtos: []
            };
        case ActionTypes.LIST_SUBJECT_ID_ACCOUNT_COMPLETED:
            return {
                ...state,
                subjectAssignmentDto: [],
                loading: false,
                subjectDtos: action.payload
            };
        case ActionTypes.LIST_SUBJECT_ID_ACCOUNT_ERROR:
            return {
                ...state,
                loading: false,
                subjectAssignmentDto: []
            };

        case ActionTypes.LIST_SUBJECT_ASSIGN_DTO_START:
            return {
                ...state,
                subjectAssignmentDto: [],
                loading: true
            };
        case ActionTypes.LIST_SUBJECT_ASSIGN_DTO_COMPLETED:
            return {
                ...state,
                loading: false,
                subjectAssignmentDto: action.payload
            };
        case ActionTypes.LIST_SUBJECT_ASSIGN_DTO_ERROR:
            return {
                ...state,
                loading: false
            };

        case ActionTypes.CHANGE_PERMISSION_ACCOUNT_START:
            return {
                ...state,
                loading: true
            };
        case ActionTypes.CHANGE_PERMISSION_ACCOUNT_COMPLETED:
            var objIndex = state.subjectAssignmentDto.findIndex((obj => obj.id == action.payload.idRole));
            state.subjectAssignmentDto[objIndex].isCheck = !state.subjectAssignmentDto[objIndex].isCheck;
            return {
                ...state,
                loading: false,
            };
        case ActionTypes.CHANGE_PERMISSION_ACCOUNT_ERROR:
            return {
                ...state,
                loading: false
            };

        case ActionTypes.DELETE_ACCOUNT_START:
            return {
                ...state,
                loading: true
            };
        case ActionTypes.DELETE_ACCOUNT_COMPLETED:
            notification.success({
                message: "Thành Công",
                description: "Đã xóa Thành Công 1 Bản Ghi!",
                placement: 'bottomRight'
            });
            return {
                ...state,
                accountShowDtos: state.accountShowDtos.filter((el: AccountShowDtos) => el.id !== action.payload),
                loading: false,
            };
        case ActionTypes.DELETE_ACCOUNT_ERROR:
            notification.error({
                message: "Thất bại",
                description: "Đã có lỗi sảy ra!",
                placement: 'bottomRight'
            });
            return {
                ...state,
                loading: false
            };
        //#endregion
        default:
            return state;
    }
}

export default aAccountReducer;