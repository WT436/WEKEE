import React, { Component } from 'react'
import { Redirect } from 'react-router-dom';
interface IAutologin {
    history: any;
    location: any;
}
declare var abp: any;
export default class index extends Component<IAutologin> {
    render() {
        let { loginUrl } = { loginUrl: { pathname: '/user/login' } };
        let { adminUrl } = { adminUrl: { pathname: '/admin' } };

        var auth = this.props.location.search;
        if (auth) {
            abp.auth.setToken(this.props.location.search.substring(6, this.props.location.search.length), undefined);
            return <Redirect to={adminUrl} />;
        }
        else {
            return <Redirect to={loginUrl} />;
        }
    }
}
