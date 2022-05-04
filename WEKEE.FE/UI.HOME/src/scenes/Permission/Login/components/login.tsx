import * as React from 'react'
import { useEffect } from 'react';
import { Checkbox, Form, Input } from 'antd';
import { L } from '../../../../lib/abpUtility';
import { createStructuredSelector } from 'reselect';
import { AuthenticationInput } from '../dtos/authenticationInput';
import { makeSelectLoading } from '../selectors';
import { useDispatch, useSelector } from 'react-redux';
import { loginRequestLoginStart } from '../actions';

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

    const onFinish = (values: AuthenticationInput) => {
        dispatch(loginRequestLoginStart(values));
    };
    // facebook
    return (
        <div className="WBYuKwbWag">
            <img className="dXZSevIeue" src="https://localhost:44327/album-resources/album/imageSystem/facebook.png" alt="" />
            <div className="fFgTYwFwNM">Đăng Nhập</div>
            <Form
                name="basic"
                initialValues={{ remember: true }}
                onFinish={onFinish}
            >
                <Form.Item
                    label={L("USER_NAME","LOGIN")}
                    name="userName"
                    rules={[{ required: true, message: 'Tài khoản không để trống!' }]}
                    className="LXSaSCCguB"
                >
                    <Input />
                </Form.Item>

                <Form.Item
                    label={L("PASSWORD","LOGIN")}
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
                    <Checkbox checked={true}>{L("REMEMBER","LOGIN")}</Checkbox>
                </Form.Item>

                <Form.Item className="grDQhEfohj">
                    <button className="vdnsCAmrtL" style={{ display: loading ? 'none' : 'block' }}>
                        <span></span>
                        <span></span>
                        <span></span>
                        <span></span>
                        {L("LOGIN","LOGIN")}
                    </button >
                </Form.Item>
                <div className="tCvhCAhEGu">
                    <div>
                        {L("NOT_ACCOUNT","LOGIN")}
                        &ensp;<a href='/register-account'>{L("REGISTRATION","LOGIN")}</a>
                    </div>
                    <a href=''>{L("FORGOT_PASWORD","LOGIN")}</a>
                </div>
                <div className="gofuVBTQrx">
                    <span>Hoặc</span>
                    <img title={L("LOGIN_WITH_FACEBOOK","LOGIN")} src='https://localhost:44327/album-resources/album/imageSystem/facebook.png' />
                    <img title={L("LOGIN_WITH_GOOGLE","LOGIN")} src='https://localhost:44327/album-resources/album/imageSystem/google.png' />
                    <img title={L("LOGIN_WITH_ZALO","LOGIN")} src='https://localhost:44327/album-resources/album/imageSystem/zalo.png' />
                </div>
            </Form>
        </div>
    )
}