import * as React from "react";
import { Redirect, Route, Switch } from "react-router-dom";
import { Col, Input, Modal, Tooltip } from "antd";
import Footer from "../Footer";
import { supplierRouters } from "../Router/router.config";
import HeaderSupplier from "../HeaderSupplier";
import Layout, { Content } from "antd/lib/layout/layout";
import SelectStore from "../../scenes/Store/SelectStore";
import SliderStorce from "../../scenes/Store/SiderStore";
declare var abp: any;
class SupplierLayout extends React.Component<any> {

  async componentDidMount(): Promise<void> {
    // var permission = true; //await LCPermission.checkSupplier();
    // if (!permission) {
    //   window.location.href = "/login";
    //   abp.auth.setSupplier("", undefined);
    // } else {
    //   if (!abp.auth.getTokenSupplier()) {
    //     Modal.confirm({
    //       title: "Shop " + permission + " yêu cầu mật khẩu.",
    //       width: "40%",
    //       content: (
    //         <div>
    //           <Tooltip
    //             title={
    //               "Nếu bạn đăng nhập lần đầu thì mật khẩu là mật khẩu của tài khoản tạo shop"
    //             }
    //           >
    //             <Input.Password
    //               placeholder="Mật khẩu shop"
    //             />
    //           </Tooltip>
    //         </div>
    //       ),
    //       autoFocusButton: null,
    //       okButtonProps: {},
    //       okText: "Đăng Nhập",
    //       cancelText: "Thoát",
    //       onCancel() {
    //         window.location.href = "/";
    //       },
    //       onOk: async () => {
    //         var tokenLogin = true; //await LCPermission.loginSupplier(input);
    //         if (!tokenLogin) {
    //           Modal.warning({
    //             title: "Mật khẩu không chính xác",
    //             content: "Nhập lại mật khẩu sau 1s",
    //           });
    //           setTimeout(() => {
    //             window.location.href = "/supplier";
    //           }, 1000);
    //         } else {
    //           abp.auth.setSupplier(abp.auth.getToken(), undefined);
    //         }
    //       },
    //     });
    //   }
    // }
  }

  render() {
    return (
      <Col className="container">
        <HeaderSupplier />
        <Layout>
          <SliderStorce location={undefined}/>
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
              }}
            >
              <Switch>
                {supplierRouters
                  .filter((item: any) => !item.isLayout)
                  .map((item: any, index: number) => (
                    <Route
                      key={index}
                      path={item.path}
                      component={item.component}
                      exact={item.exact}
                    />
                  ))}
                <Redirect from="/supplier" to="/supplier" />
              </Switch>
            </Content>
          </Layout>
        </Layout>
        {/* <Modal
          className="YTBJIVHEoW"
          footer={null}
          closable={false}
          visible={false}
        >
          <SelectStore location={undefined} />
        </Modal> */}
      </Col>
    );
  }
}

export default SupplierLayout;
