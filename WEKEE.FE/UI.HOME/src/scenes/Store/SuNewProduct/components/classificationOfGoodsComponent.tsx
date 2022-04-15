import { DeleteOutlined, EditOutlined } from '@ant-design/icons';
import {
    Avatar, Button, Col, Dropdown, Form, Input, InputNumber, Menu, Modal,
    Row, Select, Space, Table
} from 'antd'
import React, { useEffect, useState } from 'react'
import { useDispatch, useSelector } from 'react-redux';
import { createStructuredSelector } from 'reselect';
import {
    makeSelectAttributeDto, makeSelectattributeValueOne, makeSelectattributeValueTwo,
    makeSelectLoading, makeSelectproductContainer
} from '../selectors';
import { ImageProductDtos } from '../dtos/imageProductDtos';
import {
    ContainerCreateProductStart, loadCategoryValueStart,
    proAttrTypesUnitStart
} from '../actions';
import { ProductAttributeReadTypesDto } from '../dtos/productAttributeReadTypesDto';
import { FeatureProductInsertDtos } from '../dtos/featureProductInsertDtos';
import { ProductAttributeValueReadDto } from '../dtos/productAttributeValueReadDto';
const { Option } = Select;

interface IClassificationOfGoodsComponent {
    parentCallback: any
    image: ImageProductDtos[]
}

declare var abp: any;
const stateSelector = createStructuredSelector < any, any> ({
    loading: makeSelectLoading(),
    attributeDto: makeSelectAttributeDto(),
    productContainer: makeSelectproductContainer(),
    attributeValueOne: makeSelectattributeValueOne(),
    attributeValueTwo: makeSelectattributeValueTwo(),
});

export default function ClassificationOfGoodsComponent(props: IClassificationOfGoodsComponent) {

    const dispatch = useDispatch();

    const {
        attributeDto, productContainer, attributeValueOne, attributeValueTwo
    } = useSelector(stateSelector);

    //#region Loading  attribute
    const _loadCategoryProductKey = () => {
        dispatch(proAttrTypesUnitStart(0, productContainer.categoryProduct.idCategory));
    }
    //#endregion

    //#region Render Table Attribute 
    const columns = [
        {
            title: 'id',
            dataIndex: 'id',
            key: 'id',

        },
        {
            title: 'weightAdjustment',
            dataIndex: 'weightAdjustment',
            key: 'weightAdjustment',
            render: (text: any) => <a>{text.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',')}</a>,
        },
        {
            title: 'lengthAdjustment',
            dataIndex: 'lengthAdjustment',
            key: 'lengthAdjustment',
            render: (text: any) => <a>{text.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',')}</a>,
        },
        {
            title: 'widthAdjustment',
            dataIndex: 'widthAdjustment',
            key: 'widthAdjustment',
            render: (text: any) => <a>{text.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',')}</a>,
        },
        {
            title: 'heightAdjustment',
            dataIndex: 'heightAdjustment',
            key: 'heightAdjustment',
            render: (text: any) => <a>{text.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',')}</a>,
        },
        {
            title: 'Thuộc tính 1',
            dataIndex: 'productAttributeValueInsertDtos',
            key: 'productAttributeValueInsertDtos',
            render: (text: any) => <a>{text[0] === undefined ? "X" : text[0].values}</a>,
        },
        {
            title: 'Thuộc tính 2',
            dataIndex: 'productAttributeValueInsertDtos',
            key: 'productAttributeValueInsertDtos',
            render: (text: any) => <a>{text[1] === undefined ? "X" : text[1].values}</a>,
        },
        {
            title: 'price',
            dataIndex: 'price',
            key: 'price',
            render: (text: any) => <a>{text.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',')}</a>,
        },
        {
            title: 'quantity',
            dataIndex: 'quantity',
            key: 'quantity',
            render: (text: any) => <a>{text.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',')}</a>,
        },
        {
            title: 'pictureString',
            dataIndex: 'pictureString',
            key: 'pictureString',
            render: (text: any) => <Avatar shape="square"
                src={abp.serviceAlbumImage + text}
                size={128} />,
        },
        {
            title: 'Action',
            key: 'action',
            render: (text: any) => (
                <Space size="middle">
                    <a onClick={() => showEditFeatureModal(text)}><EditOutlined /></a>
                    <a onClick={() => deleteItemFeature(text)}><DeleteOutlined /></a>
                </Space>
            ),
        },
    ];
    //#endregion
    //#region Onchange Input  
    const [PriceInput, setPriceInput] = useState < Number > ();
    const [weightInput, setweightInput] = useState < Number > ();
    const [lengthInput, setlengthInput] = useState < Number > ();
    const [widthInput, setwidthInput] = useState < Number > ();
    const [heightInput, setheightInput] = useState < Number > ();
    const [quantityInput, setquantityInput] = useState < Number > ();
    //#endregion
    //#region Attribute Select
    useEffect(() => {
        setitemsDataAttribute(attributeDto);
    }, [attributeDto]);

    const [itemsDataAttribute, setitemsDataAttribute] = useState < ProductAttributeReadTypesDto[] > ([])
    const [itemsDataAttributeOne, setitemsDataAttributeOne] = useState < number > ();
    const [itemsDataAttributeTwo, setitemsDataAttributeTwo] = useState < number > ();
    const OnchangeDataAttribute = (value: any, num: number) => {
        // lưu trữ dữ liệu
        if (num === 1) {
            setitemsDataAttributeOne(value);
            dispatch(loadCategoryValueStart(value, 1));
            // lấy dữ liệu 
        } else {
            setitemsDataAttributeTwo(value);
            dispatch(loadCategoryValueStart(value, 2));
            // lấy dữ liệu 
        }
    }
    //#endregion
    //#region Select Attribute
    const [DataSelectAttributeOne, setDataSelectAttributeOne] = useState < { key: number, value: string }[] > ([]);
    const OnSelectListAttributeOne = (key: any, values: any) => {
        values.forEach((element: any, index: number) => {
            values[index].key = parseInt(values[index].key);
        });

        setDataSelectAttributeOne(values);
    }

    const [DataSelectAttributeTwo, setDataSelectAttributeTwo] = useState < { key: number, value: string }[] > ([]);
    const OnSelectListAttributeTwo = (key: any, values: any) => {
        values.forEach((element: any, index: number) => {
            values[index].key = parseInt(values[index].key);
        });
        setDataSelectAttributeTwo(values);
    }
    //#endregion
    //#region Show Classifi
    var featureEnd: FeatureProductInsertDtos[] = [];
    const [FeatureEndTable, setFeatureEndTable] = useState < FeatureProductInsertDtos[] > ([]);
    const ShowClassify = () => {
        featureEnd = [];
        var disPlayOrder = 0;
        if (DataSelectAttributeOne.length === 0 && DataSelectAttributeTwo.length === 0) {
            featureEnd.push({
                id: disPlayOrder,
                productId: 0,
                weightAdjustment: weightInput ?? 0,
                lengthAdjustment: lengthInput ?? 0,
                widthAdjustment: widthInput ?? 0,
                heightAdjustment: heightInput ?? 0,
                price: PriceInput ?? 0,
                quantity: quantityInput ?? 0,
                displayOrder: 0,
                pictureString: '',
                mainProduct: false,
                productAttributeValueInsertDtos: []
            });
        }

        // var DataSelectAttributeMax: { key: number, value: string }[] = [];
        // var DataSelectAttributeMin: { key: number, value: string }[] = [];

        // if (DataSelectAttributeOne > DataSelectAttributeTwo) {
        //     DataSelectAttributeMax = DataSelectAttributeOne;
        //     DataSelectAttributeMin = DataSelectAttributeTwo;
        // }
        // else {
        //     DataSelectAttributeMax = DataSelectAttributeTwo;
        //     DataSelectAttributeMin = DataSelectAttributeOne;
        // }

        DataSelectAttributeOne.forEach(one => {
            if (DataSelectAttributeTwo.length === 0) {
                disPlayOrder++;
                featureEnd.push({
                    id: disPlayOrder,
                    productId: 0,
                    weightAdjustment: weightInput ?? 0,
                    lengthAdjustment: lengthInput ?? 0,
                    widthAdjustment: widthInput ?? 0,
                    heightAdjustment: heightInput ?? 0,
                    price: PriceInput ?? 0,
                    quantity: quantityInput ?? 0,
                    displayOrder: disPlayOrder,
                    pictureString: '',
                    mainProduct: false,
                    productAttributeValueInsertDtos: [{ key: itemsDataAttributeOne, values: one.value }]
                });
            }
            else {
                DataSelectAttributeTwo.forEach(two => {
                    disPlayOrder++;
                    featureEnd.push({
                        id: disPlayOrder,
                        productId: 0,
                        weightAdjustment: weightInput ?? 0,
                        lengthAdjustment: lengthInput ?? 0,
                        widthAdjustment: widthInput ?? 0,
                        heightAdjustment: heightInput ?? 0,
                        price: PriceInput ?? 0,
                        quantity: quantityInput ?? 0,
                        displayOrder: disPlayOrder,
                        pictureString: '',
                        mainProduct: false,
                        productAttributeValueInsertDtos:
                            [
                                { key: itemsDataAttributeOne, values: one.value }
                                , { key: itemsDataAttributeTwo, values: two.value }
                            ]
                    });
                });
            }
        });
        setFeatureEndTable(featureEnd);
    }

    const UpdateClassify = () => {
        productContainer.featureProductInsertDtos = FeatureEndTable;
        dispatch(ContainerCreateProductStart(productContainer));
    }
    //#endregion
    //#region Modal form Change Classifi Item
    const [formChangeClassif] = Form.useForm < FeatureProductInsertDtos > ();

    const [IsEditFeatureModal, setEditFeatureModal] = useState(false);

    const deleteItemFeature = (values: any) => {
        if (FeatureEndTable.length > 1) {
            var FeatureEndTable2 = FeatureEndTable.filter(m => m.id !== values.id);
            setFeatureEndTable(FeatureEndTable2);
        }
        else {
            setFeatureEndTable([]);
        }
    }

    const showEditFeatureModal = (value: any) => {
        setNoteChangeImageFeatureItem(undefined);
        formChangeClassif.setFieldsValue(value);
        setEditFeatureModal(true);
    };

    const handleEditFeatureCancel = () => {
        setEditFeatureModal(false);
    };

    const onFinish = (values: any) => {
        values.pictureString = NoteChangeImageFeatureItem;
        if (FeatureEndTable.length > 1) {
            var FeatureEndTable2 = FeatureEndTable.filter(m => m.id !== values.id);
            setFeatureEndTable([...FeatureEndTable2, values]);
        }
        else {
            setFeatureEndTable([]);
            setFeatureEndTable(FeatureEndTable => [...FeatureEndTable, values]);
        }
    };

    const [options, setoptions] = useState < { value: string, lable: string }[] > ([])
    useEffect(() => {
        setoptions([]);
        productContainer.imageRoot.forEach((m: string) => {
            setoptions(options => [...options, { value: m, lable: m }]);
        });
    }, [productContainer])

    const [NoteChangeImageFeatureItem, setNoteChangeImageFeatureItem] = useState < string > ();
    const ChangeImageFeatureItem = (value: string) => {
        setNoteChangeImageFeatureItem(value);
    }
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
                            onChange={(value) => setPriceInput(value)}
                            formatter={value => `${value} `.replace(/\B(?=(\d{3})+(?!\d))/g, ',')}
                        />
                    </Form.Item>
                </Col>
                <Col span={12}>
                    <Form.Item
                        name="weight"
                        label="weight (₫)"
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
                            onChange={(value) => setweightInput(value)}
                            formatter={value => `${value} `.replace(/\B(?=(\d{3})+(?!\d))/g, ',')}
                        />
                    </Form.Item>
                </Col>
                <Col span={12}>
                    <Form.Item
                        name="length"
                        label="length (gram)"
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
                            onChange={(value) => setlengthInput(value)}
                            formatter={value => `${value} `.replace(/\B(?=(\d{3})+(?!\d))/g, ',')}
                        />
                    </Form.Item>
                </Col>
                <Col span={12}>
                    <Form.Item
                        name="width"
                        label="width (cm3)"
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
                            onChange={(value) => setwidthInput(value)}
                            formatter={value => `${value} `.replace(/\B(?=(\d{3})+(?!\d))/g, ',')}
                        />
                    </Form.Item>
                </Col>
                <Col span={12}>
                    <Form.Item
                        name="height"
                        label="height (tháng)"
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
                            onChange={(value) => setheightInput(value)}
                            formatter={value => `${value} `.replace(/\B(?=(\d{3})+(?!\d))/g, ',')}
                        />
                    </Form.Item>
                </Col>
                <Col span={12}>
                    <Form.Item
                        name="quantity"
                        label="quantity"
                        key="quantity"
                        wrapperCol={{ span: 14 }}
                        labelCol={{ span: 9 }}
                        rules={[
                            {
                                required: true,
                                message: 'Vui lòng nhập quantity',
                            },
                        ]}
                    >
                        <InputNumber
                            style={{ width: "100%" }}
                            min={0}
                            onChange={(value) => setquantityInput(value)}
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
                        onClick={() => _loadCategoryProductKey()}
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
                        disabled={itemsDataAttributeOne === undefined}
                        onChange={OnSelectListAttributeOne}
                        onClick={() => _loadCategoryProductKey()}
                    >
                        {attributeValueOne.map((item: ProductAttributeValueReadDto) => (
                            <Option key={item.id} value={item.values}>{item.values}</Option>
                        ))}
                    </Select>
                </Input.Group>

                <Input.Group className="lLwemSWham" compact>
                    <Select
                        showSearch
                        style={{ width: 200 }}
                        placeholder="Search to Select"
                        optionFilterProp="children"
                        disabled={DataSelectAttributeOne.length === 0}
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
                        disabled={itemsDataAttributeTwo === undefined}
                        onChange={OnSelectListAttributeTwo}
                    >
                        {attributeValueTwo.map((item: ProductAttributeValueReadDto) => (
                            <Option key={item.id} value={item.values}>{item.values}</Option>
                        ))}
                    </Select>
                </Input.Group>
            </Form.Item>

            <div style={{ margin: '10px 0', textAlign: "center" }}>
                <Button
                    type='primary'
                    style={{ margin: '0 10px ', textAlign: "center" }}
                    onClick={() => ShowClassify()}
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
                    rowKey={record => record.displayOrder.toString()}
                    size='small'
                    columns={columns}
                    dataSource={FeatureEndTable}
                    pagination={false} />

                <div style={{ margin: '10px 0', textAlign: "center" }}>
                    <Button
                        type='default'
                        style={{ margin: '0 10px ', textAlign: "center" }}
                        onClick={() => UpdateClassify()}
                    >Cập nhật tính năng phân loại hàng hóa</Button>
                </div>
            </Form.Item>

            <Modal title="Chỉnh sửa phân loại hàng hóa"
                visible={IsEditFeatureModal}
                onCancel={handleEditFeatureCancel}
                footer={null}>
                <Form
                    name="basic"
                    labelCol={{ span: 8 }}
                    wrapperCol={{ span: 16 }}
                    initialValues={{ remember: true }}
                    onFinish={onFinish}
                    autoComplete="off"
                    form={formChangeClassif}
                    className="aHCCGsdD"
                >
                    <Form.Item
                        label="weightAdjustment"
                        name="weightAdjustment"
                    >
                        <InputNumber formatter={value => `${value} `.replace(/\B(?=(\d{3})+(?!\d))/g, ',')} />
                    </Form.Item>
                    <Form.Item
                        label="lengthAdjustment"
                        name="lengthAdjustment"
                    >
                        <InputNumber formatter={value => `${value} `.replace(/\B(?=(\d{3})+(?!\d))/g, ',')} />
                    </Form.Item>
                    <Form.Item
                        label="widthAdjustment"
                        name="widthAdjustment"
                    >
                        <InputNumber formatter={value => `${value} `.replace(/\B(?=(\d{3})+(?!\d))/g, ',')} />
                    </Form.Item>
                    <Form.Item
                        label="heightAdjustment"
                        name="heightAdjustment"
                    >
                        <InputNumber formatter={value => `${value} `.replace(/\B(?=(\d{3})+(?!\d))/g, ',')} />
                    </Form.Item>
                    <Form.Item
                        label="price"
                        name="price"
                    >
                        <InputNumber formatter={value => `${value} `.replace(/\B(?=(\d{3})+(?!\d))/g, ',')} />
                    </Form.Item>
                    <Form.Item
                        label="quantity"
                        name="quantity"
                    >
                        <InputNumber formatter={value => `${value} `.replace(/\B(?=(\d{3})+(?!\d))/g, ',')} />
                    </Form.Item>
                    <Form.Item
                        label="displayOrder"
                        name="displayOrder"
                        hidden
                    >
                        <Input />
                    </Form.Item>
                    <Form.Item
                        label="pictureString"
                        name="pictureString"
                    >
                        <Dropdown
                            //onChange={onChangepictureString}
                            overlay={
                                <Menu className='GHUigtDF'>
                                    {
                                        productContainer.imageRoot
                                            .map((m: any) =>
                                                <Menu.Item key={m}
                                                    onClick={() => ChangeImageFeatureItem(m)}
                                                >
                                                    <Avatar shape="square"
                                                        src={abp.serviceAlbumImage + m}
                                                        size={128} />
                                                </Menu.Item>)
                                    }
                                </Menu>
                            }
                            trigger={['click']}>
                            <div
                                className="site-dropdown-context-menu"
                                style={{
                                    textAlign: 'center',
                                    width: '120px',
                                    height: '120px',
                                    lineHeight: '120px',
                                    border: '1px solid #bababa',
                                    borderRadius: '5px'
                                }}
                            >
                                {NoteChangeImageFeatureItem === undefined
                                    ? "Right Click on here"
                                    : <Avatar shape="square"
                                        src={abp.serviceAlbumImage + NoteChangeImageFeatureItem}
                                        size={128} />}
                            </div>
                        </Dropdown>
                    </Form.Item>
                    <Form.Item
                        label="productAttributeValueInsertDtos"
                        name="productAttributeValueInsertDtos"
                        hidden
                    >
                    </Form.Item>
                    <Form.Item
                        label="id"
                        name="id"
                        hidden
                    >
                    </Form.Item>
                    <Form.Item wrapperCol={{ offset: 8, span: 16 }}>
                        <Button type="primary" htmlType="submit">
                            Submit
                        </Button>
                    </Form.Item>
                </Form>
            </Modal>
        </>
    )
}
