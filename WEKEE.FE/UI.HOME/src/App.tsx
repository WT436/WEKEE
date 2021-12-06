import * as React from 'react';

import Router from './components/Router';

export interface IAppProps {
  
}

class App extends React.Component<IAppProps> {
  async componentWillMount() {
  }

  public render() {
    return (
      <div>
        <Router />
      </div>
    );
  }
}

export default App;
