//#region  import
import {
    Affix, Alert, Button,
    Col, Collapse, Divider, Form, Input, InputNumber,
    Progress,
    Radio, Row, Select, Steps, Typography,
} from 'antd';
import * as React from 'react';
import { useEffect, useState } from 'react';
import { Helmet } from 'react-helmet';
import { useDispatch, useSelector } from 'react-redux';
import { createStructuredSelector } from 'reselect';
import { useInjectReducer, useInjectSaga } from '../../../redux/reduxInjectors';
import reducer from './reducer';
import saga from './saga';
import { makeSelectcategorySelectDto, makeSelectLoading, makeSelectproductDto } from './selectors';
import { CaretRightOutlined } from '@ant-design/icons';
import CategoryProductComponent from './components/categoryProductComponent';
import InfomationBasicComponent from './components/infomationBasicComponent';
import InfomationSalesComponent from './components/infomationSalesComponent';
import ClassificationOfGoodsComponent from './components/classificationOfGoodsComponent';
import { FeatureProductDtos } from './dtos/featureProductDtos';
import { ImageProductDtos } from './dtos/imageProductDtos';
import { CreateProductDtos } from './dtos/createProductDtos';
import { createProductsStart } from './actions';
const { Title, Text } = Typography;
const { Option } = Select;
const { Panel } = Collapse;
const { Step } = Steps;
//#endregion

export interface ISuNewProductProps {
    location: any;
}

const key = 'sunewproduct';
declare var abp: any;
var urlCss = abp.serviceAlbumCss;

const stateSelector = createStructuredSelector < any, any> ({
    loading: makeSelectLoading(),
    categorySelectDto: makeSelectcategorySelectDto(),
    productDto: makeSelectproductDto()
});

const formItemLayout = {
    labelCol: {
        xs: { span: 24 },
        sm: { span: 5 },
    },
    wrapperCol: {
        xs: { span: 24 },
        sm: { span: 24 },
    },
};
export default function SuNewProduct(props: ISuNewProductProps) {
    useInjectReducer(key, reducer);
    useInjectSaga(key, saga);

    const dispatch = useDispatch();

    const { featureProductDtos, productDto } = useSelector(stateSelector);

    const [openingCondition2, setOpeningCondition2] = useState(false);
    const [openingCondition3, setOpeningConditio3] = useState(false);
    const [openingCondition4, setOpeningCondition4] = useState(false);
    const [openingCondition5, setOpeningCondition5] = useState(false);
    const [openingCondition6, setOpeningCondition6] = useState(false);
    const [openingCondition7, setOpeningCondition7] = useState(false);

    const [container, setContainer] = useState < HTMLDivElement | null > (null);


    const [messageimage, setMessageImage] = useState < ImageProductDtos[] > ([]);

    const callbackFunctionImage = (childData: ImageProductDtos[]) => {
        setMessageImage(childData);
    }

    const [messagefeatureProduct, setMessagefeatureProduct] = useState < FeatureProductDtos[] > ([]);

    const callbackFunctionFeature = (childData: FeatureProductDtos[]) => {
        setMessagefeatureProduct(childData);
    }

    const [messageSpecifi, setMessageSpecifi] = useState < any > ([]);

    const callbackFunctionSpecifi = (childData: any) => {
        setMessageSpecifi(childData);
    }

    const createProduct = () => {
        var createProduct: CreateProductDtos = {
            featureProductDtos: messagefeatureProduct,
            highlightProductDtos: messageSpecifi,
            imageProductDtos: messageimage,
            productDto: productDto
        };
        dispatch(createProductsStart(createProduct));
    }

    return (
        <Row gutter={[30, 10]} ref={setContainer}>
            <Helmet>
                <title>Wekee.vn</title>
                <link rel="stylesheet" href={urlCss + "/newProduct.css"} />
                <link rel="stylesheet" href={urlCss + "/editor.css"} />
            </Helmet>
            <Col span={24}>
                <Row>
                    <Title className="RzCgNC58JZ" style={{ width: '100%' }} level={3}>Thêm 1 sản phẩm mới</Title>
                    <Text className="kdMal56HSK">Vui lòng chọn ngành hàng phù hợp cho sản phẩm của bạn.</Text>
                </Row>
                <Divider orientation="left"></Divider>
                <Steps size="small" progressDot={true} current={2}>
                    <Step title={<Progress type="circle" percent={80} width={30} />} />
                    <Step title="In Progress" />
                    <Step title="Waiting" />
                </Steps>
                <Divider orientation="left"></Divider>
                <Row>
                    <Form {...formItemLayout} style={{ width: '100%' }}>
                        <Collapse
                            accordion
                            defaultActiveKey={'1'}
                            //activeKey={state}
                            expandIcon={({ isActive }) => <CaretRightOutlined rotate={isActive ? 90 : 0} />}>
                            <Panel header="Danh Mục Sản Phẩm" key="1">
                                <CategoryProductComponent />
                            </Panel>
                            <Panel header="Thông tin Căn Bản" key="2" disabled={!openingCondition2}>
                                <InfomationBasicComponent parentCallback={callbackFunctionImage} />
                            </Panel>
                            <Panel header="Phân loại hàng hóa" key="3" disabled={!openingCondition3}>
                                <ClassificationOfGoodsComponent image={messageimage} parentCallback={callbackFunctionFeature} />
                            </Panel>
                            <Panel header="Thông tin bán hàng" key="4" disabled={!openingCondition4}>
                                <InfomationSalesComponent parentCallback={callbackFunctionSpecifi} />
                            </Panel>
                            <Panel header="Vận chuyển" key="5" disabled={!openingCondition5}>

                                <Form.Item
                                    name="Cân nặng (Sau khi đóng gói)"
                                    label="Cân Nặng"
                                    rules={[
                                        {
                                            required: true,
                                            message: 'Please input your name',
                                        },
                                    ]}
                                >
                                    <InputNumber style={{ width: "100%" }} prefix="₫" />
                                    <Input suffix="Gram" />
                                </Form.Item>

                                <Form.Item
                                    label="Kích thước đóng gói"
                                    name="Kích thước"
                                    rules={[
                                        {
                                            required: true,
                                            message: 'Please input your name',
                                        },
                                    ]}
                                >
                                    <InputNumber style={{ width: "100%" }} prefix="₫" />
                                    <Input.Group className="lLwemSWham" compact>
                                        <InputNumber style={{ width: "100%" }} placeholder="Dài" prefix="cm" />
                                        <InputNumber style={{ width: "100%" }} placeholder="Rộng" prefix="cm" />
                                        <InputNumber style={{ width: "100%" }} placeholder="Cao" prefix="cm" />
                                    </Input.Group>
                                </Form.Item>

                                <Form.Item
                                    name="Phí Vận Chuyển"
                                    label="Phí Vận Chuyển"
                                    rules={[
                                        {
                                            required: true,
                                            message: 'Please input your name',
                                        },
                                    ]}
                                >

                                    <Select defaultValue="lucy" style={{ width: 120 }} allowClear>
                                        <Option value="lucy">Lucy</Option>
                                    </Select>
                                </Form.Item>

                            </Panel>
                            <Panel header="Thông tin khác" key="6" disabled={!openingCondition6}>
                                <Form.Item
                                    name="username"
                                    label="Name"
                                    rules={[
                                        {
                                            required: true,
                                            message: 'Please input your name',
                                        },
                                    ]}
                                >
                                    <Radio.Group name="radiogroup" defaultValue={1}>
                                        <Radio value={1}>A</Radio>
                                        <Radio value={2}>B</Radio>
                                    </Radio.Group>
                                </Form.Item>

                                <Form.Item
                                    name="Tình trạng"
                                    label="Tình trạng"
                                    rules={[
                                        {
                                            required: true,
                                            message: 'Please input your name',
                                        },
                                    ]}
                                >
                                    <Select defaultValue="lucy" style={{ width: 120 }} allowClear>
                                        <Option value="lucy">Lucy</Option>
                                    </Select>
                                </Form.Item>

                                <Form.Item
                                    name="SKU sản phẩm"
                                    label="SKU sản phẩm"
                                    rules={[
                                        {
                                            required: true,
                                            message: 'Please input your name',
                                        },
                                    ]}
                                >
                                    <Input />
                                </Form.Item>
                            </Panel>
                        </Collapse>
                        <Form.Item style={{ margin: '10px 0', textAlign: "center" }}>
                            <Button danger className="vuejWOzNLH">Hủy</Button>
                            <Button
                                type='primary'
                                className="vuejWOzNLH"
                                onClick={() => createProduct()}>Lưu</Button>
                            <Button className="vuejWOzNLH">Hoàn thiện sau</Button>
                        </Form.Item>
                    </Form>
                </Row>
            </Col>
        </Row>
    )
}
