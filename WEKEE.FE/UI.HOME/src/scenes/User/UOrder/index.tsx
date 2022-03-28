//#region  import
import { Affix, Button, InputNumber } from 'antd'
import * as React from 'react';
import { useDispatch } from 'react-redux';
import "slick-carousel/slick/slick.css";
import "slick-carousel/slick/slick-theme.css";
import { createStructuredSelector } from 'reselect';
import { useInjectReducer, useInjectSaga } from '../../../redux/reduxInjectors';
import reducer from './reducer';
import saga from './saga';
import { makeSelectLoading } from './selectors';
import { Helmet } from 'react-helmet';
import { BulbFilled, BulbOutlined, DeleteOutlined, MinusOutlined, PlusOutlined } from '@ant-design/icons';
import { useState } from 'react';
//#endregion
export interface IHomeProps {
    location: any;
}
const key = 'home';
declare var abp: any;
const stateSelector = createStructuredSelector<any, any>({
    loading: makeSelectLoading()
});

export default function Home(props: IHomeProps) {
    useInjectReducer(key, reducer);
    useInjectSaga(key, saga);

    const dispatch = useDispatch();
    const [top, setTop] = useState(85);
    return (
        <>
            <Helmet>
                <link rel="stylesheet" href={abp.serviceAlbumCss + "/yHWHlILSmn.css"} />
            </Helmet>

            <div className="FClVwabhDA">
                <BulbFilled />  Nhấn vào mục Mã giảm giá ở cuối trang để hưởng miễn phí vận chuyển bạn nhé!
            </div>
            <div className="IbSOhqnFgD">
                <div>Tổng Thanh Toán</div>
                <div className="yAmftCcodk">Mã giảm giá</div>
                <div className="yAmftCcodk">Wekee</div>
                <Affix offsetTop={top}>
                    <div className="yAmftCcodk EesPHDVhYp">Tổng thanh toán (10) <span>₫15.000.000</span> <button>Mua Hàng</button></div>
                </Affix>
            </div>
            <div className="MvEnqdzVak">
                <span>Chi tiết</span>
            </div>
            <div className="JFZPyQvcms" style={{ background: '#40a9ff' }}>
                <div className="LTPAhmsjsr"></div>
                <div>Sản phẩm</div>
                <div>Phân loại</div>
                <div>Đơn giá</div>
                <div>Số lượng</div>
                <div>Thanh toán</div>
                <div>Thao tác</div>
            </div>

            <div className="IbSOhqnFgD">
                <div className="JFZPyQvcms dYzwOQqEAP">
                    <div className="LTPAhmsjsr"></div>
                    <div><img src={abp.serviceAlbumImage + '/product/wekee-wekee-065117d465185d35584804fb16f5ded6-011709-23092021--012154-23092021-S340x340.jpg'} alt="" /><a href="">Bộ Sticker dán cao cấp chủ đề ICON CÔNG NGHỆ - Dùng dán Xe</a></div>
                    <div>Kích thước : S, Màu sắc : Đỏ</div>
                    <div>₫15.000.000</div>
                    <div className='quirYXYDhV'>
                        <PlusOutlined className='ZKcRNZsCHm' />
                        <InputNumber className='JmuKvefzfZ' style={{ width: '50%' }} />
                        <MinusOutlined className='ZKcRNZsCHm' />
                    </div>
                    <div>₫15.000.000</div>
                    <div><DeleteOutlined /></div>
                </div>
                <div className="JFZPyQvcms dYzwOQqEAP">
                    <div className="LTPAhmsjsr"></div>
                    <div><img src={abp.serviceAlbumImage + '/product/wekee-wekee-065117d465185d35584804fb16f5ded6-011709-23092021--012154-23092021-S340x340.jpg'} alt="" /><a href="">Bộ Sticker dán cao cấp chủ đề ICON CÔNG NGHỆ - Dùng dán Xe</a></div>
                    <div>Kích thước : S, Màu sắc : Đỏ</div>
                    <div>₫15.000.000</div>
                    <div className='quirYXYDhV'>
                        <PlusOutlined className='ZKcRNZsCHm' />
                        <InputNumber className='JmuKvefzfZ' style={{ width: '50%' }} />
                        <MinusOutlined className='ZKcRNZsCHm' />
                    </div>
                    <div>₫15.000.000</div>
                    <div><DeleteOutlined /></div>
                </div>

                <div className="yAmftCcodk">Thêm mã giảm giá shop</div>
                <div className="yAmftCcodk">Giảm ₫25.000 phí vận chuyển đơn tối thiểu ₫50.000; Giảm ₫70.000 phí vận chuyển đơn tối thiểu ₫300.000
                    <a href="">Tìm hiểu thêm</a>
                </div>
            </div>
            <div className="IbSOhqnFgD">
                <div className="JFZPyQvcms dYzwOQqEAP">
                    <div className="LTPAhmsjsr"></div>
                    <div><img src={abp.serviceAlbumImage + '/product/wekee-wekee-065117d465185d35584804fb16f5ded6-011709-23092021--012154-23092021-S340x340.jpg'} alt="" /><a href="">Bộ Sticker dán cao cấp chủ đề ICON CÔNG NGHỆ - Dùng dán Xe</a></div>
                    <div>Kích thước : S, Màu sắc : Đỏ</div>
                    <div>₫15.000.000</div>
                    <div className='quirYXYDhV'>
                        <PlusOutlined className='ZKcRNZsCHm' />
                        <InputNumber className='JmuKvefzfZ' style={{ width: '50%' }} />
                        <MinusOutlined className='ZKcRNZsCHm' />
                    </div>
                    <div>₫15.000.000</div>
                    <div><DeleteOutlined /></div>
                </div>
                <div className="JFZPyQvcms dYzwOQqEAP">
                    <div className="LTPAhmsjsr"></div>
                    <div><img src={abp.serviceAlbumImage + '/product/wekee-wekee-065117d465185d35584804fb16f5ded6-011709-23092021--012154-23092021-S340x340.jpg'} alt="" /><a href="">Bộ Sticker dán cao cấp chủ đề ICON CÔNG NGHỆ - Dùng dán Xe</a></div>
                    <div>Kích thước : S, Màu sắc : Đỏ</div>
                    <div>₫15.000.000</div>
                    <div className='quirYXYDhV'>
                        <PlusOutlined className='ZKcRNZsCHm' />
                        <InputNumber className='JmuKvefzfZ' style={{ width: '50%' }} />
                        <MinusOutlined className='ZKcRNZsCHm' />
                    </div>
                    <div>₫15.000.000</div>
                    <div><DeleteOutlined /></div>
                </div>

                <div className="yAmftCcodk">Thêm mã giảm giá shop</div>
                <div className="yAmftCcodk">Giảm ₫25.000 phí vận chuyển đơn tối thiểu ₫50.000; Giảm ₫70.000 phí vận chuyển đơn tối thiểu ₫300.000
                    <a href="">Tìm hiểu thêm</a>
                </div>
            </div>
            <div className="IbSOhqnFgD">
                <div className="JFZPyQvcms dYzwOQqEAP">
                    <div className="LTPAhmsjsr"></div>
                    <div><img src={abp.serviceAlbumImage + '/product/wekee-wekee-065117d465185d35584804fb16f5ded6-011709-23092021--012154-23092021-S340x340.jpg'} alt="" /><a href="">Bộ Sticker dán cao cấp chủ đề ICON CÔNG NGHỆ - Dùng dán Xe</a></div>
                    <div>Kích thước : S, Màu sắc : Đỏ</div>
                    <div>₫15.000.000</div>
                    <div className='quirYXYDhV'>
                        <PlusOutlined className='ZKcRNZsCHm' />
                        <InputNumber className='JmuKvefzfZ' style={{ width: '50%' }} />
                        <MinusOutlined className='ZKcRNZsCHm' />
                    </div>
                    <div>₫15.000.000</div>
                    <div><DeleteOutlined /></div>
                </div>
                <div className="JFZPyQvcms dYzwOQqEAP">
                    <div className="LTPAhmsjsr"></div>
                    <div><img src={abp.serviceAlbumImage + '/product/wekee-wekee-065117d465185d35584804fb16f5ded6-011709-23092021--012154-23092021-S340x340.jpg'} alt="" /><a href="">Bộ Sticker dán cao cấp chủ đề ICON CÔNG NGHỆ - Dùng dán Xe</a></div>
                    <div>Kích thước : S, Màu sắc : Đỏ</div>
                    <div>₫15.000.000</div>
                    <div className='quirYXYDhV'>
                        <PlusOutlined className='ZKcRNZsCHm' />
                        <InputNumber className='JmuKvefzfZ' style={{ width: '50%' }} />
                        <MinusOutlined className='ZKcRNZsCHm' />
                    </div>
                    <div>₫15.000.000</div>
                    <div><DeleteOutlined /></div>
                </div>

                <div className="yAmftCcodk">Thêm mã giảm giá shop</div>
                <div className="yAmftCcodk">Giảm ₫25.000 phí vận chuyển đơn tối thiểu ₫50.000; Giảm ₫70.000 phí vận chuyển đơn tối thiểu ₫300.000
                    <a href="">Tìm hiểu thêm</a>
                </div>
            </div>
        </>
    )
}
