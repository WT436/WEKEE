//#region  import
import {
  Button,
  Card,
  Cascader,
  Col,
  Divider,
  Form,
  Input,
  Row,
  Select,
  Table,
  Tag,
} from "antd";
import * as React from "react";
import { useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { createStructuredSelector } from "reselect";
import { useInjectReducer, useInjectSaga } from "../../../redux/reduxInjectors";
import { CategoryMapStart } from "../ACategory/actions";
import { CategoryProductReadDto } from "../ACategory/dtos/CategoryProductReadDto";
import {
  createSpecificationsStart,
  getNameClassifyValuesSpecificationsStart,
  searchSpecificationsStart,
} from "./actions";

import { SpecificationAttributeInsertDto } from "./dtos/SpecificationAttributeInsertDto";
import reducer from "./reducer";
import saga from "./saga";

import {
    makeSelectCategoryMapDtos,
  makeSelectClassifyValues,
  makeSelectLoading,
  makeSelectnameKey,
  makeSelectPageIndex,
  makeSelectPageSize,
  makeSelectSpecificationsCategoryDto,
  makeSelectTotalCount,
  makeSelectTotalPages,
} from "./selectors";

const { Option } = Select;

//#endregion
export interface IASpeciCateProps {
  location: any;
}
const key = "aspecicate";
const stateSelector = createStructuredSelector<any, any>({
  loading: makeSelectLoading(),
  pageIndex: makeSelectPageIndex(),
  pageSize: makeSelectPageSize(),
  totalCount: makeSelectTotalCount(),
  totalPages: makeSelectTotalPages(),
  optionsCategory: makeSelectCategoryMapDtos(),
  nameKey: makeSelectnameKey(),
  classifyValues: makeSelectClassifyValues(),
  specificationsCategoryDto: makeSelectSpecificationsCategoryDto(),
});

export default function ASpeciCate(props: IASpeciCateProps) {
  useInjectReducer(key, reducer);
  useInjectSaga(key, saga);
  const dispatch = useDispatch();

  const {
    loading,
    optionsCategory,
    nameKey,
    classifyValues,
    specificationsCategoryDto,
  } = useSelector(stateSelector);

  const [category, setCategory] = useState(0);
  const [keySpecifications, setKeySpecifications] = useState("");
  const [valuesSpecifications, setValuesSpecifications] = useState("");
  const [categorySpecifications, setCategorySpecifications] = useState("");

  useEffect(() => {
    dispatch(CategoryMapStart());
    //dispatch(getNameKeySpecificationsStart());
  }, []);

  const onFinish = (values: SpecificationAttributeInsertDto) => {
    values.CategoryProductId = category;
    console.log(values);
    dispatch(createSpecificationsStart(values));
  };

  const columns = [
    {
      title: "id",
      dataIndex: "id",
      key: "id",
      render: (text: any) => <a>{text}</a>,
    },
    {
      title: "key",
      dataIndex: "key",
      key: "key",
    },
    {
      title: "Tên hiển thị",
      dataIndex: "nameShow",
      key: "nameShow",
    },
    {
      title: "Phân loại",
      key: "classify",
      dataIndex: "classify",
    },
    {
      title: "Giá trị phân loại",
      key: "classifyValues",
      dataIndex: "classifyValues",
    },
    {
      title: "isEnabled",
      key: "isEnabled",
      dataIndex: "isEnabled",
      render: (text: boolean) =>
        text === true ? (
          <Tag color="#2db7f5">True</Tag>
        ) : (
          <Tag color="red">False</Tag>
        ),
    },
    {
      title: "Category",
      key: "categoryMain",
      dataIndex: "categoryMain",
    },
    {
      title: "Hành Động",
      key: "x",
      dataIndex: "x",
    },
  ];

  const rowSelection = {
    onChange: (
      selectedRowKeys: React.Key[],
      selectedRows: CategoryProductReadDto[]
    ) => {},
  };

  const displayRender = (value: any) => {
    setCategory(value[value.length - 1]);
    return value;
  };

  const keyChange = (value: any) => {
    setKeySpecifications(value);
    dispatch(getNameClassifyValuesSpecificationsStart(value));
  };

  const valuesChange = (value: any) => {
    setValuesSpecifications(value);
  };

  return (
    <>
      <Row>
        <Col span={24}>
          <Card
            title="Chỉnh sửa Dữ liệu"
            size="small"
            type="inner"
            loading={false}
          >
            <Form
              labelCol={{ span: 6 }}
              wrapperCol={{ span: 18 }}
              initialValues={{ isEnabled: false, classify: true }}
              onFinish={onFinish}
            >
              <Row>
                <Col span={12}>
                  <Form.Item
                    label="Từ khóa"
                    name="key"
                    key="key"
                    rules={[
                      { required: true, message: "Bạn cần nhập từ khóa!" },
                    ]}
                  >
                    <Input />
                  </Form.Item>
                </Col>

                <Col span={12}>
                  <Form.Item
                    label="Nhóm Key"
                    name="GroupSpecification"
                    key="GroupSpecification"
                  >
                    <Input />
                  </Form.Item>
                </Col>

                <Col span={18}>
                  <Form.Item
                    label="Category"
                    name="categoryMain"
                    key="categoryMain"
                    rules={[
                      {
                        required: true,
                        message: "Bạn cần chọn category đích!",
                      },
                    ]}
                  >
                    <Cascader
                      fieldNames={{
                        label: "nameCategory",
                        value: "id",
                        children: "items",
                      }}
                      expandTrigger="click"
                      options={optionsCategory}
                      onChange={displayRender}
                      changeOnSelect
                      placeholder="Please select category"
                    />
                  </Form.Item>
                </Col>

              </Row>
              <Form.Item wrapperCol={{ offset: 8, span: 24 }}>
                <Button
                  type="dashed"
                  style={{ margin: "0 20px" }}
                  htmlType="submit"
                >
                  Lưu
                </Button>
              </Form.Item>
            </Form>
          </Card>
        </Col>
      </Row>
      <Row>
        <Col span={24}>
          <Card
            title="Lọc thông số"
            size="small"
            type="inner"
            loading={loading}
          >
            <Row gutter={[5, 5]}>
              <Col span={6}>
                <Select
                  style={{ width: "100%" }}
                  onChange={keyChange}
                  placeholder="Key"
                  allowClear
                >
                  {nameKey.map((m: string) => (
                    <Option value={m}>{m}</Option>
                  ))}
                </Select>
              </Col>
              <Col span={6}>
                <Select
                  style={{ width: "100%" }}
                  onChange={valuesChange}
                  placeholder="Classify Values"
                  allowClear
                >
                  {classifyValues.map((m: string) => (
                    <Option value={m}>{m}</Option>
                  ))}
                </Select>
              </Col>
              <Col span={5}>
                <Button
                  onClick={() => {
                    dispatch(
                      searchSpecificationsStart(
                        keySpecifications,
                        valuesSpecifications
                      )
                    );
                  }}
                >
                  Tìm kiếm
                </Button>
                <Button style={{ margin: "0 5px" }}>All</Button>
                <Button>Clean</Button>
              </Col>
            </Row>
          </Card>
        </Col>
      </Row>
      <Row>
        <Col span={24}>
          <Card
            title={
              <>
                Hiển thị Chi tiết Bao gồm: Key :{" "}
                <Tag color="#2db7f5">{keySpecifications}</Tag>
                Values : <Tag color="#87d068">{valuesSpecifications}</Tag>
                Category : <Tag color="#108ee9">{categorySpecifications}</Tag>
              </>
            }
            size="small"
            type="inner"
            loading={loading}
          >
            <Table
              columns={columns}
              loading={loading}
              dataSource={specificationsCategoryDto}
              rowSelection={{
                type: "radio",
                ...rowSelection,
              }}
              pagination={false}
            />
          </Card>
        </Col>
      </Row>
    </>
  );
}
