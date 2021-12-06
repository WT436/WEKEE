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
export interface ILoginFormProps {
};

const stateSelector = createStructuredSelector<any, any>({
    loading: makeSelectLoading()
});

export default function LoginComponent(props: ILoginFormProps) {

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
            <div className="fFgTYwFwNM">Đăng Nhập</div>
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
                    label={L("Login.Password")}
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
                    <Checkbox checked={true}>{L("Login.Remember")}</Checkbox>
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