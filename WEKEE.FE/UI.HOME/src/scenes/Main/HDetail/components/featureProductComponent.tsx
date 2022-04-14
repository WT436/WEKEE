//#region import
import React, { useEffect, useState } from 'react'
import { useDispatch, useSelector } from 'react-redux';
import { createStructuredSelector } from 'reselect';
import moment from 'moment';
import { CheckOutlined } from '@ant-design/icons';

declare var abp: any;
//#endregion

interface IFeatureProductComponentProps {

}
const stateSelector = createStructuredSelector < any, any> ({

});
export default function FeatureProductComponent(props: IFeatureProductComponentProps) {

    const dispatch = useDispatch();

    const {
    } = useSelector(stateSelector);

    return (
        <>
            <div className="wqPWTPYvMr">
                <p className="fBvRJBvshu">
                    {" "}
                    {"startKey1"} : <span>&nbsp;{"Key1State?.name"}</span>
                </p>
                <div className="ofRgAVTeYl">
                    <div
                        className="lPibOcgFQi"
                    >
                        <img
                            src={
                                abp.serviceAlbumImage + ""
                            }
                            alt=""
                        />
                        <span>{"item.value.replace"}</span>
                        <span
                            style={{
                                display: true ? "block" : "none",
                            }}
                            className="nuTLGkaQio"
                        >
                            <CheckOutlined className="SWzJAVZYWg" />
                        </span>
                    </div>
                </div>
            </div>
            <div className="wqPWTPYvMr">
                <p className="fBvRJBvshu">
                    {" "}
                    {"startKey2"} : <span>&nbsp; {"Key2State"}</span>
                </p>
                <div className="ofRgAVTeYl">
                    <div
                        className="lBHJWvVzaH"
                    >
                        <span>{"item.replace"}</span>
                        <span
                            style={{
                                display: true ? "block" : "none",
                            }}
                            className="nuTLGkaQio"
                        >
                            <CheckOutlined className="SWzJAVZYWg" />
                        </span>
                    </div>
                </div>
            </div>
        </>
    )
}
