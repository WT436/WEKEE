//#region 
import React, { useEffect } from 'react'
import { Button, Col, Row, Table, Tag } from 'antd'
import { BorderOutlined, CheckSquareOutlined } from '@ant-design/icons';
import { ActionDto } from '../dtos/actionDto';
import { useDispatch, useSelector } from 'react-redux';
import { createStructuredSelector } from 'reselect';
import { makeSelectLoading, makeSelectCompleted, makeSelectPageIndex, makeSelectPageSize, makeSelectTotalCount, makeSelectTotalPages, makeSelectDataAction, makeSelectDataResourceAction, makeSelectPageIndexSub, makeSelectPageSizeSub, makeSelectTotalCountSub, makeSelectTotalPagesSub } from '../selectors';
import { listFormActionStart, ResourceActionGetListDataStart, ResourceActionInsertOrUpdateStart } from '../actions';
import { ResourceActionDto } from '../dtos/resourceActionDto'
//#endregion

interface IResourceActionComponents { }

const stateSelector = createStructuredSelector<any, any>({
    loading: makeSelectLoading(),
    completed: makeSelectCompleted(),
    pageIndex: makeSelectPageIndex(),
    pageSize: makeSelectPageSize(),
    totalCount: makeSelectTotalCount(),
    totalPages: makeSelectTotalPages(),
    dataAction: makeSelectDataAction(),
    dataResourceAction: makeSelectDataResourceAction(),
    pageIndexSub: makeSelectPageIndexSub(),
    pageSizeSub: makeSelectPageSizeSub(),
    totalCountSub: makeSelectTotalCountSub(),
    totalPagesSub: makeSelectTotalPagesSub(),
});


export default function ResourceActionComponents(props: IResourceActionComponents) {
    const {
        loading, dataAction, pageSize, totalCount, pageIndex, pageSizeSub, totalCountSub, pageIndexSub, dataResourceAction
    } = useSelector(stateSelector);

    const dispatch = useDispatch();

    const columns = [
        {
            title: 'Action',
            dataIndex: '',
            key: 'x',
            render: (text: ResourceActionDto) => (
                <div>
                    <Button onClick={() => dispatch(ResourceActionInsertOrUpdateStart(text))}
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
            title: 'Id Action',
            dataIndex: 'actionId',
        },
        {
            title: 'Url Server',
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
        },
        {
            title: 'Hành động',
            dataIndex: 'nameAtomic'
        },
        {
            title: 'Acticon cha',
            dataIndex: 'actionBase',
            render: (text: String) => (text === null || text === undefined || text === "" ? <Tag color="red">Null</Tag> : text)
        }
    ];

    useEffect(() => {
        dispatch(listFormActionStart({
            pageIndex: pageIndex,
            pageSize: pageSize,
            property: '',
            orderBy: ''
        }));
    }, []);

    let onChangeAction = (page: any, pageSize: any) => {
        dispatch(listFormActionStart({
            pageIndex: page - 1,
            pageSize: pageSize,
            property: '',
            orderBy: ''
        }));
    };

    let onChangeResource = (page: any, pageSize: any) => {
        dispatch(ResourceActionGetListDataStart({
            pageIndex: page - 1,
            pageSize: pageSize,
            id: dataResourceAction[0].id
        }));
    };

    const rowSelection = {
        onChange: (selectedRowKeys: React.Key[], selectedRows: ActionDto[]) => {
            dispatch(ResourceActionGetListDataStart({
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
                    <Row style={{ fontSize: '20px', fontFamily: 'cursive', padding: '5px 15px' }}>Action</Row>
                    <Table
                        rowSelection={{
                            type: 'radio',
                            ...rowSelection
                        }}
                        rowKey={(record: ActionDto) => record.id.toString()}
                        columns={columnsAction}
                        dataSource={dataAction}
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
                    <Row style={{ fontSize: '20px', fontFamily: 'cursive', padding: '5px 15px' }}>Resource</Row>
                    <Table
                        rowKey={(rec: ResourceActionDto | any)=> rec.id.toString()}
                        columns={columns}
                        dataSource={dataResourceAction}
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