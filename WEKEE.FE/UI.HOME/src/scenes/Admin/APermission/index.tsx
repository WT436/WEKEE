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
import { makeCompleted, makeLoading, makeLoadingButton, makeLoadingTable, makePageIndex, makePageSize, makeTotalCount, makeTotalPages } from "./selectors";
import ResourceComponent from "./components/resourceComponent";
import './style.css'
declare var abp: any;

const { TabPane } = Tabs;
//#endregion

const stateSelector = createStructuredSelector<any, any>({
  loadingAll: makeLoading(),
  loadingTable: makeLoadingTable(),
  loadingButton: makeLoadingButton(),
  completedAll: makeCompleted(),
  pageIndex: makePageIndex(),
  pageSize: makePageSize(),
  totalCount: makeTotalCount(),
  totalPages: makeTotalPages(),
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

  const { loading, pageSize, totalCount, pageIndex } =
    useSelector(stateSelector);
  //#endregion
  function callback(key: any) {
    console.log(key);
  }
  return (
    <>
      <Tabs defaultActiveKey="1" onChange={callback}>
        <TabPane tab={L("OVERVIEW", "PERMISSION_ADMIN")} key="OVERVIEW">
          Content of Tab Pane 2
        </TabPane>
        <TabPane tab={L("SUPJECT", "PERMISSION_ADMIN")} key="SUPJECT">
          Content of Tab Pane 3
        </TabPane>
        <TabPane tab={L("GROUP", "PERMISSION_ADMIN")} key="GROUP">
          Content of Tab Pane 3
        </TabPane>
        <TabPane tab={L("ROLE", "PERMISSION_ADMIN")} key="ROLE">
          Content of Tab Pane 3
        </TabPane>
        <TabPane tab={L("PERMISSION", "PERMISSION_ADMIN")} key="PERMISSION">
          Content of Tab Pane 3
        </TabPane>
        <TabPane tab={L("ATOMIC", "PERMISSION_ADMIN")} key="ATOMIC">
          Content of Tab Pane 3
        </TabPane>
        <TabPane tab={L("RESOURCE", "PERMISSION_ADMIN")} key="RESOURCE">
          <ResourceComponent />
        </TabPane>
      </Tabs>
    </>
  );
}
