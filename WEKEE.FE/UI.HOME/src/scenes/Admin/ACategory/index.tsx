//#region  import
import {
  CheckOutlined,
  CloseOutlined,
  DeleteOutlined,
  EditOutlined,
  FilePdfOutlined,
  HomeOutlined,
  LoadingOutlined,
  LockOutlined,
  PartitionOutlined,
  PlusOutlined,
  RedoOutlined,
  SearchOutlined,
  UnlockOutlined,
} from "@ant-design/icons";
import {
  Avatar,
  Breadcrumb,
  Button,
  Card,
  Cascader,
  Checkbox,
  Col,
  DatePicker,
  Form,
  Input,
  InputNumber,
  message,
  Modal,
  Row,
  Image,
  Select,
  Table,
  Tag,
  Typography,
  Upload,
} from "antd";
import * as React from "react";
import { useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { createStructuredSelector } from "reselect";
import { useInjectReducer, useInjectSaga } from "../../../redux/reduxInjectors";
import {
  CategoryMapStart,
  createCategoryAdminStart,
  getCategoryAdminStart,
} from "./actions";
import { CategoryProductInsertDto } from "./dtos/CategoryProductInsertDto";
import { CategoryProductReadDto } from "./dtos/CategoryProductReadDto";
import ConstTypes from "./dtos/constDto";
import reducer from "./reducer";
import saga from "./saga";
import {
  makeSelectLoading,
  makeSelectPageIndex,
  makeSelectPageSize,
  makeSelectTotalCount,
  makeSelectTotalPages,
  makeSelectCategoryDtos,
  makeSelectCategoryMapDtos,
} from "./selectors";
const { Text } = Typography;
const { Option } = Select;
const { RangePicker } = DatePicker;
//#endregion

declare var abp: any;
export interface IACategoryProps {
  location: any;
}
const key = "acategory";
const stateSelector = createStructuredSelector<any, any>({
  loading: makeSelectLoading(),
  pageIndex: makeSelectPageIndex(),
  pageSize: makeSelectPageSize(),
  totalCount: makeSelectTotalCount(),
  totalPages: makeSelectTotalPages(),
  categoryDtos: makeSelectCategoryDtos(),
  optionsCategory: makeSelectCategoryMapDtos(),
});

function beforeUpload(file: any) {
  const isJpgOrPng = file.type === "image/jpeg" || file.type === "image/png";
  if (!isJpgOrPng) {
    message.error("Bạn cần upload file JPG/PNG!");
  }
  const isLt2M = file.size / 1024 < 100;
  if (!isLt2M) {
    message.error("Ảnh không được phép lớn hơn 100kb!");
  }
  return isJpgOrPng && isLt2M;
}

export default function ACategory(props: IACategoryProps) {
  useInjectReducer(key, reducer);
  useInjectSaga(key, saga);
  const dispatch = useDispatch();

  const {
    loading,
    pageIndex,
    pageSize,
    totalCount,
    categoryDtos,
    optionsCategory,
  } = useSelector(stateSelector);

  const [loadingImage, setLoadingImage] = React.useState(false);
  const [imageUrl, setImageUrl] = React.useState("");
  const [idCategoryRoot, setIdCategoryRoot] = React.useState(false);
  const [mainCategoryState, setMainCategoryState] = useState(0);

  useEffect(() => {
    // read data for cascader
    dispatch(CategoryMapStart());
    // load data table
    dispatch(
      getCategoryAdminStart({
        pageIndex: 1,
        pageSize: 20,
        propertyOrder: "",
        valueOrderBy: "",
        propertySearch: [ConstTypes.MAIN_CATEGORY],
        valuesSearch: ["null"],
      })
    );
  }, []);

  const formFile = (info: any) => {
    if (info.file.status === "uploading") {
      setLoadingImage(true);
      return;
    }
    if (info.file.status === "done") {
      // Get this url from response in real world.
      setImageUrl(info.file.response.url.toString());
      console.log(imageUrl);
      setLoadingImage(false);
      return info.file.response.url.toString();
    }
  };

  const uploadButton = (
    <div>
      {loadingImage ? <LoadingOutlined /> : <PlusOutlined />}
      <div style={{ marginTop: 8 }}>Upload</div>
    </div>
  );

  const onFinish = (values: CategoryProductInsertDto) => {
    values.iconCategory = imageUrl;
    values.categoryMain = mainCategoryState;
    values.isEnabled = true;
    console.log(values);
    dispatch(createCategoryAdminStart(values));
  };

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
      render: (text: string)=>(
      <Avatar src={<Image src={abp.serviceAlbumImage + text} style={{ width: 32 }} />} />)
    },
    {
      title: "Cấp độ",
      dataIndex: "levelCategory",
      key: "levelCategory",
    },
    {
      title: "Category chủ",
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
      title: "Hành động",
      dataIndex: "",
      key: "x",
      width: 120,
      render: (text: any) => (
        <div>
          <Button
            type="link"
            icon={<EditOutlined />}
            title="Sửa"
            onClick={() => {}}
          ></Button>
          &nbsp;
          <Button
            type="link"
            icon={<DeleteOutlined />}
            title="Xóa"
            onClick={() => {}}
          ></Button>
          {text.isActive ? (
            <Button
              type="link"
              icon={<LockOutlined />}
              onClick={() => {}}
              title="Khóa"
            ></Button>
          ) : (
            <Button
              type="link"
              icon={<UnlockOutlined />}
              onClick={() => {}}
              title="Mở"
            ></Button>
          )}
        </div>
      ),
    },
  ];
  //#endregion

  //#region  Cascader
  let onChangeCascader = (value: any) => {
    setMainCategoryState(value.length == 0 ? 0 : value[value.length - 1]);
    dispatch(
      getCategoryAdminStart({
        pageIndex: 1,
        pageSize: 20,
        propertyOrder: "",
        valueOrderBy: "",
        propertySearch: [ConstTypes.MAIN_CATEGORY],
        valuesSearch: value.length == 0 ? ["null"] : [value[value.length - 1]],
      })
    );
  };
  //#endregion

  //#region  Modal
  const [isModalVisible, setIsModalVisible] = useState(false);

  const showModal = () => {
    setIsModalVisible(true);
  };

  const handleOk = () => {
    setIsModalVisible(false);
  };

  const handleCancel = () => {
    setIsModalVisible(false);
  };

  //#endregion

  return (
    <>
      <Row gutter={[20, 10]}>
        <Col span={24}>
          <Card
            title="Lựa chọn Danh Mục"
            size="small"
            type="inner"
            loading={loading}
          >
            <Cascader
              fieldNames={{
                label: "nameCategory",
                value: "id",
                children: "items",
              }}
              options={optionsCategory}
              style={{ width: "100%" }}
              onChange={onChangeCascader}
              changeOnSelect
            />
          </Card>
        </Col>
        <Col span={24}>
          <Row gutter={[10, 10]}>
            <Col span={3}>
              <Button
                loading={loading}
                onClick={() => {}}
                block
                icon={<RedoOutlined />}
              >
                Làm Mới
              </Button>
            </Col>
            <Col span={2}>
              <Button
                loading={loading}
                block
                onClick={() => {}}
                icon={<CheckOutlined />}
              >
                Lưu
              </Button>
            </Col>
            <Col span={2}>
              <Button
                loading={loading}
                onClick={() => {}}
                block
                icon={<CloseOutlined />}
              >
                Hủy
              </Button>
            </Col>
            <Col span={3}>
              <Button loading={loading} block icon={<FilePdfOutlined />}>
                Xuất File
              </Button>
            </Col>
            <Col span={3}>
              <Button
                loading={loading}
                block
                icon={<PlusOutlined />}
                onClick={showModal}
              >
                Thêm
              </Button>
            </Col>
            <Col span={4}>
              {console.log()}
              {true || 0 === 0 ? (
                <RangePicker onChange={(date, dateString) => {}} />
              ) : (
                <Input
                  onChange={(value) => {}}
                  disabled={loading}
                  placeholder="Từ khóa"
                />
              )}
            </Col>
            <Col span={3}>
              <Select
                optionFilterProp="children"
                style={{ width: "100%" }}
                filterOption={(input: any, option: any) =>
                  option.children.toLowerCase().indexOf(input.toLowerCase()) >=
                  0
                }
                disabled={loading}
                onChange={(value: any) => {}}
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
                style={{ width: "100%" }}
                filterOption={(input, option: any) =>
                  option.children.toLowerCase().indexOf(input.toLowerCase()) >=
                  0
                }
                defaultValue={"All"}
                disabled={loading}
                onChange={(value) => {}}
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
                onClick={() => {}}
              ></Button>
            </Col>
          </Row>
          <Card
            title='Danh mục của : ""'
            size="small"
            type="inner"
            style={{ marginTop: "10px" }}
            loading={loading}
          >
            <Table columns={columns} dataSource={categoryDtos} />
          </Card>
        </Col>
      </Row>
      <Modal
        title="Category"
        closable={true}
        mask={true}
        maskClosable={false}
        visible={isModalVisible}
        footer={null}
        onCancel={()=> setIsModalVisible(false)}
      >
        <Form
          labelCol={{ span: 10 }}
          wrapperCol={{ span: 14 }}
          initialValues={{ isEnabled: true }}
          onFinish={onFinish}
        >
          <Row>
            <Col span={24}>
              <Form.Item
                name="nameCategory"
                label="Tên Danh Mục"
                rules={[
                  {
                    required: true,
                    message: "Tên danh mục không được để trống!",
                  },
                ]}
              >
                <Input />
              </Form.Item>
            </Col>
            <Col span={24}>
              <Form.Item
                name="urlCategory"
                label="Đường dẫn"
                rules={[
                  {
                    required: true,
                    message: "Đường dẫn danh mục không được để trống!",
                  },
                ]}
              >
                <Input />
              </Form.Item>
            </Col>
            <Col span={24}>
              <Form.Item
                name="iconCategory"
                label="Icon Danh Mục"
                getValueFromEvent={formFile}
              >
                <Upload
                  name="file"
                  listType="picture-card"
                  className="avatar-uploader"
                  showUploadList={false}
                  action={abp.serviceAlbumAPI + "upload-icon"}
                  method="POST"
                  beforeUpload={beforeUpload}
                >
                  {imageUrl ? (
                    <img
                      src={abp.serviceAlbumImage + imageUrl}
                      alt="avatar"
                      style={{ width: "100%" }}
                    />
                  ) : (
                    uploadButton
                  )}
                </Upload>
              </Form.Item>
              <Form.Item wrapperCol={{ offset: 8, span: 16 }}>
                <Button type="primary" htmlType="submit">
                  Submit
                </Button>
              </Form.Item>
            </Col>
          </Row>
        </Form>
      </Modal>
    </>
  );
}
