import { notification } from "antd";
import ActionTypes from "./constants";
import { ActionDto } from "./dtos/actionDto";
import { PermissionDto } from "./dtos/permissionDto";
import { ResourceDto } from "./dtos/resourceDto";
import { RoleDto } from "./dtos/roleDto";
import { APermissionState, APermissionActions } from "./types";

declare var abp: any;

export const initialState: APermissionState = {
  // common - chung
  loading: false,
  completed: true,
  pageIndex: 0,
  pageSize: 0,
  totalCount: 0,
  totalPages: 0,

  pageIndexSub: 0,
  pageSizeSub: 0,
  totalCountSub: 0,
  totalPagesSub: 0,

  // individually - riêng lẻ
  dataResource: [],
  dataAtomic: [],
  dataAction: [],
  dataRole: [],
  dataResourceAction: [],
  insertOrUpdateResourceAction: {
    id: 0,
    actionId: 0,
    name: "",
    isActive: false,
    isCheck: false,
  },
  dataActionAssignment: [],
  insertOrUpdateActionAssignment: {
    id: 0,
    permissionId: 0,
    name: "",
    nameAtomic: "",
    actionBase: 0,
    isActive: false,
    isCheck: false,
  },

  dataPermissionAssignment: [],
  insertOrUpdatePermissionAssignment: {
    id: 0,
    roleId: 0,
    name: "",
    isActive: false,
    isCheck: false,
  },

  dataPermission: [],
  dataRemoveResource: [],
  dataRemoveAction: [],
  dataRemovePermission: [],
  dataRemoveRole: [],
  dataRemoveAtomic: []
};

function aPermissionReducer(
  state: APermissionState = initialState,
  action: APermissionActions
) {
  switch (action.type) {

    //#region  resource
    case ActionTypes.LIST_FORM_RESOURCE_START:
      return {
        ...state,
        loading: true,
        pageIndex: action.payload.pageIndex,
        pageSize: action.payload.pageSize,
      };
    case ActionTypes.LIST_FORM_RESOURCE_COMPLETED:
      return {
        ...state,
        loading: false,
        dataRemoveResource: [],
        dataResource: action.payload.items,
        pageIndex: action.payload.pageIndex,
        pageSize: action.payload.pageSize,
        totalCount: action.payload.totalCount,
        totalPages: action.payload.totalPages,
      };
    case ActionTypes.LIST_FORM_RESOURCE_ERROR:
      notification.warning({
        message: "Thất Bại",
        description: "Đã sảy ra lỗi!",
        placement: "bottomRight",
      });
      return {
        ...state,
        loading: false,
      };

    case ActionTypes.RESOURCE_CREATE_ITEM_START:
      return {
        ...state,
        loading: true,
      };
    case ActionTypes.RESOURCE_CREATE_ITEM_COMPLETED:
      notification.success({
        message: "Thành Công",
        description: "Khởi tạo Resource Thành Công!",
        placement: "bottomRight",
      });
      return {
        ...state,
        loading: false,
      };
    case ActionTypes.RESOURCE_CREATE_ITEM_ERROR:
      notification.warning({
        message: "Thất Bại",
        description: "Đã sảy ra lỗi!",
        placement: "bottomRight",
      });
      return {
        ...state,
        loading: false,
      };

    case ActionTypes.RESOURCE_EDIT_ITEM_START:
      return {
        ...state,
        loading: true,
      };
    case ActionTypes.RESOURCE_EDIT_ITEM_COMPLETED:
      notification.success({
        message: "Thành Công",
        description: "Chỉnh sửa Resource Thành Công!",
        placement: "bottomRight",
      });
      return {
        ...state,
        loading: false,
      };
    case ActionTypes.RESOURCE_EDIT_ITEM_ERROR:
      notification.warning({
        message: "Thất Bại",
        description: "Đã sảy ra lỗi!",
        placement: "bottomRight",
      });
      return {
        ...state,
        loading: false,
      };
    case ActionTypes.RESOURCE_REMOVE_FE_ITEM_START:

      if (action.payload.types == 1) {
        return {
          ...state,
          dataResource: state.dataResource.filter(
            (el: ResourceDto) => el.id !== action.payload.id
          ),
          dataRemoveResource: state.dataRemoveResource.concat(action.payload.id),
        };
      }

      if (action.payload.types == 2) {
        return {
          ...state,
          dataResource: state.dataResource.map(
            (el: ResourceDto) => el.id === action.payload.id ? { ...el, isActive: !el.isActive } : el
          ),
          // nếu chưa có thì add , nếu có thì xóa
          dataRemoveResource: !state.dataRemoveResource.includes(action.payload.id)
            ? state.dataRemoveResource.concat(action.payload.id)
            : state.dataRemoveResource.filter((num) => num !== action.payload.id),
        };
      }

      return;

    case ActionTypes.RESOURCE_REMOVE_FE_ITEM_CANCEL:
      return {
        ...state,
        dataRemoveResource: [],
        loading: false,
      };
    case ActionTypes.RESOURCE_REMOVE_START:
      return {
        ...state,
        loading: true,
      };
    case ActionTypes.RESOURCE_REMOVE_COMPLETED:
      notification.success({
        message: "Thành Công",
        description: "Đã xóa Thành Công " + action.payload + " Bản Ghi!",
        placement: "bottomRight",
      });
      return {
        ...state,
        dataRemoveResource: [],
        loading: false,
      };
    case ActionTypes.RESOURCE_REMOVE_ERROR:
      notification.warning({
        message: "Thất Bại",
        description: "Đã sảy ra lỗi!",
        placement: "bottomRight",
      });
      return {
        ...state,
        loading: false,
      };

    case ActionTypes.RESOURCE_EDIT_STATUS_START:
      return {
        ...state,
        loading: true,
      };
    case ActionTypes.RESOURCE_EDIT_STATUS_COMPLETED:
      notification.success({
        message: "Thành Công",
        description: "Đã xóa Thành Công " + action.payload + " Bản Ghi!",
        placement: "bottomRight",
      });
      return {
        ...state,
        dataRemoveResource: [],
        loading: false,
      };
    case ActionTypes.RESOURCE_EDIT_STATUS_ERROR:
      notification.warning({
        message: "Thất Bại",
        description: "Đã sảy ra lỗi!",
        placement: "bottomRight",
      });
      return {
        ...state,
        loading: false,
      };
    //#endregion

    //#region Atomic
    case ActionTypes.ATOMIC_LIST_START:
      return {
        ...state,
        loading: true,
      };
    case ActionTypes.ATOMIC_LIST_COMPLETED:
      return {
        ...state,
        loading: false,
        dataAtomic: action.payload.items,
        pageIndex: action.payload.pageIndex,
        pageSize: action.payload.pageSize,
        totalCount: action.payload.totalCount,
        totalPages: action.payload.totalPages,
      };
    case ActionTypes.ATOMIC_LIST_ERROR:
      notification.warning({
        message: "Thất Bại",
        description: "Đã sảy ra lỗi!",
        placement: "bottomRight",
      });
      return {
        ...state,
        loading: false,
      };
    //#endregion

    //#region  Action
    case ActionTypes.ACTION_LIST_FORM_START:
      return {
        ...state,
        loading: true,
        pageIndex: action.payload.pageIndex,
        pageSize: action.payload.pageSize,
      };
    case ActionTypes.ACTION_LIST_FORM_COMPLETED:
      return {
        ...state,
        loading: false,
        dataRemoveAction: [],
        dataAction: action.payload.items,
        pageIndex: action.payload.pageIndex,
        pageSize: action.payload.pageSize,
        totalCount: action.payload.totalCount,
        totalPages: action.payload.totalPages,
      };
    case ActionTypes.ACTION_LIST_FORM_ERROR:
      notification.warning({
        message: "Thất Bại",
        description: "Đã sảy ra lỗi!",
        placement: "bottomRight",
      });
      return {
        ...state,
        loading: false,
      };

    case ActionTypes.ACTION_CREATE_ITEM_START:
      return {
        ...state,
        loading: true,
      };
    case ActionTypes.ACTION_CREATE_ITEM_COMPLETED:
      notification.success({
        message: "Thành Công",
        description: "Khởi tạo ACTION Thành Công!",
        placement: "bottomRight",
      });
      return {
        ...state,
        loading: false,
      };
    case ActionTypes.ACTION_CREATE_ITEM_ERROR:
      notification.warning({
        message: "Thất Bại",
        description: "Đã sảy ra lỗi!",
        placement: "bottomRight",
      });
      return {
        ...state,
        loading: false,
      };

    case ActionTypes.ACTION_EDIT_ITEM_START:
      return {
        ...state,
        loading: true,
      };
    case ActionTypes.ACTION_EDIT_ITEM_COMPLETED:
      notification.success({
        message: "Thành Công",
        description: "Chỉnh sửa ACTION Thành Công!",
        placement: "bottomRight",
      });
      return {
        ...state,
        loading: false,
      };
    case ActionTypes.ACTION_EDIT_ITEM_ERROR:
      notification.warning({
        message: "Thất Bại",
        description: "Đã sảy ra lỗi!",
        placement: "bottomRight",
      });
      return {
        ...state,
        loading: false,
      };
    
    case ActionTypes.ACTION_REMOVE_FE_ITEM_START:
      return {
        ...state,
        dataAction: state.dataAction.filter(
          (el: ActionDto) => el.id !== action.payload
        ),
        dataRemoveAction: state.dataRemoveAction.concat(action.payload),
      };
    case ActionTypes.ACTION_REMOVE_FE_ITEM_CANCEL:
      return {
        ...state,
        dataRemoveACTION: [],
        loading: false,
      };
    
    case ActionTypes.ACTION_REMOVE_START:
      return {
        ...state,
        loading: true,
      };
    case ActionTypes.ACTION_REMOVE_COMPLETED:
      notification.success({
        message: "Thành Công",
        description: "Đã xóa Thành Công " + action.payload + " Bản Ghi!",
        placement: "bottomRight",
      });
      return {
        ...state,
        dataRemoveAction: [],
        loading: false,
      };
    case ActionTypes.ACTION_REMOVE_ERROR:
      notification.warning({
        message: "Thất Bại",
        description: "Đã sảy ra lỗi!",
        placement: "bottomRight",
      });
      return {
        ...state,
        loading: false,
      };
    //#endregion

    //#region  Permission
    case ActionTypes.PERMISSION_LIST_FORM_START:
      return {
        ...state,
        loading: true,
        pageIndex: action.payload.pageIndex,
        pageSize: action.payload.pageSize,
      };
    case ActionTypes.PERMISSION_LIST_FORM_COMPLETED:
      return {
        ...state,
        loading: false,
        dataRemovePermission: [],
        dataPermission: action.payload.items,
        pageIndex: action.payload.pageIndex,
        pageSize: action.payload.pageSize,
        totalCount: action.payload.totalCount,
        totalPages: action.payload.totalPages,
      };
    case ActionTypes.PERMISSION_LIST_FORM_ERROR:
      notification.warning({
        message: "Thất Bại",
        description: "Đã sảy ra lỗi!",
        placement: "bottomRight",
      });
      return {
        ...state,
        loading: false,
      };

    case ActionTypes.PERMISSION_CREATE_ITEM_START:
      return {
        ...state,
        loading: true,
      };
    case ActionTypes.PERMISSION_CREATE_ITEM_COMPLETED:
      notification.success({
        message: "Thành Công",
        description: "Khởi tạo PERMISSION Thành Công!",
        placement: "bottomRight",
      });
      return {
        ...state,
        loading: false,
      };
    case ActionTypes.PERMISSION_CREATE_ITEM_ERROR:
      notification.warning({
        message: "Thất Bại",
        description: "Đã sảy ra lỗi!",
        placement: "bottomRight",
      });
      return {
        ...state,
        loading: false,
      };

    case ActionTypes.PERMISSION_EDIT_ITEM_START:
      return {
        ...state,
        loading: true,
      };
    case ActionTypes.PERMISSION_EDIT_ITEM_COMPLETED:
      notification.success({
        message: "Thành Công",
        description: "Chỉnh sửa PERMISSION Thành Công!",
        placement: "bottomRight",
      });
      return {
        ...state,
        loading: false,
      };
    case ActionTypes.PERMISSION_EDIT_ITEM_ERROR:
      notification.warning({
        message: "Thất Bại",
        description: "Đã sảy ra lỗi!",
        placement: "bottomRight",
      });
      return {
        ...state,
        loading: false,
      };
    
    case ActionTypes.PERMISSION_REMOVE_FE_ITEM_START:
      return {
        ...state,
        dataPermission: state.dataPermission.filter(
          (el: PermissionDto) => el.id !== action.payload
        ),
        dataRemovePermission: state.dataRemovePermission.concat(action.payload),
      };
    case ActionTypes.PERMISSION_REMOVE_FE_ITEM_CANCEL:
      return {
        ...state,
        dataRemovePermission: [],
        loading: false,
      };
    
    case ActionTypes.PERMISSION_REMOVE_START:
      return {
        ...state,
        loading: true,
      };
    case ActionTypes.PERMISSION_REMOVE_COMPLETED:
      notification.success({
        message: "Thành Công",
        description: "Đã xóa Thành Công " + action.payload + " Bản Ghi!",
        placement: "bottomRight",
      });
      return {
        ...state,
        dataRemovePermission: [],
        loading: false,
      };
    case ActionTypes.PERMISSION_REMOVE_ERROR:
      notification.warning({
        message: "Thất Bại",
        description: "Đã sảy ra lỗi!",
        placement: "bottomRight",
      });
      return {
        ...state,
        loading: false,
      };
    //#endregion

    //#region  Role
    case ActionTypes.ROLE_LIST_FORM_START:
      return {
        ...state,
        loading: true,
        pageIndex: action.payload.pageIndex,
        pageSize: action.payload.pageSize,
      };
    case ActionTypes.ROLE_LIST_FORM_COMPLETED:
      return {
        ...state,
        loading: false,
        dataRemoveRole: [],
        dataRole: action.payload.items,
        pageIndex: action.payload.pageIndex,
        pageSize: action.payload.pageSize,
        totalCount: action.payload.totalCount,
        totalPages: action.payload.totalPages,
      };
    case ActionTypes.ROLE_LIST_FORM_ERROR:
      notification.warning({
        message: "Thất Bại",
        description: "Đã sảy ra lỗi!",
        placement: "bottomRight",
      });
      return {
        ...state,
        loading: true,
      };

    case ActionTypes.ROLE_CREATE_ITEM_START:
      return {
        ...state,
        loading: true,
      };
    case ActionTypes.ROLE_CREATE_ITEM_COMPLETED:
      notification.success({
        message: "Thành Công",
        description: "Khởi tạo ROLE Thành Công!",
        placement: "bottomRight",
      });
      return {
        ...state,
        loading: false,
      };
    case ActionTypes.ROLE_CREATE_ITEM_ERROR:
      notification.warning({
        message: "Thất Bại",
        description: "Đã sảy ra lỗi!",
        placement: "bottomRight",
      });
      return {
        ...state,
        loading: false,
      };

    case ActionTypes.ROLE_EDIT_ITEM_START:
      return {
        ...state,
        loading: true,
      };
    case ActionTypes.ROLE_EDIT_ITEM_COMPLETED:
      notification.success({
        message: "Thành Công",
        description: "Chỉnh sửa ROLE Thành Công!",
        placement: "bottomRight",
      });
      return {
        ...state,
        loading: false,
      };
    case ActionTypes.ROLE_EDIT_ITEM_ERROR:
      notification.warning({
        message: "Thất Bại",
        description: "Đã sảy ra lỗi!",
        placement: "bottomRight",
      });
      return {
        ...state,
        loading: false,
      };
    case ActionTypes.ROLE_REMOVE_FE_ITEM_START:
      return {
        ...state,
        dataRole: state.dataRole.filter(
          (el: RoleDto) => el.id !== action.payload
        ),
        dataRemoveRole: state.dataRemoveRole.concat(action.payload),
      };
    case ActionTypes.ROLE_REMOVE_FE_ITEM_CANCEL:
      return {
        ...state,
        dataRemoveRole: [],
      };
    case ActionTypes.ROLE_REMOVE_START:
      return {
        ...state,
      };
    case ActionTypes.ROLE_REMOVE_COMPLETED:
      notification.success({
        message: "Thành Công",
        description: "Đã xóa Thành Công " + action.payload + " Bản Ghi!",
        placement: "bottomRight",
      });
      return {
        ...state,
        dataRemoveRole: [],
      };
    case ActionTypes.ROLE_REMOVE_ERROR:
      notification.warning({
        message: "Thất Bại",
        description: "Đã sảy ra lỗi!",
        placement: "bottomRight",
      });
      return {
        ...state,
      };
    //#endregion

    //#region  Resource action
    case ActionTypes.RESOURCE_ACTION_GET_LIST_DATA_START:
      return {
        ...state,
        dataResourceAction: [],
        loading: true,
      };
    case ActionTypes.RESOURCE_ACTION_GET_LIST_DATA_COMPELETED:
      return {
        ...state,
        loading: false,
        dataRemoveRole: [],
        dataResourceAction: action.payload.items,
        pageIndexSub: action.payload.pageIndex,
        pageSizeSub: action.payload.pageSize,
        totalCountSub: action.payload.totalCount,
        totalPagesSub: action.payload.totalPages,
      };
    case ActionTypes.RESOURCE_ACTION_GET_LIST_DATA_ERROR:
      notification.warning({
        message: "Thất Bại",
        description: "Đã sảy ra lỗi!",
        placement: "bottomRight",
      });
      return {
        ...state,
        loading: false,
      };

    case ActionTypes.RESOURCE_ACTION_INSERT_OR_UPDATE_START:
      return {
        ...state,
        loading: true,
      };
    case ActionTypes.RESOURCE_ACTION_INSERT_OR_UPDATE_COMPELETED:
      var objIndex = state.dataResourceAction.findIndex(
        (obj) => obj.id === action.payload.id
      );
      state.dataResourceAction[objIndex].isCheck =
        !state.dataResourceAction[objIndex].isCheck;
      return {
        ...state,
        loading: false,
      };
    case ActionTypes.RESOURCE_ACTION_INSERT_OR_UPDATE_ERROR:
      notification.warning({
        message: "Thất Bại",
        description: "Đã sảy ra lỗi!",
        placement: "bottomRight",
      });
      return {
        ...state,
        loading: false,
      };
    //#endregion

    //#region  Action Assignment
    case ActionTypes.ACTION_ASSIGNMENT_GET_LIST_DATA_START:
      return {
        ...state,
        dataActionAssignment: [],
        loading: true,
      };
    case ActionTypes.ACTION_ASSIGNMENT_GET_LIST_DATA_COMPELETED:
      return {
        ...state,
        loading: false,
        dataActionAssignment: action.payload.items,
        pageIndexSub: action.payload.pageIndex,
        pageSizeSub: action.payload.pageSize,
        totalCountSub: action.payload.totalCount,
        totalPagesSub: action.payload.totalPages,
      };
    case ActionTypes.ACTION_ASSIGNMENT_GET_LIST_DATA_ERROR:
      notification.warning({
        message: "Thất Bại",
        description: "Đã sảy ra lỗi!",
        placement: "bottomRight",
      });
      return {
        ...state,
        loading: false,
      };

    case ActionTypes.ACTION_ASSIGNMENT_INSERT_OR_UPDATE_START:
      return {
        ...state,
        loading: true,
      };
    case ActionTypes.ACTION_ASSIGNMENT_INSERT_OR_UPDATE_COMPELETED:
      var objIndex = state.dataActionAssignment.findIndex(
        (obj) => obj.id === action.payload.id
      );
      state.dataActionAssignment[objIndex].isCheck =
        !state.dataActionAssignment[objIndex].isCheck;
      return {
        ...state,
        loading: false,
      };
    case ActionTypes.RESOURCE_ACTION_INSERT_OR_UPDATE_ERROR:
      notification.warning({
        message: "Thất Bại",
        description: "Đã sảy ra lỗi!",
        placement: "bottomRight",
      });
      return {
        ...state,
        loading: false,
      };
    //#endregion

    //#region  Permission Assignment
    case ActionTypes.PERMISSION_ASSIGNMENT_GET_LIST_DATA_START:
      return {
        ...state,
        dataPermissionAssignment: [],
        loading: true,
      };
    case ActionTypes.PERMISSION_ASSIGNMENT_GET_LIST_DATA_COMPELETED:
      return {
        ...state,
        loading: false,
        dataPermissionAssignment: action.payload.items,
        pageIndexSub: action.payload.pageIndex,
        pageSizeSub: action.payload.pageSize,
        totalCountSub: action.payload.totalCount,
        totalPagesSub: action.payload.totalPages,
      };
    case ActionTypes.PERMISSION_ASSIGNMENT_GET_LIST_DATA_ERROR:
      notification.warning({
        message: "Thất Bại",
        description: "Đã sảy ra lỗi!",
        placement: "bottomRight",
      });
      return {
        ...state,
        loading: false,
      };

    case ActionTypes.PERMISSION_ASSIGNMENT_INSERT_OR_UPDATE_START:
      return {
        ...state,
        loading: true,
      };
    case ActionTypes.PERMISSION_ASSIGNMENT_INSERT_OR_UPDATE_COMPELETED:
      var objIndex = state.dataPermissionAssignment.findIndex(
        (obj) => obj.id === action.payload.id
      );
      state.dataPermissionAssignment[objIndex].isCheck =
        !state.dataPermissionAssignment[objIndex].isCheck;
      return {
        ...state,
        loading: false,
      };
    case ActionTypes.PERMISSION_ASSIGNMENT_INSERT_OR_UPDATE_ERROR:
      notification.warning({
        message: "Thất Bại",
        description: "Đã sảy ra lỗi!",
        placement: "bottomRight",
      });
      return {
        ...state,
        loading: false,
      };
    //#endregion

    default:
      return state;
  }
}

export default aPermissionReducer;
