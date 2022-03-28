//#region  import
import * as React from 'react';
import { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { createStructuredSelector } from 'reselect';
import { useInjectReducer, useInjectSaga } from '../../redux/reduxInjectors';
import { watchPageStart } from './actions';
import reducer from './reducer';
import saga from './saga';
import { makeSelectLoading } from './selectors';
import { Badge, Button, Checkbox, Col, Collapse, Dropdown, Form, Input, Menu, Row } from 'antd';
import { CaretRightOutlined, CheckOutlined, DesktopOutlined, EllipsisOutlined, LockOutlined, SettingOutlined, UserOutlined } from '@ant-design/icons';
declare var abp: any;
const { Panel } = Collapse;
//#endregion
export interface IBaseProps { // đây
    location: any;
}
const key = 'base';// đây
const stateSelector = createStructuredSelector<any, any>({
    loading: makeSelectLoading()
});

const formItemLayout = {
    labelCol: {
        xs: { span: 24 },
        sm: { span: 10 },
    },
    wrapperCol: {
        xs: { span: 24 },
        sm: { span: 14 },
    },
};
export default function Base(props: IBaseProps) { // Đây
    useInjectReducer(key, reducer);
    useInjectSaga(key, saga);

    const dispatch = useDispatch();
    const { loading } = useSelector(stateSelector);
    useEffect(() => {
        dispatch(watchPageStart());
    }, []);

    const text = `
    A dog is a type of domesticated animal.
    Known for its loyalty and faithfulness,
    it can be found as a welcome guest in many households across the world.
  `;

    return (
        <>
         Basse
        </>
    )
}
