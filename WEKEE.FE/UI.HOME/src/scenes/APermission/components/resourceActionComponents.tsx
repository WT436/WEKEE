//#region 
import React, { useEffect, useState } from 'react'
import { Button, Col, DatePicker, Input, Modal, Row, Select, Table, Tabs, Tag } from 'antd'
import { BorderOutlined, CheckOutlined, CheckSquareOutlined, CloseOutlined, DeleteOutlined, EditOutlined, ExclamationCircleOutlined, PlusOutlined, RedoOutlined, SearchOutlined } from '@ant-design/icons';
import { ActionDto } from '../dtos/actionDto';
import { useDispatch, useSelector } from 'react-redux';
import { createStructuredSelector } from 'reselect';
import { makeSelectLoading, makeSelectCompleted, makeSelectPageIndex, makeSelectPageSize, makeSelectTotalCount, makeSelectTotalPages, makeSelectDataAction, makeSelectDataResourceAction, makeSelectPageIndexSub, makeSelectPageSizeSub, makeSelectTotalCountSub, makeSelectTotalPagesSub, makeSelectdataActionResourceDto } from '../selectors';
import { ActionResourceGetListDataStart, ResourceActionInsertOrUpdateStart } from '../actions';
import { ResourceActionDto } from '../dtos/resourceActionDto'
import { ResourceDto } from '../dtos/resourceDto';
import moment from 'moment';
import { ActionResourceDto } from '../dtos/actionResourceDto';
import Loading from '../../../components/Loading';
const { Option } = Select;
const { RangePicker } = DatePicker;
const { TabPane } = Tabs;
//#endregion

interface IResourceActionComponents {
    isResource: Boolean
    resourceData: ResourceDto | undefined
    actionData: ActionDto | undefined
}

const stateSelector = createStructuredSelector<any, any>({
    loading: makeSelectLoading(),
    completed: makeSelectCompleted(),
    pageIndex: makeSelectPageIndex(),
    pageSize: makeSelectPageSize(),
    totalCount: makeSelectTotalCount(),
    totalPages: makeSelectTotalPages(),
    dataAction: makeSelectdataActionResourceDto()
});

export default function ResourceActionComponents(props: IResourceActionComponents) {
    const {
        loading, dataAction, pageSize, totalCount, pageIndex
    } = useSelector(stateSelector);

    const dispatch = useDispatch();
    // state

    const [selectedRowKeys, setselectedRowKeys] = useState<React.Key[]>([]);
    const [selectdataDefault, setselectdataDefault] = useState<React.Key[]>([]);
    let absOnchange = 0;
    // Ctor
    useEffect(() => {
        startOrReload();
    }, [props.isResource, props.actionData, props.resourceData]);

    useEffect(() => {
        setselectedRowKeys([]);
        setselectdataDefault([]);
        dataAction.map((element: ActionResourceDto) => {
            if (element.isCheck) {
                setselectedRowKeys((selectedRowKeys) => [...selectedRowKeys, element.id.toString()]);
                setselectdataDefault((selectedRowKeys) => [...selectedRowKeys, element.id.toString()]);
            }
        });
    }, [dataAction]);

    // start
    const startOrReload = () => {
        if (props.isResource) {
            dispatch(ActionResourceGetListDataStart({
                pageIndex: 0,
                pageSize: 20,
                propertySearch: [],
                valuesSearch: [],
                propertyOrder: "",
                valueOrderBy: "",
                id: props.resourceData === undefined ? 0 : props.resourceData.id,
            }));
        }
        else {

        }
    }
    // skip data change

    const columns = [
        {
            title: 'id',
            dataIndex: 'id',
            width: 50
        },
        {
            title: 'Tên',
            dataIndex: 'name'
        },
        {
            title: 'Hành động',
            dataIndex: 'atomicName'
        },
        {
            title: 'Acticon cha',
            dataIndex: 'actionBaseName',
            render: (text: String) => (text === null || text === undefined || text === "" ? <Tag color="red">Null</Tag> : text)
        },
        {
            title: 'Chi tiết',
            dataIndex: 'description'
        },
        {
            title: 'Status',
            dataIndex: 'isActive',
            width: 60,
            render: (text: boolean) => (text === true ? <Tag color="#2db7f5">True</Tag> : <Tag color="red">False</Tag>)
        }
    ];

    const rowSelection = {
        onChange: (selectedRowKeys: React.Key[], selectedRows: ActionResourceDto[]) => {
            setselectedRowKeys(selectedRowKeys);
        },
        getCheckboxProps: (record: ActionResourceDto) => ({
            disabled: record.isActive === false
        }),
        selectedRowKeys: selectedRowKeys,
    };
    let onChange = (page: any, pageSize: any) => {
        if (props.isResource) {
            dispatch(ActionResourceGetListDataStart({
                pageIndex: page - 1,
                pageSize: pageSize,
                propertySearch: [],
                valuesSearch: [],
                propertyOrder: "",
                valueOrderBy: "",
                id: props.resourceData === undefined ? 0 : props.resourceData.id,
            }));
        }
        else {

        }
    };

    let onSave = (control: number) => {
        switch (control) {
            case 1:
                saveByActionWithResouce();
                break;
            default: break;
        }
        // Modal.confirm({
        //     title: 'Yêu cầu xác nhận!',
        //     icon: <ExclamationCircleOutlined />,
        //     content: 'Bạn muốn lưu ' + 2 + ' bản ghi đang thay đổi không?',
        //     closable: false,
        //     okText: 'Xác nhận',
        //     cancelText: 'Hủy bỏ',
        //     onOk: () => {
        //         return new Promise((resolve, reject) => {
        //             if (control === 1) { foo(2); };
        //         }).catch(() => console.log('Oops errors!'));
        //     },
        //     onCancel: () => {
        //     },
        // }).update({
        //     title: 'Updated title',
        //     content: 'Updated content',
        // });
    }

    let saveByActionWithResouce = () => {
        // lấy sự thay đổi
        // sử lý thay đổi
        console.log('Thay doi');
        var dataUpdate: React.Key[] = [];
        // lấy dữ liệu bị hủy kết nối
        selectedRowKeys.forEach(
            m => selectdataDefault.includes(m)
                ? dataUpdate.push('') // dữ liệu có không có sự thay đổi
                : dataUpdate.push(m) // dữ liệu được check mới
        );
        // lấy dữ liệu thêm mới kết nối
        selectdataDefault.forEach(
            m => selectedRowKeys.includes(m)
                ? dataUpdate.push('') // dữ liệu có không có sự thay đổi
                : dataUpdate.push(m) // dữ liệu được check
        );
        dataUpdate = dataUpdate.filter((m) => m !== '');
        if (dataUpdate.length > 0) {
            // gửi dữ liệu
            dispatch(ResourceActionInsertOrUpdateStart({
                Id: props.resourceData == undefined ? 0 : props.resourceData.id,
                IsResource: props.isResource,
                DataUpdate: (dataUpdate) as string[]
            }));
            startOrReload();
        }

        // xác nhận
    }
    const onCancelData = () => {
        startOrReload();
    }
    return (
        <>
            <Tabs defaultActiveKey={props.isResource ? "Action" : "Resource"} size='small' >
                <TabPane disabled={props.isResource ? false : true} tab="Action" key="Action">
                    <Row gutter={[10, 10]} >
                        <Col span={3}>
                            <Button loading={loading}
                            onClick={()=>onCancelData()}
                                block icon={<RedoOutlined />}>Làm Mới</Button>
                        </Col>
                        <Col span={3}>
                            <Button loading={loading}
                                block
                                onClick={() => onSave(1)}
                                icon={<CheckOutlined />}>Lưu</Button>
                        </Col>
                        <Col span={3}>
                            <Button loading={loading}
                                onClick={() => onCancelData()}
                                block icon={<CloseOutlined />}>Hủy</Button>
                        </Col>
                        <Col span={6}>
                            {/* {
                        SelectColumn.indexOf("CreatedAt") === 0 || SelectColumn.indexOf("UpdatedAt") === 0
                            ? <RangePicker onChange={(date, dateString) => {
                                setvaluesSearch([]);
                                setvaluesSearch(dateString);
                            }
                            } />
                            : <Input onChange={(value) => {
                                setvaluesSearch([]);
                                setvaluesSearch([value.target.value]);
                            }} disabled={loading} placeholder="Từ khóa" />
                    } */}
                            <Input disabled={loading} placeholder="Từ khóa" />
                        </Col>
                        <Col span={4}>
                            <Select
                                optionFilterProp="children"
                                style={{ width: '100%' }}
                                filterOption={(input, option: any) =>
                                    option.children.toLowerCase().indexOf(input.toLowerCase()) >= 0
                                }
                                disabled={loading}
                            >
                                <Option value="All">Tìm kiếm Tất cả</Option>
                                <Option value="Id">Id</Option>
                                <Option value="Name">Tên</Option>
                                <Option value="TypesRsc">Kiểu</Option>
                                <Option value="Description">Chi tiết</Option>
                                <Option value="IsActive">Trạng thái</Option>
                                <Option value="CreatedAt">Ngày Tạo</Option>
                                <Option value="CreateBy">Người sửa</Option>
                                <Option value="UpdatedAt">Ngày cập nhật</Option>
                            </Select>
                        </Col>
                        <Col span={4}>
                            <Select
                                optionFilterProp="children"
                                style={{ width: '100%' }}
                                filterOption={(input, option: any) =>
                                    option.children.toLowerCase().indexOf(input.toLowerCase()) >= 0
                                }
                                defaultValue={"All"}
                                disabled={loading}
                            >
                                <Option value="All">Không Sắp Xếp</Option>
                                <Option value="Id_ASC ">Id tăng dần</Option>
                                <Option value="Id_DESC">Id giảm dần</Option>
                                <Option value="Name_ASC ">Tên tăng dần</Option>
                                <Option value="Name_DESC">Tên giảm dần</Option>
                                <Option value="TypesRsc_ASC ">Kiểu tăng dần</Option>
                                <Option value="TypesRsc_DESC">Kiểu giảm dần</Option>
                                <Option value="Description_ASC ">Chi tiết tăng dần</Option>
                                <Option value="Description_DESC">Chi tiết giảm dần</Option>
                                <Option value="IsActive_ASC ">Trạng thái tăng dần</Option>
                                <Option value="IsActive_DESC">Trạng thái giảm dần</Option>
                                <Option value="CreatedAt_ASC ">Ngày Tạo tăng dần</Option>
                                <Option value="CreatedAt_DESC">Ngày Tạo giảm dần</Option>
                                <Option value="CreateBy_ASC ">Người sửa tăng dần</Option>
                                <Option value="CreateBy_DESC">Người sửa giảm dần</Option>
                                <Option value="UpdatedAt_ASC ">Ngày cập nhật tăng dần</Option>
                                <Option value="UpdatedAt_DESC">Ngày cập nhật giảm dần</Option>
                            </Select>
                        </Col>
                        <Col span={1}>
                            <Button
                                disabled={loading}
                                type="primary"
                                icon={<SearchOutlined />}
                            >
                            </Button>
                        </Col>
                    </Row>
                    <Table
                        rowSelection={{
                            type: 'checkbox',
                            ...rowSelection
                        }}
                        rowKey={(record: ActionResourceDto | any) => record.id.toString()}
                        style={{ width: '100%', margin: '10px 0' }}
                        scroll={{ y: 350 }}
                        size='small'
                        columns={columns}
                        dataSource={dataAction}
                        loading={loading}
                        pagination={{
                            pageSize: pageSize,
                            total: totalCount,
                            defaultCurrent: 1,
                            onChange: onChange,
                            showSizeChanger: true,
                            pageSizeOptions: ['5', '10', '20', '50', '100', '200', '500', '1000']
                        }}
                    />
                </TabPane>
                <TabPane disabled={props.isResource ? true : false} tab="Resource" key="Resource"></TabPane>
            </Tabs>
        </>
    )
}
