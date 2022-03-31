//#region  import
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
import { Button } from "antd";
import Sider from "antd/lib/layout/Sider";
import Menu from "antd/lib/menu";
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
export interface IMenuSliderAdminProps {
  // đây
  location: any;
}
const key = "menuslideradmin"; // đây
const stateSelector = createStructuredSelector<any, any>({
  loading: makeSelectLoading(),
});

const formItemLayout = {
  labelCol: {
    xs: { span: 24 },
    sm: { span: 10 },
  },
  wrapperCol: {
    xs: { span: 24 },
    sm: { span: 14 },
  },
};
export default function MenuSliderAdmin(props: IMenuSliderAdminProps) {
  // Đây
  useInjectReducer(key, reducer);
  useInjectSaga(key, saga);

  const dispatch = useDispatch();
  const { loading } = useSelector(stateSelector);
  useEffect(() => {
    dispatch(watchPageStart());
  }, []);

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
              defaultChecked={true}
              icon={<DashboardOutlined />}
            >
              <Link to="/admin">Trình điều khiển</Link>
            </Menu.Item>
            <SubMenu key="sub1" icon={<ShopOutlined />} title="Gian Hàng">
              <Menu.Item key="item1_1">Option 5</Menu.Item>
            </SubMenu>
            <SubMenu
              key="sub2"
              icon={<ShoppingCartOutlined />}
              title="Đơn Hàng"
            >
              <Menu.Item key="item2_1">Option 9</Menu.Item>
              <SubMenu key="sub2_1" title="Kho">
                <Menu.Item key="item2_1_1">Option 11</Menu.Item>
              </SubMenu>
            </SubMenu>
            <SubMenu
              key="sub3"
              icon={<UserSwitchOutlined />}
              title="Nhà cung cấp"
            >
              <Menu.Item key="item3_1">Thống Kê</Menu.Item>
              <Menu.Item key="item3_2">Trang của tôi</Menu.Item>
              <SubMenu key="sub3_1" title="Kho">
                <Menu.Item key="item3_1_1">Option 11</Menu.Item>
              </SubMenu>
            </SubMenu>
            <SubMenu key="sub4" icon={<GiftOutlined />} title="Sản Phẩm">
              <Menu.Item key="item4_1">
                {" "}
                <Link to="/admin/product">Chung</Link>
              </Menu.Item>
              <SubMenu key="sub4_1" title="Kho">
                <Menu.Item key="item4_1_1">Option 11</Menu.Item>
              </SubMenu>
            </SubMenu>
            <SubMenu key="sub5" icon={<ToolOutlined />} title="Tự động hóa">
              <Menu.Item key="item5_1">Option 6</Menu.Item>
            </SubMenu>
            <SubMenu key="sub6" icon={<CommentOutlined />} title="Thông điệp">
              <Menu.Item key="item6_1">Option 6</Menu.Item>
            </SubMenu>
            <SubMenu key="sub7" icon={<UserOutlined />} title="Tài khoản">
              <Menu.Item key="item7_1">
                <Link to="/admin/account">Chung</Link>
              </Menu.Item>
              <SubMenu key="sub7_1" title="Thao tác">
                <Menu.Item key="item7_1_1">Thêm tài khoản</Menu.Item>
              </SubMenu>
            </SubMenu>
            <SubMenu
              key="sub8"
              icon={<UsergroupAddOutlined />}
              title="Hội nhóm"
            >
              <Menu.Item key="item8_1">Option 6</Menu.Item>
            </SubMenu>
            <SubMenu key="sub9" icon={<FormOutlined />} title="Bài viết">
              <Menu.Item key="item9_1">Option 6</Menu.Item>
            </SubMenu>
            <SubMenu key="sub10" icon={<SettingOutlined />} title="Cài Đặt">
              <Menu.Item key="item10_1">Option 9</Menu.Item>
              <SubMenu key="sub10_1" title="Quyền Hạn">
                <Menu.Item key="item10_1_1">
                  <Link to="/admin/setting-role-basic">Chỉnh sửa gốc</Link>
                </Menu.Item>
                <Menu.Item key="item10_1_2">
                  <Link to="/admin/setting-role">Mặc định</Link>
                </Menu.Item>
              </SubMenu>
              <SubMenu key="sub10_2" title="Giao Diện">
                <Menu.Item key="item10_2_1">Option 11</Menu.Item>
              </SubMenu>
              <SubMenu key="sub10_3" title="Menu">
                <Menu.Item key="item10_3_1">Option 11</Menu.Item>
              </SubMenu>
              <SubMenu key="sub10_4" title="Sản phẩm">
                <Menu.Item key="item10_4_1">
                  <Link to="/admin/category">Chủ đề</Link>
                </Menu.Item>
                <Menu.Item key="item10_4_2">
                  <Link to="/admin/specifications-category">Thông số</Link>
                </Menu.Item>
                <Menu.Item key="item10_4_3">
                  <Link to="/admin/attribute-product">Thuộc tính</Link>
                </Menu.Item>
              </SubMenu>
            </SubMenu>
            <SubMenu key="sub11" icon={<TeamOutlined />} title="Người Dùng">
              <Menu.Item key="item11_1">Option 9</Menu.Item>
              <SubMenu key="sub11_1" title="Quyền Hạn">
                <Menu.Item key="item11_1_1"></Menu.Item>
              </SubMenu>
            </SubMenu>
            <SubMenu
              key="sub12"
              icon={<ReconciliationOutlined />}
              title="Quản lý Dữ liệu"
            >
              <Menu.Item key="item12_1">
                <Link to="/admin/data-management">Quản lý chung</Link>
              </Menu.Item>
              <SubMenu key="sub12_1" title="Album">
                <Menu.Item key="item12_1_1">
                  <Link to="/admin/data-management/album/image">Ảnh</Link>
                </Menu.Item>
                <Menu.Item key="item12_1_2">
                  <Link to="/admin/data-management/album/image">Video</Link>
                </Menu.Item>
                <Menu.Item key="item12_1_3">
                  <Link to="/admin/data-management/album/image">Ảnh</Link>
                </Menu.Item>
              </SubMenu>
            </SubMenu>
            <SubMenu
              key="sub13"
              icon={<AreaChartOutlined />}
              title="Thị Trường"
            >
              <Menu.Item key="item13_1">Option 9</Menu.Item>
              <SubMenu key="sub13_1" title="Quyền Hạn">
                <Menu.Item key="item13_1_1">Option 11</Menu.Item>
              </SubMenu>
            </SubMenu>
            <SubMenu key="sub14" icon={<DatabaseOutlined />} title="Hệ thống">
              <Menu.Item key="item14_1">
                <Link to="/admin/system/error">Lỗi Hệ thống</Link>
              </Menu.Item>
              <SubMenu key="sub14_1" title="Máy chủ">
                <Menu.Item key="item14_1_1">Option 11</Menu.Item>
                <Menu.Item key="item14_1_2">Option 12</Menu.Item>
              </SubMenu>
            </SubMenu>
          </Menu>
        </div>
      </Sider>
    </>
  );
}
