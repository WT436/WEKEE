import * as React from "react";
import { Redirect, Route, Switch } from "react-router-dom";
import { Button, Col, Menu } from "antd";

import Footer from "../Footer";
import { adminRouters } from "../Router/router.config";
import HeaderAdmin from "../HeaderAdmin";
import SubMenu from "antd/lib/menu/SubMenu";
import Layout, { Content } from "antd/lib/layout/layout";
import Sider from "antd/lib/layout/Sider";
import { Helmet } from "react-helmet";
import { Link } from "react-router-dom";
import {
  MenuUnfoldOutlined,
  MenuFoldOutlined,
  DashboardOutlined,
  ShopOutlined,
  ShoppingCartOutlined,
  UserSwitchOutlined,
  GiftOutlined,
  ToolOutlined,
  CommentOutlined,
  UserOutlined,
  UsergroupAddOutlined,
  FormOutlined,
  SettingOutlined,
  TeamOutlined,
  ReconciliationOutlined,
  AreaChartOutlined,
  DatabaseOutlined,
} from "@ant-design/icons";
import MenuSliderAdmin from "../../scenes/Admin/MenuSliderAdmin";

declare var abp: any;
var urlCss = abp.serviceAlbumCss + "/login.css";

class AdminLayout extends React.Component<any> {
  state = {
    collapsed: false,
  };

  render() {
    return (
      <Col className="container">
        <Helmet>
          <link rel="stylesheet" href={urlCss} />
        </Helmet>
        <HeaderAdmin />
        <Layout>
          <MenuSliderAdmin location={undefined} />
          <Layout className="site-layout">
            <Content
              className="site-layout-background"
              style={{
                margin: "5px",
                marginBottom: "0",
                padding: "10px",
                border: "1px solid black",
                background: "white",
                boxShadow: "0 0 10px 0 black",
                borderRadius: "5px",
                minHeight: "280px",
                overflow: "hidden",
              }}
            >
              <Switch>
                {adminRouters
                  .filter((item: any) => !item.isLayout)
                  .map((item: any, index: number) => (
                    <Route
                      key={index}
                      path={item.path}
                      component={item.component}
                      exact={item.exact}
                    />
                  ))}
                <Redirect from="/admin" to="/admin" />
              </Switch>
            </Content>
          </Layout>
        </Layout>
      </Col>
    );
  }
}

export default AdminLayout;
