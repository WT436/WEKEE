//#region  import
import * as React from 'react';
import { useDispatch } from 'react-redux';
import "slick-carousel/slick/slick.css";
import "slick-carousel/slick/slick-theme.css";
import { createStructuredSelector } from 'reselect';
import { useInjectReducer, useInjectSaga } from '../../redux/reduxInjectors';
import reducer from './reducer';
import saga from './saga';
import { makeSelectLoading } from './selectors';
import { Helmet } from 'react-helmet';
import { Tabs } from 'antd';
import ViewedComponents from './components/viewedComponents';
import LoveComponents from './components/loveComponents';
import CommentComponent from './components/commentComponent';
const { TabPane } = Tabs;
//#endregion
export interface IUViewedProps {
    location: any;
}
const key = 'uviewed';
declare var abp: any;
const stateSelector = createStructuredSelector<any, any>({
    loading: makeSelectLoading()
});

export default function UViewed(props: IUViewedProps) {
    useInjectReducer(key, reducer);
    useInjectSaga(key, saga);

    const dispatch = useDispatch();
    return (
        <>
            <Helmet>
                <link rel="stylesheet" href={abp.appServiceUrlStaticFile + "/fileCss/yHWHlILSmn.css"} />
            </Helmet>
            <Tabs defaultActiveKey="1">
                <TabPane tab="Sản phẩm đã xem" key="1">
                    <ViewedComponents />
                </TabPane>
                <TabPane tab="Sản phẩm yêu thích" key="2">
                    <LoveComponents />
                </TabPane>
                <TabPane tab="Đánh giá sản phẩm" key="3">
                    <CommentComponent />
                </TabPane>
            </Tabs>
        </>
    )
}
