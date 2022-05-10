//#region  import
import * as React from 'react';
import { useEffect, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { createStructuredSelector } from 'reselect';
import { useInjectReducer, useInjectSaga } from '../../../redux/reduxInjectors';
import { watchPageStart } from './actions';
import reducer from './reducer';
import saga from './saga';
import { makeSelectLoading } from './selectors';
import { Avatar, Badge, Button, Dropdown, Menu } from 'antd';
import { CheckOutlined, DesktopOutlined, EllipsisOutlined, SettingOutlined, UserOutlined } from '@ant-design/icons';
import { Redirect } from 'react-router-dom';
declare var abp: any;
//#endregion
export interface ILoginHomeComponentProps {
    location: any;
}
const key = 'loginhomecomponent';
const stateSelector = createStructuredSelector<any, any>({
    loading: makeSelectLoading()
});

export default function LoginHomeComponent(props: ILoginHomeComponentProps) {
    useInjectReducer(key, reducer);
    useInjectSaga(key, saga);

    const dispatch = useDispatch();

    const { } = useSelector(stateSelector);
    const [NameAccount, setNameAccount] = useState<string>();
    const [AvatarAccount, setAvatarAccount] = useState<string>();
    const [TokenActive, setTokenActive] = useState(false);
    //#region  START

    useEffect(() => {
        processAccount();
    }, [dispatch]);

    const processAccount = () => {
        var data = abp.utils.getCookieValue('_pus');
        var isToken = data === null || data === undefined || data === "";
        setTokenActive(isToken ? false : true);
        console.log(isToken)
        if (!isToken) {
            const result = data.split(/[|]/i);
            setNameAccount(result[0]);
            setAvatarAccount(result[1].trim());
        }
    }

    const redirectLogin = () => {
        if (!TokenActive) {
            window.location.href = '/login';
        }
    }
    //#endregion
    //#region  Function
    const logOutAccount = () => {
        abp.auth.clearToken();
    }
    //#endregion
    return (
        <>
            <Dropdown
                trigger={['click']}
                onVisibleChange={() => redirectLogin()}
                overlay={TokenActive === true ?
                    <Menu className="ccSjlOHyqP XqOafsewtF">
                        <div className="ygsRYzMMyV EeevvVzBxE">
                            <span>Xin chào : {NameAccount}</span>
                        </div>
                        <Menu.Divider />
                        <Menu.Item key="sadfsa1" >
                            <a href="/login">Đơn hàng của tôi</a>
                        </Menu.Item>
                        <Menu.Item key="sadfsa2" >
                            <a href="/login">Quản lý đổi trả</a>
                        </Menu.Item>
                        <Menu.Item key="sadfsa3" >
                            <a href="/login">Thông báo của tôi</a>
                        </Menu.Item>
                        <Menu.Item key="sadfsa4" >
                            <a href="/login">Tài khoản của tôi</a>
                        </Menu.Item>
                        <Menu.Item key="sadfsa5" >
                            <a href="/login">Nhận xét sản phẩm đã mua</a>
                        </Menu.Item>
                        <Menu.Item key="sadfsa6" >
                            <a href="/login" className="UWRJovyiDd">
                                <div className="bRDSowVZlW">
                                    <img src={abp.serviceAlbumImage + AvatarAccount} alt="" />
                                </div>
                                <span className="qGjeERhsix">
                                    <span>hello anh và mọi người</span>
                                    <span>4 giờ</span>
                                </span>
                            </a>
                        </Menu.Item>
                        <Menu.Item key="sadfsa7" onClick={logOutAccount} >
                            <a href="/">Đăng xuất</a>
                        </Menu.Item>
                    </Menu>
                    : <></>
                }>
                {AvatarAccount === undefined
                    ? <UserOutlined className='hdfutmacic' />
                    : <Badge size='small' className="wuurxwiIVq">
                        <Avatar src={abp.serviceAlbumImage + AvatarAccount} />
                    </Badge>}

            </Dropdown>
        </>
    )
}
