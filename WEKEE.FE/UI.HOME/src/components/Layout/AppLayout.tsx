import * as React from 'react';
import { Redirect, Route, Switch } from 'react-router-dom';
import { Col } from 'antd';

import Footer from '../../components/Footer';
import Header from '../../components/Header';
import { appRouters } from '../Router/router.config';

declare var abp: any;
//var urlImage = abp.appServiceUrlStaticFile + "/album/common/ezgif.com-gif-maker.gif";

export interface ILayoutProps {
}

export default function AppLayout(props: ILayoutProps) {

  return (
    <Col className="container">
      <Header />
      <div style={{ margin: '0px 30px 10px 30px' }}>
        <Switch>
          {appRouters
            .filter((item: any) => !item.isLayout)
            .map((item: any, index: number) => (
              <Route key={index} path={item.path} component={item.component} exact={item.exact} />
            ))}
          <Redirect from="/" to="/" />
        </Switch>
      </div>
      <Footer />
    </Col>
  );
}