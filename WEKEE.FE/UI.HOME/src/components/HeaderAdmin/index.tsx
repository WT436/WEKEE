import * as React from 'react';
import { Badge, Col, Input, Menu, Row, Select } from 'antd';
import AppComponentBase from '../../components/ComponentBase';
import { Helmet } from 'react-helmet';
import 'antd/dist/antd.css';
import { AuditOutlined, BellOutlined, CodeSandboxOutlined, CreditCardOutlined,
     DollarCircleOutlined, HomeOutlined, PhoneOutlined, PieChartOutlined, PlusOutlined,
      QuestionCircleOutlined, RiseOutlined, SettingOutlined, ShoppingCartOutlined, SoundOutlined, UsergroupAddOutlined } from '@ant-design/icons'
const { Option } = Select;
const { SubMenu } = Menu;
export interface IHeaderAdminProps {
    collapsed?: any;
    toggle?: any;
}

export interface IHeaderAdminState {

}
class HeaderAdmin extends AppComponentBase<IHeaderAdminProps, IHeaderAdminState> {

    public render() {
        return (
            <Col className='hdfut'>
                <Helmet>
                    <link rel="stylesheet" href="https://localhost:44324/StaticFiles/header/header.css" />
                </Helmet>
                <Row className='hdfutm'>
                    <Col span={4} className='hdfutmlg'>
                        <a href='#'><img src=''/></a>
                    </Col>
                    <Col span={20}>
                    </Col>
                </Row>
            </Col>
        );
    }
}

export default HeaderAdmin;
