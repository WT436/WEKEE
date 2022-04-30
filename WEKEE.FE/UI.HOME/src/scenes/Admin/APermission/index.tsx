//#region  import
import * as React from "react";
import { useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { createStructuredSelector } from "reselect";
import { useInjectReducer, useInjectSaga } from "../../../redux/reduxInjectors";
import reducer from "./reducer";
import saga from "./saga";
import { Tabs } from 'antd';
import { L } from "../../../lib/abpUtility";
import ResourceComponent from "./components/resourceComponent";
import './style.css'
import AtomicComponent from "./components/atomicComponent";
import PermissionComponent from "./components/permissionComponent";
import RoleComponent from "./components/roleComponent";
import SubjectComponent from "./components/subjectComponent";
import OverviewComponent from "./components/overviewComponent";
declare var abp: any;

const { TabPane } = Tabs;
//#endregion

const stateSelector = createStructuredSelector<any, any>({

});

export interface IAPermissionProps {
  // đây

}

const key = "apermission"; // đây

export default function APermission(props: IAPermissionProps) {
  //#region START
  useInjectReducer(key, reducer);
  useInjectSaga(key, saga);
  const dispatch = useDispatch();
  //#endregion
  function callback(key: any) {
    console.log(key);
  }
  return (
    <>
      <Tabs defaultActiveKey="1" onChange={callback}>
        <TabPane tab={L("OVERVIEW", "PERMISSION_ADMIN")} key="OVERVIEW">
          <OverviewComponent />
        </TabPane>
        <TabPane tab={L("SUPJECT", "PERMISSION_ADMIN")} key="SUPJECT">
          <SubjectComponent />
        </TabPane>
        <TabPane tab={L("GROUP", "PERMISSION_ADMIN")} key="GROUP">
          Content of Tab Pane 3
        </TabPane>
        <TabPane tab={L("ROLE", "PERMISSION_ADMIN")} key="ROLE">
          <RoleComponent />
        </TabPane>
        <TabPane tab={L("PERMISSION", "PERMISSION_ADMIN")} key="PERMISSION">
          <PermissionComponent />
        </TabPane>
        <TabPane tab={L("ATOMIC", "PERMISSION_ADMIN")} key="ATOMIC">
          <AtomicComponent />
        </TabPane>
        <TabPane tab={L("RESOURCE", "PERMISSION_ADMIN")} key="RESOURCE">
          <ResourceComponent />
        </TabPane>
      </Tabs>
    </>
  );
}
