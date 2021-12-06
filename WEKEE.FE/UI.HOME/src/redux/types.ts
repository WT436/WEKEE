import { Store } from "redux";
import { Saga } from "redux-saga";

import { GlobalState } from "../components/ComponentBase/types";
import { LoginState } from "../scenes/Login/types";
import { HomeState } from "../scenes/Home/types";
import { APermissionState } from "../scenes/APermission/types";
import { AAccountState } from "../scenes/AAccount/types";
import { SErrorState } from "../scenes/SError/types";
import { UHomeState } from "../scenes/UHome/types";
import { ACategoryState } from "../scenes/ACategory/types";
import { ASpeciCateState } from "../scenes/ASpeciCate/types";
import { SuNewProductState } from "../scenes/SuNewProduct/types";
import { HDetailState } from "../scenes/HDetail/types";

export interface InjectedStore extends Store {
  injectedReducers: any;
  injectedSagas: any;
  runSaga(saga: Saga<any[]> | undefined, args: any | undefined): any;
}

// Your root reducer type, which is your redux state types also
export interface ApplicationRootState {
  readonly global: GlobalState;
  readonly login: LoginState;
  readonly home: HomeState;
  readonly apermission: APermissionState;
  readonly aaccount: AAccountState;
  readonly serror: SErrorState;
  readonly uhome: UHomeState;
  readonly acategory: ACategoryState;
  readonly aspecicate: ASpeciCateState;
  readonly sunewproduct: SuNewProductState;
  readonly hdetail: HDetailState;
}
