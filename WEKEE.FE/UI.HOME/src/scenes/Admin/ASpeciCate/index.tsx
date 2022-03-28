//#region  import
import { Button, Card, Cascader, Col, Divider, Form, Input, Row, Select, Switch, Table, Tag } from 'antd'
import * as React from 'react';
import { useEffect, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { createStructuredSelector } from 'reselect';
import { useInjectReducer, useInjectSaga } from '../../../redux/reduxInjectors';
import { CategoryProductReadDto } from '../ACategory/dtos/CategoryProductReadDto';
import {
    createSpecificationsStart, getCategotyMainStart, getNameClassifyValuesSpecificationsStart,
    getNameKeySpecificationsStart, searchSpecificationsStart
} from './actions';
import { SpecificationsCategoryDto } from './dtos/specificationsCategoryDto';
import reducer from './reducer';
import saga from './saga';
import {
    makeSelectcategorySelectDto,
    makeSelectClassifyValues,
    makeSelectLoading, makeSelectnameKey, makeSelectPageIndex, makeSelectPageSize,
    makeSelectSpecificationsCategoryDto,
    makeSelectTotalCount, makeSelectTotalPages
} from './selectors';
const { Option } = Select;
//#endregion
export interface IASpeciCateProps {
    location: any;
}
const key = 'aspecicate';
const stateSelector = createStructuredSelector<any, any>({
    loading: makeSelectLoading(),
    pageIndex: makeSelectPageIndex(),
    pageSize: makeSelectPageSize(),
    totalCount: makeSelectTotalCount(),
    totalPages: makeSelectTotalPages(),
    categorySelectDto: makeSelectcategorySelectDto(),
    nameKey: makeSelectnameKey(),
    classifyValues: makeSelectClassifyValues(),
    specificationsCategoryDto: makeSelectSpecificationsCategoryDto()
});

function dropdownRender(menus: any) {
    return (
        <div>
            {menus}
            <Divider style={{ margin: 0 }} />
            <div style={{ padding: 8 }}>Lựa chọn danh mục sản phẩm của bạn!</div>
        </div>
    );
}
export default function ASpeciCate(props: IASpeciCateProps) {
    useInjectReducer(key, reducer);
    useInjectSaga(key, saga);
    const dispatch = useDispatch();

    const {
        loading,
        categorySelectDto, nameKey, classifyValues, specificationsCategoryDto
    } = useSelector(stateSelector);

    const [classifyClient, setClassifyClient] = useState(false);
    const [category, setCategory] = useState(0);
    const [keySpecifications, setKeySpecifications] = useState("");
    const [valuesSpecifications, setValuesSpecifications] = useState("");
    const [categorySpecifications, setCategorySpecifications] = useState("");

    useEffect(() => {
        dispatch(getCategotyMainStart());
        dispatch(getNameKeySpecificationsStart());
    }, []);

    const onFinish = (values: SpecificationsCategoryDto) => {
        values.categoryMain = category;
        dispatch(createSpecificationsStart(values));

    };

    const columns = [
        {
            title: 'id',
            dataIndex: 'id',
            key: 'id',
            render: (text: any) => <a>{text}</a>,
        },
        {
            title: 'key',
            dataIndex: 'key',
            key: 'key',
        },
        {
            title: 'Tên hiển thị',
            dataIndex: 'nameShow',
            key: 'nameShow',
        },
        {
            title: 'Phân loại',
            key: 'classify',
            dataIndex: 'classify'
        },
        {
            title: 'Giá trị phân loại',
            key: 'classifyValues',
            dataIndex: 'classifyValues'
        },
        {
            title: 'isEnabled',
            key: 'isEnabled',
            dataIndex: 'isEnabled',
            render: (text: boolean) => (text === true ? <Tag color="#2db7f5">True</Tag> : <Tag color="red">False</Tag>)
        },
        {
            title: 'Category',
            key: 'categoryMain',
            dataIndex: 'categoryMain'
        },
        {
            title: 'Hành Động',
            key: 'x',
            dataIndex: 'x'
        }
    ];

    const rowSelection = {
        onChange: (selectedRowKeys: React.Key[], selectedRows: CategoryProductReadDto[]) => {

        }
    };

    const displayRender = (value: any) => {
        setCategory(value[value.length - 1]);
        return value;
    }

    const keyChange = (value: any) => {
        setKeySpecifications(value)
        dispatch(getNameClassifyValuesSpecificationsStart(value));
    }

    const valuesChange = (value: any) => {
        setValuesSpecifications(value);
    }

    return (
        <>
            <Row>
                <Col span={24}>
                    <Card title='Chỉnh sửa Dữ liệu' size="small" type="inner" loading={false}>
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
                                        rules={[{ required: true, message: 'Bạn cần nhập từ khóa!' }]}
                                    >
                                        <Input />
                                    </Form.Item>
                                </Col>

                                <Col span={12}>
                                    <Form.Item
                                        label="Tên hiển thị"
                                        name="nameShow"
                                        key="nameShow"
                                        rules={[{ required: true, message: 'Bạn cần nhập tên hiển thị!' }]}
                                    >
                                        <Input />
                                    </Form.Item>
                                </Col>

                                <Col span={12}>
                                    <Form.Item
                                        label="Giá trị phân loại"
                                        name="classifyValues"
                                        key="classifyValues"
                                    >
                                        <Input disabled={classifyClient} />
                                    </Form.Item>
                                </Col>

                                <Col span={12}>
                                    <Form.Item
                                        label="Hiển thị"
                                        name="isEnabled"
                                        key="isEnabled"
                                        rules={[{ required: true, message: 'Bạn cần chọn dạng hiển thị!' }]}
                                    >
                                        <Switch
                                            checkedChildren="Kích hoạt"
                                            unCheckedChildren="Khóa"
                                            defaultChecked />
                                    </Form.Item>
                                </Col>

                                <Col span={6}>
                                    <Form.Item
                                        label="Thuộc tính"
                                        name="classify"
                                        key="classify"
                                        rules={[{ required: true, message: 'Bạn cần chọn dạng thuộc tính!' }]}
                                    >
                                        <Switch
                                            checkedChildren="Dạng thông số"
                                            unCheckedChildren="Dạng chi tiết"
                                            defaultChecked
                                            onChange={(value: any) => setClassifyClient(!value)}
                                        />
                                    </Form.Item>
                                </Col>

                                <Col span={18}>
                                    <Form.Item
                                        label="Category đích"
                                        name="categoryMain"
                                        key="categoryMain"
                                        rules={[{ required: true, message: 'Bạn cần chọn category đích!' }]}
                                    >
                                        <Cascader
                                            fieldNames={{
                                                label: 'nameCategory',
                                                value: 'id',
                                                children: 'items'
                                            }}
                                            expandTrigger='hover'
                                            options={categorySelectDto}
                                            dropdownRender={dropdownRender}
                                            onChange={displayRender}
                                            changeOnSelect
                                            placeholder="Please select category" />
                                    </Form.Item>
                                </Col>
                            </Row>
                            <Form.Item wrapperCol={{ offset: 8, span: 24 }}>
                                <Button
                                    type="dashed"
                                    style={{ margin: '0 20px' }}
                                    htmlType="submit"
                                >Tạo mới</Button>
                            </Form.Item>
                        </Form>
                    </Card>
                </Col>
            </Row>
            <Row>
                <Col span={24}>
                    <Card title='Lọc thông số' size="small" type="inner" loading={loading}>
                        <Row gutter={[5, 5]}>
                            <Col span={6}>
                                <Select
                                    style={{ width: '100%' }}
                                    onChange={keyChange}
                                    placeholder="Key"
                                    allowClear>
                                    {
                                        nameKey.map((m: string) => (
                                            <Option value={m}>{m}</Option>
                                        ))
                                    }
                                </Select>
                            </Col>
                            <Col span={6}>
                                <Select
                                    style={{ width: '100%' }}
                                    onChange={valuesChange}
                                    placeholder="Classify Values"
                                    allowClear>
                                    {
                                        classifyValues.map((m: string) => (
                                            <Option value={m}>{m}</Option>
                                        ))
                                    }
                                </Select>
                            </Col>
                            <Col span={5}>
                                <Button onClick={() => { dispatch(searchSpecificationsStart(keySpecifications, valuesSpecifications)) }}>Tìm kiếm</Button>
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
                                Hiển thị Chi tiết Bao gồm:
                                Key : <Tag color="#2db7f5">{keySpecifications}</Tag>
                                Values : <Tag color="#87d068">{valuesSpecifications}</Tag>
                                Category : <Tag color="#108ee9">{categorySpecifications}</Tag>
                            </>
                        }
                        size="small"
                        type="inner"
                        loading={loading}>
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
    )
}
