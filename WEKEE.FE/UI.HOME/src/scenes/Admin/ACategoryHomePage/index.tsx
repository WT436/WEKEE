//#region  import
import * as React from 'react';
import { useEffect, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { createStructuredSelector } from 'reselect';
import { useInjectReducer, useInjectSaga } from '../../../redux/reduxInjectors';
import reducer from './reducer';
import saga from './saga';
import { makeSelectCategoryDtos, makeSelectCompleted, makeSelectLoading, makeSelectPageIndex, makeSelectPageSize, makeSelectTotalCount, makeSelectTotalPages } from './selectors';
import { Avatar, Image, Button, Card, Col, Collapse, DatePicker, Form, Input, InputNumber, notification, Row, Select, Table, Tag, Tooltip, Cascader } from 'antd';
import { CheckOutlined, CloseOutlined, DeleteOutlined, DesktopOutlined, EditOutlined, EllipsisOutlined, FilePdfOutlined, LockOutlined, PlusOutlined, RedoOutlined, SearchOutlined, SettingOutlined, UnlockOutlined, UserOutlined } from '@ant-design/icons';
import ConstTypes, { confirmTypes } from './objectValues/ConstTypes';
import form from 'antd/lib/form';
import OrderByProperty from '../../../services/dto/orderByProperty';
import moment from 'moment';
import { getCategoryAdminStart } from './actions';
import { CategoryHomePageReadDto } from './dto/categoryHomePageReadDto';
import { CategoryComponentProperty } from './objectValues/categoryComponentProperty';
declare var abp: any;
const { Panel } = Collapse;
const { Option } = Select;
const { RangePicker } = DatePicker;
//#endregion
export interface IACategoryHomePageProps { // đây
    location: any;
}

const key = 'acategoryhomepage';// đây

const stateSelector = createStructuredSelector<any, any>({
    loading: makeSelectLoading(),
    completed: makeSelectCompleted(),
    pageIndex: makeSelectPageIndex(),
    pageSize: makeSelectPageSize(),
    totalCount: makeSelectTotalCount(),
    totalPages: makeSelectTotalPages(),
    categoryDtos: makeSelectCategoryDtos(),
});

export default function ACategoryHomePage(props: IACategoryHomePageProps) { // Đây

    //#region START
    useInjectReducer(key, reducer);
    useInjectSaga(key, saga);
    const dispatch = useDispatch();

    const [propertySearch, setpropertySearch] = useState<any[]>([ConstTypes.IS_COMPONENT]);
    const [valuesSearch, setvaluesSearch] = useState<any[]>([CategoryComponentProperty.HOME_NULL]);
    const [orderbyColumn, setOrderbyColumn] = useState<string>('');
    const [orderbyTypes, setOrderbyTypes] = useState<string>('');

    const {
        loading, pageSize, totalCount, pageIndex, categoryDtos
    } = useSelector(stateSelector);

    useEffect(() => {
        // load data table
        setpropertySearch([ConstTypes.IS_COMPONENT]);
        setvaluesSearch([CategoryComponentProperty.HOME_NULL]);
    }, []);

    //#endregion

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

    //#region SEARCH OR ORDER 

    useEffect(() => {
        dispatch(
            getCategoryAdminStart({
                pageIndex: 1,
                pageSize: 20,
                propertyOrder: orderbyColumn,
                valueOrderBy: orderbyTypes,
                propertySearch: propertySearch,
                valuesSearch: valuesSearch,
            })
        );
    }, [propertySearch, valuesSearch, orderbyColumn, orderbyTypes])

    //#endregion

    //#region SEARCH DADA ONCLICK BUTTON OR CHANGE PAGE
    // có key mà không có giá trị => xóa cả 2
    const _searchDataOnClick = (page: any, pageSize: any) => {
        if (propertySearch.length !== valuesSearch.length) {
            notification.warning({
                message: "Thất Bại",
                description: "Bạn cần nhập dữ liệu tìm kiếm!",
                placement: "bottomRight",
            });
        }
        else {
        }
    }

    const _OnchangeIsComponent = (value: string) => {
        var prosearch = propertySearch;
        prosearch[0] = ConstTypes.IS_COMPONENT;
        var valsearch = valuesSearch;
        valsearch[0] = value;

        dispatch(
            getCategoryAdminStart({
                pageIndex: 1,
                pageSize: 20,
                propertyOrder: orderbyColumn,
                valueOrderBy: orderbyTypes,
                propertySearch: prosearch,
                valuesSearch: valsearch,
            })
        );

        setpropertySearch(prosearch);
        setvaluesSearch(valsearch);
    }
    //#endregion

    //#region SELECT COLUMN SEARCH
    const [SelectColumnSearch, setSelectColumnSearch] = useState<JSX.Element>(<Input disabled placeholder="Từ khóa" />);

    function _selectColumnSearch(value: ConstTypes) {
        value === ConstTypes.NULL ? setpropertySearch([]) : setpropertySearch([value]);
        setvaluesSearch([]);

        if (confirmTypes(value) === "DATE") {
            setSelectColumnSearch(<RangePicker
                format="YYYY/MM/DD"
                disabled={value === ConstTypes.NULL}
                onChange={(date, dateString) => _onChangeDataColumnSearch(dateString[0] + "|" + dateString[1])}
            />)
        }
        else if (confirmTypes(value) === "SELECT") {
            setSelectColumnSearch(<Select
                showSearch
                placeholder="Giá trị"
                optionFilterProp="children"
                style={{ width: '100%' }}
                disabled={value === ConstTypes.NULL}
                onChange={(values: number) => _onChangeDataColumnSearch(values)}
            >
                {(() => {
                    if (value === ConstTypes.CREATE_BY)
                        // return (optionCategoryProduct.map((province: CateProReadIdAndNameDto) => (
                        //     <Option value={province.id}>{province.name}</Option>
                        // )))
                        return (<Option value={'province.id'}>{'province.name'}</Option>)
                    if (value === ConstTypes.MAIN_CATEGORY)
                        // return (optionCreateByCate.map((province: CateProReadIdAndNameDto) => (
                        //     <Option value={province.id}>{province.name}</Option>
                        // )))
                        return (<Option value={'province.id'}>{'province.name'}</Option>)
                    if (value === ConstTypes.NUMBER_ORDER)
                        // return (optionCreateByCate.map((province: CateProReadIdAndNameDto) => (
                        //     <Option value={province.id}>{province.name}</Option>
                        // )))
                        return (<Option value={'province.id'}>{'province.name'}</Option>)
                    if (value === ConstTypes.IS_COMPONENT)
                        // return (optionCreateByCate.map((province: CateProReadIdAndNameDto) => (
                        //     <Option value={province.id}>{province.name}</Option>
                        // )))
                        return (<Option value={'province.id'}>{'province.name'}</Option>)
                    else {
                        return (
                            <>
                                <Option value={'province.id'}>{'province.name'}</Option>
                            </>)
                    }
                })()
                }
            </Select>)
        }
        else if (confirmTypes(value) === "BOOLEAN") {
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
        else if (confirmTypes(value) === "NUMBER") {
            setSelectColumnSearch(
                <InputNumber
                    disabled={value === ConstTypes.NULL}
                    placeholder="Từ khóa"
                    style={{ width: '100%' }}
                    formatter={value => `${value} `.replace(/\B(?=(\d{3})+(?!\d))/g, ',')}
                    onChange={_onChangeDataColumnSearch}
                />)
        }
        else if (confirmTypes(value) === "STRING") {
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
                    defaultValue={ConstTypes.NULL}
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
    const [disableColumnOrder, setdisableColumnOrder] = useState<string>(ConstTypes.NULL);

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

    //#region INSERT OR UPDATE FORM DATA 
    const [checkCreate, setCheckCreate] = useState(false);
    const [checkRemove, setCheckRemove] = useState(true);
    const [checkRestart, setCheckRestart] = useState(true);
    const [isModalVisible, setisModalVisible] = useState(false);
    const [isDataChange, setisDataChange] = useState(0);

    const [form] = Form.useForm();

    const onFill = (value: any) => {
        console.log(value)
        form.setFieldsValue(value);
    };

    const onRemove = (value: any) => {
        setisDataChange(1);
    };

    const onChangeIsStatus = (value: any) => {
        setisDataChange(2);
    };

    const onFinish = (values: any) => {
        if (values.types === -1 || values.types === undefined) {
            notification.warning({
                message: "Thất Bại",
                description: "Kiểu dữ liệu không hợp lệ!",
                placement: "bottomRight",
            });
        }
        else {

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

    //#region Main Table
    const columns = [
        {
            title: "Tên hiển thị",
            dataIndex: "nameCategory",
            key: "nameCategory",
        },
        {
            title: "Đường dẫn",
            dataIndex: "urlCategory",
            key: "urlCategory",
        },
        {
            title: "Icon",
            dataIndex: "iconCategory",
            key: "iconCategory",
            render: (text: string) => (
                <Avatar src={<Image src={abp.serviceAlbumImage + text} style={{ width: 32 }} />} />)
        },
        {
            title: "Category Main",
            dataIndex: "categoryMainName",
            key: "categoryMainName",
        },
        {
            title: "Vị trí hiển thị",
            dataIndex: "numberOrder",
            key: "numberOrder",
        },
        {
            title: "Trạng thái",
            dataIndex: "isEnabled",
            key: "isEnabled",
            render: (text: boolean) =>
                text === true ? (
                    <Tag color="#2db7f5">True</Tag>
                ) : (
                    <Tag color="red">False</Tag>
                ),
        },
        {
            title: "Component",
            dataIndex: "isComponent",
            key: "isComponent",
            render: (text: boolean) => (<Tag color="#2db7f5">{text}</Tag>)
        }
    ];
    //#endregion

    //#region  SELECT TYPES VIEW ORDER CATEGORY

    //#endregion

    //#region  Table Main
    const rowSelection = {
        onChange: (selectedRowKeys: React.Key[], selectedRows: CategoryHomePageReadDto[]) => {
            console.log(`selectedRowKeys: ${selectedRowKeys}`, 'selectedRows: ', selectedRows);
        },
        getCheckboxProps: (record: CategoryHomePageReadDto) => ({
            name: record.nameCategory
        }),
    };
    //#endregion

    return (
        <>
            <Col span={24}>
                <Card
                    title="Lựa chọn nơi hiển thị"
                    size="small"
                    type="inner"
                >
                    <Select
                        optionFilterProp="children"
                        style={{ width: '100%' }}
                        filterOption={(input, option: any) =>
                            option.children.toLowerCase().indexOf(input.toLowerCase()) >= 0
                        }
                        onChange={(value: string) => _OnchangeIsComponent(value)}
                        placeholder="Tìm kiếm nơi hiển thị"
                        defaultValue={CategoryComponentProperty.HOME_NULL}
                    >
                        <Option value={CategoryComponentProperty.HOME_NULL}>{CategoryComponentProperty.HOME_NULL}</Option>
                        <Option value={CategoryComponentProperty.COMPONENT_HOME}>{CategoryComponentProperty.COMPONENT_HOME}</Option>
                        <Option value={CategoryComponentProperty.HOME_PAGE_MENU}>{CategoryComponentProperty.HOME_PAGE_MENU}</Option>
                    </Select>
                </Card>
            </Col>
            <Card
                title="CATEGORY PRODUCT SHOW HOME"
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
                                    value={propertySearch[0] === '' ? ConstTypes.NULL : propertySearch[0]}
                                    placeholder="Tìm Kiếm"
                                >
                                    <Option value={ConstTypes.NULL}>Mặc định</Option>
                                    <Option value={ConstTypes.ID}>{ConstTypes.ID}</Option>
                                    <Option value={ConstTypes.CREATE_BY}>{ConstTypes.CREATE_BY}</Option>
                                    <Option value={ConstTypes.CATEGORY_ID}>{ConstTypes.CATEGORY_ID}</Option>
                                    <Option value={ConstTypes.NAME_CATEGORY}>{ConstTypes.NAME_CATEGORY}</Option>
                                    <Option value={ConstTypes.URL_CATEGORY}>{ConstTypes.URL_CATEGORY}</Option>
                                    <Option value={ConstTypes.NUMBER_ORDER}>{ConstTypes.NUMBER_ORDER}</Option>
                                    <Option value={ConstTypes.IS_ENABLED}>{ConstTypes.IS_ENABLED}</Option>
                                    <Option value={ConstTypes.MAIN_CATEGORY}>{ConstTypes.MAIN_CATEGORY}</Option>
                                    <Option value={ConstTypes.CREATE_DATE_UTC}>{ConstTypes.CREATE_DATE_UTC}</Option>
                                    <Option value={ConstTypes.UPDATE_DATE_UTC}>{ConstTypes.UPDATE_DATE_UTC}</Option>
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
                                    <Option value={ConstTypes.ID}>{ConstTypes.ID}</Option>
                                    <Option value={ConstTypes.CREATE_BY}>{ConstTypes.CREATE_BY}</Option>
                                    <Option value={ConstTypes.CATEGORY_ID}>{ConstTypes.CATEGORY_ID}</Option>
                                    <Option value={ConstTypes.NAME_CATEGORY}>{ConstTypes.NAME_CATEGORY}</Option>
                                    <Option value={ConstTypes.URL_CATEGORY}>{ConstTypes.URL_CATEGORY}</Option>
                                    <Option value={ConstTypes.NUMBER_ORDER}>{ConstTypes.NUMBER_ORDER}</Option>
                                    <Option value={ConstTypes.IS_ENABLED}>{ConstTypes.IS_ENABLED}</Option>
                                    <Option value={ConstTypes.MAIN_CATEGORY}>{ConstTypes.MAIN_CATEGORY}</Option>
                                    <Option value={ConstTypes.CREATE_DATE_UTC}>{ConstTypes.CREATE_DATE_UTC}</Option>
                                    <Option value={ConstTypes.UPDATE_DATE_UTC}>{ConstTypes.UPDATE_DATE_UTC}</Option>
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
                </Row >
                <Card
                    size="small"
                    type="inner"
                    style={{ marginTop: "10px" }}
                    loading={loading}
                >
                    <Table
                        columns={columns}
                        dataSource={categoryDtos}
                        rowKey={(record: CategoryHomePageReadDto | any) => record.id.toString()}
                        rowSelection={{
                            type: 'checkbox',
                            ...rowSelection,
                        }} />
                </Card>
            </Card>
        </>
    )
}
