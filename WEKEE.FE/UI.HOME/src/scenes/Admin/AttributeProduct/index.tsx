//#region  import
import * as React from "react";
import { useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { createStructuredSelector } from "reselect";
import { useInjectReducer, useInjectSaga } from "../../../redux/reduxInjectors";
import {
    RedoOutlined, CheckOutlined, CloseOutlined, FilePdfOutlined, PlusOutlined, SearchOutlined, EditOutlined,
    DeleteOutlined, LockOutlined, UnlockOutlined,
} from "@ant-design/icons";
import {
    Row, Col, Button, Input, Select, Table, Modal, Form, DatePicker, Tag, Tooltip, Card, notification, InputNumber,
} from "antd";
import reducer from "./reducer";
import saga from "./saga";
import {
    makeSelectcateProReadIdAndNameDto,
    makeSelectCompleted, makeSelectLoading, makeSelectoptionCreateByCate, makeSelectPageIndex,
    makeSelectPageSize, makeSelectproductAttributeReadDto, makeSelectTotalCount, makeSelectTotalPages,
} from "./selectors";
import moment from "moment";
import ConstTypes, { confirmTypes_PROATTR } from "./objectValues/constTypes";
import { ProductAttributeReadDto } from "./dtos/productAttributeReadDto"
import { createAttributeProductStart, getDataAttibuteProductStart, loadCateProStart, loadCreateByCateStart } from "./actions";
import { ProductAttributeInsertDto } from "./dtos/productAttributeInsertDto";
import OrderByProperty from "../../../services/dto/orderByProperty";
import { CateProReadIdAndNameDto } from "./dtos/cateProReadIdAndNameDto";
import AttributeProductTypes from "./objectValues/attributeProductTypes";
const { Option } = Select;
const { RangePicker } = DatePicker;
declare var abp: any;
//#endregion
export interface IAttributeProductProps {
    location: any;
}

const key = "attributeproduct";

const stateSelector = createStructuredSelector < any, any> ({
    loading: makeSelectLoading(),
    completed: makeSelectCompleted(),
    pageIndex: makeSelectPageIndex(),
    pageSize: makeSelectPageSize(),
    totalCount: makeSelectTotalCount(),
    totalPages: makeSelectTotalPages(),
    attibuteData: makeSelectproductAttributeReadDto(),
    optionCategoryProduct: makeSelectcateProReadIdAndNameDto(),
    optionCreateByCate: makeSelectoptionCreateByCate()
});

//#region CSS Layout Item 
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
//#endregion

export default function AttributeProduct(props: IAttributeProductProps) {

    //#region START
    useInjectReducer(key, reducer);
    useInjectSaga(key, saga);
    const dispatch = useDispatch();

    const {
        loading, pageSize, totalCount, pageIndex, attibuteData, optionCategoryProduct
        , optionCreateByCate
    } = useSelector(stateSelector);

    useEffect(() => {
        _selectColumnSearch(ConstTypes.NULL);
        _selectColumnOrder(ConstTypes.NULL);
        dispatch(getDataAttibuteProductStart({
            pageIndex: 1,
            pageSize: 20,
            propertyOrder: 0,
            valueOrderBy: 0,
            propertySearch: [],
            valuesSearch: [],
        }));
        dispatch(loadCateProStart());
        dispatch(loadCreateByCateStart());
    }, []);
    //#endregion

    //#region STATE FOR SEARCH OR ORDER 
    const [propertySearch, setpropertySearch] = useState < any[] > ([]);
    const [valuesSearch, setvaluesSearch] = useState < any[] > ([]);
    const [orderbyColumn, setOrderbyColumn] = useState < string > ('');
    const [orderbyTypes, setOrderbyTypes] = useState < string > ('');
    //#endregion

    //#region SEARCH DADA ONCLICK BUTTON OR CHANGE PAGE
    // có key mà không có giá trị => xóa cả 2
    const _searchDataOnClick = (page: any, pageSize: any) => {
        console.log(valuesSearch);
        if (propertySearch.length !== valuesSearch.length) {
            notification.warning({
                message: "Thất Bại",
                description: "Bạn cần nhập dữ liệu tìm kiếm!",
                placement: "bottomRight",
            });
        }
        else {
            dispatch(getDataAttibuteProductStart({
                pageIndex: page === 0 ? pageIndex : page,
                pageSize: pageSize,
                propertyOrder: 0,
                valueOrderBy: 0,
                propertySearch: propertySearch,
                valuesSearch: valuesSearch,
            }));
        }
    }
    //#endregion

    //#region SELECT COLUMN SEARCH
    const [SelectColumnSearch, setSelectColumnSearch] = useState < JSX.Element > (<Input placeholder="Từ khóa" />);

    function _selectColumnSearch(value: ConstTypes) {

        value === ConstTypes.NULL ? setpropertySearch([]) : setpropertySearch([value]);
        setvaluesSearch([]);

        if (confirmTypes_PROATTR(value) === "DATE") {
            setSelectColumnSearch(<RangePicker
                format="YYYY/MM/DD"
                disabled={value === ConstTypes.NULL}
                onChange={(date, dateString) => _onChangeDataColumnSearch(dateString[0] + "|" + dateString[1])}
            />)
        }
        else if (confirmTypes_PROATTR(value) === "SELECT") {
            setSelectColumnSearch(<Select
                showSearch
                placeholder="Giá trị"
                optionFilterProp="children"
                style={{ width: '100%' }}
                disabled={value === ConstTypes.NULL}
                onChange={(values: number) => _onChangeDataColumnSearch(values)}
            >
                {(() => {
                    if (value === ConstTypes.CATE_PRO_PROATTR)
                        return (optionCategoryProduct.map((province: CateProReadIdAndNameDto) => (
                            <Option value={province.id}>{province.name}</Option>
                        )))
                    if (value === ConstTypes.CREATEBY_PROATTR)
                        return (optionCreateByCate.map((province: CateProReadIdAndNameDto) => (
                            <Option value={province.id}>{province.name}</Option>
                        )))
                    else {
                        return (
                            <>
                                <Option value={AttributeProductTypes.ATTRIBUTE}>{AttributeProductTypes.ATTRIBUTE}</Option>
                                <Option value={AttributeProductTypes.SPECIFICATIONS}>{AttributeProductTypes.SPECIFICATIONS}</Option>
                                <Option value={AttributeProductTypes.TRADEMARK}>{AttributeProductTypes.TRADEMARK}</Option>
                                <Option value={AttributeProductTypes.UNIT}>{AttributeProductTypes.UNIT}</Option>
                                <Option value={AttributeProductTypes.VIDU4}>{AttributeProductTypes.VIDU4}</Option>
                                <Option value={AttributeProductTypes.VIDU5}>{AttributeProductTypes.VIDU5}</Option>
                            </>)
                    }
                })()
                }
            </Select>)
        }
        else if (confirmTypes_PROATTR(value) === "BOOLEAN") {
            setSelectColumnSearch(<Select
                showSearch
                placeholder="Giá trị"
                optionFilterProp="children"
                style={{ width: '100%' }}
                disabled={value === ConstTypes.NULL}
                onChange={(values: number) => _onChangeDataColumnSearch(values)}
            >
                <Option value={1}>TRUE</Option>
                <Option value={0}>FALSE</Option>
            </Select>)
        }
        else if (confirmTypes_PROATTR(value) === "NUMBER") {
            setSelectColumnSearch(
                <InputNumber
                    disabled={value === ConstTypes.NULL}
                    placeholder="Từ khóa"
                    style={{ width: '100%' }}
                    formatter={value => `${value} `.replace(/\B(?=(\d{3})+(?!\d))/g, ',')}
                    onChange={_onChangeDataColumnSearch}
                />)
        }
        else if (confirmTypes_PROATTR(value) === "STRING") {
            setSelectColumnSearch(
                <Input
                    disabled={value === ConstTypes.NULL}
                    placeholder="Từ khóa"
                    onChange={(values: any) => _onChangeDataColumnSearch(values.target.value)}
                />)
        }
        else {
            setSelectColumnSearch(
                <Input
                    placeholder="Từ khóa"
                    value={""}
                    disabled={value === ConstTypes.NULL} />
            );
        }
    }

    // khi cột value search thay đổi mà  key null  => xóa vaule
    const _onChangeDataColumnSearch = (value: any) => {
        if (propertySearch[0] === ConstTypes.NULL) {
            setvaluesSearch([]);
        }
        setvaluesSearch([value]);
    }
    //#endregion

    //#region SELECT COLUMN ORDER

    const [disableColumnOrder, setdisableColumnOrder] = useState < string > (ConstTypes.NULL);

    function _selectColumnOrder(value: string) {
        if (value === ConstTypes.NULL) {
            setOrderbyColumn('');
            setOrderbyTypes('');
        }
        setOrderbyColumn(value);
        setdisableColumnOrder(value);
    }
    function _selectColumnOrderValue(value: any) {
        setOrderbyTypes(value);
    }
    //#endregion

    const [checkCreate, setCheckCreate] = useState(false);
    const [checkRemove, setCheckRemove] = useState(true);
    const [checkRestart, setCheckRestart] = useState(true);
    const [isModalVisible, setisModalVisible] = useState(false);
    // 0 : bật tất cả 1: đang xóa, 2 đang update khóa/mở
    const [isDataChange, setisDataChange] = useState(0);

    //#region INSERT OR UPDATE FORM DATA 
    const [form] = Form.useForm();

    const onFill = (value: ProductAttributeReadDto) => {
        console.log(value)
        form.setFieldsValue(value);
    };

    const onRemove = (value: ProductAttributeReadDto) => {
        setisDataChange(1);
    };

    const onChangeIsStatus = (value: ProductAttributeReadDto) => {
        setisDataChange(2);
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

    const onGenderChangeCategory = (value: number) => {
        form.setFieldsValue({ categoryProductId: value });
    };

    //#endregion

    const columns = [
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
            title: 'Category',
            dataIndex: 'categoryProductIdName'
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

    return (
        <Card
            title="PRODUCT ATTRIBUTE"
            size="small"
            type="inner"
        >
            <Row gutter={[10, 10]}>
                <Col span={24}>
                    <Row gutter={[10, 10]} >
                        <Col span={1}>
                            <Tooltip placement="bottom" title={"Làm Mới"}>
                                <Button loading={loading}
                                    onClick={() => {
                                        setCheckRestart(true);
                                        setisDataChange(0);
                                    }}
                                    disabled={checkRestart}
                                    block icon={<RedoOutlined />}>
                                </Button>
                            </Tooltip>
                        </Col>
                        <Col span={1}>
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
                        <Col span={1}>
                            <Tooltip placement="bottom" title={"Hủy"}>
                                <Button loading={loading} disabled={checkRemove}
                                    onClick={() => {
                                        setisDataChange(0);
                                    }} block icon={<CloseOutlined />}>
                                </Button>
                            </Tooltip>
                        </Col>
                        <Col span={1}>
                            <Tooltip placement="bottom" title={"Xuất File"}>
                                <Button loading={loading} block icon={<FilePdfOutlined />}>
                                </Button>
                            </Tooltip>
                        </Col>
                        <Col span={1}>
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
                        <Col span={4}>
                            <Select
                                optionFilterProp="children"
                                style={{ width: '100%' }}
                                filterOption={(input, option: any) =>
                                    option.children.toLowerCase().indexOf(input.toLowerCase()) >= 0
                                }
                                disabled={loading}
                                onChange={(value: any) => {
                                    _selectColumnSearch(value)
                                }}
                                value={propertySearch[0] === '' ? undefined : propertySearch[0]}
                                placeholder="Tìm Kiếm"
                            >
                                <Option value={ConstTypes.NULL}>Mặc định</Option>
                                <Option value={ConstTypes.ID_PROATTR}>{ConstTypes.ID_PROATTR}</Option>
                                <Option value={ConstTypes.NAME_PROATTR}>{ConstTypes.NAME_PROATTR}</Option>
                                <Option value={ConstTypes.TYPES_PROATTR}>{ConstTypes.TYPES_PROATTR}</Option>
                                <Option value={ConstTypes.CATE_PRO_PROATTR}>{ConstTypes.CATE_PRO_PROATTR}</Option>
                                <Option value={ConstTypes.ISDELETE_PROATTR}>{ConstTypes.ISDELETE_PROATTR}</Option>
                                <Option value={ConstTypes.CREATEBY_PROATTR}>{ConstTypes.CREATEBY_PROATTR}</Option>
                                <Option value={ConstTypes.CREATE_DATE_UTC_PROATTR}>{ConstTypes.CREATE_DATE_UTC_PROATTR}</Option>
                                <Option value={ConstTypes.UPDATE_DATE_UTC_PROATTR}>{ConstTypes.UPDATE_DATE_UTC_PROATTR}</Option>
                            </Select>
                        </Col>
                        <Col span={5}>{SelectColumnSearch}</Col>
                        <Col span={4}>
                            <Select
                                optionFilterProp="children"
                                style={{ width: '100%' }}
                                filterOption={(input, option: any) =>
                                    option.children.toLowerCase().indexOf(input.toLowerCase()) >= 0
                                }
                                defaultValue={orderbyColumn === '' ? undefined : orderbyColumn}
                                disabled={loading}
                                placeholder="Từ khóa"
                                value={orderbyColumn === '' ? undefined : orderbyColumn}
                                onChange={_selectColumnOrder}
                            >
                                <Option value={ConstTypes.NULL}>Mặc định</Option>
                                <Option value={ConstTypes.ID_PROATTR}>{ConstTypes.ID_PROATTR}</Option>
                                <Option value={ConstTypes.NAME_PROATTR}>{ConstTypes.NAME_PROATTR}</Option>
                                <Option value={ConstTypes.TYPES_PROATTR}>{ConstTypes.TYPES_PROATTR}</Option>
                                <Option value={ConstTypes.ISDELETE_PROATTR}>{ConstTypes.ISDELETE_PROATTR}</Option>
                                <Option value={ConstTypes.CREATEBY_PROATTR}>{ConstTypes.CREATEBY_PROATTR}</Option>
                                <Option value={ConstTypes.CREATE_DATE_UTC_PROATTR}>{ConstTypes.CREATE_DATE_UTC_PROATTR}</Option>
                                <Option value={ConstTypes.UPDATE_DATE_UTC_PROATTR}>{ConstTypes.UPDATE_DATE_UTC_PROATTR}</Option>
                            </Select>
                        </Col>
                        <Col span={3}>
                            <Select
                                optionFilterProp="children"
                                style={{ width: '100%' }}
                                filterOption={(input, option: any) =>
                                    option.children.toLowerCase().indexOf(input.toLowerCase()) >= 0
                                }
                                disabled={disableColumnOrder === ConstTypes.NULL}
                                onChange={(value: any) => _selectColumnOrderValue(value)}
                                placeholder="Theo"
                                value={orderbyTypes === '' ? undefined : orderbyTypes}
                                defaultValue={orderbyTypes === '' ? undefined : orderbyTypes}
                            >
                                <Option value={OrderByProperty.UP}>{OrderByProperty.UP}</Option>
                                <Option value={OrderByProperty.DOWN}>{OrderByProperty.DOWN}</Option>
                            </Select>
                        </Col>
                        <Col span={1}>
                            <Button
                                disabled={loading}
                                type="primary"
                                icon={<SearchOutlined />}
                                onClick={() => _searchDataOnClick(0, 0)}
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
                            onChange: _searchDataOnClick,
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
                                rules={[{ required: true, message: 'Kiểu thuộc tính không được để trống!' }]}
                            >
                                <Select
                                    onChange={onGenderChange}
                                    allowClear
                                    style={{ width: '100%' }}
                                    placeholder="Chọn Kiểu dữ liệu"
                                >
                                    <Option value={0}>Kiểu Thuộc tính</Option>
                                    <Option value={1}>Kiểu Đơn vị</Option>
                                    <Option value={2}>Kiểu Thông số kỹ thuật</Option>
                                    <Option value={3}>Kiểu URL</Option>
                                    <Option value={4}>Kiểu URL</Option>
                                    <Option value={5}>Kiểu URL</Option>
                                </Select>
                            </Form.Item>
                            <Form.Item
                                label="Category"
                                name="categoryProductId"
                                rules={[{ required: true, message: 'Category thuộc tính không được để trống!' }]}
                            >
                                <Select
                                    onChange={onGenderChangeCategory}
                                    allowClear
                                    style={{ width: '100%' }}
                                    placeholder="Chọn Kiểu dữ liệu"
                                >
                                    <Option value={-1}>Bỏ qua</Option>
                                    {
                                        optionCategoryProduct.map((province: CateProReadIdAndNameDto) => (
                                            <Option value={province.id}>{province.name}</Option>))
                                    }
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
