import * as React from 'react'
import { useEffect } from 'react';
import { Checkbox, Form, Input, Modal } from 'antd';
import { L } from '../../../../lib/abpUtility';
import { createStructuredSelector } from 'reselect';
import { AuthenticationInput } from '../dtos/authenticationInput';
import { makeSelectLoading } from '../selectors';
import { useDispatch, useSelector } from 'react-redux';
import { loginRequestLoginStart, registrationAccountBasicStart } from '../actions';
import { ExclamationCircleOutlined } from '@ant-design/icons';
import { UserProfileInsertDto } from '../dtos/userProfileInsertDto';

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

    const onFinish = (values: UserProfileInsertDto) => {
        if (values.email?.match(/^((03(\d){8})|(09(\d){8})|(086(\d){7})|(088(\d){7})|(089(\d){7})|(01(\d){9}))$/g) !== null) {
            values.numberPhone = values.email;
            values.email = undefined;
        }
        dispatch(registrationAccountBasicStart(values));
    };

    // function confirm() {
    //     Modal.confirm({
    //         title: 'Mã code xác nhận',
    //         icon: <ExclamationCircleOutlined />,
    //         content: <>
    //             <div>
    //                 <input className='DzwkfmNSxJ' type="text" />
    //                 <input className='DzwkfmNSxJ' type="text" />
    //                 <input className='DzwkfmNSxJ' type="text" />
    //                 <input className='DzwkfmNSxJ' type="text" />
    //                 <input className='DzwkfmNSxJ' type="text" />
    //                 <input className='DzwkfmNSxJ' type="text" />
    //             </div>
    //         </>,
    //         okText: 'Xác nhận',
    //         cancelText: 'Hủy bỏ',
    //     });
    // }

    // facebook
    return (
        <div className="WBYuKwbWag">
            <img className="dXZSevIeue" src={abp.serviceAlbumImage + "album/imageSystem/avatar-default.jpg"} alt="" />
            <div className="fFgTYwFwNM">{L("REGISTRATION", "LOGIN")}</div>
            <Form
                name="basic"
                initialValues={{ remember: true }}
                onFinish={onFinish}
                labelCol={{ span: 6 }}
                autoComplete="off"
            >
                <Form.Item
                    label={L("USER_NAME", "LOGIN")}
                    name="userName"
                    rules={[{ required: true, message: L("USER_NAME_REQUIRED", "LOGIN") },
                    () => ({
                        validator(_, value) {
                            if (value.match(/[+=`!#$%*()'\":;<>?]/g) !== null
                                || value.match(/.{8,}/g) === null
                                || value.match(/\d/g) === null
                                || value.match(/[a-z]{1,}/g) === null
                                || value.match(/[A-Z]{1,}/g) === null
                                || value.split(" ").length - 1 != 0
                                ) {
                        return Promise.reject(new Error(L("INVALID_ACCOUNT", "LOGIN")));
                    }
                            else {
                                return Promise.resolve();
                            }
                        },
                    })
                    ]}
                className="LXSaSCCguB"
                >
                <Input placeholder={L("USER_NAME_INPUT", "LOGIN")} />
            </Form.Item>

            <Form.Item
                label={L("EMAIL_OR_NUMBERPHONE", "LOGIN")}
                name="email"
                rules={[
                    { required: true, message: 'Email không để trống!' },
                    () => ({
                        validator(_, value) {
                            if (value.match(/^((03(\d){8})|(09(\d){8})|(086(\d){7})|(088(\d){7})|(089(\d){7})|(01(\d){9}))$/g) === null
                                && value.match(/\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/g) === null) {
                                return Promise.reject(new Error(L("INVALID_ACCOUNT", "LOGIN")));
                            }
                            else {
                                return Promise.resolve();
                            }
                        },
                    })
                ]}
                className="LXSaSCCguB"
            >
                <Input placeholder='Email hoặc số điện thoại' />
            </Form.Item>

            <Form.Item
                name="password"
                label="Password"
                className="LXSaSCCguB"
                rules={[
                    {
                        required: true,
                        message: 'Please input your password!',
                    },
                    () => ({
                        validator(_, value) {
                            if (value.match(/[+=`!#$%*()'\":;<>?]/g) !== null
                                || value.match(/.{8,}/g) === null
                                || value.match(/\d/g) === null
                                || value.match(/[a-z]{1,}/g) === null
                                || value.match(/[A-Z]{1,}/g) === null
                                || value.split(" ").length - 1 != 0
                                ) {
                                return Promise.reject(new Error(L("INVALID_ACCOUNT", "LOGIN")));
                            }
                            else {
                                return Promise.resolve();
                            }
                        },
                    })
                ]}
                hasFeedback
            >
                <Input.Password />
            </Form.Item>

            <Form.Item
                name="confirm"
                label="Confirm Password"
                dependencies={['password']}
                hasFeedback
                className="LXSaSCCguB"
                rules={[
                    {
                        required: true,
                        message: 'Please confirm your password!',
                    },
                    ({ getFieldValue }) => ({
                        validator(_, value) {
                            if (!value || getFieldValue('password') === value) {
                                return Promise.resolve();
                            }
                            return Promise.reject(new Error('The two passwords that you entered do not match!'));
                        },
                    }),
                ]}
            >
                <Input.Password />
            </Form.Item>

            <Form.Item
                name="isAcceptTerm"
                valuePropName="checked"
                className="LXSaSCCguB"
            >
                <Checkbox checked={true}>{L("IS_ACCEPT_TERM", "LOGIN")}</Checkbox>
            </Form.Item>

            <Form.Item className="grDQhEfohj">
                {/* onClick={confirm} */}
                <button className="vdnsCAmrtL" style={{ display: loading ? 'none' : 'block' }}>
                    <span></span>
                    <span></span>
                    <span></span>
                    <span></span>
                    {'Đăng ký'}
                </button >
            </Form.Item>
        </Form>
        </div >
    )
}