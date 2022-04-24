//#region import
import React from 'react'
import { useDispatch, useSelector } from 'react-redux';
import { createStructuredSelector } from 'reselect';
import { Rate } from 'antd';
import { makeSelectbasicProduct } from '../selectors';

declare var abp: any;
//#endregion

interface IChartsTopProductComponentProps {
    id: number;
}
const stateSelector = createStructuredSelector < any, any> ({
    basicProduct: makeSelectbasicProduct()
});

export default function ChartsTopProductComponent(props: IChartsTopProductComponentProps) {

    // const dispatch = useDispatch();

    const { basicProduct
    } = useSelector(stateSelector);

    return (
        <>
            <div className="LboUrliYOw">
                <div className="RnmeRAZZRs">
                    Thương hiệu : {basicProduct.trademark}
                    <a>{""}</a> | Đứng thứ 3 trong
                    <a href=""> Top 1000 Áo thun nữ bán chạy tháng này</a>
                </div>
                <div className="EQjksUFMJC">
                    {basicProduct.name}
                </div>
                <div className="xYeyreVUjs">
                    <Rate disabled defaultValue={2} /> (Xem 157 đánh giá) | Đã bán 537
                </div>
            </div>
        </>
    )
}
