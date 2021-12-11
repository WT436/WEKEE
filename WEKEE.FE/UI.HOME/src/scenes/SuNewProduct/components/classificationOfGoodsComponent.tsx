import { DeleteOutlined, FormOutlined } from '@ant-design/icons';
import { Col, Form, Input, InputNumber, Modal, Row, Select, Space, Table, Tag } from 'antd'
import React, { useEffect, useState } from 'react'
import { useDispatch, useSelector } from 'react-redux';
import { createStructuredSelector } from 'reselect';
import { SpecificationsCategoryDto } from '../dtos/specificationsCategoryDto';
import { makeSelectLoading, makeSelectspecificationsCategoryDto } from '../selectors';
import { FeatureProductDtos } from '../dtos/featureProductDtos'
import { ImageProductDtos } from '../dtos/imageProductDtos';
const { Option } = Select;

interface IClassificationOfGoodsComponent {
    parentCallback: any
    image: ImageProductDtos[]
}
declare var abp: any;
const stateSelector = createStructuredSelector<any, any>({
    loading: makeSelectLoading(),
    specificationsCategoryDto: makeSelectspecificationsCategoryDto()
});

export default function ClassificationOfGoodsComponent(props: IClassificationOfGoodsComponent) {

    const dispatch = useDispatch();

    const {
        loading, specificationsCategoryDto
    } = useSelector(stateSelector);

    //useState
    const [showSpecifi, setshowSpecifi] = useState<{ key: string; nameShow: string; }[]>([]);
    const [selectSpecifi1, setselectSpecifi1] = useState('');
    const [selectValuesSpecifi1, setselectValuesSpecifi1] = useState(['']);
    const [useSelectValuesSpecifi1, setuseSelectValuesSpecifi1] = useState(['']);

    const [selectSpecifi2, setselectSpecifi2] = useState('');
    const [selectValuesSpecifi2, setselectValuesSpecifi2] = useState(['']);
    const [useSelectValuesSpecifi2, setuseSelectValuesSpecifi2] = useState(['']);

    const [Price, setPrice] = useState(0);
    const [priceMarket, setpriceMarket] = useState(0);
    const [mass, setmass] = useState(0);
    const [capacity, setcapacity] = useState(0);
    const [guarantee, setguarantee] = useState(0);
    const [totalNumber, settotalNumber] = useState(0)

    const [dataTable, setDataTable] = useState<FeatureProductDtos[]>([]);

    var dataTableitem: FeatureProductDtos = {
        id: 0,
        price: 0,
        priceMarket: 0,
        totalNumber: 0,
        key1: '',
        properties1: '',
        key2: '',
        properties2: '',
        vat: 0,
        mass: 0,
        volume: 0,
        guarantee: 0,
        image: ''
    };

    var dataTableitemRoot: FeatureProductDtos = {
        id: 0,
        price: 0,
        priceMarket: 0,
        totalNumber: 0,
        key1: '',
        properties1: '',
        key2: '',
        properties2: '',
        vat: 0,
        mass: 0,
        volume: 0,
        guarantee: 0,
        image: ''
    };

    //useEffect
    useEffect(() => {
        setshowSpecifi([]);
        specificationsCategoryDto.forEach((p: SpecificationsCategoryDto) => {
            if (p.classify === 1 && showSpecifi.findIndex(item => item.key === p.key) === -1) {
                showSpecifi.push({ key: p.key, nameShow: p.nameShow });
                setshowSpecifi([...showSpecifi]);
            }
        });
    }, [specificationsCategoryDto]);

    useEffect(() => {
        var data: FeatureProductDtos[] = [];
        setDataTable([]);
        useSelectValuesSpecifi1.map((x: string) => {
            if (useSelectValuesSpecifi2.length === 1 && useSelectValuesSpecifi2[0] === '') {
                data.push({
                    id: data.length,
                    price: Price,
                    priceMarket: priceMarket,
                    totalNumber: totalNumber,
                    key1: selectSpecifi1,
                    properties1: x,
                    key2: '',
                    properties2: '',
                    vat: 0,
                    mass: mass,
                    volume: capacity,
                    guarantee: guarantee,
                    image: ''
                });
            }
            else {
                useSelectValuesSpecifi2.map((y: string) => {
                    data.push({
                        id: data.length,
                        price: Price,
                        priceMarket: priceMarket,
                        totalNumber: totalNumber,
                        key1: selectSpecifi1,
                        properties1: x,
                        key2: selectSpecifi2,
                        properties2: y,
                        vat: 0,
                        mass: mass,
                        volume: capacity,
                        guarantee: guarantee,
                        image: ''
                    });
                });
            }
        })
        setDataTable(data);
    }, [useSelectValuesSpecifi1, useSelectValuesSpecifi2,
        Price, priceMarket, mass, capacity, guarantee, totalNumber]);

    const columns = [
        {
            title: 'Hành động',
            key: 'id',
            render: (text: FeatureProductDtos) => (
                <Space size="middle">
                    <DeleteOutlined style={{ cursor: 'pointer' }} onClick={() => setDataTable(dataTable.filter((item: any) => item !== text))} />
                    <FormOutlined
                        style={{ cursor: 'pointer' }}
                        onClick={() => {
                            dataTableitem = text;
                            dataTableitemRoot = text;
                            Modal.info({
                                title: 'Chỉnh sửa sản phẩm!',
                                width: "60%",
                                content: (
                                    <Row gutter={[10, 10]}>
                                        <Col span={12}>
                                            <Input
                                                addonBefore="Giá (₫)"
                                                defaultValue={text.price}
                                                type='number'
                                                min={0}
                                                onChange={(value: any) => { dataTableitem.price = parseInt(value.target.value) }} />
                                        </Col>
                                        <Col span={12}>
                                            <Input
                                                addonBefore="Giá thị trường (₫)"
                                                defaultValue={text.priceMarket}
                                                type='number'
                                                min={0}
                                                onChange={(value: any) => { dataTableitem.id = parseInt(value.target.value) }} />
                                        </Col>
                                        <Col span={12}>
                                            <Input
                                                addonBefore="Thuộc tính 1"
                                                disabled
                                                defaultValue={text.key1}
                                            />
                                        </Col>
                                        <Col span={12}>
                                            <Input
                                                addonBefore="Giá trị 1"
                                                disabled
                                                defaultValue={text.properties1}
                                            />
                                        </Col>
                                        <Col span={12}>
                                            <Input
                                                addonBefore="Thuộc tính 2"
                                                disabled
                                                defaultValue={text.key2}
                                            />
                                        </Col>
                                        <Col span={12}>
                                            <Input
                                                addonBefore="Giá trị 2"
                                                disabled
                                                defaultValue={text.properties2}
                                            />
                                        </Col>
                                        <Col span={12}>
                                            <Input
                                                addonBefore="Số lượng"
                                                defaultValue={text.totalNumber}
                                                type='number'
                                                min={0}
                                                onChange={(value: any) => { dataTableitem.totalNumber = value.target.value }} />
                                        </Col>
                                        <Col span={12}>
                                            <Input
                                                addonBefore="Khối lượng"
                                                defaultValue={text.mass}
                                                type='number'
                                                min={0}
                                                onChange={(value: any) => { dataTableitem.mass = value.target.value }} />
                                        </Col>
                                        <Col span={12}>
                                            <Input
                                                addonBefore="Thể tích"
                                                defaultValue={text.volume}
                                                type='number'
                                                min={0}
                                                onChange={(value: any) => { dataTableitem.volume = value.target.value }} />
                                        </Col>
                                        <Col span={12}>
                                            <Input
                                                addonBefore="Bảo Hành"
                                                defaultValue={text.guarantee}
                                                type='number'
                                                min={0}
                                                onChange={(value: any) => { dataTableitem.guarantee = value.target.value }} />
                                        </Col>
                                        <Col span={12}>
                                            <Select
                                                defaultValue={text.image === "" ? "_" : text.image}
                                                style={{ width: '100%' }}
                                                bordered={false}
                                                onChange={(value: any) => { dataTableitem.image = value }}
                                            >
                                                <Option key="0" value="_">Chọn Ảnh</Option>
                                                <Option key="1" disabled={(props.image[1].url === '')} value={props.image[1].url}>{!(props.image[1].url === '') ? <img style={{ width: 30, height: 30 }} src={abp.appServiceUrlStaticFile + '/' + props.image[1].url} alt="" /> : ""}  Ảnh 1</Option>
                                                <Option key="2" disabled={(props.image[2].url === '')} value={props.image[2].url}>{!(props.image[2].url === '') ? <img style={{ width: 30, height: 30 }} src={abp.appServiceUrlStaticFile + '/' + props.image[2].url} alt="" /> : ""}  Ảnh 2</Option>
                                                <Option key="3" disabled={(props.image[3].url === '')} value={props.image[3].url}>{!(props.image[3].url === '') ? <img style={{ width: 30, height: 30 }} src={abp.appServiceUrlStaticFile + '/' + props.image[3].url} alt="" /> : ""}  Ảnh 3</Option>
                                                <Option key="4" disabled={(props.image[4].url === '')} value={props.image[4].url}>{!(props.image[4].url === '') ? <img style={{ width: 30, height: 30 }} src={abp.appServiceUrlStaticFile + '/' + props.image[4].url} alt="" /> : ""}  Ảnh 4</Option>
                                                <Option key="5" disabled={(props.image[5].url === '')} value={props.image[5].url}>{!(props.image[5].url === '') ? <img style={{ width: 30, height: 30 }} src={abp.appServiceUrlStaticFile + '/' + props.image[5].url} alt="" /> : ""}  Ảnh 5</Option>
                                                <Option key="6" disabled={(props.image[6].url === '')} value={props.image[6].url}>{!(props.image[6].url === '') ? <img style={{ width: 30, height: 30 }} src={abp.appServiceUrlStaticFile + '/' + props.image[6].url} alt="" /> : ""}  Ảnh 6</Option>
                                                <Option key="7" disabled={(props.image[7].url === '')} value={props.image[7].url}>{!(props.image[7].url === '') ? <img style={{ width: 30, height: 30 }} src={abp.appServiceUrlStaticFile + '/' + props.image[7].url} alt="" /> : ""}  Ảnh 7</Option>
                                                <Option key="8" disabled={(props.image[8].url === '')} value={props.image[8].url}>{!(props.image[8].url === '') ? <img style={{ width: 30, height: 30 }} src={abp.appServiceUrlStaticFile + '/' + props.image[8].url} alt="" /> : ""}  Ảnh 8</Option>
                                            </Select >
                                        </Col>
                                    </Row>
                                ),
                                onOk: () => {
                                    var datai = dataTable.filter((item: any) => item !== dataTableitemRoot);
                                    setDataTable([])
                                    datai.push(dataTableitem);
                                    setDataTable(datai);
                                },
                                onCancel: () => { },
                            }
                            )
                        }
                        } />
                </Space>
            ),
        },
        {
            title: 'Giá',
            dataIndex: 'price',
            key: 'price'
        },
        {
            title: 'Giá thị trường',
            dataIndex: 'priceMarket',
            key: 'priceMarket',
        },
        {
            title: 'Tổng số lượng',
            dataIndex: 'totalNumber',
            key: 'totalNumber',
        },
        {
            title: 'Thuộc tính 1',
            dataIndex: 'properties1',
            key: 'properties1',
            render: (text: any) => (
                <Tag color="red">{text}</Tag>
            ),
        },
        {
            title: 'Thuộc tính 2',
            dataIndex: 'properties2',
            key: 'properties2',
            render: (text: any) => (
                <Tag color="blue">{text}</Tag>
            ),
        },
        {
            title: 'Ảnh',
            dataIndex: 'image',
            key: 'image',
            render: (text: any) => (
                <img style={{ width: 30, height: 30 }} src={abp.appServiceUrlStaticFile + '/' + text} alt="" />
            ),
        }
    ];

    useEffect(() => {
        props.parentCallback(dataTable);
    }, [dataTable])

    function tagRenderClassify1(props: { label: any; value: any; closable: any; onClose: any; }) {
        const { label, value, closable, onClose } = props;
        const onPreventMouseDown = (event: { preventDefault: () => void; stopPropagation: () => void; }) => {
            event.preventDefault();
            event.stopPropagation();
        };

        return (
            <Tag
                color={"blue"}
                onMouseDown={onPreventMouseDown}
                closable={closable}
                onClose={onClose}
                style={{ marginRight: 3 }}
            >
                {label}
            </Tag>
        );
    }

    const onSelectSpecifi1 = (value: string) => {
        setselectSpecifi1(value);
        setselectValuesSpecifi1([]);
        specificationsCategoryDto.map((m: SpecificationsCategoryDto) => {
            if (m.key === value) {
                selectValuesSpecifi1.push(m.classifyValues);
                setselectValuesSpecifi1([...selectValuesSpecifi1])
            }
        })
    }

    const onSelectSpecifi2 = (value: string) => {
        setselectSpecifi2(value);
        setselectValuesSpecifi2([]);
        specificationsCategoryDto.map((m: SpecificationsCategoryDto) => {
            if (m.key === value) {
                selectValuesSpecifi2.push(m.classifyValues);
                setselectValuesSpecifi2([...selectValuesSpecifi2])
            }
        })
    }

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
                            onChange={(value: number) => setPrice(value)}
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
                            onChange={(value: number) => setpriceMarket(value)}
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
                            onChange={(value: number) => setmass(value)}
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
                            onChange={(value: number) => setcapacity(value)}
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
                            onChange={(value: number) => setguarantee(value)}
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
                            onChange={(value: number) => settotalNumber(value)}
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
                    <Select onChange={onSelectSpecifi1} style={{ width: '30%' }}>
                        {
                            showSpecifi.map(m => (
                                <Option value={m.key}>{m.nameShow}</Option>
                            ))
                        }
                    </Select>
                    <Select
                        mode="multiple"
                        allowClear
                        onChange={(value: any) => {
                            if (value.length > 4) {
                                value.splice(0, 1);
                            }

                            setuseSelectValuesSpecifi1([]);
                            setuseSelectValuesSpecifi1(value)
                        }}
                        tagRender={tagRenderClassify1}
                        style={{ width: '100%' }}
                    >
                        {
                            selectValuesSpecifi1.map(m => (
                                <Option value={m}>{m}</Option>
                            ))
                        }
                    </Select>
                </Input.Group>
                <Input.Group className="lLwemSWham" compact>
                    <Select onChange={onSelectSpecifi2} style={{ width: '30%' }}>
                        {
                            showSpecifi.map(m => {
                                if (m.key !== selectSpecifi1) {
                                    return (
                                        <Option value={m.key}>{m.nameShow}</Option>)
                                }
                            }
                            )
                        }
                    </Select>
                    <Select
                        mode="multiple"
                        showArrow
                        allowClear
                        onChange={(value: any) => {
                            if (value.length > 4) {
                                value.splice(0, 1);
                            }
                            setuseSelectValuesSpecifi2([]);
                            setuseSelectValuesSpecifi2(value)
                        }}
                        tagRender={tagRenderClassify1}
                        style={{ width: '100%' }}
                    >
                        {
                            selectValuesSpecifi2.map(m => (
                                <Option value={m}>{m}</Option>
                            ))
                        }
                    </Select>
                </Input.Group>
            </Form.Item>

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
                    columns={columns}
                    dataSource={dataTable}
                    pagination={false} />
            </Form.Item>
        </>
    )
}
