import * as React from 'react';
import { Redirect, Route, Switch } from 'react-router-dom';
import { Button, Col, Input, Menu, Modal, Tooltip } from 'antd';
import Footer from '../Footer';
import { supplierRouters } from '../Router/router.config';
import HeaderSupplier from '../HeaderSupplier';
import SubMenu from 'antd/lib/menu/SubMenu';
import Layout, { Content } from 'antd/lib/layout/layout';
import Sider from 'antd/lib/layout/Sider';
import { Link } from 'react-router-dom';
import {
    MenuUnfoldOutlined, MenuFoldOutlined, DashboardOutlined, ShoppingCartOutlined,
    GiftOutlined, SettingOutlined,
} from '@ant-design/icons';
import LCPermission from '../../scenes/Permission/LCPermission/services'
declare var abp: any;
var input = "";
class SupplierLayout extends React.Component<any> {
    state = {
        collapsed: true,
    };
    onInputChange = (value: any) => {
        input = value.target.value;
    }
    async componentDidMount(): Promise<void> {
         var permission = true; //await LCPermission.checkSupplier();
        if (!permission) {
            window.location.href = '/login'
            abp.auth.setSupplier("", undefined)
        }
        else {
            if (!abp.auth.getTokenSupplier()) {
                Modal.confirm({
                    title: "Shop " + permission + " yêu cầu mật khẩu.",
                    width: '40%',
                    content: (
                        <div>
                            <Tooltip title={"Nếu bạn đăng nhập lần đầu thì mật khẩu là mật khẩu của tài khoản tạo shop"}>
                                <Input.Password onChange={this.onInputChange} placeholder="Mật khẩu shop" />
                            </Tooltip>
                        </div>
                    ),
                    autoFocusButton: null,
                    okButtonProps: {},
                    okText: "Đăng Nhập",
                    cancelText: "Thoát",
                    onCancel() { window.location.href = '/' },
                    onOk: async () => {
                        var tokenLogin = true; //await LCPermission.loginSupplier(input);
                        if (!tokenLogin) {
                            Modal.warning({
                                title: 'Mật khẩu không chính xác',
                                content: 'Nhập lại mật khẩu sau 1s',
                            });
                            setTimeout(() => {
                                window.location.href = '/supplier'
                            }, 1000);
                        }
                        else {
                            abp.auth.setSupplier(abp.auth.getToken(), undefined);
                        }
                    }
                });
            }
        }
    }

    toggleCollapsed = () => {
        this.setState({
            collapsed: !this.state.collapsed,
        });
    };

    render() {
        return (
            <Col className="container">
                <HeaderSupplier />
                <Layout>
                    <Sider trigger={null} collapsible collapsed={this.state.collapsed}>
                        <div style={{ overflowY: 'scroll', overflowX: 'hidden', maxWidth: '250px', maxHeight: '90vh' }}>
                            <Menu
                                defaultSelectedKeys={['item0_1']}
                                defaultOpenKeys={['item0_1']}
                                mode="inline"
                                theme="dark"
                                inlineCollapsed={this.state.collapsed}
                            >
                                <Button className="" onClick={this.toggleCollapsed} style={{ width: '100%', margin: '5px 0' }}>
                                    {React.createElement(this.state.collapsed ? MenuUnfoldOutlined : MenuFoldOutlined)}
                                </Button>
                                <Menu.Item key="item0_1" defaultChecked={false} icon={<DashboardOutlined />}>
                                    <Link to="/supplier">Trình điều khiển</Link>
                                </Menu.Item>
                                <SubMenu key="sub1" icon={<ShoppingCartOutlined />} title="Đơn Hàng">
                                    <Menu.Item key="item1_1">Option 9</Menu.Item>
                                    <SubMenu key="sub1_1" title="Kho">
                                        <Menu.Item key="item1_1_1">Option 11</Menu.Item>
                                    </SubMenu>
                                </SubMenu>
                                <SubMenu key="sub2" icon={<ShoppingCartOutlined />} title="Vận Chuyển">
                                    <Menu.Item key="item2_1">Option 9</Menu.Item>
                                    <SubMenu key="sub2_1" title="Kho">
                                        <Menu.Item key="item2_1_1">Option 11</Menu.Item>
                                    </SubMenu>
                                </SubMenu>
                                <SubMenu key="sub3" icon={<GiftOutlined />} title="Sản Phẩm">
                                    <Menu.Item key="item3_1">Thống Kê</Menu.Item>
                                    <SubMenu key="sub3_1" title="Kho">
                                        <Menu.Item key="item3_1_1"><Link to="/">Tạo Mới Sản Phẩm</Link></Menu.Item>
                                    </SubMenu>
                                    <SubMenu key="sub3_2" title="">
                                        <Menu.Item key="item3_2_1">Option 11</Menu.Item>
                                    </SubMenu>
                                </SubMenu>
                                <SubMenu key="sub4" icon={<ShoppingCartOutlined />} title="Marketting">
                                    <Menu.Item key="item2_1">Option 9</Menu.Item>
                                    <SubMenu key="sub2_1" title="Kho">
                                        <Menu.Item key="item2_1_1">Option 11</Menu.Item>
                                    </SubMenu>
                                </SubMenu>
                                <SubMenu key="sub5" icon={<ShoppingCartOutlined />} title="Tài Chính">
                                    <Menu.Item key="item2_1">Option 9</Menu.Item>
                                    <SubMenu key="sub2_1" title="Kho">
                                        <Menu.Item key="item2_1_1">Option 11</Menu.Item>
                                    </SubMenu>
                                </SubMenu>
                                <SubMenu key="sub6" icon={<ShoppingCartOutlined />} title="Dữ Liệu">
                                    <Menu.Item key="item2_1">Option 9</Menu.Item>
                                    <SubMenu key="sub2_1" title="Kho">
                                        <Menu.Item key="item2_1_1">Option 11</Menu.Item>
                                    </SubMenu>
                                </SubMenu>
                                <SubMenu key="sub7" icon={<ShoppingCartOutlined />} title="Tiềm Năng">
                                    <Menu.Item key="item2_1">Option 9</Menu.Item>
                                    <SubMenu key="sub2_1" title="Kho">
                                        <Menu.Item key="item2_1_1">Option 11</Menu.Item>
                                    </SubMenu>
                                </SubMenu>
                                <SubMenu key="sub8" icon={<ShoppingCartOutlined />} title="Khách Hàng">
                                    <Menu.Item key="item2_1">Option 9</Menu.Item>
                                    <SubMenu key="sub2_1" title="Kho">
                                        <Menu.Item key="item2_1_1">Option 11</Menu.Item>
                                    </SubMenu>
                                </SubMenu>
                                <SubMenu key="sub9" icon={<ShoppingCartOutlined />} title="Shop">
                                    <Menu.Item key="item9_1">Option 9</Menu.Item>
                                    <SubMenu key="sub9_1" title="Gian Hàng">
                                        <Menu.Item key="item9_1_1">Bố Cục</Menu.Item>
                                        <Menu.Item key="item9_1_2">Hồ Sơ</Menu.Item>
                                        <Menu.Item key="item9_1_3">Đánh Giá</Menu.Item>
                                        <Menu.Item key="item9_1_4">Danh Mục</Menu.Item>
                                        <Menu.Item key="item9_1_5">Báo Cáo</Menu.Item>
                                    </SubMenu>
                                </SubMenu>
                                <SubMenu key="sub10" icon={<SettingOutlined />} title="Thiết Lập">
                                    <Menu.Item key="item10_1"><Link to="/supplier/store/information">Thông Tin Cửa Hàng</Link></Menu.Item>
                                    <Menu.Item key="item10_2">Địa Chỉ</Menu.Item>
                                    <Menu.Item key="item10_3">Tài Khoản</Menu.Item>
                                    <Menu.Item key="item10_4">Người Dùng</Menu.Item>
                                    <Menu.Item key="item10_5">Nhân Viên</Menu.Item>
                                    <Menu.Item key="item10_6">Website Của Tôi</Menu.Item>
                                    <Menu.Item key="item10_6">Cài Đặt</Menu.Item>
                                </SubMenu>
                            </Menu>
                        </div>
                    </Sider>
                    <Layout className="site-layout">
                        <Content
                            className="site-layout-background"
                            style={{
                                margin: '5px',
                                marginBottom: '0',
                                padding: '10px',
                                border: '1px solid black',
                                background: 'white',
                                boxShadow: '0 0 10px 0 black',
                                borderRadius: '5px',
                                minHeight: '280px'
                            }}
                        >
                            <Switch>
                                {supplierRouters
                                    .filter((item: any) => !item.isLayout)
                                    .map((item: any, index: number) => (
                                        <Route key={index} path={item.path} component={item.component} exact={item.exact} />
                                    ))}
                                <Redirect from="/supplier" to="/supplier" />
                            </Switch>
                        </Content>
                    </Layout>
                </Layout>
                <Footer />
            </Col>
        );
    }
}

export default SupplierLayout;
