import * as React from 'react'
import { useEffect } from 'react';
import { Checkbox, Form, Input } from 'antd';
import { L } from '../../../lib/abpUtility';
import { createStructuredSelector } from 'reselect';
import { AuthenticationInput } from '../dtos/authenticationInput';
import { makeSelectLoading } from '../selectors';
import { useDispatch, useSelector } from 'react-redux';
import { loginRequestLoginStart, loginShowStart } from '../actions';

declare var abp: any;

export interface IForgotPasswordFormProps {

};

const stateSelector = createStructuredSelector<any, any>({
    loading: makeSelectLoading()
});

export default function ForgotPasswordComponent(props: IForgotPasswordFormProps) {

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
    // facebook
    return (
        <div className="WBYuKwbWag">
            <img className="dXZSevIeue" src="https://localhost:44324/StaticFiles/login/image/facebook.png" alt="" />
            <div className="fFgTYwFwNM">Lấy lại mật khẩu</div>
            <Form
                name="basic"
                initialValues={{ remember: true }}
                onFinish={onFinish}
                labelCol={{ span: 6 }}
            >
                <Form.Item
                    label={L("Login.Account")}
                    name="Account"
                    rules={[{ required: true, message: 'Tài khoản không để trống!' }]}
                    className="LXSaSCCguB"
                >
                    <Input type='text' placeholder='Nhập tên tài khoản' />
                </Form.Item>

                <Form.Item
                    label={'Email'}
                    name="Email"
                    rules={[{ required: true, message: 'Email không để trống!' }]}
                    className="LXSaSCCguB"
                >
                    <Input placeholder='Nhập tên email hoặc số điện thoại' />
                </Form.Item>

                <Form.Item
                    name="Remember"
                    valuePropName="checked"
                    className="gHirHByIww"
                >
                    
                </Form.Item>

                <Form.Item className="grDQhEfohj">
                    <button className="vdnsCAmrtL" style={{ display: loading ? 'none' : 'block' }}>
                        <span></span>
                        <span></span>
                        <span></span>
                        <span></span>
                        {'Lấy mật khẩu'}
                    </button >
                </Form.Item>
                <div className="tCvhCAhEGu">
                    <div>
                        {L("Login.NotAccount")}
                        &ensp;<a href='/register-an-account'>{L("Login.Registration")}</a>
                    </div>
                    <a href='/login'>Đăng nhập</a>
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