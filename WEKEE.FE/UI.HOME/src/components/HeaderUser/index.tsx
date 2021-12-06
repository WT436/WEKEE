import * as React from 'react';
import { Col, Input, Menu, Row, Select } from 'antd';
import AppComponentBase from '../../components/ComponentBase';
import { Helmet } from 'react-helmet';
import 'antd/dist/antd.css';
import { AuditOutlined, BellOutlined, CodeSandboxOutlined, CreditCardOutlined, DollarCircleOutlined, HomeOutlined, PhoneOutlined, PieChartOutlined, PlusOutlined, QuestionCircleOutlined, RiseOutlined, SettingOutlined, ShoppingCartOutlined, SoundOutlined, UnorderedListOutlined, UsergroupAddOutlined } from '@ant-design/icons'
const { Option } = Select;
const { SubMenu } = Menu;
export interface IHeaderUserProps {
    collapsed?: any;
    toggle?: any;
}

export interface IHeaderUserState {

}
class HeaderUser extends AppComponentBase<IHeaderUserProps, IHeaderUserState> {

    public render() {
        return (
            <Col className='hdfut'>
                <Helmet>
                    <link rel="stylesheet" href="https://localhost:44324/StaticFiles/header/header.css" />
                </Helmet>
                <Row className='hdfutm'>
                    <Col span={4} className='hdfutmlg'>
                        <a href='#'><img src='' /></a>
                    </Col>
                    <Col span={20}>
                        <Row>
                            <Col span={16} className='hdfutmips'>
                                <Input.Group compact>
                                    <Select defaultValue="Option1">
                                        <Option value="Option1">Tất Cả</Option>
                                        <Option value="Option2">Option2</Option>
                                    </Select>
                                    <Input.Search className='hdfutmipsdt' style={{ width: '60%' }} placeholder='Tìm kiếm sản phẩm, nhà cung cấp' />
                                </Input.Group>
                            </Col>
                            <Col span={8}>
                                <Menu mode="horizontal" className='hdfutmsttac'>
                                    <SubMenu icon={<PlusOutlined className='hdfutmacic' />}>
                                    </SubMenu>
                                    <SubMenu icon={<CodeSandboxOutlined className='hdfutmacic' />}>
                                        <Menu.Item key="setting:1">Option 1 </Menu.Item>
                                        <Menu.Item key="setting:2">Option 2</Menu.Item>
                                    </SubMenu>
                                    <SubMenu icon={<BellOutlined className='hdfutmacic' />}>
                                        <Menu.Item key="setting:1">Option 1</Menu.Item>
                                        <Menu.Item key="setting:2">Option 2</Menu.Item>
                                    </SubMenu>
                                    <SubMenu icon={<SettingOutlined className='hdfutmacic' />}>
                                        <Menu.Item key="setting:1">Option 1</Menu.Item>
                                        <Menu.Item key="setting:2">Option 2</Menu.Item>
                                    </SubMenu>
                                    <SubMenu icon={<QuestionCircleOutlined className='hdfutmacic' />}>
                                        <Menu.Item key="setting:1">Option 1</Menu.Item>
                                        <Menu.Item key="setting:2">Option 2</Menu.Item>
                                    </SubMenu>
                                    <img className='hdfutmacim' src='' />
                                </Menu>
                            </Col>
                        </Row>
                        <Row>
                            <Menu mode="horizontal" className='hdmnctgr hdfutmsttac'>
                                <SubMenu icon={<HomeOutlined />} title='Tổng quan'>
                                    <Menu.Item key="setting:1">Option 1</Menu.Item>
                                    <Menu.Item key="setting:2">Option 2</Menu.Item>
                                </SubMenu>
                                <SubMenu icon={<RiseOutlined />} title='Tiềm năng'>
                                    <Menu.Item key="setting:1">Option 1</Menu.Item>
                                    <Menu.Item key="setting:2">Option 2</Menu.Item>
                                </SubMenu>
                                <SubMenu icon={<PhoneOutlined />} title='Liên Hệ'>
                                    <Menu.Item key="setting:1">Option 1</Menu.Item>
                                    <Menu.Item key="setting:2">Option 2</Menu.Item>
                                </SubMenu>
                                <SubMenu icon={<UsergroupAddOutlined />} title='Khách Hàng'>
                                    <Menu.Item key="setting:1">Option 1</Menu.Item>
                                    <Menu.Item key="setting:2">Option 2</Menu.Item>
                                </SubMenu>
                                <SubMenu icon={<CreditCardOutlined />} title='Cơ Hội'>
                                    <Menu.Item key="setting:1">Option 1</Menu.Item>
                                    <Menu.Item key="setting:2">Option 2</Menu.Item>
                                </SubMenu>
                                <SubMenu icon={<ShoppingCartOutlined />} title='Đơn Hàng'>
                                    <Menu.Item key="setting:1">Option 1</Menu.Item>
                                    <Menu.Item key="setting:2">Option 2</Menu.Item>
                                </SubMenu>
                                <SubMenu icon={<DollarCircleOutlined />} title='Báo Giá'>
                                    <Menu.Item key="setting:1">Option 1</Menu.Item>
                                    <Menu.Item key="setting:2">Option 2</Menu.Item>
                                </SubMenu>
                                <SubMenu icon={<AuditOutlined />} title='Hóa Đơn'>
                                    <Menu.Item key="setting:1">Option 1</Menu.Item>
                                    <Menu.Item key="setting:2">Option 2</Menu.Item>
                                </SubMenu>
                                <SubMenu icon={<PieChartOutlined />} title='Báo Cáo'>
                                    <Menu.Item key="setting:1">Option 1</Menu.Item>
                                    <Menu.Item key="setting:2">Option 2</Menu.Item>
                                </SubMenu>
                                <SubMenu icon={<SoundOutlined />} title='Chiến Dịch'>
                                    <Menu.Item key="setting:1">Option 1</Menu.Item>
                                    <Menu.Item key="setting:2">Option 2</Menu.Item>
                                </SubMenu>
                            </Menu>
                        </Row>
                    </Col>
                </Row>
            </Col>
        );
    }
}

export default HeaderUser;
