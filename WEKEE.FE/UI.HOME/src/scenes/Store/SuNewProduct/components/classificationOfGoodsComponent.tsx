import { PlusOutlined } from '@ant-design/icons';
import { Button, Col, Divider, Form, Input, InputNumber, Modal, Row, Select, Space, Table, Tag, Typography } from 'antd'
import React, { useEffect, useState } from 'react'
import { useDispatch, useSelector } from 'react-redux';
import { createStructuredSelector } from 'reselect';
import { makeSelectAttributeDto, makeSelectLoading, makeSelectspecificationsCategoryDto } from '../selectors';
import { ImageProductDtos } from '../dtos/imageProductDtos';
import { proAttrTypesUnitStart } from '../actions';
import { ProductAttributeReadTypesDto } from '../dtos/productAttributeReadTypesDto';
const { Option } = Select;

interface IClassificationOfGoodsComponent {
    parentCallback: any
    image: ImageProductDtos[]
}

declare var abp: any;
const stateSelector = createStructuredSelector < any, any> ({
    loading: makeSelectLoading(),
    attributeDto: makeSelectAttributeDto()
});

export default function ClassificationOfGoodsComponent(props: IClassificationOfGoodsComponent) {

    const dispatch = useDispatch();

    const {
        loading, attributeDto
    } = useSelector(stateSelector);

    //#region Loading  attribute
    useEffect(() => {
        dispatch(proAttrTypesUnitStart(0));
    }, []);
    //#endregion

    //#region Attribute Select
    useEffect(() => {
        setitemsDataAttribute(attributeDto);
    }, [attributeDto]);

    const [itemsDataAttribute, setitemsDataAttribute] = useState < ProductAttributeReadTypesDto[] > ([])
    const [itemsDataAttributeOne, setitemsDataAttributeOne] = useState < Number > ();
    const [itemsDataAttributeTwo, setitemsDataAttributeTwo] = useState < Number > ();
    const OnchangeDataAttribute = (value: any, num: number) => {
        // lưu trữ dữ liệu
        if (num === 1) {
            setitemsDataAttributeOne(value);
            // lấy dữ liệu 
        } else {
            setitemsDataAttributeTwo(value);
            // lấy dữ liệu 
        }
    }
    //#endregion

    //#region Attribute 1
    const [items, setItems] = useState(['jack', 'lucy']);
    const [name, setName] = useState('');

    const onNameChange = (event: { target: { value: React.SetStateAction<string>; }; }) => {
        setName(event.target.value);
    };

    const addItem = (e: { preventDefault: () => void; }) => {
        e.preventDefault();
        setItems([...items, name]);
        setName('');
    };

    //#endregion

    return (
        <>
            <Row gutter={[10, 10]} >
                <Col span={12}>
                    <Form.Item
                        name="Price"
                        label="Giá (₫)"
                        wrapperCol={{ span: 14 }}
                        labelCol={{ span: 9 }}
                        rules={[
                            {
                                required: true,
                                message: 'Nhập giá bán',
                            },
                        ]}
                    >
                        <InputNumber
                            style={{ width: "100%" }}
                            min={0}
                            formatter={value => `${value} `.replace(/\B(?=(\d{3})+(?!\d))/g, ',')}
                        />
                    </Form.Item>
                </Col>
                <Col span={12}>
                    <Form.Item
                        name="priceMarket"
                        label="Giá thị trường (₫)"
                        wrapperCol={{ span: 14 }}
                        labelCol={{ span: 9 }}
                        rules={[
                            {
                                required: true,
                                message: 'Nhập giá thị trường',
                            },
                        ]}
                    >
                        <InputNumber
                            style={{ width: "100%" }}
                            min={0}
                            formatter={value => `${value} `.replace(/\B(?=(\d{3})+(?!\d))/g, ',')}
                        />
                    </Form.Item>
                </Col>
                <Col span={12}>
                    <Form.Item
                        name="mass"
                        label="Khối lượng (gram)"
                        wrapperCol={{ span: 14 }}
                        labelCol={{ span: 9 }}
                        rules={[
                            {
                                required: true,
                                message: 'Nhập khối lượng',
                            },
                        ]}
                    >
                        <InputNumber
                            style={{ width: "100%" }}
                            min={0}
                            formatter={value => `${value} `.replace(/\B(?=(\d{3})+(?!\d))/g, ',')}
                        />
                    </Form.Item>
                </Col>
                <Col span={12}>
                    <Form.Item
                        name="volume"
                        label="Thể tích (cm3)"
                        wrapperCol={{ span: 14 }}
                        labelCol={{ span: 9 }}
                        rules={[
                            {
                                required: true,
                                message: 'Nhập thể tích',
                            },
                        ]}
                    >
                        <InputNumber
                            style={{ width: "100%" }}
                            min={0}
                            formatter={value => `${value} `.replace(/\B(?=(\d{3})+(?!\d))/g, ',')}
                        />
                    </Form.Item>
                </Col>
                <Col span={12}>
                    <Form.Item
                        name="guarantee"
                        label="Bảo hành (tháng)"
                        wrapperCol={{ span: 14 }}
                        labelCol={{ span: 9 }}
                        rules={[
                            {
                                required: true,
                                message: 'Nhập thời gian bảo hành',
                            },
                        ]}
                    >
                        <InputNumber
                            style={{ width: "100%" }}
                            min={0}
                        />
                    </Form.Item>
                </Col>
                <Col span={12}>
                    <Form.Item
                        name="totalNumber"
                        label="Số lượng"
                        key="totalNumber"
                        wrapperCol={{ span: 14 }}
                        labelCol={{ span: 9 }}
                        rules={[
                            {
                                required: true,
                                message: 'Vui lòng nhập số lượng',
                            },
                        ]}
                    >
                        <InputNumber
                            style={{ width: "100%" }}
                            min={0}
                            formatter={value => `${value} `.replace(/\B(?=(\d{3})+(?!\d))/g, ',')}
                        />
                    </Form.Item>
                </Col>

            </Row>

            <Form.Item
                label="Phân loại hàng"
                name="Phân loại hàng"
                labelAlign='left'
                wrapperCol={{ span: 24 }}
                labelCol={{ span: 24 }}
                rules={[
                    {
                        required: true,
                        message: 'Please input your name',
                    },
                ]}
            >
                <Input.Group className="lLwemSWham" compact>
                    <Select
                        showSearch
                        style={{ width: 200 }}
                        placeholder="Search to Select"
                        optionFilterProp="children"
                        onChange={(value: any) => OnchangeDataAttribute(value, 1)}
                    >
                        {itemsDataAttribute.map((item: ProductAttributeReadTypesDto) => (
                            <Option key={item.id}
                                disabled={item.id === itemsDataAttributeOne
                                    || item.id === itemsDataAttributeTwo}
                                value={item.id}>{item.name}</Option>
                        ))}
                    </Select>
                    <Select
                        style={{ width: 300 }}
                        placeholder="custom dropdown render"
                        mode="multiple"
                        dropdownRender={menu => (
                            <>
                                {menu}
                                <Divider style={{ margin: '8px 0' }} />
                                <Space align="center" style={{ padding: '0 8px 4px' }}>
                                    <Input placeholder="Please enter item" value={name} onChange={onNameChange} />
                                    <Typography.Link onClick={addItem} style={{ whiteSpace: 'nowrap' }}>
                                        <PlusOutlined /> Add item
                                    </Typography.Link>
                                </Space>
                            </>
                        )}
                    >
                        {items.map((item: string) => (
                            <Option key={item} value={item}>{item}</Option>
                        ))}
                    </Select>
                </Input.Group>

                <Input.Group className="lLwemSWham" compact>
                    <Select
                        showSearch
                        style={{ width: 200 }}
                        placeholder="Search to Select"
                        optionFilterProp="children"
                        onChange={(value: any) => OnchangeDataAttribute(value, 2)}
                    >
                        {itemsDataAttribute.map((item: ProductAttributeReadTypesDto) => (
                            <Option key={item.id}
                                disabled={item.id === itemsDataAttributeOne
                                    || item.id === itemsDataAttributeTwo}
                                value={item.id}>{item.name}</Option>
                        ))}
                    </Select>
                    <Select
                        style={{ width: 300 }}
                        placeholder="custom dropdown render"
                        mode="multiple"
                        dropdownRender={menu => (
                            <>
                                {menu}
                                <Divider style={{ margin: '8px 0' }} />
                                <Space align="center" style={{ padding: '0 8px 4px' }}>
                                    <Input placeholder="Please enter item" value={name} onChange={onNameChange} />
                                    <Typography.Link onClick={addItem} style={{ whiteSpace: 'nowrap' }}>
                                        <PlusOutlined /> Add item
                                    </Typography.Link>
                                </Space>
                            </>
                        )}
                    >
                        {items.map((item: string) => (
                            <Option key={item} value={item}>{item}</Option>
                        ))}
                    </Select>
                </Input.Group>
            </Form.Item>
            <div style={{ margin: '10px 0', textAlign: "center" }}>
                <Button
                    type='primary'
                    >Áp dụng tính năng phân loại hàng hóa</Button>
            </div>
            <Form.Item
                name="username"
                label="Bảng Thông số"
                labelAlign='left'
                wrapperCol={{ span: 24 }}
                labelCol={{ span: 24 }}
                rules={[
                    {
                        required: true,
                        message: 'Please input your name',
                    },
                ]}
            >
                <Table
                    rowKey={record => record.id}
                    size='small'
                    //columns={columns}
                    //dataSource={dataTable}
                    pagination={false} />
            </Form.Item>
        </>
    )
}
