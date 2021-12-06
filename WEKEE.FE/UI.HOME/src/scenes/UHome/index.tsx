//#region  import
import { Button, Row } from 'antd'
import * as React from 'react';
import { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { createStructuredSelector } from 'reselect';
import { useInjectReducer, useInjectSaga } from '../../redux/reduxInjectors';
import { watchPageStart } from './actions';
import reducer from './reducer';
import saga from './saga';
import {
    makeSelectLoading, makeSelectPageIndex, makeSelectPageSize,
    makeSelectTotalCount, makeSelectTotalPages
} from './selectors';
//#endregion
export interface IUHomeProps {
    location: any;
}
const key = 'uhome';
const stateSelector = createStructuredSelector<any, any>({
    loading: makeSelectLoading(),
    pageIndex: makeSelectPageIndex(),
    pageSize: makeSelectPageSize(),
    totalCount: makeSelectTotalCount(),
    totalPages: makeSelectTotalPages(),
});

export default function UHome(props: IUHomeProps) {
    useInjectReducer(key, reducer);
    useInjectSaga(key, saga);
    const dispatch = useDispatch();
    const { loading, pageIndex, pageSize, totalCount } = useSelector(stateSelector);
    useEffect(() => {
        dispatch(watchPageStart());
    }, []);

    return (
        <Row>
            <Button loading={loading}>asdda</Button>
        </Row>
    )
}
