import * as React from 'react'
import { useEffect } from 'react';
import { Checkbox, Form, Input, Modal } from 'antd';
import { L } from '../../../../lib/abpUtility';
import { createStructuredSelector } from 'reselect';
import { AuthenticationInput } from '../dtos/authenticationInput';
import { makeSelectLoading } from '../selectors';
import { useDispatch, useSelector } from 'react-redux';
import { loginRequestLoginStart } from '../actions';
import { ExclamationCircleOutlined } from '@ant-design/icons';

const key = 'login';

export interface IChangePasswordFormProps {

};
const stateSelector = createStructuredSelector<any, any>({
    loading: makeSelectLoading()
});
export default function ChangePasswordComponent(props: IChangePasswordFormProps) {
    const dispatch = useDispatch();

    const {
        loading
    } = useSelector(stateSelector);

    const onFinish = (values: AuthenticationInput) => {
        confirm();
    };


    function confirm() {
        Modal.confirm({
            title: 'Thay Đổi mật khẩu',
            icon: <ExclamationCircleOutlined />,
            content: <>
                <Form
                    name="basic"
                    initialValues={{ remember: true }}
                    onFinish={onFinish}
                    labelCol={{ span: 6 }}
                >

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
                </Form>
            </>,
            okText: 'Xác nhận',
            cancelText: 'Hủy bỏ',
        });
    }

    // facebook
    return (
        <div className="WBYuKwbWag">
            <img className="dXZSevIeue" src="https://localhost:44324/StaticFiles/login/image/facebook.png" alt="" />
            <div className="fFgTYwFwNM">Thay đổi mật khẩu</div>
            <Form
                name="basic"
                initialValues={{ remember: true }}
                onFinish={onFinish}
            >
                <Form.Item
                    label={L("Login.Account")}
                    name="Account"
                    rules={[{ required: true, message: 'Tài khoản không để trống!' }]}
                    className="LXSaSCCguB"
                >
                    <Input />
                </Form.Item>
                <Form.Item
                    rules={[{ required: true, message: 'Tài khoản không để trống!' }]}
                    className="LXSaSCCguB"
                    style={{ textAlign: 'center', marginBottom: '10px' }}
                >
                    <input className='DzwkfmNSxJ' type="text" />
                    <input className='DzwkfmNSxJ' type="text" />
                    <input className='DzwkfmNSxJ' type="text" />
                    <input className='DzwkfmNSxJ' type="text" />
                    <input className='DzwkfmNSxJ' type="text" />
                    <input className='DzwkfmNSxJ' type="text" />
                </Form.Item>
                <Form.Item className="grDQhEfohj">
                    <button className="vdnsCAmrtL" style={{ display: loading ? 'none' : 'block' }}>
                        <span></span>
                        <span></span>
                        <span></span>
                        <span></span>
                        {L("Login.Login")}
                    </button >
                </Form.Item>
                <div className="tCvhCAhEGu">
                    <div>
                        {L("Login.NotAccount")}
                        &ensp;<a href=''>{L("Login.Registration")}</a>
                    </div>
                    <a href=''>{L("Login.ForgotPassword")}</a>
                </div>
                <div className="gofuVBTQrx">
                    <span>Hoặc</span>
                    <img title={L("Login.LoginWithFacebook")} src='https://localhost:44324/StaticFiles/login/image/facebook.png' />
                    <img title={L("Login.LoginWithYoutube")} src='https://localhost:44324/StaticFiles/login/image/google.png' />
                    <img title={L("Login.LoginWithZalo")} src='https://localhost:44324/StaticFiles/login/image/zalo.png' />
                </div>
            </Form>
        </div>
    )
}