import * as React from 'react';
import { Avatar, BackTop, Badge, Button, Card, Col, Divider, Dropdown, Input, Menu, Row, Select, Typography } from 'antd';
import AppComponentBase from '../../components/ComponentBase';
import { Helmet } from 'react-helmet';
import 'antd/dist/antd.css';
import { BellFilled, BellOutlined, CaretDownOutlined, CaretUpOutlined, CheckOutlined, CloseOutlined, DesktopOutlined, EllipsisOutlined, QuestionCircleOutlined, SearchOutlined, SettingOutlined, ShoppingCartOutlined, ShoppingFilled } from '@ant-design/icons';
import Meta from 'antd/lib/card/Meta';
import Slider from 'react-slick';
import "slick-carousel/slick/slick.css";
import "slick-carousel/slick/slick-theme.css";
const { Option, OptGroup } = Select;
const { SubMenu } = Menu;
const { Text } = Typography;
declare var abp: any;

export interface IHeaderProps {
    collapsed?: any;
    toggle?: any;
}

export interface IHeaderState {

}

const loginInfo = () => {
    var info = abp.auth.getInfo();
    if (info) {
        var avatar = info.slice(info.indexOf("album"));
        var name = info.slice(0, info.indexOf("id:"));
        return (
            <Dropdown
                trigger={['click']}
                overlay={
                    <Menu className="ccSjlOHyqP">
                        <div className="ygsRYzMMyV">
                            <span>Thông báo</span>
                            <Dropdown
                                trigger={['click']}
                                overlay={<Menu className="ccSjlOHyqP">
                                    <Menu.Item key="sada" >
                                        <CheckOutlined /> Đánh dấu tất cả đã đọc
                                    </Menu.Item>
                                    <Menu.Item key="sadas" >
                                        <SettingOutlined />  Cài đặt thông báo
                                    </Menu.Item>
                                    <Menu.Item key="dasdsasdasda" >
                                        <DesktopOutlined />  Mở thông báo
                                    </Menu.Item>
                                </Menu>}>
                                <EllipsisOutlined className='YLvdaHYdIV' />
                            </Dropdown>
                        </div>
                        <Menu.Divider />
                        <div className="DXObXwsQyb">
                            <span>Mới nhất</span>
                            <span>Xem tất cả</span>
                        </div>
                        <Menu.Item key="sadfsa" >
                            <a href="/login" className="UWRJovyiDd">
                                <div className="bRDSowVZlW">
                                    <img src={abp.appServiceUrlStaticFile + "/" + "album/product/wekee-wekee-146121821_430393218381317_505496019680432805_n-210306-07102021--210518-07102021-S80x80.jpg"} alt="" />
                                </div>
                                <span className="qGjeERhsix">
                                    <span>hello anh và mọi người , chúc anh và mọi người xem live vui vẻ. anh mở hàng cho mọi người trong top 4 nha a</span>
                                    <span>4 giờ</span>
                                </span>
                                <span className="oqNMgqILWc"><EllipsisOutlined className='YLvdaHYdIV' /></span>
                            </a>
                        </Menu.Item>
                        <Menu.Item key="sadfsa" >
                            <a href="/login" className="UWRJovyiDd">
                                <div className="bRDSowVZlW">
                                    <img src={abp.appServiceUrlStaticFile + "/" + "album/product/wekee-wekee-146121821_430393218381317_505496019680432805_n-210306-07102021--210518-07102021-S80x80.jpg"} alt="" />
                                </div>
                                <span className="qGjeERhsix">
                                    <span>hello anh và mọi người , chúc anh và mọi người xem live vui vẻ. anh mở hàng cho mọi người trong top 4 nha a</span>
                                    <span>4 giờ</span>
                                </span>
                                <span className="oqNMgqILWc"><EllipsisOutlined className='YLvdaHYdIV' /></span>
                            </a>
                        </Menu.Item>
                        <div className="DXObXwsQyb">
                            <span>Trước đó</span>
                            <span></span>
                        </div>
                        <Menu.Item key="sadfsa" >
                            <a href="/login" className="UWRJovyiDd">
                                <div className="bRDSowVZlW">
                                    <img src={abp.appServiceUrlStaticFile + "/" + "album/product/wekee-wekee-146121821_430393218381317_505496019680432805_n-210306-07102021--210518-07102021-S80x80.jpg"} alt="" />
                                </div>
                                <span className="qGjeERhsix">
                                    <span>hello anh và mọi người , chúc anh và mọi người xem live vui vẻ. anh mở hàng cho mọi người trong top 4 nha a</span>
                                    <span>4 giờ</span>
                                </span>
                                <span className="oqNMgqILWc"><EllipsisOutlined className='YLvdaHYdIV' /></span>
                            </a>
                        </Menu.Item>
                        <Menu.Item key="sadfsa" >
                            <a href="/login" className="UWRJovyiDd">
                                <div className="bRDSowVZlW">
                                    <img src={abp.appServiceUrlStaticFile + "/" + "album/product/wekee-wekee-146121821_430393218381317_505496019680432805_n-210306-07102021--210518-07102021-S80x80.jpg"} alt="" />
                                </div>
                                <span className="qGjeERhsix">
                                    <span>hello anh và mọi người , chúc anh và mọi người xem live vui vẻ. anh mở hàng cho mọi người trong top 4 nha a</span>
                                    <span>4 giờ</span>
                                </span>
                                <span className="oqNMgqILWc"><EllipsisOutlined className='YLvdaHYdIV' /></span>
                            </a>
                        </Menu.Item>
                        <Menu.Item key="sadfsa" >
                            <a href="/login" className="UWRJovyiDd">
                                <div className="bRDSowVZlW">
                                    <img src={abp.appServiceUrlStaticFile + "/" + "album/product/wekee-wekee-146121821_430393218381317_505496019680432805_n-210306-07102021--210518-07102021-S80x80.jpg"} alt="" />
                                </div>
                                <span className="qGjeERhsix">
                                    <span>hello anh và mọi người , chúc anh và mọi người xem live vui vẻ. anh mở hàng cho mọi người trong top 4 nha a</span>
                                    <span>4 giờ</span>
                                </span>
                                <span className="oqNMgqILWc"><EllipsisOutlined className='YLvdaHYdIV' /></span>
                            </a>
                        </Menu.Item>
                        <Menu.Item key="sadfsa" >
                            <a href="/login">Đăng Nhập</a>
                        </Menu.Item>
                    </Menu>
                }>
                <Badge size='small' className="wuurxwiIVq">
                    <CaretDownOutlined className='hdfutmacic' />
                </Badge>
            </Dropdown>
        )
    }
    else {
        return (
            <Dropdown
                trigger={['click']}
                overlay={
                    <Menu className="ccSjlOHyqP">
                        <div className="ygsRYzMMyV">
                            <span>Thông báo</span>
                            <Dropdown
                                trigger={['click']}
                                overlay={<Menu className="ccSjlOHyqP">
                                    <Menu.Item key="sada" >
                                        <CheckOutlined /> Đánh dấu tất cả đã đọc
                                    </Menu.Item>
                                    <Menu.Item key="sadas" >
                                        <SettingOutlined />  Cài đặt thông báo
                                    </Menu.Item>
                                    <Menu.Item key="dasdsasdasda" >
                                        <DesktopOutlined />  Mở thông báo
                                    </Menu.Item>
                                </Menu>}>
                                <EllipsisOutlined className='YLvdaHYdIV' />
                            </Dropdown>
                        </div>
                        <Menu.Divider />
                        <div className="DXObXwsQyb">
                            <span>Mới nhất</span>
                            <span>Xem tất cả</span>
                        </div>
                        <Menu.Item key="sadfsa" >
                            <a href="/login" className="UWRJovyiDd">
                                <div className="bRDSowVZlW">
                                    <img src={abp.appServiceUrlStaticFile + "/" + "album/product/wekee-wekee-146121821_430393218381317_505496019680432805_n-210306-07102021--210518-07102021-S80x80.jpg"} alt="" />
                                </div>
                                <span className="qGjeERhsix">
                                    <span>hello anh và mọi người , chúc anh và mọi người xem live vui vẻ. anh mở hàng cho mọi người trong top 4 nha a</span>
                                    <span>4 giờ</span>
                                </span>
                                <span className="oqNMgqILWc"><EllipsisOutlined className='YLvdaHYdIV' /></span>
                            </a>
                        </Menu.Item>
                        <Menu.Item key="sadfsa" >
                            <a href="/login" className="UWRJovyiDd">
                                <div className="bRDSowVZlW">
                                    <img src={abp.appServiceUrlStaticFile + "/" + "album/product/wekee-wekee-146121821_430393218381317_505496019680432805_n-210306-07102021--210518-07102021-S80x80.jpg"} alt="" />
                                </div>
                                <span className="qGjeERhsix">
                                    <span>hello anh và mọi người , chúc anh và mọi người xem live vui vẻ. anh mở hàng cho mọi người trong top 4 nha a</span>
                                    <span>4 giờ</span>
                                </span>
                                <span className="oqNMgqILWc"><EllipsisOutlined className='YLvdaHYdIV' /></span>
                            </a>
                        </Menu.Item>
                        <div className="DXObXwsQyb">
                            <span>Trước đó</span>
                            <span></span>
                        </div>
                        <Menu.Item key="sadfsa" >
                            <a href="/login" className="UWRJovyiDd">
                                <div className="bRDSowVZlW">
                                    <img src={abp.appServiceUrlStaticFile + "/" + "album/product/wekee-wekee-146121821_430393218381317_505496019680432805_n-210306-07102021--210518-07102021-S80x80.jpg"} alt="" />
                                </div>
                                <span className="qGjeERhsix">
                                    <span>hello anh và mọi người , chúc anh và mọi người xem live vui vẻ. anh mở hàng cho mọi người trong top 4 nha a</span>
                                    <span>4 giờ</span>
                                </span>
                                <span className="oqNMgqILWc"><EllipsisOutlined className='YLvdaHYdIV' /></span>
                            </a>
                        </Menu.Item>
                        <Menu.Item key="sadfsa" >
                            <a href="/login" className="UWRJovyiDd">
                                <div className="bRDSowVZlW">
                                    <img src={abp.appServiceUrlStaticFile + "/" + "album/product/wekee-wekee-146121821_430393218381317_505496019680432805_n-210306-07102021--210518-07102021-S80x80.jpg"} alt="" />
                                </div>
                                <span className="qGjeERhsix">
                                    <span>hello anh và mọi người , chúc anh và mọi người xem live vui vẻ. anh mở hàng cho mọi người trong top 4 nha a</span>
                                    <span>4 giờ</span>
                                </span>
                                <span className="oqNMgqILWc"><EllipsisOutlined className='YLvdaHYdIV' /></span>
                            </a>
                        </Menu.Item>
                        <Menu.Item key="sadfsa" >
                            <a href="/login" className="UWRJovyiDd">
                                <div className="bRDSowVZlW">
                                    <img src={abp.appServiceUrlStaticFile + "/" + "album/product/wekee-wekee-146121821_430393218381317_505496019680432805_n-210306-07102021--210518-07102021-S80x80.jpg"} alt="" />
                                </div>
                                <span className="qGjeERhsix">
                                    <span>hello anh và mọi người , chúc anh và mọi người xem live vui vẻ. anh mở hàng cho mọi người trong top 4 nha a</span>
                                    <span>4 giờ</span>
                                </span>
                                <span className="oqNMgqILWc"><EllipsisOutlined className='YLvdaHYdIV' /></span>
                            </a>
                        </Menu.Item>
                        <Menu.Item key="sadfsa" >
                            <a href="/login">Đăng Nhập</a>
                        </Menu.Item>
                    </Menu>
                }>
                <Badge size='small' className="wuurxwiIVq">
                    <CaretDownOutlined className='hdfutmacic' />
                </Badge>
            </Dropdown>
        )
    }
}

const bellInfo = () => {
    return (
        <Dropdown
            trigger={['click']}
            overlay={
                <Menu className="ccSjlOHyqP">
                    <div className="ygsRYzMMyV">
                        <span>Thông báo</span>
                        <Dropdown
                            trigger={['click']}
                            overlay={<Menu className="ccSjlOHyqP">
                                <Menu.Item key="sada" >
                                    <CheckOutlined /> Đánh dấu tất cả đã đọc
                                </Menu.Item>
                                <Menu.Item key="sadas" >
                                    <SettingOutlined />  Cài đặt thông báo
                                </Menu.Item>
                                <Menu.Item key="dasdsasdasda" >
                                    <DesktopOutlined />  Mở thông báo
                                </Menu.Item>
                            </Menu>}>
                            <EllipsisOutlined className='YLvdaHYdIV' />
                        </Dropdown>
                    </div>
                    <Menu.Divider />
                    <div className="DXObXwsQyb">
                        <span>Mới nhất</span>
                        <span>Xem tất cả</span>
                    </div>
                    <Menu.Item key="sadfsa" >
                        <a href="/login" className="UWRJovyiDd">
                            <div className="bRDSowVZlW">
                                <img src={abp.appServiceUrlStaticFile + "/" + "album/product/wekee-wekee-146121821_430393218381317_505496019680432805_n-210306-07102021--210518-07102021-S80x80.jpg"} alt="" />
                            </div>
                            <span className="qGjeERhsix">
                                <span>hello anh và mọi người , chúc anh và mọi người xem live vui vẻ. anh mở hàng cho mọi người trong top 4 nha a</span>
                                <span>4 giờ</span>
                            </span>
                            <span className="oqNMgqILWc"><EllipsisOutlined className='YLvdaHYdIV' /></span>
                        </a>
                    </Menu.Item>
                    <Menu.Item key="sadfsa" >
                        <a href="/login" className="UWRJovyiDd">
                            <div className="bRDSowVZlW">
                                <img src={abp.appServiceUrlStaticFile + "/" + "album/product/wekee-wekee-146121821_430393218381317_505496019680432805_n-210306-07102021--210518-07102021-S80x80.jpg"} alt="" />
                            </div>
                            <span className="qGjeERhsix">
                                <span>hello anh và mọi người , chúc anh và mọi người xem live vui vẻ. anh mở hàng cho mọi người trong top 4 nha a</span>
                                <span>4 giờ</span>
                            </span>
                            <span className="oqNMgqILWc"><EllipsisOutlined className='YLvdaHYdIV' /></span>
                        </a>
                    </Menu.Item>
                    <div className="DXObXwsQyb">
                        <span>Trước đó</span>
                        <span></span>
                    </div>
                    <Menu.Item key="sadfsa" >
                        <a href="/login" className="UWRJovyiDd">
                            <div className="bRDSowVZlW">
                                <img src={abp.appServiceUrlStaticFile + "/" + "album/product/wekee-wekee-146121821_430393218381317_505496019680432805_n-210306-07102021--210518-07102021-S80x80.jpg"} alt="" />
                            </div>
                            <span className="qGjeERhsix">
                                <span>hello anh và mọi người , chúc anh và mọi người xem live vui vẻ. anh mở hàng cho mọi người trong top 4 nha a</span>
                                <span>4 giờ</span>
                            </span>
                            <span className="oqNMgqILWc"><EllipsisOutlined className='YLvdaHYdIV' /></span>
                        </a>
                    </Menu.Item>
                    <Menu.Item key="sadfsa" >
                        <a href="/login" className="UWRJovyiDd">
                            <div className="bRDSowVZlW">
                                <img src={abp.appServiceUrlStaticFile + "/" + "album/product/wekee-wekee-146121821_430393218381317_505496019680432805_n-210306-07102021--210518-07102021-S80x80.jpg"} alt="" />
                            </div>
                            <span className="qGjeERhsix">
                                <span>hello anh và mọi người , chúc anh và mọi người xem live vui vẻ. anh mở hàng cho mọi người trong top 4 nha a</span>
                                <span>4 giờ</span>
                            </span>
                            <span className="oqNMgqILWc"><EllipsisOutlined className='YLvdaHYdIV' /></span>
                        </a>
                    </Menu.Item>
                    <Menu.Item key="sadfsa" >
                        <a href="/login" className="UWRJovyiDd">
                            <div className="bRDSowVZlW">
                                <img src={abp.appServiceUrlStaticFile + "/" + "album/product/wekee-wekee-146121821_430393218381317_505496019680432805_n-210306-07102021--210518-07102021-S80x80.jpg"} alt="" />
                            </div>
                            <span className="qGjeERhsix">
                                <span>hello anh và mọi người , chúc anh và mọi người xem live vui vẻ. anh mở hàng cho mọi người trong top 4 nha a</span>
                                <span>4 giờ</span>
                            </span>
                            <span className="oqNMgqILWc"><EllipsisOutlined className='YLvdaHYdIV' /></span>
                        </a>
                    </Menu.Item>
                    <Menu.Item key="sadfsa" >
                        <a href="/login">Đăng Nhập</a>
                    </Menu.Item>
                </Menu>
            }>
            <Badge size='small' className="wuurxwiIVq" count={10}>
                <BellFilled className='hdfutmacic' />
            </Badge>
        </Dropdown>
    )
}

const cardInfo = () => {
    return (
        <Dropdown
            trigger={['click']}
            overlay={
                <Menu className="ccSjlOHyqP">
                    <div className="ygsRYzMMyV">
                        <span>Giỏ Hàng Của Tôi</span>
                        <Dropdown
                            trigger={['click']}
                            overlay={<Menu className="ccSjlOHyqP">
                                <Menu.Item key="sada" >
                                    <CheckOutlined /> Đánh dấu tất cả đã đọc
                                </Menu.Item>
                                <Menu.Item key="sadas" >
                                    <SettingOutlined />  Cài đặt thông báo
                                </Menu.Item>
                                <Menu.Item key="dasdsasdasda" >
                                    <DesktopOutlined />  Mở thông báo
                                </Menu.Item>
                            </Menu>}>
                            <EllipsisOutlined className='YLvdaHYdIV' />
                        </Dropdown>
                    </div>
                    <Menu.Divider />
                    <div className="DXObXwsQyb">
                        <span>Mới nhất</span>
                        <span>Xem tất cả</span>
                    </div>
                    <Menu.Item key="sadfsa" >
                        <a href="/login" className="UWRJovyiDd">
                            <div className="bRDSowVZlW">
                                <img src={abp.appServiceUrlStaticFile + "/" + "album/product/wekee-wekee-146121821_430393218381317_505496019680432805_n-210306-07102021--210518-07102021-S80x80.jpg"} alt="" />
                            </div>
                            <span className="qGjeERhsix">
                                <span>hello anh và mọi người , chúc anh và mọi người xem live vui vẻ. anh mở hàng cho mọi người trong top 4 nha a</span>
                                <span>4 giờ</span>
                            </span>
                            <span className="oqNMgqILWc"><EllipsisOutlined className='YLvdaHYdIV' /></span>
                        </a>
                    </Menu.Item>
                    <Menu.Item key="sadfsa" >
                        <a href="/login" className="UWRJovyiDd">
                            <div className="bRDSowVZlW">
                                <img src={abp.appServiceUrlStaticFile + "/" + "album/product/wekee-wekee-146121821_430393218381317_505496019680432805_n-210306-07102021--210518-07102021-S80x80.jpg"} alt="" />
                            </div>
                            <span className="qGjeERhsix">
                                <span>hello anh và mọi người , chúc anh và mọi người xem live vui vẻ. anh mở hàng cho mọi người trong top 4 nha a</span>
                                <span>4 giờ</span>
                            </span>
                            <span className="oqNMgqILWc"><EllipsisOutlined className='YLvdaHYdIV' /></span>
                        </a>
                    </Menu.Item>
                    <div className="DXObXwsQyb">
                        <span>Trước đó</span>
                        <span></span>
                    </div>
                    <Menu.Item key="sadfsa" >
                        <a href="/login" className="UWRJovyiDd">
                            <div className="bRDSowVZlW">
                                <img src={abp.appServiceUrlStaticFile + "/" + "album/product/wekee-wekee-146121821_430393218381317_505496019680432805_n-210306-07102021--210518-07102021-S80x80.jpg"} alt="" />
                            </div>
                            <span className="qGjeERhsix">
                                <span>hello anh và mọi người , chúc anh và mọi người xem live vui vẻ. anh mở hàng cho mọi người trong top 4 nha a</span>
                                <span>4 giờ</span>
                            </span>
                            <span className="oqNMgqILWc"><EllipsisOutlined className='YLvdaHYdIV' /></span>
                        </a>
                    </Menu.Item>
                    <Menu.Item key="sadfsa" >
                        <a href="/login" className="UWRJovyiDd">
                            <div className="bRDSowVZlW">
                                <img src={abp.appServiceUrlStaticFile + "/" + "album/product/wekee-wekee-146121821_430393218381317_505496019680432805_n-210306-07102021--210518-07102021-S80x80.jpg"} alt="" />
                            </div>
                            <span className="qGjeERhsix">
                                <span>hello anh và mọi người , chúc anh và mọi người xem live vui vẻ. anh mở hàng cho mọi người trong top 4 nha a</span>
                                <span>4 giờ</span>
                            </span>
                            <span className="oqNMgqILWc"><EllipsisOutlined className='YLvdaHYdIV' /></span>
                        </a>
                    </Menu.Item>
                    <Menu.Item key="sadfsa" >
                        <a href="/login" className="UWRJovyiDd">
                            <div className="bRDSowVZlW">
                                <img src={abp.appServiceUrlStaticFile + "/" + "album/product/wekee-wekee-146121821_430393218381317_505496019680432805_n-210306-07102021--210518-07102021-S80x80.jpg"} alt="" />
                            </div>
                            <span className="qGjeERhsix">
                                <span>hello anh và mọi người , chúc anh và mọi người xem live vui vẻ. anh mở hàng cho mọi người trong top 4 nha a</span>
                                <span>4 giờ</span>
                            </span>
                            <span className="oqNMgqILWc"><EllipsisOutlined className='YLvdaHYdIV' /></span>
                        </a>
                    </Menu.Item>
                    <Menu.Item key="sadfsa" >
                        <a href="/login">Đăng Nhập</a>
                    </Menu.Item>
                </Menu>
            }>

            <Badge size='small' className="wuurxwiIVq" count={0}>
                <ShoppingFilled className='hdfutmacic' />
            </Badge>
        </Dropdown>
    )
}
const settings = {
    className: "slider variable-width iEZpNgvDLE",
    dots: false,
    infinite: true,
    autoplay: true,
    speed: 1000,
    slidesToShow: 5,
    slidesToScroll: 5,
    variableWidth: true
};

function handleChange(value: any) {
    console.log(`selected ${value}`);
}

class Header extends AppComponentBase<IHeaderProps, IHeaderState> {
    public render() {
        return (
            <Col className='hdfut'>
                <Helmet>
                    <link rel="stylesheet" href={abp.appServiceUrlStaticFile + "/fileCss/header.css"} />
                    <link rel="stylesheet" href={abp.appServiceUrlStaticFile + "/fileCss/discountProduct.css"} />
                    <link rel="stylesheet" href={abp.appServiceUrlStaticFile + "/fileCss/home.css"} />
                </Helmet>
                <Row className="VTvJenqWvs">
                    <Col span={10}>Để cái gì đó ở đây</Col>
                    <Col span={4}></Col>
                    <Col span={10}>Để cái gì đó ở đây</Col>
                </Row>
                <Row className='hdfutm'>
                    <Col span={4} className='hdfutmlg'>
                        <a href='#'><img src={abp.appServiceUrlStaticFile + "/" + "album/common/1-google-logo.png"} /></a>
                    </Col>
                    <Col span={16} >
                        <Row className="kZiNLsSYJF">
                            <Col className='sKsTybFlbF'>
                                <Input.Group compact>
                                    <Select defaultValue="Option1" className="WftrqkfVlN">
                                        <Option value="Option1">Tất Cả</Option>
                                        <Option value="Option2">Tên sản phẩm</Option>
                                        <Option value="Option3">Tên nhà cung cấp</Option>
                                        <Option value="Option4">Tên người dùng</Option>
                                        <Option value="Option5">Giá sản phẩm</Option>
                                        <Option value="Option6">Mô tả sản phẩm</Option>
                                        <Option value="Option7">Tag sản phẩm</Option>
                                    </Select>
                                    <Select
                                        className='uaLLOirpgi'
                                        placeholder='Tìm kiếm sản phẩm, nhà cung cấp'
                                        autoFocus={true}
                                        showSearch
                                        onChange={handleChange}
                                        optionLabelProp="label"
                                        allowClear
                                        suffixIcon={<SearchOutlined />}
                                        dropdownRender={menu => (
                                            <div>
                                                {menu}
                                                <Divider style={{ margin: '4px 0' }} />
                                                Lịch sử
                                            </div>
                                        )}
                                    >
                                        <Option value="china" label="China">
                                            <div className="NfxUTNJIOM">
                                                <img src="" alt="" />
                                                <div>DSQUARED2 - Áo khoác blazer nam phối cổ satin S71BN0735-900 DSQUARED2 - Áo khoác blazer nam phối cổ satin S71BN0735-900</div>
                                            </div>
                                        </Option>
                                    </Select>
                                </Input.Group>
                            </Col>
                            <Col>
                                <Slider {...settings}>
                                    <a className='XCEiljUgdo' href="">Váy</a>
                                    <a className='XCEiljUgdo' href="">Áo phông</a>
                                    <a className='XCEiljUgdo' href="">Quần</a>
                                    <a className='XCEiljUgdo' href="">Bông tẩy trang</a>
                                    <a className='XCEiljUgdo' href="">Balo</a>
                                    <a className='XCEiljUgdo' href="">Dép</a>
                                    <a className='XCEiljUgdo' href="">Khẩu Trang</a>
                                    <a className='XCEiljUgdo' href="">Máy tính</a>
                                    <a className='XCEiljUgdo' href="">Phụ kiện</a>
                                </Slider>
                            </Col>
                        </Row>
                    </Col>
                    <Col span={4}>
                        <div className='hdfutmsttac'>
                            <div>{cardInfo()}</div>
                            <div>{bellInfo()}</div>
                            <div>{loginInfo()}</div>
                            <div>{loginInfo()}</div>
                        </div>
                    </Col>
                </Row >
                <BackTop style={{ right: '50px' }}>
                    <CaretUpOutlined className="OARbhCigKQ" />
                </BackTop>
            </Col >
        );
    }
}

export default Header;
