import { notification } from "antd";
import ActionTypes from "./constants";
import { LoginState, LoginActions } from "./types";

declare var abp: any;

export const initialState: LoginState = {
  loading: false,
  completed: true,
};

function loginReducer(state: LoginState = initialState, action: LoginActions) {
  switch (action.type) {
    // CLICK LOGIN
    case ActionTypes.LOGIN_REQUEST_LOGIN_START:
      return {
        ...state,
        loading: true,
      };

    case ActionTypes.LOGIN_REQUEST_LOGIN_COMPLETED:
      abp.auth.setToken(action.payload.data.tokens, undefined);
      abp.auth.setRoles(action.payload.data.roles, undefined);
      abp.auth.setAccessToken(action.payload.data.access, undefined);
      abp.auth.setInfo(action.payload.data.fullName + " | " + action.payload.data.picture, undefined
      );
      abp.session.userId = action.payload.data.id;
      notification.success({
        message: "Thành Công",
        description: "Đăng Nhập tài khoản thành công!",
        placement: "bottomRight",
      });
      window.history.back();
      return {
        ...state,
        loading: false,
        completed: true,
      };

    case ActionTypes.LOGIN_REQUEST_LOGIN_ERROR:
      return {
        ...state,
        loading: false,
      };

    //#region REGISTRATION_ACCOUNT_BASIC_START
    case ActionTypes.REGISTRATION_ACCOUNT_BASIC_START:
      if (action.payload) {
        setTimeout(function () {
          notification.success({
            message: "Thành Công",
            description: "Vui lòng đăng nhập tài khoản!",
            placement: "bottomRight",
          });
        }, 5000);
      }
      else {
        notification.warning({
          message: "Thất bại",
          description: "Tạo tài khoản thất bại!",
          placement: "bottomRight",
        });
      }
      return {
        ...state,
      };

    case ActionTypes.REGISTRATION_ACCOUNT_BASIC_COMPLETED:
      return {
        ...state,
      };

    case ActionTypes.REGISTRATION_ACCOUNT_BASIC_ERROR:
      return {
        ...state,
      };
    //#endregion

    //#region LOGIN_OAUTH_GOOGLE_START
    case ActionTypes.LOGIN_OAUTH_GOOGLE_START:
      return {
        ...state,
      };

    case ActionTypes.LOGIN_OAUTH_GOOGLE_COMPLETED:
      
      abp.auth.setToken(action.payload.data.tokens, undefined);
      abp.auth.setRoles(action.payload.data.roles, undefined);
      abp.auth.setAccessToken(action.payload.data.access, undefined);
      abp.auth.setInfo(action.payload.data.fullName + " | " + action.payload.data.picture, undefined);
      abp.session.userId = action.payload.data.id;
      notification.success({
        message: "Thành Công",
        description: "Đăng Nhập tài khoản thành công!",
        placement: "bottomRight",
      });
      window.history.back();

      return {
        ...state,
      };

    case ActionTypes.LOGIN_OAUTH_GOOGLE_ERROR:
      return {
        ...state,
      };
    //#endregion
    default:
      return state;
  }
}

export default loginReducer;
