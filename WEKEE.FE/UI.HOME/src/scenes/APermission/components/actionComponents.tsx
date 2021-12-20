//#region import
import React, { useEffect, useState } from 'react'
import { useDispatch, useSelector } from 'react-redux';
import { createStructuredSelector } from 'reselect';
import { listFormActionStart, ActionCreateStart, ActionEditStart, ActionRemoveFeCancel, ActionRemoveFeStart, ActionRemoveStart } from '../actions';
import {
    CheckOutlined, CloseOutlined, DeleteOutlined, EditOutlined,
    FilePdfOutlined, LockOutlined, PartitionOutlined, PlusOutlined, RedoOutlined, SearchOutlined, UnlockOutlined
} from '@ant-design/icons';
import { Button, Col, DatePicker, Form, Input, Modal, Row, Select, Switch, Table, Tag } from 'antd'
import {
    makeSelectCompleted, makeSelectDataAction, makeSelectDataRemoveAction, makeSelectLoading, makeSelectPageIndex,
    makeSelectPageSize, makeSelectTotalCount, makeSelectTotalPages
} from '../selectors';
import { ActionDto } from '../dtos/actionDto';
import moment from 'moment';
const { Option } = Select;
const { RangePicker } = DatePicker;
//#endregion

interface IActionComponentsProps {

}
const stateSelector = createStructuredSelector<any, any>({
    loading: makeSelectLoading(),
    completed: makeSelectCompleted(),
    pageIndex: makeSelectPageIndex(),
    pageSize: makeSelectPageSize(),
    totalCount: makeSelectTotalCount(),
    totalPages: makeSelectTotalPages(),
    dataAction: makeSelectDataAction(),
    dataRemoveAction: makeSelectDataRemoveAction()
});
export default function ActionComponents(props: IActionComponentsProps) {
    const [checkCreate, setCheckCreate] = useState(false);
    const [checkRemove, setCheckRemove] = useState(true);
    const [checkRestart, setCheckRestart] = useState(true);
    const [isModalVisible, setisModalVisible] = useState(false);
    // 0 : bật tất cả 1: đang xóa, 2 đang update khóa/mở
    const [isDataChange, setisDataChange] = useState(0);
    const [SelectColumn, setSelectColumn] = useState(["All"]);
    const [valuesSearch, setvaluesSearch] = useState<string[]>([]);
    const [OrderbyColumn, setOrderbyColumn] = useState("");
    const [OrderbyTypes, setOrderbyTypes] = useState("");

    const dispatch = useDispatch();

    const {
        loading, dataAction, pageSize, totalCount, pageIndex,
        dataRemoveAction
    } = useSelector(stateSelector);

    useEffect(() => {
        dispatch(listFormActionStart({
            pageIndex: pageIndex,
            pageSize: pageSize,
            propertyOrder: "UpdatedAt",
            valueOrderBy: "ASC",
            propertySearch: [],
            valuesSearch: [],
        }));
    }, []);

    const columns = [
        {
            title: 'id',
            dataIndex: 'id',
            width: 50
        },
        {
            title: 'Tên',
            dataIndex: 'name',
            sorter: {
                compare: (a: { name: string; }, b: { name: string; }) => a.name.length - b.name.length,
                multiple: 3,
            }
        },
        {
            title: 'Status',
            dataIndex: 'isActive',
            key: 'isActive',
            width: 60,
            render: (text: boolean) => (text === true ? <Tag color="#2db7f5">True</Tag> : <Tag color="red">False</Tag>)
        },
        {
            title: 'Hành động',
            dataIndex: 'atomicName'
        },
        {
            title: 'Chi tiết',
            dataIndex: 'description'
        },
        {
            title: 'Acticon cha',
            dataIndex: 'actionBaseName',
            render: (text: String) => (text === null || text === undefined || text === "" ? <Tag color="red">Null</Tag> : text)
        },
        {
            title: 'Người Update',
            dataIndex: 'createByName'
        },
        {
            title: 'Ngày Tạo',
            dataIndex: 'createdAt',
            render: (text: Date) => moment(text).format("DD/MM/YYYY hh:mm:ss.ms")
        },
        {
            title: 'Ngày Update',
            dataIndex: 'updatedAt',
            render: (text: Date) => moment(text).format("DD/MM/YYYY hh:mm:ss.ms")
        },
        {
            title: 'Hành động',
            dataIndex: '',
            key: 'x',
            render: (text: ActionDto) => (
                <div>
                    <Button type="link" icon={<EditOutlined />}
                        title='Sửa'
                        onClick={() => {
                            setCheckCreate(true);
                            onFill(text);
                        }}>
                    </Button>
                    &nbsp;
                    <Button type="link" icon={<DeleteOutlined />}
                        title='Xóa'
                        onClick={() => {
                            onRemove(text);
                        }}
                    >
                    </Button>
                    {
                        text.isActive
                            ? <Button disabled={!(isDataChange == 0 || isDataChange == 2)} type="link" icon={<LockOutlined />}
                                onClick={() => onChangeIsStatus(text)}
                                title='Khóa'
                            >
                            </Button>
                            : <Button disabled={!(isDataChange == 0 || isDataChange == 2)} type="link" icon={<UnlockOutlined />}
                                onClick={() => onChangeIsStatus(text)}
                                title='Mở'
                            >
                            </Button>
                    }
                    <Button type="link"
                        icon={<PartitionOutlined />}
                        title='Nạp quyền'
                    >
                    </Button>
                </div>
            )
        }
    ];

    useEffect(() => {
        if (dataRemoveAction.length === 0) {
            setCheckRemove(true);
        }
        else {
            setCheckRemove(false);
            setCheckRestart(false);
        }
    }, [dataRemoveAction]);

    const [form] = Form.useForm();

    const onFill = (value: ActionDto) => {
        form.setFieldsValue(value);
    };

    const onRemove = (value: ActionDto) => {
        setisDataChange(1);
        //dispatch(ResourceRemoveFeStart(value.id, 1));
    };

    const onChangeIsStatus = (value: ActionDto) => {
        setisDataChange(2);
        //dispatch(ResourceRemoveFeStart(value.id, 2));
    };

    let onChange = (page: any, pageSize: any) => {
        dispatch(listFormActionStart({
            pageIndex: page - 1,
            pageSize: pageSize,
            propertyOrder: OrderbyColumn,
            valueOrderBy: OrderbyTypes,
            propertySearch: [],
            valuesSearch: valuesSearch
        }));
    };

    const onFinish = (values: ActionDto) => {
        if (values.id === undefined) {
            //dispatch(ResourceCreateStart(values));
        }
        else {
            //dispatch(ResourceEditStart(values));
        }
    };

    const onReset = () => {
        setCheckCreate(false);
        form.resetFields();
    };

    const onGenderChange = (value: string) => {
        form.setFieldsValue({ types: value });
    };

    return (
        <Row gutter={[10, 10]}>
            <Col span={24}>
                <Row gutter={[10, 10]} >
                    <Col span={3}>
                        <Button loading={loading}
                            onClick={() => {
                                dispatch(listFormActionStart({
                                    pageIndex: pageIndex,
                                    pageSize: pageSize,
                                    propertyOrder: "",
                                    valueOrderBy: "",
                                    propertySearch: [],
                                    valuesSearch: []
                                }));
                                setCheckRestart(true);
                                setisDataChange(0);
                                setSelectColumn(["All"]);
                            }}
                            disabled={checkRestart}
                            block icon={<RedoOutlined />}>Làm Mới</Button>
                    </Col>
                    <Col span={2}>
                        <Button loading={loading}
                            disabled={checkRemove}
                            block
                            onClick={() => {
                                //dispatch(ResourceRemoveStart(dataRemoveAction, isDataChange));
                                setisDataChange(0);
                            }}
                            icon={<CheckOutlined />}>Lưu</Button>
                    </Col>
                    <Col span={2}>
                        <Button loading={loading} disabled={checkRemove}
                            onClick={() => {
                                //dispatch(ResourceRemoveFeCancel());
                                setisDataChange(0);
                            }} block icon={<CloseOutlined />}>Hủy</Button>
                    </Col>
                    <Col span={3}>
                        <Button loading={loading} block icon={<FilePdfOutlined />}>Xuất File</Button>
                    </Col>
                    <Col span={3}>
                        <Button loading={loading} block icon={<PlusOutlined />}
                            onClick={() => setisModalVisible(true)}
                        >Thêm</Button>
                    </Col>
                    <Col span={4}>
                        {console.log()}
                        {
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
                        }
                    </Col>
                    <Col span={3}>
                        <Select
                            optionFilterProp="children"
                            style={{ width: '100%' }}
                            filterOption={(input, option: any) =>
                                option.children.toLowerCase().indexOf(input.toLowerCase()) >= 0
                            }
                            disabled={loading}
                            defaultValue={SelectColumn}
                            onChange={(value: any) => {
                                setSelectColumn([]);
                                setSelectColumn(value);
                            }}
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
                    <Col span={3}>
                        <Select
                            optionFilterProp="children"
                            style={{ width: '100%' }}
                            filterOption={(input, option: any) =>
                                option.children.toLowerCase().indexOf(input.toLowerCase()) >= 0
                            }
                            defaultValue={"All"}
                            disabled={loading}
                            onChange={(value) => {
                                setOrderbyColumn(value.substring(0, value.lastIndexOf("_")));
                                setOrderbyTypes(value.substring(value.lastIndexOf("_") + 1));
                            }}
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
                            onClick={() => {
                                dispatch(listFormActionStart({
                                    pageIndex: 0,
                                    pageSize: 0,
                                    propertyOrder: OrderbyColumn,
                                    valueOrderBy: OrderbyTypes,
                                    propertySearch: SelectColumn,
                                    valuesSearch: valuesSearch
                                }));
                            }}
                        >
                        </Button>
                    </Col>
                </Row>
                <Row style={{ margin: '10px 0' }}>
                    <Table
                        columns={columns}
                        dataSource={dataAction}
                        rowKey={(record: ActionDto | any) => record.id.toString()}
                        loading={loading}
                        style={{ width: '100%' }}
                        scroll={{ y: 350 }}
                        size='small'
                        pagination={{
                            pageSize: pageSize,
                            total: totalCount,
                            defaultCurrent: 1,
                            onChange: onChange,
                            showSizeChanger: true,
                            pageSizeOptions: ['5', '10', '20', '50', '100']
                        }}
                    />
                </Row>
            </Col>
            <Modal title="Thêm mới hoặc sửa Resource"
                visible={isModalVisible}
                onCancel={() => setisModalVisible(false)}
                maskClosable={false}
                style={{ top: 20 }}
                footer={null}
            >
                <Row style={{
                    fontSize: '16px', fontFamily: 'monospace',
                    margin: '10px 0', padding: '20px 10px',
                    borderTop: '3px solid #150799', borderRadius: '5px',
                }}
                >
                    <Form
                        name="basic"
                        labelCol={{ span: 8 }}
                        wrapperCol={{ span: 16 }}
                        initialValues={{ remember: true }}
                        form={form}
                        onFinish={onFinish}
                        style={{ width: '100%', textAlign: 'left' }}
                    > <Form.Item
                        label="ID"
                        name="id"
                    >
                            <Input disabled />
                        </Form.Item>

                        <Form.Item
                            label="Tên Action"
                            name="name"
                            rules={[{ required: true, message: 'Đường dẫn không được để trống!' }]}
                        >
                            <Input />
                        </Form.Item>
                        <Form.Item
                            label="Tên Atomic"
                            name="atomicId"
                        >
                            <Select
                                onChange={onGenderChange}
                                allowClear
                                style={{ width: '100%' }}
                                defaultValue="_"
                            >
                                <Option value="_">Chọn Kiểu dữ liệu</Option>
                                <Option value={1}>GET</Option>
                                <Option value={2}>LIST</Option>
                                <Option value={3}>WATCH</Option>
                                <Option value={4}>UPDATE</Option>
                                <Option value={5}>CREATE</Option>
                                <Option value={6}>DELETE</Option>
                                <Option value={7}>EDIT</Option>
                            </Select>
                        </Form.Item>
                        <Form.Item
                            label="Chi Tiết"
                            name="description"
                            rules={[{ required: true, message: 'Please input your description!' }]}
                        >
                            <Input.TextArea />
                        </Form.Item>
                        <Form.Item
                            label="ID Action Cha"
                            name="actionBase"
                        >
                            <Input type='number' />
                        </Form.Item>
                        <Form.Item name="isActive" label="Trạng Thái" valuePropName="checked">
                            <Switch />
                        </Form.Item>
                        <Form.Item
                            label="Ngày sửa :"
                            name="dateCreate"
                        >
                            <Input disabled />
                        </Form.Item>
                        <Row gutter={[10, 10]}>
                            <Col span={6}><Button loading={loading} onClick={onReset} block icon={<RedoOutlined />}>Làm Mới</Button></Col>
                            <Col span={6}><Button loading={loading} hidden={!checkCreate} type="primary" htmlType="submit" block icon={<CheckOutlined />}>Lưu</Button></Col>
                            <Col span={6}><Button loading={loading} hidden={!checkCreate} onClick={onReset} block icon={<CloseOutlined />}>Hủy</Button></Col>
                            <Col span={6}><Button loading={loading} hidden={checkCreate} type="primary" htmlType="submit" block icon={<PlusOutlined />}>Tạo mới</Button></Col>
                        </Row>
                    </Form>
                </Row>
            </Modal>
        </Row >
    )
}
