//#region 
import React, { useEffect } from 'react'
import { Button, Col, Row, Table, Tag } from 'antd'
import { BorderOutlined, CheckSquareOutlined } from '@ant-design/icons';
import { ActionDto } from '../dtos/actionDto';
import { useDispatch, useSelector } from 'react-redux';
import { createStructuredSelector } from 'reselect';
import {
    makeSelectLoading, makeSelectCompleted, makeSelectPageIndex,
    makeSelectPageSize, makeSelectTotalCount, makeSelectTotalPages,
    makeSelectPageIndexSub, makeSelectPageSizeSub, makeSelectTotalCountSub,
    makeSelectTotalPagesSub, makeSelectDataRole, makeSelectDataPermissionAssignment
} from '../selectors';
import { ActionAssignmentGetListDataStart, listFormPermissionStart, listFormRoleStart, PermissionAssignmentGetListDataStart, PermissionAssignmentInsertOrUpdateStart } from '../actions';
import { PermissionAssignmentDto } from '../dtos/permissionAssignmentDto';
//#endregion

interface IPermissionAssignmentComponents { }

const stateSelector = createStructuredSelector<any, any>({
    loading: makeSelectLoading(),
    completed: makeSelectCompleted(),
    pageIndex: makeSelectPageIndex(),
    pageSize: makeSelectPageSize(),
    totalCount: makeSelectTotalCount(),
    totalPages: makeSelectTotalPages(),
    dataRole: makeSelectDataRole(),
    dataPermissionAssignment: makeSelectDataPermissionAssignment(),
    pageIndexSub: makeSelectPageIndexSub(),
    pageSizeSub: makeSelectPageSizeSub(),
    totalCountSub: makeSelectTotalCountSub(),
    totalPagesSub: makeSelectTotalPagesSub(),
});

export default function PermissionAssignmentComponents(props: IPermissionAssignmentComponents) {
    const {
        loading, dataRole, pageSize, totalCount,
        pageIndex, pageSizeSub, totalCountSub,
        pageIndexSub, dataPermissionAssignment
    } = useSelector(stateSelector);

    const dispatch = useDispatch();

    const columns = [
        {
            title: 'Action',
            dataIndex: '',
            key: 'x',
            render: (text: PermissionAssignmentDto) => (
                <div>
                    <Button onClick={() => dispatch(PermissionAssignmentInsertOrUpdateStart(text))}
                        type="link"
                        icon={text.isCheck ? <CheckSquareOutlined style={{ color: 'blue' }} />
                            : <BorderOutlined style={{ color: 'black' }} />}>
                    </Button>
                </div>
            )
        },
        {
            title: 'id',
            dataIndex: 'id',
        },
        {
            title: 'Id Role',
            dataIndex: 'roleId',
        },
        {
            title: 'Name',
            dataIndex: 'name',
            sorter: {
                compare: (a: { name: string; }, b: { name: string; }) => a.name.length - b.name.length,
                multiple: 3,
            }
        },
        {
            title: 'Active',
            dataIndex: 'isActive',
            render: (text: boolean) => (text === true ? <Tag color="#2db7f5">True</Tag> : <Tag color="red">False</Tag>)
        }
    ];

    const columnsAction = [
        {
            title: 'id',
            dataIndex: 'id',
            with: 50
        },
        {
            title: 'Tên',
            dataIndex: 'name',
            sorter: {
                compare: (a: { name: string; }, b: { name: string; }) => a.name.length - b.name.length,
                multiple: 3,
            },
            with: 300
        },
        {
            title: 'isActive',
            dataIndex: 'isActive',
            key: 'isActive',
            render: (text: boolean) => (text === true ? <Tag color="#2db7f5">True</Tag> : <Tag color="red">False</Tag>)
        }
    ];

    useEffect(() => {
        dispatch(listFormRoleStart({
            pageIndex: pageIndex,
            pageSize: pageSize,
            property: '',
            orderBy: ''
        }));
    }, []);

    let onChangeAction = (page: any, pageSize: any) => {
        dispatch(listFormPermissionStart({
            pageIndex: page - 1,
            pageSize: pageSize,
            property: '',
            orderBy: ''
        }));
    };

    let onChangeResource = (page: any, pageSize: any) => {
        dispatch(ActionAssignmentGetListDataStart({
            pageIndex: page - 1,
            pageSize: pageSize,
            id: dataPermissionAssignment[0].id
        }));
    };

    const rowSelection = {
        onChange: (selectedRowKeys: React.Key[], selectedRows: ActionDto[]) => {
            dispatch(PermissionAssignmentGetListDataStart({
                pageIndex: pageIndexSub,
                pageSize: pageSizeSub,
                id: selectedRows[0].id
            }));
        }
    };

    return (
        <>
            <Row gutter={[35, 5]}>
                <Col span={12}>
                    <Row style={{ fontSize: '20px', fontFamily: 'cursive', padding: '5px 15px' }}>Role</Row>
                    <Table
                        rowSelection={{
                            type: 'radio',
                            ...rowSelection
                        }}
                        rowKey={(record: PermissionAssignmentDto | any) => record.id.toString()}
                        columns={columnsAction}
                        dataSource={dataRole}
                        loading={loading}
                        size='small'
                        scroll={{ y: 350 }}
                        pagination={{
                            pageSize: pageSize,
                            total: totalCount,
                            defaultCurrent: 1,
                            onChange: onChangeAction,
                            showSizeChanger: true,
                            pageSizeOptions: ['5', '10', '20', '50', '100']
                        }}
                    />
                </Col>
                <Col span={12}>
                    <Row style={{ fontSize: '20px', fontFamily: 'cursive', padding: '5px 15px' }}>Permission</Row>
                    <Table
                        rowKey={(rec: PermissionAssignmentDto | any) => rec.id.toString()}
                        columns={columns}
                        dataSource={dataPermissionAssignment}
                        size='small'
                        loading={loading}
                        pagination={{
                            pageSize: pageSizeSub,
                            total: totalCountSub,
                            defaultCurrent: 1,
                            onChange: onChangeResource,
                            showSizeChanger: true,
                            pageSizeOptions: ['5', '10', '20', '50', '100']
                        }}
                        scroll={{ y: 350 }}
                    />
                </Col>
            </Row>
        </>
    )
}