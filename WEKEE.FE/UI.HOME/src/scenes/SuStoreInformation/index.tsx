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
import { Button, Checkbox, Col, Collapse, Form, Input, Row } from 'antd';
import { CaretRightOutlined, LockOutlined, UserOutlined } from '@ant-design/icons';

const { Panel } = Collapse;
//#endregion
export interface ISuStoreInformationProps {
    location: any;
}
const key = 'uhome';
const stateSelector = createStructuredSelector<any, any>({
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
export default function SuStoreInformation(props: ISuStoreInformationProps) {
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
    return (
        <>
            <Collapse
                bordered={false}
                defaultActiveKey={['1']}
                expandIcon={({ isActive }) => <CaretRightOutlined rotate={isActive ? 90 : 0} />}
                className="site-collapse-custom-collapse"
            >
                <Panel header="Thông tin căn bản" key="1" className="site-collapse-custom-panel">
                    <Form
                        {...formItemLayout}
                        name="normal_login"
                        className="login-form"
                        initialValues={{ remember: true }}
                    >
                        <Row gutter={[10, 10]}>
                            <Col span={8}>
                                <Form.Item
                                    name="username"
                                    label="Tên đầy đủ"
                                    rules={[{ required: true, message: 'Please input your Username!' }]}
                                >
                                    <Input />
                                </Form.Item>
                            </Col>
                            <Col span={8}>
                                <Form.Item
                                    name="username"
                                    label="Số Điện thoại shop"
                                    rules={[{ required: true, message: 'Please input your Username!' }]}
                                >
                                    <Input type="number" />
                                </Form.Item>
                            </Col>
                            <Col span={8}>
                                <Form.Item
                                    name="username"
                                    label="Email Shop"
                                    rules={[{ required: true, message: 'Please input your Username!' }]}
                                >
                                    <Input type="email" />
                                </Form.Item>
                            </Col>
                            <Col span={8}>
                                <Form.Item
                                    name="username"
                                    label="Password Shop Cũ"
                                    rules={[{ required: true, message: 'Please input your Username!' }]}
                                >
                                    <Input.Password />
                                </Form.Item>
                            </Col>
                            <Col span={8}>
                                <Form.Item
                                    name="username"
                                    label="Password Shop Mới"
                                    rules={[{ required: true, message: 'Please input your Username!' }]}
                                >
                                    <Input.Password />
                                </Form.Item>
                            </Col>
                            <Col span={8}>
                                <Form.Item
                                    name="username"
                                    label="Website của tôi"
                                    rules={[{ required: true, message: 'Please input your Username!' }]}
                                >
                                    <Input />
                                </Form.Item>
                            </Col>
                            <Col span={8}>
                                <Form.Item
                                    name="username"
                                    label="Địa chỉ chính"
                                    rules={[{ required: true, message: 'Please input your Username!' }]}
                                >
                                    <Input />
                                </Form.Item>
                            </Col>
                            <Col span={8}>
                                <Form.Item
                                    name="remember"
                                    valuePropName="checked"
                                    noStyle
                                >
                                    <Checkbox>Trạng thái hoạt động</Checkbox>
                                </Form.Item>
                            </Col>
                            <Col span={8}>
                                <Form.Item
                                    name="username"
                                    label="Tài khoản Lập Shop"
                                >
                                    <Input disabled placeholder="Username" />
                                </Form.Item>
                            </Col>
                            <Col span={24} style={{ textAlign: "center" }}>
                                <Form.Item>
                                    <Button type="primary" htmlType="submit" style={{ width: '100px' }} className="login-form-button">
                                        Cập Nhật
                                    </Button>
                                </Form.Item>
                            </Col>
                        </Row>
                    </Form>
                </Panel>
                <Panel header="Thông tin giấy tờ" key="2" className="site-collapse-custom-panel">
                    <p>{text}</p>
                </Panel>
                <Panel header="This is panel header 3" key="3" className="site-collapse-custom-panel">
                    <p>{text}</p>
                </Panel>
            </Collapse>
        </>
    )
}
