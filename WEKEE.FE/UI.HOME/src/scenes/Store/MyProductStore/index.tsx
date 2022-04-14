//#region  import
import * as React from 'react';
import { useEffect, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { createStructuredSelector } from 'reselect';
import { useInjectReducer, useInjectSaga } from '../../../redux/reduxInjectors';
import reducer from './reducer';
import saga from './saga';
import { makeSelectLoading } from './selectors';
import {
    Button, Card, Col, Collapse, DatePicker, Form, Input, InputNumber, Modal, notification, Row, Select, Switch,
    Table, Tag, Tooltip
} from 'antd';
import {
    CheckOutlined, CloseOutlined, DeleteOutlined, EditOutlined, FilePdfOutlined, LockOutlined,
    PlusOutlined, RedoOutlined, SearchOutlined, UnlockOutlined
} from '@ant-design/icons';
import moment from 'moment';
import ConstTypes, { confirmTypes } from './objectValues/ConstTypes';
import OrderByProperty from '../../../services/dto/orderByProperty';
import CardProduct from '../../../components/CardProduct';
declare var abp: any;
const { Panel } = Collapse;
const { Option } = Select;
const { RangePicker } = DatePicker;
//#endregion
export interface IMyProductStoreProps { // đây
    location: any;
}
const key = 'myproductstore';// đây
const stateSelector = createStructuredSelector < any, any> ({
    loading: makeSelectLoading()
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
export default function MyProductStore(props: IMyProductStoreProps) { // Đây

    //#region START
    useInjectReducer(key, reducer);
    useInjectSaga(key, saga);
    const dispatch = useDispatch();

    const {
        loading, pageSize, totalCount, pageIndex
    } = useSelector(stateSelector);
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
        }
    }
    //#endregion
    //#region SELECT COLUMN SEARCH
    const [SelectColumnSearch, setSelectColumnSearch] = useState < JSX.Element > (<Input placeholder="Từ khóa" />);

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
                    if (value === ConstTypes.CATE_PRO_PROATTR)
                        // return (optionCategoryProduct.map((province: CateProReadIdAndNameDto) => (
                        //     <Option value={province.id}>{province.name}</Option>
                        // )))
                        return (<Option value={'province.id'}>{'province.name'}</Option>);
                    if (value === ConstTypes.CREATEBY_PROATTR)
                        // return (optionCreateByCate.map((province: CateProReadIdAndNameDto) => (
                        //     <Option value={province.id}>{province.name}</Option>
                        // )))
                        return (<Option value={'province.id'}>{'province.name'}</Option>);
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
            render: (text: any) => (
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
       let data = [
          {
              "id": 1,
              "name": "GET",
              "description": "yêu cầu xem thông tin",
              "typesRsc": "URL",
              "isActive": true,
              "createdAt": "2022-02-10T03:10:02.5",
              "createBy": null,
              "updatedAt": "2022-02-10T03:10:02.5",
              "count": 0
          }];
    return (
        <>
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
                                    <Option value={ConstTypes.ID}>{ConstTypes.ID}</Option>
                                    <Option value={ConstTypes.NAME_PROATTR}>{ConstTypes.NAME_PROATTR}</Option>
                                    <Option value={ConstTypes.TYPES_PROATTR}>{ConstTypes.TYPES_PROATTR}</Option>
                                    <Option value={ConstTypes.CATE_PRO_PROATTR}>{ConstTypes.CATE_PRO_PROATTR}</Option>
                                    <Option value={ConstTypes.ISDELETE_PROATTR}>{ConstTypes.ISDELETE_PROATTR}</Option>
                                    <Option value={ConstTypes.CREATEBY_PROATTR}>{ConstTypes.CREATEBY_PROATTR}</Option>
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
                                    <Option value={ConstTypes.NAME_PROATTR}>{ConstTypes.NAME_PROATTR}</Option>
                                    <Option value={ConstTypes.TYPES_PROATTR}>{ConstTypes.TYPES_PROATTR}</Option>
                                    <Option value={ConstTypes.ISDELETE_PROATTR}>{ConstTypes.ISDELETE_PROATTR}</Option>
                                    <Option value={ConstTypes.CREATEBY_PROATTR}>{ConstTypes.CREATEBY_PROATTR}</Option>
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
                    <Col>
                    </Col>
                </Row >
                <Row style={{ margin: '10px 0' }}>
                    <Table
                        columns={columns}
                        rowKey={(record: any) => record.id}
                        dataSource={data}
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
            </Card>
        </>
    )
}
