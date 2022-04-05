//#region  import
import * as React from 'react';
import { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { createStructuredSelector } from 'reselect';
import { useInjectReducer, useInjectSaga } from '../../redux/reduxInjectors';
import { watchPageStart } from './actions';
import reducer from './reducer';
import saga from './saga';
import { makeSelectLoading } from './selectors';
import { Badge, Button, Checkbox, Col, Collapse, Dropdown, Form, Input, Menu, Row } from 'antd';
import { CaretRightOutlined, CheckOutlined, DesktopOutlined, EllipsisOutlined, LockOutlined, SettingOutlined, UserOutlined } from '@ant-design/icons';
declare var abp: any;
const { Panel } = Collapse;
//#endregion
export interface IBaseProps { // đây
    location: any;
}
const key = 'base';// đây
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
export default function Base(props: IBaseProps) { // Đây
    useInjectReducer(key, reducer);
    useInjectSaga(key, saga);

    const dispatch = useDispatch();
    const { loading } = useSelector(stateSelector);
    useEffect(() => {
        dispatch(watchPageStart());
    }, []);

    const text = `
    A dog is a type of domesticated animal.
    Known for its loyalty and faithfulness,
    it can be found as a welcome guest in many households across the world.
  `;

    //#region adsdasdasda 
    //   useInjectReducer(key, reducer);
    //   useInjectSaga(key, saga);

    //   const dispatch = useDispatch();

    //   const [checkCreate, setCheckCreate] = useState(false);
    //   const [checkRemove, setCheckRemove] = useState(true);
    //   const [checkRestart, setCheckRestart] = useState(true);
    //   const [isModalVisible, setisModalVisible] = useState(false);
    //   // 0 : bật tất cả 1: đang xóa, 2 đang update khóa/mở
    //   const [isDataChange, setisDataChange] = useState(0);
    //   const [SelectColumn, setSelectColumn] = useState(["All"]);
    //   const [valuesSearch, setvaluesSearch] = useState<string[]>([]);
    //   const [OrderbyColumn, setOrderbyColumn] = useState("");
    //   const [OrderbyTypes, setOrderbyTypes] = useState("");

    //   const {
    //       loading, pageSize, totalCount, pageIndex, dataRemoveAtomic
    //   } = useSelector(stateSelector);

    //   let data = [
    //       {
    //           "id": 1,
    //           "name": "GET",
    //           "description": "yêu cầu xem thông tin",
    //           "typesRsc": "URL",
    //           "isActive": true,
    //           "createdAt": "2022-02-10T03:10:02.5",
    //           "createBy": null,
    //           "updatedAt": "2022-02-10T03:10:02.5",
    //           "count": 0
    //       },
    //       {
    //           "id": 2,
    //           "name": "LIST",
    //           "description": "hiển danh sách hoặc thông tin chi tiết",
    //           "typesRsc": "URL",
    //           "isActive": true,
    //           "createdAt": "2022-02-10T03:10:02.5",
    //           "createBy": null,
    //           "updatedAt": "2022-02-10T03:10:02.5",
    //           "count": 0
    //       },
    //       {
    //           "id": 3,
    //           "name": "WATCH",
    //           "description": "chỉ cho phép xem và không chức năng sửa đổi",
    //           "typesRsc": "URL",
    //           "isActive": true,
    //           "createdAt": "2022-02-10T03:10:02.503",
    //           "createBy": null,
    //           "updatedAt": "2022-02-10T03:10:02.503",
    //           "count": 0
    //       },
    //       {
    //           "id": 4,
    //           "name": "UPDATE",
    //           "description": "chỉnh sửa thông tin nâng cao, như active ....",
    //           "typesRsc": "URL",
    //           "isActive": true,
    //           "createdAt": "2022-02-10T03:10:02.503",
    //           "createBy": null,
    //           "updatedAt": "2022-02-10T03:10:02.503",
    //           "count": 0
    //       },
    //       {
    //           "id": 5,
    //           "name": "CREATE",
    //           "description": "tạo bản ghi trên Database",
    //           "typesRsc": "URL",
    //           "isActive": true,
    //           "createdAt": "2022-02-10T03:10:02.503",
    //           "createBy": null,
    //           "updatedAt": "2022-02-10T03:10:02.503",
    //           "count": 0
    //       },
    //       {
    //           "id": 6,
    //           "name": "DELETE",
    //           "description": "active hoặc xóa bản ghi trên Database",
    //           "typesRsc": "URL",
    //           "isActive": true,
    //           "createdAt": "2022-02-10T03:10:02.503",
    //           "createBy": null,
    //           "updatedAt": "2022-02-10T03:10:02.503",
    //           "count": 0
    //       },
    //       {
    //           "id": 7,
    //           "name": "EDIT",
    //           "description": "chỉnh sửa thông tin căn bản",
    //           "typesRsc": "URL",
    //           "isActive": true,
    //           "createdAt": "2022-02-10T03:10:02.503",
    //           "createBy": null,
    //           "updatedAt": "2022-02-10T03:10:02.503",
    //           "count": 0
    //       }
    //   ];

    //   const [form] = Form.useForm();

    //   const onFill = (value: any) => {
    //       form.setFieldsValue(value);
    //   };

    //   const onRemove = (value: any) => {
    //       setisDataChange(1);
    //   };

    //   const onChangeIsStatus = (value: any) => {
    //       setisDataChange(2);
    //   };

    //   let onChange = (page: any, pageSize: any) => {

    //   };

    //   const onFinish = (values: any) => {
    //       if (values.id === undefined) {
    //       }
    //       else {
    //       }
    //   };

    //   const onReset = () => {
    //       setCheckCreate(false);
    //       form.resetFields();
    //   };

    //   const onGenderChange = (value: string) => {
    //       form.setFieldsValue({ types: value });
    //   };

    //   const columns = [
    //       {
    //           title: 'Id',
    //           dataIndex: 'id'
    //       },
    //       {
    //           title: 'Tên',
    //           dataIndex: 'name',
    //           sorter: {
    //               compare: (a: { name: string; }, b: { name: string; }) => a.name.length - b.name.length,
    //               multiple: 3,
    //           },
    //       },
    //       {
    //           title: 'Trạng thái',
    //           dataIndex: 'isActive',
    //           key: 'isActive',
    //           render: (text: boolean) => (text === true ? <Tag color="#2db7f5">True</Tag> : <Tag color="red">False</Tag>)
    //       },
    //       {
    //           title: 'Kiểu',
    //           dataIndex: 'typesRsc'
    //       },
    //       {
    //           title: 'Số lần sử dụng',
    //           dataIndex: 'count'
    //       },
    //       {
    //           title: 'Chi tiết',
    //           dataIndex: 'description'
    //       },
    //       {
    //           title: 'Người cập nhật',
    //           dataIndex: 'createBy'
    //       },
    //       {
    //           title: 'Thời gian cập nhật',
    //           dataIndex: 'updatedAt',
    //           render: (text: Date) => moment(text).format("DD/MM/YYYY hh:mm:ss.ms")
    //       },
    //       {
    //           title: 'Thời gian tạo',
    //           dataIndex: 'createdAt',
    //           render: (text: Date) => moment(text).format("DD/MM/YYYY hh:mm:ss.ms")
    //       },
    //       {
    //           title: 'Hành động',
    //           dataIndex: '',
    //           key: 'x',
    //           width: 120,
    //           render: (text: any) => (
    //               <div>
    //                   <Button type="link" icon={<EditOutlined />}
    //                       onClick={() => {
    //                           setisModalVisible(true)
    //                           setCheckCreate(true);
    //                           onFill(text);
    //                       }}></Button>
    //                   <Button type="link" disabled={!(isDataChange == 0 || isDataChange == 1)} icon={<DeleteOutlined />}
    //                       onClick={() => {
    //                           onRemove(text);
    //                       }}
    //                   ></Button>
    //                   {text.isActive ? <Button disabled={!(isDataChange == 0 || isDataChange == 2)} type="link" icon={<LockOutlined />}
    //                       onClick={() => onChangeIsStatus(text)}
    //                   ></Button> :
    //                       <Button disabled={!(isDataChange == 0 || isDataChange == 2)} type="link" icon={<UnlockOutlined />}
    //                           onClick={() => onChangeIsStatus(text)}
    //                       ></Button>}
    //               </div>
    //           )
    //       },
    //   ];

    //   return (
    //       <Card
    //           title="Lọc thông số"
    //           size="small"
    //           type="inner"
    //           loading={loading}
    //       >
    //           <Row gutter={[10, 10]}>
    //               <Col span={24}>
    //                   <Row gutter={[10, 10]} >
    //                       <Col span={2}>
    //                           <Tooltip placement="bottom" title={"Làm Mới"}>
    //                               <Button loading={loading}
    //                                   onClick={() => {
    //                                       setCheckRestart(true);
    //                                       setisDataChange(0);
    //                                       setSelectColumn(["All"]);
    //                                   }}
    //                                   disabled={checkRestart}
    //                                   block icon={<RedoOutlined />}>
    //                               </Button>
    //                           </Tooltip>
    //                       </Col>
    //                       <Col span={2}>
    //                           <Tooltip placement="bottom" title={"Lưu"}>
    //                               <Button loading={loading}
    //                                   disabled={checkRemove}
    //                                   block
    //                                   onClick={() => {
    //                                       setisDataChange(0);
    //                                   }}
    //                                   icon={<CheckOutlined />}>
    //                               </Button>
    //                           </Tooltip>
    //                       </Col>
    //                       <Col span={2}>
    //                           <Tooltip placement="bottom" title={"Hủy"}>
    //                               <Button loading={loading} disabled={checkRemove}
    //                                   onClick={() => {
    //                                       setisDataChange(0);
    //                                   }} block icon={<CloseOutlined />}>
    //                               </Button>
    //                           </Tooltip>
    //                       </Col>
    //                       <Col span={2}>
    //                           <Tooltip placement="bottom" title={"Xuất File"}>
    //                               <Button loading={loading} block icon={<FilePdfOutlined />}>
    //                               </Button>
    //                           </Tooltip>
    //                       </Col>
    //                       <Col span={2}>
    //                           <Tooltip placement="bottom" title={"Thêm"}>
    //                               <Button loading={loading} block icon={<PlusOutlined />}
    //                                   onClick={() => {
    //                                       setisModalVisible(true);
    //                                       form.resetFields();
    //                                   }}
    //                               >
    //                               </Button>
    //                           </Tooltip>
    //                       </Col>
    //                       <Col span={3}>
    //                           <Select
    //                               optionFilterProp="children"
    //                               style={{ width: '100%' }}
    //                               filterOption={(input, option: any) =>
    //                                   option.children.toLowerCase().indexOf(input.toLowerCase()) >= 0
    //                               }
    //                               disabled={loading}
    //                               defaultValue={SelectColumn}
    //                               onChange={(value: any) => {
    //                                   setSelectColumn([]);
    //                                   setSelectColumn(value);
    //                               }}
    //                           >
    //                               <Option value="All">Tìm kiếm</Option>
    //                               <Option value={ConstTypes.ID_SPEC}>{ConstTypes.ID_SPEC}</Option>
    //                               <Option value="Name">Tên</Option>
    //                               <Option value="TypesRsc">Kiểu</Option>
    //                               <Option value="Description">Chi tiết</Option>
    //                               <Option value="IsActive">Trạng thái</Option>
    //                               <Option value="CreatedAt">Ngày Tạo</Option>
    //                               <Option value="CreateBy">Người sửa</Option>
    //                               <Option value="UpdatedAt">Ngày cập nhật</Option>
    //                           </Select>
    //                       </Col>
    //                       <Col span={5}>
    //                           {console.log()}
    //                           {
    //                               SelectColumn.indexOf("CreatedAt") === 0 || SelectColumn.indexOf("UpdatedAt") === 0
    //                                   ? <RangePicker onChange={(date, dateString) => {
    //                                       setvaluesSearch([]);
    //                                       setvaluesSearch(dateString);
    //                                   }
    //                                   } />
    //                                   : <Input onChange={(value) => {
    //                                       setvaluesSearch([]);
    //                                       setvaluesSearch([value.target.value]);
    //                                   }} disabled={loading} placeholder="Từ khóa" />
    //                           }
    //                       </Col>
    //                       <Col span={3}>
    //                           <Select
    //                               optionFilterProp="children"
    //                               style={{ width: '100%' }}
    //                               filterOption={(input, option: any) =>
    //                                   option.children.toLowerCase().indexOf(input.toLowerCase()) >= 0
    //                               }
    //                               defaultValue={"All"}
    //                               disabled={loading}
    //                               onChange={(value) => {
    //                                   setOrderbyColumn(value.substring(0, value.lastIndexOf("_")));
    //                                   setOrderbyTypes(value.substring(value.lastIndexOf("_") + 1));
    //                               }}
    //                           >
    //                               <Option value="All">Sắp Xếp</Option>
    //                               <Option value="Id">Id</Option>
    //                               <Option value="Name">Tên</Option>
    //                               <Option value="TypesRsc">Kiểu</Option>
    //                               <Option value="Description">Chi tiết</Option>
    //                               <Option value="IsActive">Trạng thái</Option>
    //                               <Option value="CreatedAt">Ngày Tạo</Option>
    //                               <Option value="CreateBy">Người sửa</Option>
    //                               <Option value="UpdatedAt">Ngày cập nhật</Option>
    //                           </Select>
    //                       </Col>
    //                       <Col span={2}>
    //                           <Select
    //                               optionFilterProp="children"
    //                               style={{ width: '100%' }}
    //                               filterOption={(input, option: any) =>
    //                                   option.children.toLowerCase().indexOf(input.toLowerCase()) >= 0
    //                               }
    //                               disabled={loading}
    //                               defaultValue={SelectColumn}
    //                               onChange={(value: any) => {
    //                                   setSelectColumn([]);
    //                                   setSelectColumn(value);
    //                               }}
    //                           >
    //                               <Option value="All">Sắp Xếp</Option>
    //                               <Option value="Id">Tăng</Option>
    //                               <Option value="Name">Giảm</Option>
    //                           </Select>
    //                       </Col>
    //                       <Col span={1}>
    //                           <Button
    //                               disabled={loading}
    //                               type="primary"
    //                               icon={<SearchOutlined />}
    //                               onClick={() => {

    //                               }}
    //                           >
    //                           </Button>
    //                       </Col>
    //                   </Row>
    //               </Col>
    //               <Row style={{ margin: '10px 0' }}>
    //                   <Table
    //                       columns={columns}
    //                       rowKey={(record: any) => record.id}
    //                       dataSource={data}
    //                       loading={loading}
    //                       style={{ width: 'calc(100% - 10px)' }}
    //                       scroll={{ y: 350 }}
    //                       size='small'
    //                       pagination={{
    //                           pageSize: pageSize,
    //                           total: totalCount,
    //                           defaultCurrent: 1,
    //                           onChange: onChange,
    //                           showSizeChanger: true,
    //                           pageSizeOptions: ['5', '10', '20', '50', '100']
    //                       }}
    //                   />
    //               </Row>
    //               <Modal title="Thêm mới hoặc sửa Resource"
    //                   visible={isModalVisible}
    //                   onCancel={() => setisModalVisible(false)}
    //                   maskClosable={false}
    //                   style={{ top: 20 }}
    //                   footer={null}
    //               >
    //                   <Row style={{
    //                       fontSize: '16px', fontFamily: 'monospace',
    //                       margin: '10px 0', padding: '20px 10px',
    //                       borderTop: '3px solid #150799', borderRadius: '5px',
    //                   }}
    //                   >
    //                       <Form
    //                           name="basic"
    //                           labelCol={{ span: 8 }}
    //                           wrapperCol={{ span: 16 }}
    //                           initialValues={{ remember: true }}
    //                           form={form}
    //                           onFinish={onFinish}
    //                           style={{ width: '100%', textAlign: 'left' }}
    //                       >
    //                           <Form.Item
    //                               label="ID"
    //                               name="id"
    //                           >
    //                               <Input disabled />
    //                           </Form.Item>

    //                           <Form.Item
    //                               label="Method or Name..."
    //                               name="name"
    //                               rules={[{ required: true, message: 'Đường dẫn không được để trống!' }]}
    //                           >
    //                               <Input />
    //                           </Form.Item>
    //                           <Form.Item
    //                               label="Kiểu"
    //                               name="typesRsc"
    //                           >
    //                               <Select
    //                                   onChange={onGenderChange}
    //                                   allowClear
    //                                   style={{ width: '100%' }}
    //                                   defaultValue="_">
    //                                   <Option value="_">Chọn Kiểu dữ liệu</Option>
    //                                   <Option value="URL">URL</Option>
    //                               </Select>
    //                           </Form.Item>
    //                           <Form.Item
    //                               label="Chi Tiết"
    //                               name="description"
    //                               rules={[{ required: true, message: 'Please input your password!' }]}
    //                           >
    //                               <Input.TextArea />
    //                           </Form.Item>
    //                           <Form.Item name="isActive" label="Trạng Thái" valuePropName="checked">
    //                               <Switch />
    //                           </Form.Item>
    //                           <Form.Item
    //                               label="Ngày sửa :"
    //                               name="createdAt"
    //                           >
    //                               <Input disabled />
    //                           </Form.Item>
    //                           <Row gutter={[10, 10]}>
    //                               <Col span={6}><Button loading={loading} onClick={onReset} block icon={<RedoOutlined />}>Làm Mới</Button></Col>
    //                               <Col span={6}><Button loading={loading} hidden={!checkCreate} type="primary" htmlType="submit" block icon={<CheckOutlined />}>Lưu</Button></Col>
    //                               <Col span={6}><Button loading={loading} hidden={!checkCreate} onClick={onReset} block icon={<CloseOutlined />}>Hủy</Button></Col>
    //                               <Col span={6}><Button loading={loading} hidden={checkCreate} type="primary" htmlType="submit" block icon={<PlusOutlined />}>Tạo mới</Button></Col>
    //                           </Row>
    //                       </Form>
    //                   </Row>
    //               </Modal>
    //           </Row >
    //       </Card>
    //   );
    //#endregion
    
    return (
        <>
            Basse
        </>
    )
}
