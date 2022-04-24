//#region  import
import * as React from "react";
import { useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { createStructuredSelector } from "reselect";
import { useInjectReducer, useInjectSaga } from "../../../redux/reduxInjectors";
import reducer from "./reducer";
import saga from "./saga";
import { L } from '../../../lib/abpUtility';
import {
  makeCompleted, makeLoading, makePageIndex, makePageSize,
  makeTotalCount, makeTotalPages,
} from "./selectors";
import {
  Button, Card, Col, DatePicker, Form, Input, InputNumber, notification, Row,
  Select, Table, Tag, Tooltip,
} from "antd";
import {
  CloseOutlined, DeleteOutlined, EditOutlined, LockOutlined,
  PlusOutlined, RedoOutlined, SearchOutlined, UnlockOutlined,
} from "@ant-design/icons";
import OrderByProperty from "../../../services/dto/orderByProperty";
import moment from "moment";
import ConstTypesResource, { confirmTypesResource } from "./objectValues/ConstTypesResource";
import { ResourceReadDto } from "./dto/resourceReadDto";
import { getResourceStart } from "./actions";
declare var abp: any;
const { Option } = Select;
const { RangePicker } = DatePicker;
//#endregion
export interface IAPermissionProps {
  // đây
  location: any;
}

const key = "apermission"; // đây

const stateSelector = createStructuredSelector < any, any> ({
  loadingAll: makeLoading(),
  completedAll: makeCompleted(),
  pageIndex: makePageIndex(),
  pageSize: makePageSize(),
  totalCount: makeTotalCount(),
  totalPages: makeTotalPages(),
});

export default function APermission(props: IAPermissionProps) {

  //#region START
  useInjectReducer(key, reducer);
  useInjectSaga(key, saga);
  const dispatch = useDispatch();

  const { loadingAll, completedAll, pageSize, totalCount, pageIndex } =
    useSelector(stateSelector);
  
  useEffect(() => {
    dispatch(getResourceStart({ pageIndex: 1,
      pageSize: 20,
      propertyOrder: 0,
      valueOrderBy: 0,
      propertySearch: [0],
      valuesSearch: ["null"],}));
  }, [])
  
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
  const [orderbyColumn, setOrderbyColumn] = useState < number > (0);
  const [orderbyTypes, setOrderbyTypes] = useState < string > ("");
  //#endregion
  //#region SEARCH DADA ONCLICK BUTTON OR CHANGE PAGE
  const _searchDataOnClick = (page: any, pageSize: any) => {
    if (propertySearch.length !== valuesSearch.length) {
      notification.warning({
        message: "Thất Bại",
        description: "Bạn cần nhập dữ liệu tìm kiếm!",
        placement: "bottomRight",
      });
    } else {
    }
  };
  //#endregion
  //#region SELECT COLUMN SEARCH
  const [SelectColumnSearch, setSelectColumnSearch] = useState < JSX.Element > (
    <Input placeholder={L("KEYWORD",'COMMON')} disabled />
  );

  function _selectColumnSearch(value: number) {
    value === ConstTypesResource.NULL || value === 0
      ? setpropertySearch([])
      : setpropertySearch([value]);
    setvaluesSearch([]);
    if (confirmTypesResource(value) === "DATE") {
      setSelectColumnSearch(
        <RangePicker
          format="YYYY/MM/DD"
          onChange={(date, dateString) =>
            _onChangeDataColumnSearch(dateString[0] + "|" + dateString[1])
          }
        />
      );
    } else if (confirmTypesResource(value) === "SELECT") {
      setSelectColumnSearch(
        <Select
          showSearch
          placeholder={L("FILL",'COMMON')}
          optionFilterProp="children"
          style={{ width: "100%" }}
          onChange={(values: number) => _onChangeDataColumnSearch(values)}
        >
          {(() => {
            if (value === ConstTypesResource.CREATE_BY)
              // return (optionCategoryProduct.map((province: CateProReadIdAndNameDto) => (
              //     <Option value={province.id}>{province.name}</Option>
              // )))
              return <Option value={"province.id"}>{"province.name"}</Option>;
            if (value === ConstTypesResource.TYPES_RSC)
              // return (optionCreateByCate.map((province: CateProReadIdAndNameDto) => (
              //     <Option value={province.id}>{province.name}</Option>
              // )))
              return <Option value={"province.id"}>{"province.name"}</Option>;
            else {
              return (
                <>
                  <Option value={"province.id"}>{"province.name"}</Option>
                </>
              );
            }
          })()}
        </Select>
      );
    } else if (confirmTypesResource(value) === "BOOLEAN") {
      setSelectColumnSearch(
        <Select
          showSearch
          placeholder={L("FILL",'COMMON')}
          optionFilterProp="children"
          style={{ width: "100%" }}
          onChange={(values: number) => _onChangeDataColumnSearch(values)}
        >
          <Option value={1}>TRUE</Option>
          <Option value={0}>FALSE</Option>
        </Select>
      );
    } else if (confirmTypesResource(value) === "NUMBER") {
      setSelectColumnSearch(
        <InputNumber
          placeholder={L("KEYWORD",'COMMON')}
          style={{ width: "100%" }}
          formatter={(value) =>
            `${value} `.replace(/\B(?=(\d{3})+(?!\d))/g, ",")
          }
          defaultValue={0}
          onChange={_onChangeDataColumnSearch}
        />
      );
    } else if (confirmTypesResource(value) === "STRING") {
      setSelectColumnSearch(
        <Input
          placeholder={L("KEYWORD",'COMMON')}
          onChange={(values: any) =>
            _onChangeDataColumnSearch(values.target.value)
          }
        />
      );
    } else {
      setSelectColumnSearch(
        <Input
          placeholder={L("KEYWORD",'COMMON')}
          value={""}
          disabled={true}
        />
      );
    }
  }

  // khi cột value search thay đổi mà  key null  => xóa vaule
  const _onChangeDataColumnSearch = (value: any) => {
    if (propertySearch[0] === ConstTypesResource.NULL || value === 0) {
      setvaluesSearch([]);
    }
    setvaluesSearch([value]);
  };
  //#endregion

  //#region SELECT COLUMN ORDER

  function _selectColumnOrder(value: number) {
    console.log(value)
    if (value === 0) {
      setOrderbyColumn(0);
      setOrderbyTypes("");
    }
    setOrderbyColumn(value);
  }
  function _selectColumnOrderValue(value: any) {
    setOrderbyTypes(value);
  }
  //#endregion

  const [checkCreate, setCheckCreate] = useState(false);
  const [checkRemove, setCheckRemove] = useState(true);
  const [isModalVisible, setisModalVisible] = useState(false);

  //#region INSERT OR UPDATE FORM DATA
  const [form] = Form.useForm();

  const onFill = (value: any) => {
    form.setFieldsValue(value);
  };

  const onFinish = (values: any) => {
    if (values.types === -1 || values.types === undefined) {
      notification.warning({
        message: L("FAILURE",'COMMON'),
        description: L("INVALID_DATA_TYPE",'COMMON'),
        placement: "bottomRight",
      });
    } else {
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

  //#region TABLE
  const columns = [
    {
      title: L("NAME","CONST_TYPE_RESOURCE"),
      dataIndex: "name"
    },
    {
      title: "Trạng thái",
      dataIndex: "isDelete",
      key: "isDelete",
      render: (text: boolean) =>
        text === true ? (
          <Tag color="#2db7f5">True</Tag>
        ) : (
          <Tag color="red">False</Tag>
        ),
    },
    {
      title: "Kiểu",
      dataIndex: "typesName",
    },
    {
      title: "Category",
      dataIndex: "categoryProductIdName",
    },
    {
      title: "Người cập nhật",
      dataIndex: "createByName",
    },
    {
      title: "Thời gian cập nhật",
      dataIndex: "updatedOnUtc",
      render: (text: Date) => moment(text).format("DD/MM/YYYY hh:mm:ss.ms"),
    },
    {
      title: "Thời gian tạo",
      dataIndex: "createdOnUtc",
      render: (text: Date) => moment(text).format("DD/MM/YYYY hh:mm:ss.ms"),
    },
    {
      title: "Hành động",
      dataIndex: "",
      key: "x",
      width: 120,
      render: (text: any) => (
        <div>
          <Button type="link" icon={<EditOutlined />}
            onClick={() => {
              setisModalVisible(true);
              setCheckCreate(true);
              onFill(text);
            }}
          ></Button>
          <Button
            type="link"
            icon={<DeleteOutlined />}
          ></Button>
          {text.isDelete ? (
            <Button type="link" icon={<LockOutlined />}
            ></Button>
          ) : (
            <Button type="link" icon={<UnlockOutlined />}
            ></Button>
          )}
        </div>
      ),
    },
  ];

  const rowSelection = {
    onChange: (selectedRowKeys: React.Key[], selectedRows: ResourceReadDto[]) => {
      console.log(`selectedRowKeys: ${selectedRowKeys}`, 'selectedRows: ', selectedRows);
    },
    getCheckboxProps: (record: ResourceReadDto) => ({
      disabled: record.isActive === true,
      name: record.name,
    }),
  };
  //#endregion

  return (
    <>
      <Card title={L("CATEGORY PRODUCT SHOW HOME PAGE")} size="small" type="inner">
        <Row gutter={[10, 10]}>
          <Col span={24}>
            <Row gutter={[10, 10]}>
              <Col span={1}>
                <Tooltip placement="bottom" title={L("REFRESH",'COMMON')}>
                  <Button loading={loadingAll} block icon={<RedoOutlined />}  ></Button>
                </Tooltip>
              </Col>
              <Col span={1}>
                <Tooltip placement="bottom" title={L("DELETE",'COMMON')}>
                  <Button loading={loadingAll} disabled={checkRemove} block icon={<DeleteOutlined />}  ></Button>
                </Tooltip>
              </Col>
              <Col span={1}>
                <Tooltip placement="bottom" title={L("CANCEL",'COMMON')}>
                  <Button loading={loadingAll} disabled={checkRemove} block icon={<CloseOutlined />} ></Button>
                </Tooltip>
              </Col>
              <Col span={2}>
                <Tooltip placement="top" title={L("REPORT_FILE",'COMMON')}>
                  <Select style={{ width: '100%' }} placeholder={L("REPORT_FILE",'COMMON')}>
                    <Option value={1}>{L("EXCEL",'COMMON')}</Option>
                    <Option value={2}>{L("PDF",'COMMON')}</Option>
                    <Option value={3}>{L("ALL",'COMMON')}</Option>
                  </Select>
                </Tooltip>
              </Col>
              <Col span={1}>
                <Tooltip placement="bottom" title={L("ADD",'COMMON')}>
                  <Button loading={loadingAll} block icon={<PlusOutlined />}></Button>
                </Tooltip>
              </Col>
              <Col span={4}>
                <Select
                  optionFilterProp="children"
                  style={{ width: "100%" }}
                  disabled={loadingAll}
                  placeholder={L("SELECT",'COMMON')}
                  filterOption={(input, option: any) =>
                    option.children
                      .toLowerCase()
                      .indexOf(input.toLowerCase()) >= 0
                  }
                  onChange={(value: number) => {
                    _selectColumnSearch(value);
                  }}
                  value={
                    propertySearch[0] === "" ? undefined : propertySearch[0]
                  }
                >
                  {Object.keys(ConstTypesResource).map((key: any) => {
                    if (!isNaN(Number(key))) {
                      return (<Option value={key}>{L(ConstTypesResource[key],'CONST_TYPE_RESOURCE')}</Option>)
                    }
                  })}
                </Select>
              </Col>
              <Col span={6}>{SelectColumnSearch}</Col>
              <Col span={4}>
                <Select
                  optionFilterProp="children"
                  style={{ width: "100%" }}
                  filterOption={(input, option: any) =>
                    option.children
                      .toLowerCase()
                      .indexOf(input.toLowerCase()) >= 0
                  }
                  defaultValue={
                    orderbyColumn === 0 ? undefined : orderbyColumn
                  }
                  disabled={loadingAll}
                  placeholder={L("SORT",'COMMON')}
                  value={orderbyColumn === 0 ? undefined : orderbyColumn}
                  onChange={_selectColumnOrder}
                >
                  {Object.keys(ConstTypesResource).map((key: any) => {
                    if (!isNaN(Number(key))) {
                      return (<Option value={key}>{L(ConstTypesResource[key],'CONST_TYPE_RESOURCE')}</Option>)
                    }
                  })}
                </Select>
              </Col>
              <Col span={3}>
                <Select
                  optionFilterProp="children"
                  style={{ width: "100%" }}
                  filterOption={(input, option: any) =>
                    option.children
                      .toLowerCase()
                      .indexOf(input.toLowerCase()) >= 0
                  }
                  disabled={orderbyColumn === 0}
                  onChange={(value: any) => _selectColumnOrderValue(value)}
                  placeholder={L("BY",'COMMON')}
                  value={orderbyTypes === "" ? undefined : orderbyTypes}
                  defaultValue={orderbyTypes === "" ? undefined : orderbyTypes}
                >
                  {Object.keys(OrderByProperty).map((key: any) => {
                    if (!isNaN(Number(key))) {
                      return (<Option value={key}>{L(OrderByProperty[key],'COMMON')}</Option>)
                    }
                  })}
                </Select>
              </Col>
              <Col span={1}>
                <Tooltip placement="bottom" title={L("SEARCH_BUTTON",'COMMON')}>
                  <Button disabled={loadingAll} type="primary" icon={<SearchOutlined />}
                    onClick={() => _searchDataOnClick(0, 0)} ></Button>
                </Tooltip>
              </Col>
            </Row>
          </Col>
          <Col style={{ margin: '10px 0' }}>
            <Table
              columns={columns}
              //dataSource = {null}
              rowSelection={{
                type: "checkbox",
                ...rowSelection,
              }}
              rowKey={(record: ResourceReadDto) => record.id}
              loading={loadingAll}
              style={{ width: 'calc(100%)' }}
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
          </Col>
        </Row>
      </Card>
    </>
  );
}
