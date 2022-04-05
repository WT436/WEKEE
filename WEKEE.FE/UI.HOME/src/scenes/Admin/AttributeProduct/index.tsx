//#region  import
import * as React from "react";
import { useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { Switch } from "react-router-dom";
import { createStructuredSelector } from "reselect";
import { useInjectReducer, useInjectSaga } from "../../../redux/reduxInjectors";
import {
    RedoOutlined, CheckOutlined, CloseOutlined, FilePdfOutlined, PlusOutlined, SearchOutlined, EditOutlined, DeleteOutlined, LockOutlined, ClusterOutlined, HistoryOutlined, PartitionOutlined, SlidersOutlined, StarOutlined, UnlockOutlined,
} from "@ant-design/icons";
import {
    Row, Col, Button, Input, Select, Table, Modal, Form, DatePicker, Tag, Tooltip, Card, notification,
} from "antd";
import reducer from "./reducer";
import saga from "./saga";
import {
    makeSelectCompleted, makeSelectLoading, makeSelectPageIndex,
    makeSelectPageSize, makeSelectproductAttributeReadDto, makeSelectTotalCount, makeSelectTotalPages,
} from "./selectors";
import moment from "moment";
import ConstTypes from "./objectValues/constTypes";
import { ProductAttributeReadDto } from "./dtos/productAttributeReadDto"
import { createAttributeProductStart, getDataAttibuteProductStart } from "./actions";
import { ProductAttributeInsertDto } from "./dtos/productAttributeInsertDto";
const { Option } = Select;
const { RangePicker } = DatePicker;
declare var abp: any;
//#endregion
export interface IAttributeProductProps {
    // đây
    location: any;
}

const key = "attributeproduct"; // đây

const stateSelector = createStructuredSelector < any, any> ({
    loading: makeSelectLoading(),
    completed: makeSelectCompleted(),
    pageIndex: makeSelectPageIndex(),
    pageSize: makeSelectPageSize(),
    totalCount: makeSelectTotalCount(),
    totalPages: makeSelectTotalPages(),
    attibuteData: makeSelectproductAttributeReadDto()
});

const formItemLayout = {
    labelCol: {
        xs: { span: 24 },
        sm: { span: 10 },
    },
    wrapperCol: {
        xs: { span: 24 },
        sm: { span: 14 },
    },
};

export default function AttributeProduct(props: IAttributeProductProps) {
    // Đây
    useInjectReducer(key, reducer);
    useInjectSaga(key, saga);

    const dispatch = useDispatch();

    const [checkCreate, setCheckCreate] = useState(false);
    const [checkRemove, setCheckRemove] = useState(true);
    const [checkRestart, setCheckRestart] = useState(true);
    const [isModalVisible, setisModalVisible] = useState(false);
    // 0 : bật tất cả 1: đang xóa, 2 đang update khóa/mở
    const [isDataChange, setisDataChange] = useState(0);
    const [SelectColumn, setSelectColumn] = useState(["All"]);
    const [valuesSearch, setvaluesSearch] = useState < string[] > ([]);
    const [OrderbyColumn, setOrderbyColumn] = useState("");
    const [OrderbyTypes, setOrderbyTypes] = useState("");

    const {
        loading, pageSize, totalCount, pageIndex, attibuteData
    } = useSelector(stateSelector);

    const [form] = Form.useForm();

    const onFill = (value: ProductAttributeReadDto) => {
        form.setFieldsValue(value);
    };

    const onRemove = (value: ProductAttributeReadDto) => {
        setisDataChange(1);
    };

    const onChangeIsStatus = (value: ProductAttributeReadDto) => {
        setisDataChange(2);
    };

    let onChange = (page: any, pageSize: any) => {
        dispatch(getDataAttibuteProductStart({
            pageIndex: page,
            pageSize: pageSize,
            propertyOrder: '',
            valueOrderBy: '',
            propertySearch: [],
            valuesSearch: [],
        }));
    };

    const onFinish = (values: ProductAttributeInsertDto) => {
        if (values.types === -1 || values.types === undefined) {
            notification.warning({
                message: "Thất Bại",
                description: "Kiểu dữ liệu không hợp lệ!",
                placement: "bottomRight",
            });
        }
        else {
            dispatch(createAttributeProductStart(values));
        }
    };

    const onReset = () => {
        setCheckCreate(false);
        form.resetFields();
    };

    const onGenderChange = (value: number) => {
        form.setFieldsValue({ types: value });
    };

    const columns = [
        {
            title: 'Id',
            dataIndex: 'id'
        },
        {
            title: 'Tên',
            dataIndex: 'name',
            sorter: {
                compare: (a: { name: string; }, b: { name: string; }) => a.name.length - b.name.length,
                multiple: 3,
            },
        },
        {
            title: 'Trạng thái',
            dataIndex: 'isDelete',
            key: 'isDelete',
            render: (text: boolean) => (text === true ? <Tag color="#2db7f5">True</Tag> : <Tag color="red">False</Tag>)
        },
        {
            title: 'Kiểu',
            dataIndex: 'typesName'
        },
        {
            title: 'Người cập nhật',
            dataIndex: 'createByName'
        },
        {
            title: 'Thời gian cập nhật',
            dataIndex: 'updatedOnUtc',
            render: (text: Date) => moment(text).format("DD/MM/YYYY hh:mm:ss.ms")
        },
        {
            title: 'Thời gian tạo',
            dataIndex: 'createdOnUtc',
            render: (text: Date) => moment(text).format("DD/MM/YYYY hh:mm:ss.ms")
        },
        {
            title: 'Hành động',
            dataIndex: '',
            key: 'x',
            width: 120,
            render: (text: ProductAttributeReadDto) => (
                <div>
                    <Button type="link" icon={<EditOutlined />}
                        onClick={() => {
                            setisModalVisible(true)
                            setCheckCreate(true);
                            onFill(text);
                        }}></Button>
                    <Button type="link" disabled={!(isDataChange == 0 || isDataChange == 1)} icon={<DeleteOutlined />}
                        onClick={() => {
                            onRemove(text);
                        }}
                    ></Button>
                    {text.isDelete ? <Button disabled={!(isDataChange == 0 || isDataChange == 2)} type="link" icon={<LockOutlined />}
                        onClick={() => onChangeIsStatus(text)}
                    ></Button> :
                        <Button disabled={!(isDataChange == 0 || isDataChange == 2)} type="link" icon={<UnlockOutlined />}
                            onClick={() => onChangeIsStatus(text)}
                        ></Button>}
                </div>
            )
        },
    ];

    //#region Get data attribute product
    useEffect(() => {
        dispatch(getDataAttibuteProductStart({
            pageIndex: 1,
            pageSize: 20,
            propertyOrder: '',
            valueOrderBy: '',
            propertySearch: [],
            valuesSearch: [],
        }));
    }, [])
    //#endregion

    return (
        <Card
            title="PRODUCT ATTRIBUTE"
            size="small"
            type="inner"
            loading={loading}
        >
            <Row gutter={[10, 10]}>
                <Col span={24}>
                    <Row gutter={[10, 10]} >
                        <Col span={2}>
                            <Tooltip placement="bottom" title={"Làm Mới"}>
                                <Button loading={loading}
                                    onClick={() => {
                                        setCheckRestart(true);
                                        setisDataChange(0);
                                        setSelectColumn(["All"]);
                                    }}
                                    disabled={checkRestart}
                                    block icon={<RedoOutlined />}>
                                </Button>
                            </Tooltip>
                        </Col>
                        <Col span={2}>
                            <Tooltip placement="bottom" title={"Lưu"}>
                                <Button loading={loading}
                                    disabled={checkRemove}
                                    block
                                    onClick={() => {
                                        setisDataChange(0);
                                    }}
                                    icon={<CheckOutlined />}>
                                </Button>
                            </Tooltip>
                        </Col>
                        <Col span={2}>
                            <Tooltip placement="bottom" title={"Hủy"}>
                                <Button loading={loading} disabled={checkRemove}
                                    onClick={() => {
                                        setisDataChange(0);
                                    }} block icon={<CloseOutlined />}>
                                </Button>
                            </Tooltip>
                        </Col>
                        <Col span={2}>
                            <Tooltip placement="bottom" title={"Xuất File"}>
                                <Button loading={loading} block icon={<FilePdfOutlined />}>
                                </Button>
                            </Tooltip>
                        </Col>
                        <Col span={2}>
                            <Tooltip placement="bottom" title={"Thêm"}>
                                <Button loading={loading} block icon={<PlusOutlined />}
                                    onClick={() => {
                                        setisModalVisible(true);
                                        form.resetFields();
                                    }}
                                >
                                </Button>
                            </Tooltip>
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
                                <Option value="All">Tìm kiếm</Option>
                                <Option value={ConstTypes.ID_SPEC}>{ConstTypes.ID_SPEC}</Option>
                                <Option value="Name">Tên</Option>
                                <Option value="TypesRsc">Kiểu</Option>
                                <Option value="Description">Chi tiết</Option>
                                <Option value="IsActive">Trạng thái</Option>
                                <Option value="CreatedAt">Ngày Tạo</Option>
                                <Option value="CreateBy">Người sửa</Option>
                                <Option value="UpdatedAt">Ngày cập nhật</Option>
                            </Select>
                        </Col>
                        <Col span={5}>
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
                                defaultValue={"All"}
                                disabled={loading}
                                onChange={(value) => {
                                    setOrderbyColumn(value.substring(0, value.lastIndexOf("_")));
                                    setOrderbyTypes(value.substring(value.lastIndexOf("_") + 1));
                                }}
                            >
                                <Option value="All">Sắp Xếp</Option>
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
                        <Col span={2}>
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
                                <Option value="All">Sắp Xếp</Option>
                                <Option value="Id">Tăng</Option>
                                <Option value="Name">Giảm</Option>
                            </Select>
                        </Col>
                        <Col span={1}>
                            <Button
                                disabled={loading}
                                type="primary"
                                icon={<SearchOutlined />}
                                onClick={() => {

                                }}
                            >
                            </Button>
                        </Col>
                    </Row>
                </Col>
                <Row style={{ margin: '10px 0' }}>
                    <Table
                        columns={columns}
                        rowKey={(record: any) => record.id}
                        dataSource={attibuteData}
                        loading={loading}
                        style={{ width: 'calc(100% - 10px)' }}
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
                <Modal title={!checkCreate == true ? "THÊM MỚI" : "CHỈNH SỬA"}
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
                        >
                            <Form.Item
                                label="ID"
                                name="id"
                                hidden={!checkCreate}
                            >
                                <Input disabled />
                            </Form.Item>

                            <Form.Item
                                label="Tên thuộc tính"
                                name="name"
                                rules={[{ required: true, message: 'Tên thuộc tính không được để trống!' }]}
                            >
                                <Input />
                            </Form.Item>
                            <Form.Item
                                label="Kiểu"
                                name="types"
                            >
                                <Select
                                    onChange={onGenderChange}
                                    allowClear
                                    style={{ width: '100%' }}
                                    defaultValue={-1}>
                                    <Option value={-1}>Chọn Kiểu dữ liệu</Option>
                                    <Option value={0}>Thuộc tính sản phẩm</Option>
                                    <Option value={1}>Đơn vị sản phẩm</Option>
                                    <Option value={2}>Thông số kỹ thuật</Option>
                                    <Option value={3}>URL</Option>
                                    <Option value={4}>URL</Option>
                                    <Option value={5}>URL</Option>
                                </Select>
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
        </Card>
    );
}
