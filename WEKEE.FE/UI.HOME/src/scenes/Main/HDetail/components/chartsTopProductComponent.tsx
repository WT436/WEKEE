//#region import
import React, { useEffect, useState } from 'react'
import { useDispatch, useSelector } from 'react-redux';
import { createStructuredSelector } from 'reselect';
import moment from 'moment';
import { Rate } from 'antd';

declare var abp: any;
//#endregion

interface IChartsTopProductComponentProps {

}
const stateSelector = createStructuredSelector < any, any> ({

});
export default function ChartsTopProductComponent(props: IChartsTopProductComponentProps) {

    const dispatch = useDispatch();

    const {
    } = useSelector(stateSelector);

    return (
        <>
            <div className="LboUrliYOw">
                <div className="RnmeRAZZRs">
                    Thương hiệu :{" "}
                    <a>{""}</a> | Đứng thứ
                    3 trong <a href="">Top 1000 Áo thun nữ bán chạy tháng này</a>
                </div>
                <div className="EQjksUFMJC">
                    {""}
                </div>
                <div className="xYeyreVUjs">
                    <Rate disabled defaultValue={2} /> (Xem 157 đánh giá) | Đã bán 537
                </div>
            </div>
        </>
    )
}
