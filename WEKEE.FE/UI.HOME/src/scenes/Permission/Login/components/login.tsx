import * as React from 'react'
import { useEffect, useState } from 'react';
import { Checkbox, Form, Input, message } from 'antd';
import { L } from '../../../../lib/abpUtility';
import { createStructuredSelector } from 'reselect';
import { AuthenticationInput } from '../dtos/authenticationInput';
import { makeSelectLoading } from '../selectors';
import { useDispatch, useSelector } from 'react-redux';
import { loginRequestLoginStart } from '../actions';
import AuthV2GoogleComponent from './authV2GoogleComponent';
import LoadingProcess from '../../../../components/LoadingProcess';

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

        let isAccount = (values.account !== null || values.account !== undefined)
            && (values.account.match(/[+=`!#$%*()'\":;<>?]/g) !== null
                || values.account.match(/.{8,}/g) === null
                || values.account.match(/\d/g) === null
                || values.account.match(/[a-z]{1,}/g) === null
                || values.account.match(/[A-Z]{1,}/g) === null
                || values.account.split(" ").length - 1 != 0);

        let isPassword = (values.password !== null || values.password !== undefined)
            && (values.password.match(/[+=`!#$%*()'\":;<>?]/g) !== null
                || values.password.match(/.{8,}/g) === null
                || values.password.match(/\d/g) === null
                || values.password.match(/[a-z]{1,}/g) === null
                || values.password.match(/[A-Z]{1,}/g) === null
                || values.password.split(" ").length - 1 != 0
            );

        if (isAccount) {
            message.error(L("INVALID_ACCOUNT", "LOGIN"));
        }
        else if (isPassword) {
            message.error(L("INVALID_ACCOUNT", "LOGIN"));
        }
        else {
            dispatch(loginRequestLoginStart(values));
        }
    };

    useEffect(() => {
        processAccount()
    }, [])

    const [AvatarAccount, setAvatarAccount] = useState<string>();

    const processAccount = () => {
        var data = abp.utils.getCookieValue('_pus');
        var isToken = data === null || data === undefined || data === "";
        if (!isToken) {
            let result = data.split(/[|]/i);
            if (result.toString().toUpperCase().indexOf("https".toUpperCase) != -1) {
                setAvatarAccount(result[1].trim());
            }
            else {
                setAvatarAccount(abp.serviceAlbumImage + result[1].trim());
            }
        }
        else {
            setAvatarAccount(abp.serviceAlbumImage + "/album/imageSystem/facebook.png");
        }
    }

    return (
        <>

            <div className="WBYuKwbWag">
                <img className="dXZSevIeue" src={AvatarAccount} alt="" />
                <div className="fFgTYwFwNM">Đăng Nhập</div>
                <Form
                    name="basic"
                    initialValues={{ remember: true }}
                    onFinish={onFinish}
                >
                    <Form.Item
                        label={L("USER_NAME", "LOGIN")}
                        name="account"
                        className="LXSaSCCguB"
                    >
                        <Input />
                    </Form.Item>

                    <Form.Item
                        label={L("PASSWORD", "LOGIN")}
                        name="password"
                        className="LXSaSCCguB"
                    >
                        <Input.Password />
                    </Form.Item>

                    <Form.Item
                        name="remember"
                        valuePropName="checked"
                        className="gHirHByIww"
                    >
                        <Checkbox checked={true}>{L("REMEMBER", "LOGIN")}</Checkbox>
                    </Form.Item>

                    <Form.Item className="grDQhEfohj">
                        <button className="vdnsCAmrtL" style={{ display: loading ? 'none' : 'block' }}>
                            <span></span>
                            <span></span>
                            <span></span>
                            <span></span>
                            {L("LOGIN", "LOGIN")}
                        </button >
                    </Form.Item>
                    <div className="tCvhCAhEGu">
                        <div>
                            {L("NOT_ACCOUNT", "LOGIN")}
                            &ensp;<a href='/register-account'>{L("REGISTRATION", "LOGIN")}</a>
                        </div>
                        <a href=''>{L("FORGOT_PASWORD", "LOGIN")}</a>
                    </div>
                    <div className="gofuVBTQrx">
                        <span>Hoặc</span>
                        <AuthV2GoogleComponent />
                        <div>
                            <img title={L("LOGIN_WITH_FACEBOOK", "LOGIN")} src='https://localhost:44327/album-resources/album/imageSystem/facebook.png' />
                        </div>
                        <div>
                            <img title={L("LOGIN_WITH_ZALO", "LOGIN")} src='https://localhost:44327/album-resources/album/imageSystem/zalo.png' />
                        </div>
                    </div>
                </Form>
            </div>
            {LoadingProcess(loading)}
        </>
    )
}