import * as React from "react";
import { Redirect, Route, Switch } from "react-router-dom";
import { Col } from "antd";
import { adminRouters } from "../Router/router.config";
import HeaderAdmin from "../HeaderAdmin";
import Layout, { Content } from "antd/lib/layout/layout";
import { Helmet } from "react-helmet";
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
