import { HomeOutlined } from '@ant-design/icons';
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
        {/* <div className='navigation'>
          <ul>
            <li className='list active-navigation'>
              <a href="#">
                <span className='icon'><HomeOutlined /></span>
                <span className='text'>Home</span>
              </a>
            </li>
            <li className='list'>
              <a href="#">
                <span className='icon'><HomeOutlined /></span>
                <span className='text'>Home</span>
              </a>
            </li>
            <li className='list'>
              <a href="#">
                <span className='icon'><HomeOutlined /></span>
                <span className='text'>Home</span>
              </a>
            </li>
            <li className='list'>
              <a href="#">
                <span className='icon'><HomeOutlined /></span>
                <span className='text'>Home</span>
              </a>
            </li>
            <div className='indicator'></div>
          </ul>
        </div> */}
      </div>
    );
  }
}

export default App;
