import * as React from "react";
import { Col, Menu, Row } from "antd";
import AppComponentBase from "../../components/ComponentBase";
import { Helmet } from "react-helmet";
import "antd/dist/antd.css";
declare var abp: any;

export interface IHeaderAdminProps {
  collapsed?: any;
  toggle?: any;
}

export interface IHeaderAdminState {}
class HeaderAdmin extends AppComponentBase<
  IHeaderAdminProps,
  IHeaderAdminState
> {
  public render() {
    return (
      <Col className="hdfut">
        <Helmet>
          <link rel="stylesheet" href={abp.serviceAlbumCss + "/headerAdmin.css"} />
        </Helmet>
        <Row className="hdfutm">
          <Col span={4} className="hdfutmlg">
            <a href="#">
              <img src="" />
            </a>
          </Col>
          <Col span={20}></Col>
        </Row>
      </Col>
    );
  }
}

export default HeaderAdmin;
