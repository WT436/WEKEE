import * as React from 'react';

export interface ILogoutProps {

}

class Logout extends React.Component<ILogoutProps> {
  componentDidMount() {
    window.location.href = '/user/login';
  }

  render() {
    return null;
  }
}

export default Logout;
