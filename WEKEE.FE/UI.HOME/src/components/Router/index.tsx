import * as React from 'react';

import { Route, Switch } from 'react-router-dom';
import utils from '../../utils/utils';

const Router = () => {
  const UserLayout = utils.getRoute('/user').component;
  const SupplierLayout = utils.getRoute('/store').component;
  const AppLayout = utils.getRoute('/').component;
  const AdminLayout = utils.getRoute('/admin').component;
  const ErrorLayout = utils.getRoute('/error').component;

  return (
    <Switch>
      <Route path="/admin" render={(props: any) => <AdminLayout {...props} />} />
      <Route path="/user" render={(props: any) => <UserLayout {...props} />} />
      <Route path="/store" render={(props: any) => <SupplierLayout {...props} />} />
      <Route path="/error" render={(props: any) => <ErrorLayout {...props} />} />
      <Route path="/" render={(props: any) => <AppLayout {...props} />} />
    </Switch>
  );
};

export default Router;
