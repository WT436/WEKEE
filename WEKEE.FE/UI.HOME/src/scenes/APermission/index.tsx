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
            <Tabs defaultActiveKey="Overview">
                <TabPane tab="Overview" key="Overview">
                    <CommonRoleComponents />
                </TabPane>
                <TabPane disabled={false} tab="Resource" key="Resource">
                    <ResourceComponents />
                </TabPane>
                <TabPane disabled={false} tab="Atomic" key="Atomic">
                    <AtomicComponents />
                </TabPane>
                {/* <TabPane disabled={false} tab="Resource Action" key="Resource_Action">
                    <ResourceActionComponents />
                </TabPane> */}
                <TabPane disabled={false} tab="Action" key="Action">
                    <ActionComponents />
                </TabPane>
                {/* <TabPane disabled={false} tab="Action Assignment" key="Action_Assignment">
                    <ActionAssignmentComponents />
                </TabPane> */}
                <TabPane disabled={false} tab="Permission" key="Permission">
                    <PermissionComponents />
                </TabPane>
                {/* <TabPane disabled={false} tab="Permission Assignment" key="Permission_Assignment">
                    <PermissionAssignmentComponent />
                </TabPane> */}
                <TabPane disabled={false} tab="Role " key="Role">
                    <RoleComponents />
                </TabPane>
                {/* <TabPane disabled={false} tab="Algorithm Role" key="Algorithm_Role">
                    <RoleComponents />
                </TabPane> */}
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

