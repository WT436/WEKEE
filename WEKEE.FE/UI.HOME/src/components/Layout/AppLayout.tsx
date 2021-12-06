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
  const [bl, setbl] = React.useState(true);
  // useEffect(() => {
  //   setTimeout(() => {
  //     Modal.confirm({
  //       title: bl ? "Rất xin lỗi vì sự làm phiền không đáng có này!" : "Dev said : Thế giờ muốn gì. uýnh nhau không? ",
  //       width: '40%',
  //       content: (
  //         <>
  //           {bl ? "Website hiện tại đang hoàn thiện bộ khung. chưa tích hợp phân quyền, chưa Responsive  và đang có nhiều lỗi không thèm fix.Quý khách thông cảm cho thằng dev nó lười!" : <div style={{ width: '100%', textAlign: 'center' }}><img src={urlImage} /></div>}
  //         </>
  //       ),
  //       autoFocusButton: null,
  //       okText: bl ? "Tôi hiểu mà!" : "Á Đù",
  //       cancelText: bl ? "Liên quan :)" : "Anh tạm tha cho chú!",
  //       onCancel() { setbl(false) }
  //     })
  //   }, 5000);
  // }, [bl]);

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