//#region 
import React, { useEffect } from 'react'
import { Button, Col, Row, Table, Tag } from 'antd'
import { BorderOutlined, CheckSquareOutlined } from '@ant-design/icons';
import { ActionDto } from '../dtos/actionDto';
import { useDispatch, useSelector } from 'react-redux';
import { createStructuredSelector } from 'reselect';
import {
    makeSelectLoading, makeSelectCompleted, makeSelectPageIndex, makeSelectPageSize,
    makeSelectTotalCount, makeSelectTotalPages, makeSelectDataActionAssignment, makeSelectPageIndexSub,
    makeSelectPageSizeSub, makeSelectTotalCountSub, makeSelectTotalPagesSub, makeSelectDataPermission
} from '../selectors';
import { ActionAssignmentGetListDataStart, ActionAssignmentInsertOrUpdateStart, listFormPermissionStart } from '../actions';
import { ActionAssignmentDto } from '../dtos/actionAssignmentDto'
//#endregion

interface IActionAssignmentComponents { }

const stateSelector = createStructuredSelector<any, any>({
    loading: makeSelectLoading(),
    completed: makeSelectCompleted(),
    pageIndex: makeSelectPageIndex(),
    pageSize: makeSelectPageSize(),
    totalCount: makeSelectTotalCount(),
    totalPages: makeSelectTotalPages(),
    dataPermission: makeSelectDataPermission(),
    dataActionAssignment: makeSelectDataActionAssignment(),
    pageIndexSub: makeSelectPageIndexSub(),
    pageSizeSub: makeSelectPageSizeSub(),
    totalCountSub: makeSelectTotalCountSub(),
    totalPagesSub: makeSelectTotalPagesSub(),
});

export default function ActionAssignmentComponents(props: IActionAssignmentComponents) {
    const {
        loading, dataPermission, pageSize, totalCount, pageIndex, pageSizeSub, totalCountSub, pageIndexSub, dataActionAssignment
    } = useSelector(stateSelector);

    const dispatch = useDispatch();

    const columns = [
        {
            title: 'Action',
            dataIndex: '',
            key: 'x',
            render: (text: ActionAssignmentDto) => (
                <div>
                    <Button onClick={() => dispatch(ActionAssignmentInsertOrUpdateStart(text))}
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
            title: 'Id permission',
            dataIndex: 'permissionId',
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
            title: 'Name Atomic',
            dataIndex: 'nameAtomic',
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
        dispatch(listFormPermissionStart({
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
            id: dataActionAssignment[0].id
        }));
    };

    const rowSelection = {
        onChange: (selectedRowKeys: React.Key[], selectedRows: ActionDto[]) => {
            dispatch(ActionAssignmentGetListDataStart({
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
                    <Row style={{ fontSize: '20px', fontFamily: 'cursive', padding: '5px 15px' }}>Permission</Row>
                    <Table
                        rowSelection={{
                            type: 'radio',
                            ...rowSelection
                        }}
                        rowKey={(record: ActionDto) => record.id.toString()}
                        columns={columnsAction}
                        dataSource={dataPermission}
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
                    <Row style={{ fontSize: '20px', fontFamily: 'cursive', padding: '5px 15px' }}>Action</Row>
                    <Table
                        rowKey={(rec: ActionAssignmentDto | any) => rec.id.toString()}
                        columns={columns}
                        dataSource={dataActionAssignment}
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