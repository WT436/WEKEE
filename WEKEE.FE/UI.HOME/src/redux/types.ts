import { Store } from "redux";
import { Saga } from "redux-saga";

import { GlobalState } from "../components/ComponentBase/types";
import { LoginState } from "../scenes/Permission/Login/types";
import { HomeState } from "../scenes/Main/Home/types";
import { APermissionState } from "../scenes/Admin/APermission/types";
import { AAccountState } from "../scenes/Admin/Account/types";
import { SErrorState } from "../scenes/System/SError/types";
import { UHomeState } from "../scenes/User/UHome/types";
import { ACategoryState } from "../scenes/Admin/ACategory/types";
import { ASpeciCateState } from "../scenes/Admin/ASpeciCate/types";
import { SuNewProductState } from "../scenes/Store/SuNewProduct/types";
import { HDetailState } from "../scenes/Main/HDetail/types";
import { InfoCardHomeState } from "../cms/InfoCardHome/types";
import { BaseState } from "../components/Base/types";
import { SelectStoreState } from "../scenes/Store/SelectStore/types";
import { SiderStoreState } from "../scenes/Store/SiderStore/types"
import { MenuSliderAdminState } from "../scenes/Admin/MenuSliderAdmin/types";
import { AttributeProductState } from "../scenes/Admin/AttributeProduct/types";

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
  readonly infoCardHome: InfoCardHomeState
  readonly selectStore: SelectStoreState
  readonly siderstore: SiderStoreState
  readonly menuslideradmin : MenuSliderAdminState
  readonly attributeproduct: AttributeProductState
  readonly base: BaseState
}
