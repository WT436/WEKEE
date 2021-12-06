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
    // OPEN PAGE
    case ActionTypes.LOGIN_SHOW_START:
      return {
        ...state,
        loading: false,
      };

    case ActionTypes.LOGIN_SHOW_COMPLETED:
      return {
        ...state,
        loading: false,
        completed: true,
      };

    case ActionTypes.LOGIN_SHOW_ERROR:
      return {
        ...state,
        loading: false,
      };

    // CLICK LOGIN

    case ActionTypes.LOGIN_REQUEST_LOGIN_START:
      return {
        ...state,
        loading: true,
      };

    case ActionTypes.LOGIN_REQUEST_LOGIN_COMPLETED:
      abp.auth.setToken(action.payload.tokens.token, undefined);
      abp.auth.setRoles(action.payload.roles, undefined);
      abp.auth.setInfo(
        action.payload.fullName +
          "id:" +
          action.payload.id +
          " | " +
          action.payload.picture,
        undefined
      );
      abp.session.userId = action.payload.id;
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

    default:
      return state;
  }
}

export default loginReducer;
