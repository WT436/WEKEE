//#region  import
import {
  MenuUnfoldOutlined,
  MenuFoldOutlined,
  DashboardOutlined,
  ShoppingCartOutlined,
  GiftOutlined,
  SettingOutlined,
  CarOutlined,
  DatabaseOutlined,
  RiseOutlined,
  UsergroupAddOutlined,
  ShopOutlined,
} from "@ant-design/icons";
import { Button, Menu } from "antd";
import Sider from "antd/lib/layout/Sider";
import SubMenu from "antd/lib/menu/SubMenu";
import * as React from "react";
import { useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { Link } from "react-router-dom";
import { createStructuredSelector } from "reselect";
import { useInjectReducer, useInjectSaga } from "../../../redux/reduxInjectors";
import { watchPageStart } from "./actions";
import reducer from "./reducer";
import saga from "./saga";
import { makeSelectLoading } from "./selectors";
declare var abp: any;
//#endregion
export interface ISiderStoreProps {
  // đây
  location: any;
}
const key = "siderstore"; // đây
const stateSelector = createStructuredSelector<any, any>({
  loading: makeSelectLoading(),
});

export default function SiderStore(props: ISiderStoreProps) {
  // Đây
  useInjectReducer(key, reducer);
  useInjectSaga(key, saga);

  const dispatch = useDispatch();
  const { loading } = useSelector(stateSelector);
  useEffect(() => {
    dispatch(watchPageStart());
  }, []);

  let input = "";

  const onInputChange = (value: any) => {
    input = value.target.value;
  };
  const [collapsed, setcollapsed] = useState(false);
  return (
    <>
      <Sider trigger={null} collapsible collapsed={collapsed}>
        <div
          style={{
            overflowY: "scroll",
            overflowX: "hidden",
            maxWidth: "250px",
            maxHeight: "90vh",
          }}
        >
          <Menu
            defaultSelectedKeys={["item0_1"]}
            defaultOpenKeys={["item0_1"]}
            mode="inline"
            theme="dark"
            inlineCollapsed={collapsed}
          >
            <Button
              className=""
              onClick={() => setcollapsed(!collapsed)}
              style={{ width: "100%", margin: "5px 0" }}
            >
              {React.createElement(
                collapsed ? MenuUnfoldOutlined : MenuFoldOutlined
              )}
            </Button>
            <Menu.Item
              key="item0_1"
              defaultChecked={false}
              icon={<DashboardOutlined />}
            >
              <Link to="/supplier">Trình điều khiển</Link>
            </Menu.Item>
            <SubMenu
              key="sub1"
              icon={<ShoppingCartOutlined />}
              title="Đơn Hàng"
            >
              <Menu.Item key="item1_1">Option 9</Menu.Item>
              <SubMenu key="sub1_1" title="Kho">
                <Menu.Item key="item1_1_1">Option 11</Menu.Item>
              </SubMenu>
            </SubMenu>
            <SubMenu
              key="sub2"
              icon={<CarOutlined />}
              title="Vận Chuyển"
            >
              <Menu.Item key="item2_1">Option 9</Menu.Item>
              <SubMenu key="sub2_1" title="Kho">
                <Menu.Item key="item2_1_1">Option 11</Menu.Item>
              </SubMenu>
            </SubMenu>
            <SubMenu key="sub3" icon={<GiftOutlined />} title="Quản lý sản phẩm">
              <Menu.Item key="item3_1">Thống Kê</Menu.Item>
              <SubMenu key="sub3_1" title="Kho">
                <Menu.Item key="item3_1_1">
                  
                </Menu.Item>
              </SubMenu>
              <SubMenu key="sub3_2" title="Sản phẩm">
                <Menu.Item key="item3_2_1"><Link to="/store/product/new-product">Tạo Mới Sản Phẩm</Link></Menu.Item>
              </SubMenu>
            </SubMenu>
            <SubMenu
              key="sub4"
              icon={<ShoppingCartOutlined />}
              title="Marketting"
            >
              <Menu.Item key="item2_1">Option 9</Menu.Item>
              <SubMenu key="sub2_1" title="Kho">
                <Menu.Item key="item2_1_1">Option 11</Menu.Item>
              </SubMenu>
            </SubMenu>
            <SubMenu
              key="sub5"
              icon={<ShoppingCartOutlined />}
              title="Tài Chính"
            >
              <Menu.Item key="item2_1">Option 9</Menu.Item>
              <SubMenu key="sub2_1" title="Kho">
                <Menu.Item key="item2_1_1">Option 11</Menu.Item>
              </SubMenu>
            </SubMenu>
            <SubMenu key="sub6" icon={<DatabaseOutlined />} title="Dữ Liệu">
              <Menu.Item key="item2_1">Option 9</Menu.Item>
              <SubMenu key="sub2_1" title="Kho">
                <Menu.Item key="item2_1_1">Option 11</Menu.Item>
              </SubMenu>
            </SubMenu>
            <SubMenu
              key="sub7"
              icon={<RiseOutlined />}
              title="Tiềm Năng"
            >
              <Menu.Item key="item2_1">Option 9</Menu.Item>
              <SubMenu key="sub2_1" title="Kho">
                <Menu.Item key="item2_1_1">Option 11</Menu.Item>
              </SubMenu>
            </SubMenu>
            <SubMenu
              key="sub8"
              icon={<UsergroupAddOutlined />}
              title="Khách Hàng"
            >
              <Menu.Item key="item2_1">Option 9</Menu.Item>
              <SubMenu key="sub2_1" title="Kho">
                <Menu.Item key="item2_1_1">Option 11</Menu.Item>
              </SubMenu>
            </SubMenu>
            <SubMenu key="sub9" icon={<ShopOutlined />} title="Shop">
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
              <Menu.Item key="item10_1">
                <Link to="/supplier/store/information">Thông Tin Cửa Hàng</Link>
              </Menu.Item>
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
    </>
  );
}
