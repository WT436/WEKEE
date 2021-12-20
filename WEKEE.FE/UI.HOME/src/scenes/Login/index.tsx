import * as React from 'react';
import { useInjectReducer, useInjectSaga } from '../../redux/reduxInjectors';
import reducer from './reducer';
import saga from './saga';
import { Card, Col, FormInstance, Row } from 'antd';
import { Helmet } from 'react-helmet';
import { L } from '../../lib/abpUtility';
import LoginComponent from './components/login';
import ForgotPasswordComponent from './components/forgotPassword';
import RegistrationComponent from './components/registration';
import ChangePasswordComponent from './components/changePassword';
declare var abp: any;
const key = 'login';
var status = "login";
 
var urlCss = abp.serviceAlbumCss + "/login.css";
export interface ILoginProps extends FormInstance {
    location: any;
    nam: any;
}
export default function Login(props: ILoginProps) {
    useInjectReducer(key, reducer);
    useInjectSaga(key, saga);
    status = props.location.pathname;
    return (
        <>
            <Helmet>
                <title>{L("Login.Account")} | Wekee.vn</title>
                <link rel="stylesheet" href={urlCss} />
            </Helmet>
            <div className="VIvzMVhyoG">
                <div className="RIIYMqSaRe">
                    <div className="nNJgmDvtIq">

                    </div>
                    <div className="dTOjdZIMlb">
                        {{
                            '/login': <LoginComponent />,
                            '/forgot-password': <ForgotPasswordComponent />,
                            '/register-an-account': <RegistrationComponent />,
                            '/change-the-password': <ChangePasswordComponent />,
                            _: <LoginComponent />
                        }[status]}
                    </div>
                </div>
            </div>
        </>

    )
};
