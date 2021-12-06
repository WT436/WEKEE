import * as React from 'react';
import { Redirect, Route, Switch } from 'react-router-dom';
import { Col } from 'antd';
import Footer from '../Footer';
import { errorRouters } from '../Router/router.config';

class ErrorLayout extends React.Component<any> {
    render() {
        return (
            <Col className="container">
                <Switch>
                    {errorRouters
                        .filter((item: any) => !item.isLayout)
                        .map((item: any, index: number) => (
                            <Route key={index} path={item.path} component={item.component} exact={item.exact} />
                        ))}
                    <Redirect from="/error" to="/error" />
                </Switch>
                <Footer />
            </Col>
        );
    }
}

export default ErrorLayout;
