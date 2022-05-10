//#region  import
import { Button, Row } from 'antd'
import * as React from 'react';
import { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { createStructuredSelector } from 'reselect';
import { useInjectReducer, useInjectSaga } from '../../../redux/reduxInjectors';
import { watchPageStart } from './actions';
import reducer from './reducer';
import saga from './saga';
import { makeSelectLoading } from './selectors';
//#endregion
export interface IHomeProps {
    location: any;
}
const key = 'home';
const stateSelector = createStructuredSelector<any, any>({
    loading: makeSelectLoading()
});

export default function Home(props: IHomeProps) {
    useInjectReducer(key, reducer);
    useInjectSaga(key, saga);
    const dispatch = useDispatch();
    const { loading } = useSelector(stateSelector);
    useEffect(() => {
    }, []);

    return (
        <Row>
            <Button loading={loading}>asdda</Button>
        </Row>
    )
}
