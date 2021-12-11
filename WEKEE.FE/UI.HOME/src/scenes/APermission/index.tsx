//#region  import
import { Modal, Tabs } from 'antd'
import * as React from 'react';
import {  useSelector } from 'react-redux';
import { createStructuredSelector } from 'reselect';
import { useInjectReducer, useInjectSaga } from '../../redux/reduxInjectors';
import ActionAssignmentComponents from './components/actionAssignmentComponents';
import ActionComponents from './components/actionComponents';
import AtomicComponents from './components/atomicComponents';
import CommonRoleComponents from './components/commonRoleComponents';
import PermissionComponents from './components/permissionComponents';
import ResourceActionComponents from './components/resourceActionComponents';
import ResourceComponents from './components/resourceComponents';
import RoleComponents from './components/roleComponents';
import PermissionAssignmentComponent from './components/permissionAssignmentComponent';
import reducer from './reducer';
import saga from './saga';
import { makeSelectLoading } from './selectors';

const { TabPane } = Tabs;
//#endregion
export interface IAPermissionProps {
    location: any;
}
const key = 'apermission';
const stateSelector = createStructuredSelector<any, any>({
    loading: makeSelectLoading()
});

export default function APermission(props: IAPermissionProps) {
    useInjectReducer(key, reducer);
    useInjectSaga(key, saga);
    const { } = useSelector(stateSelector);

    return (
        <>
            <Tabs defaultActiveKey="0">
                <TabPane tab="Overview" key="0">
                    <CommonRoleComponents />
                </TabPane>
                <TabPane disabled={false} tab="Resource" key="Resource">
                    <ResourceComponents />
                </TabPane>
                <TabPane disabled={false} tab="Atomic" key="2">
                    <AtomicComponents />
                </TabPane>
                <TabPane disabled={false} tab="Resource Action" key="3">
                    <ResourceActionComponents />
                </TabPane>
                <TabPane disabled={false} tab="Action" key="4">
                    <ActionComponents />
                </TabPane>
                <TabPane disabled={false} tab="Action Assignment" key="5">
                    <ActionAssignmentComponents />
                </TabPane>
                <TabPane disabled={false} tab="Permission" key="6">
                    <PermissionComponents />
                </TabPane>
                <TabPane disabled={false} tab="Permission Assignment" key="7">
                    <PermissionAssignmentComponent />
                </TabPane>
                <TabPane disabled={false} tab="Role " key="8">
                    <RoleComponents />
                </TabPane>
                <TabPane disabled={false} tab="Algorithm Role" key="9">
                    <RoleComponents />
                </TabPane>
            </Tabs>

            <Modal
                title="Resource Action"
                centered
                visible={false}
                width={'90%'}
                okButtonProps={{ hidden: true }}
                cancelButtonProps={{ hidden: true }}
            >
                <ActionAssignmentComponents />
            </Modal>
        </>
    )
}

