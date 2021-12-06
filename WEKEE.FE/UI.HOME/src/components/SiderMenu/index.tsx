import * as React from 'react';

import { Avatar, Col, Layout, Menu } from 'antd';
import { L } from '../../lib/abpUtility';

import AbpLogo from '../../images/mgm-log.png';
import { appRouters } from '../../components/Router/router.config';
import Icon from '@ant-design/icons/lib/components/Icon';

const { Sider } = Layout;
declare var abp: any;

export interface ISiderMenuProps {
  path: any;
  collapsed: boolean;
  onCollapse: any;
  history: any;
}

const SiderMenu = (props: ISiderMenuProps) => {
  const { collapsed, history, onCollapse } = props;
  return (
    <Sider trigger={null} className={'sidebar non-printable'} width={256} collapsible collapsed={collapsed} onCollapse={onCollapse}>
      {collapsed ? (
        <Col style={{ textAlign: 'center', marginTop: 15, marginBottom: 10 }}>
          <Avatar shape="square" style={{ height: 27, width: 64 }} src={AbpLogo} />
        </Col>
      ) : (
        <Col style={{ textAlign: 'center', marginTop: 15, marginBottom: 10 }}>
          <Avatar shape="square" style={{ height: 54, width: 180 }} src={AbpLogo} />
        </Col>
      )}
      
      <Menu theme="dark" mode="inline" selectedKeys={[props.history.location.pathname]}>
        {appRouters.sort((a: any, b: any) => {
          const indexA = a.index;
          const indexB = b.index;
          let comparison = 0;
          if (indexA > indexB) {
            comparison = 1;
          } else if (indexA < indexB) {
            comparison = -1;
          }
          return comparison;
        }).filter((item: any) => !item.isLayout && item.showInMenu).map((route: any, index: number) => {
          if (route.type === 'sub-menu') {
            var right = false;
            var roles = route.permission.split(",");
            roles.forEach((role: string) => {
              if (role){
                if (abp.auth.getRoles().indexOf(',' + role + ',') >= 0){
                  right = true;
                }
              }
            });
            if(right){
              return (
                <Menu.SubMenu 
                  key={index}
                  title={
                    <span>
                      <Icon type={route.icon} />
                      <span>{L(route.title)}</span>
                    </span>
                  }>
                  {
                    route.childrens.filter(function(item: any) {
                      return abp.auth.getRoles().indexOf(item.permission) >= 0;
                    }).map((item: any) => 
                      <Menu.Item key={item.path} onClick={() => {
                          localStorage.removeItem("screenData");
                          localStorage.removeItem("amt_Due_Or_Paid");
                          history.push(item.path);
                        }}>
                        <Icon type={item.icon} />
                        <span>{L(item.title)}</span>
                      </Menu.Item>
                    )
                  }
                </Menu.SubMenu>
              );
            }
            else{
              return null;
            }
          }
          else {
            var ri=false;
            var string= route.permission.split(',');
            string.forEach((element:string) => {
              if(element){
                if(abp.auth.getRoles().indexOf(','+element+',')>=0) ri= true;
              }
            });
            if(ri){
              return (
                <Menu.Item key={route.path} onClick={() => {
                    localStorage.removeItem("screenData");
                    localStorage.removeItem("amt_Due_Or_Paid");
                    history.push(route.path);
                  }}>
                  <Icon type={route.icon} />
                  <span>{L(route.title)}</span>
                </Menu.Item>
              );
            }
            else{
              return null;
            }
          }
        })}
      </Menu>
    </Sider>
  );
};

export default SiderMenu;
