import * as React from 'react'
import { useEffect } from 'react';
import { Checkbox, Form, Input, Modal } from 'antd';
import { L } from '../../../../lib/abpUtility';
import { createStructuredSelector } from 'reselect';
import { AuthenticationInput } from '../dtos/authenticationInput';
import { makeSelectLoading } from '../selectors';
import { useDispatch, useSelector } from 'react-redux';
import { loginRequestLoginStart, loginShowStart } from '../actions';
import { ExclamationCircleOutlined } from '@ant-design/icons';

declare var abp: any;

export interface IRegistrationFormProps {

};

const stateSelector = createStructuredSelector<any, any>({
    loading: makeSelectLoading()
});

export default function RegistrationComponent(props: IRegistrationFormProps) {

    const dispatch = useDispatch();

    const {
        loading
    } = useSelector(stateSelector);

    useEffect(() => {
        dispatch(loginShowStart());
    }, []);

    const onFinish = (values: AuthenticationInput) => {
        dispatch(loginRequestLoginStart(values));
    };
    
    function confirm() {
        Modal.confirm({
            title: 'Mã code xác nhận',
            icon: <ExclamationCircleOutlined />,
            content: <>
                <div>
                    <input className='DzwkfmNSxJ' type="text" />
                    <input className='DzwkfmNSxJ' type="text" />
                    <input className='DzwkfmNSxJ' type="text" />
                    <input className='DzwkfmNSxJ' type="text" />
                    <input className='DzwkfmNSxJ' type="text" />
                    <input className='DzwkfmNSxJ' type="text" />
                </div>
            </>,
            okText: 'Xác nhận',
            cancelText: 'Hủy bỏ',
        });
    }

    // facebook
    return (
        <div className="WBYuKwbWag">
            <img className="dXZSevIeue" src="https://localhost:44324/StaticFiles/login/image/facebook.png" alt="" />
            <div className="fFgTYwFwNM">Đăng Ký</div>
            <Form
                name="basic"
                initialValues={{ remember: true }}
                //onFinish={onFinish}
                labelCol={{ span: 6 }}
            >
                <Form.Item
                    label={L("Login.Account")}
                    name="Account"
                    rules={[{ required: true, message: 'Tài khoản không để trống!' }]}
                    className="LXSaSCCguB"
                >
                    <Input placeholder='Nhập tên tài khoản' />
                </Form.Item>

                <Form.Item
                    label={'Email'}
                    name="Account"
                    rules={[{ required: true, message: 'Tài khoản không để trống!' }]}
                    className="LXSaSCCguB"
                >
                    <Input placeholder='Email hoặc số điện thoại' />
                </Form.Item>

                <Form.Item
                    label={L("Login.Password")}
                    name="Password"
                    rules={[{ required: true, message: 'Mật khẩu không để trống!' }]}
                    className="LXSaSCCguB"
                >
                    <Input.Password />
                </Form.Item>

                <Form.Item
                    label={'Xác nhận'}
                    name="Password"
                    rules={[{ required: true, message: 'Mật khẩu không để trống!' }]}
                    className="LXSaSCCguB"
                >
                    <Input.Password />
                </Form.Item>

                <Form.Item
                    name="Remember"
                    valuePropName="checked"
                    className="gHirHByIww"
                >
                </Form.Item>

                <Form.Item className="grDQhEfohj">
                    <button onClick={confirm} className="vdnsCAmrtL" style={{ display: loading ? 'none' : 'block' }}>
                        <span></span>
                        <span></span>
                        <span></span>
                        <span></span>
                        {'Đăng ký'}
                    </button >
                </Form.Item>
            </Form>
        </div>
    )
}