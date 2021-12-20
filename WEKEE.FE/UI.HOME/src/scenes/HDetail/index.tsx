//#region  import
import { Breadcrumb, Button, Col, Input, InputNumber, Modal, Pagination, Progress, Rate, Row, Select, Typography } from 'antd'
import * as React from 'react';
import { useEffect, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { createStructuredSelector } from 'reselect';
import { useInjectReducer, useInjectSaga } from '../../redux/reduxInjectors';
import { getCategoryBreadcrumbStart, getProductCardStart } from './actions';
import reducer from './reducer';
import saga from './saga';
import { makeSelectcategoryBreadcrumbDtos, makeSelectimageS1360x1360, makeSelectimageS340x340, makeSelectimageS80x80, makeSelectLoading, makeSelectstartKey1, makeSelectstartKey2, makeSelectstartValues1, makeSelectstartValues2, makeSelectunitCardProduct } from './selectors';
import ReactImageMagnify from 'react-image-magnify';
import { Helmet } from 'react-helmet';
import {
    CheckOutlined, CloseCircleOutlined, DislikeOutlined, DropboxOutlined, EllipsisOutlined, FileImageOutlined, GiftOutlined, HeartOutlined, HistoryOutlined,
    HomeOutlined, LikeOutlined, MessageOutlined, MinusOutlined, PlusOutlined,
    ShareAltOutlined, ShopOutlined, SmileOutlined, StarFilled, StarOutlined
} from '@ant-design/icons';
import BasicSeo from '../../components/Seo/basicSeo';
import { CategoryBreadcrumbDtos } from './dtos/categoryBreadcrumbDtos';
import { HighlightProductCardDtos } from './dtos/highlightProductCardDtos'
import { LazyLoadImage } from 'react-lazy-load-image-component';
import 'react-lazy-load-image-component/src/effects/blur.css';
import { ImageProductCardDtos } from './dtos/imageProductCardDtos';
import Slider from 'react-slick';
import "slick-carousel/slick/slick.css";
import "slick-carousel/slick/slick-theme.css";
import YouAssessmentComponent from './components/youAssessmentComponent';
import AssessmentComponent from './components/assessmentComponent';
import CardProduct from '../../components/CardProduct';
import { FeatureProductCardDtos } from './dtos/featureProductCardDtos';
import GoogleMapComponents from '../../components/GoogleMapComponents';
const { Option } = Select;
const { Text } = Typography;

//#endregion
export interface IHDetailProps {
    location: any;
    i: any;
}

declare var abp: any;
var urlCss = abp.serviceAlbumCss + "/detail.css";
const key = 'hdetail';
const stateSelector = createStructuredSelector<any, any>({
    loading: makeSelectLoading(),
    categoryBreadcrumbDtos: makeSelectcategoryBreadcrumbDtos(),
    unitCardProduct: makeSelectunitCardProduct(),
    imageS80x80: makeSelectimageS80x80(),
    imageS340x340: makeSelectimageS340x340(),
    imageS1360x1360: makeSelectimageS1360x1360(),
    startKey1: makeSelectstartKey1(),
    startKey2: makeSelectstartKey2(),
    startValues1: makeSelectstartValues1(),
    startValues2: makeSelectstartValues2()
});

export default function HDetail(props: IHDetailProps) {
    useInjectReducer(key, reducer);
    useInjectSaga(key, saga);
    const dispatch = useDispatch();
    const { categoryBreadcrumbDtos, unitCardProduct,
        imageS80x80, imageS340x340, imageS1360x1360,
        startKey1, startKey2, startValues1, startValues2
    } = useSelector(stateSelector);

    const [routes, setroutes] = useState<{ path: string; breadcrumbName: any; }[]>([]);

    useEffect(() => {
        var id = props.location.pathname.substring(props.location.pathname.lastIndexOf("/adsid=") + 7);
        dispatch(getCategoryBreadcrumbStart(id));
        dispatch(getProductCardStart(id));
    }, []);

    useEffect(() => {
        setroutes([]);
        categoryBreadcrumbDtos.forEach((element: CategoryBreadcrumbDtos) => {
            routes[element.levelCategory] = {
                path: element.urlCategory,
                breadcrumbName: element.nameCategory
            }
        });
        setroutes(routes);
    }, [categoryBreadcrumbDtos]);

    const [selectImage, setselectImage] = useState(0);
    const [zoomImage, setzoomImage] = useState({
        smallImage: {
            alt: '',
            isFluidWidth: true,
            src: ''
        },
        largeImage: {
            src: '',
            width: 900,
            height: 900
        }
    });

    useEffect(() => {
        if (imageS340x340.length > 0) {
            setzoomImage({
                smallImage: {
                    alt: imageS340x340[0].alt,
                    isFluidWidth: true,
                    src: abp.serviceAlbumImage + imageS340x340[0].src
                },
                largeImage: {
                    src: abp.serviceAlbumImage + imageS1360x1360[0].src,
                    width: 900,
                    height: 900
                }
            });
        }
    }, [imageS340x340, unitCardProduct])

    const onSelectImageZoom = (value: number) => {
        imageS80x80.map((element: ImageProductCardDtos) => { if (element.imageRoot === value) { setselectImage(element.id); } })

        var data340: ImageProductCardDtos = {
            id: 0,
            src: '',
            alt: '',
            title: '',
            size: '',
            folder: '',
            product: 0,
            imageRoot: 0
        };

        imageS340x340.forEach((element: ImageProductCardDtos) => {
            if (element.imageRoot === value) {
                data340 = element;
            }
        });

        var dataS1360x1360: ImageProductCardDtos = {
            id: 0,
            src: '',
            alt: '',
            title: '',
            size: '',
            folder: '',
            product: 0,
            imageRoot: 0
        };

        imageS1360x1360.forEach((element: ImageProductCardDtos) => {
            if (element.imageRoot === value) {
                dataS1360x1360 = element;
            }
        });

        setzoomImage({
            smallImage: {
                alt: data340.alt,
                isFluidWidth: true,
                src: abp.serviceAlbumImage + data340.src
            },
            largeImage: {
                src: abp.serviceAlbumImage + dataS1360x1360.src,
                width: 900,
                height: 900
            }
        });
    }

    const settings3 = {
        dots: false,
        infinite: true,
        speed: 1000,
        slidesToShow: 5,
        slidesToScroll: 3,
        autoplay: true,
        autoplaySpeed: 5000,
        pauseOnHover: true
    };

    const [Key1State, setKey1State] = useState<{ name: string, imageRoot: number }>();
    const [Key2State, setKey2State] = useState("");
    const [price, setprice] = useState(0);
    const [priceMarket, setpriceMarket] = useState(0);
    const [discount, setdiscount] = useState(0);
    const [timeDiscount, settimeDiscount] = useState<string>();

    useEffect(() => {
        if (Key1State && Key2State) {
            var data = unitCardProduct
                .featureProductCardDtos
                .filter((x: FeatureProductCardDtos) =>
                (x.properties1.replace(" ", "") === Key1State.name.replace(" ", "")
                    && x.properties2.replace(" ", "") === Key2State.replace(" ", "")))[0];
            setprice(data?.price);
            setpriceMarket(data?.priceMarket);
            onSelectImageZoom(data.image);
        }
        else {
            if (Key1State) {
                var data = unitCardProduct.featureProductCardDtos.filter((x: FeatureProductCardDtos) => (x.image === Key1State.imageRoot && x.properties1 === Key1State.name))[0];
                setprice(data?.price);
                setpriceMarket(data?.priceMarket);
                onSelectImageZoom(data.image);
            }
            if (Key2State) {
                var data = unitCardProduct.featureProductCardDtos.filter((x: FeatureProductCardDtos) => (x.properties2 === Key2State))[0];
                setprice(data?.price);
                setpriceMarket(data?.priceMarket);
                onSelectImageZoom(data.image);
            }
        }
    }, [Key2State, Key1State]);

    useEffect(() => {
        setprice(unitCardProduct.featureProductCardDtos[0]?.price);
        setpriceMarket(unitCardProduct.featureProductCardDtos[0]?.priceMarket)
    }, [unitCardProduct]);

    useEffect(() => {
        setdiscount(parseInt(((1 - (price / priceMarket)) * 100).toFixed(0)));
    }, [price, priceMarket]);

    var x = setInterval(function () {

        // Get today's date and time
        var now = new Date().getTime();

        // Find the distance between now and the count down date
        var distance = new Date("Jan 5, 2022 15:37:25").getTime() - now;

        // Time calculations for days, hours, minutes and seconds
        var days = Math.floor(distance / (1000 * 60 * 60 * 24));
        var hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
        var minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
        var seconds = Math.floor((distance % (1000 * 60)) / 1000);

        // Display the result in the element with id="demo"
        settimeDiscount(days + " : " + hours + " : "
            + minutes + " : " + seconds);

        // If the count down is finished, write some text
        if (distance < 0) {
            clearInterval(x);
            settimeDiscount("");
        }
    }, 1000);

    const [openintroduce, setopenintroduce] = useState(false);
    // google map
    const [visible, setVisible] = useState(false);
    return (
        <>
            <BasicSeo />
            <Helmet>
                <link rel="stylesheet" href={urlCss} />
                <link rel="stylesheet" href={abp.serviceAlbumCss + "/discountProduct.css"} />
                <link rel="stylesheet" href={abp.serviceAlbumCss + "/home.css"} />
            </Helmet>

            {<ul className='GjLseculzy'>
                <li><a href="/"><HomeOutlined /></a></li>
                {categoryBreadcrumbDtos.sort((m: CategoryBreadcrumbDtos) => m.levelCategory)
                    .reverse((m: CategoryBreadcrumbDtos) => m.levelCategory)
                    .map((element: CategoryBreadcrumbDtos, index: number) => {
                        //className="GjLseculzyac"
                        if (element.levelCategory == categoryBreadcrumbDtos.length) {
                            return (<li key={index}><a className="GjLseculzyac" href={element.urlCategory}> {element.nameCategory}</a></li>);
                        }
                        else {
                            return (<li key={index}><a href={element.urlCategory}> {element.nameCategory}</a></li>);
                        }
                    })}
            </ul>}

            <Row>
                <Col span={7} className='lIiNahOSjz'>
                    <div className="diTRzvSLbS">
                        <ReactImageMagnify style={{ zIndex: 10 }}  {...zoomImage} />
                    </div>
                    <div className="CDBhRpMxwl">
                        <Slider {...settings3}>
                            {
                                imageS80x80.map((element: ImageProductCardDtos) => {
                                    return (<img className={"LmqLbjIyYc" + " " + (selectImage === element.id ? "bFpTBTrDfH" : "")} onClick={() => onSelectImageZoom(element.imageRoot)} src={abp.serviceAlbumImage + element.src} alt={element.alt} />)
                                })
                            }
                        </Slider>
                    </div>
                    <Row style={{ marginTop: 10 }}>
                        <hr className='BozncDhktp' />
                        <Button className='ReUuFHMkvq' size='small' icon={<HeartOutlined />}>Like</Button>
                        <Button className='ReUuFHMkvq' size='small' icon={<MessageOutlined />}>Đánh Giá</Button>
                        <Button className='ReUuFHMkvq' size='small' icon={<ShareAltOutlined />}>Chia sẻ</Button>
                        <hr className='BozncDhktp' />
                    </Row>
                    <Row className='qFCWRAtWva'>
                        <Col span={6}>
                            <div style={{ position: 'relative' }}>
                                <img className='cUNLNWbjKS' src={abp.serviceAlbumImage + '/product/wekee-wekee-065117d465185d35584804fb16f5ded6-011709-23092021--012154-23092021-S340x340.jpg'} alt="" />
                                <HistoryOutlined
                                    className='QtHTvWzBal' />
                            </div>
                        </Col>
                        <Col span={18}>
                            <a className='XhuOxcXgNZ' href="#"> Bé mèo vàng</a>
                            <div style={{ display: 'flex', width: '100%' }}>
                                <Button className='PhtnSETPFW' size='small' icon={<ShopOutlined />}>Shop</Button>
                                <Button className='PhtnSETPFW' size='small' icon={<MessageOutlined />}>Chat</Button>
                                <Button className='PhtnSETPFW' size='small' icon={<PlusOutlined />}>Follow</Button>
                            </div>
                            <div style={{ display: 'flex', width: '100%' }}>
                                <img className='AhhxWVRcUP' />
                                <img className='AhhxWVRcUP' />
                                <img className='AhhxWVRcUP' />
                                <img className='AhhxWVRcUP' />
                                <img className='AhhxWVRcUP' />
                                <img className='AhhxWVRcUP' />
                                <img className='AhhxWVRcUP' />
                            </div>
                        </Col>
                        <Col span={24}></Col>
                    </Row>
                </Col>
                <Col style={{ width: 'calc(100% - 340px)', paddingLeft: '10px' }}>
                    <div className='LboUrliYOw'>
                        <div className='RnmeRAZZRs'>
                            Thương hiệu : <a>{unitCardProduct.productCardDtos.nameTrademark}</a> | Đứng thứ 3 trong <a href="">Top 1000 Áo thun nữ bán chạy tháng này</a>
                        </div>
                        <div className='EQjksUFMJC'>{unitCardProduct.productCardDtos.name}</div>
                        <div className='xYeyreVUjs'>
                            <Rate disabled defaultValue={2} />  (Xem 157 đánh giá) | Đã bán 537
                        </div>
                    </div>
                    <Row>
                        <Col className='otSUEGfNRF'>
                            <div className='AEQBszOavW'>
                                <div className="dcp-khung">
                                    <span className="dcp-khung-before"></span>
                                    <span className="dcp-loi">
                                        <span className="dcp-base">
                                            <span>-{discount}%</span>
                                        </span>
                                    </span>
                                </div>
                                <div className='oibhFVaXiQ'>
                                    {
                                        new Intl.NumberFormat('vi-VN', { style: 'currency', currency: 'VND' }).format(price)
                                    }
                                    <div><span>{
                                        new Intl.NumberFormat('vi-VN', { style: 'currency', currency: 'VND' }).format(priceMarket)
                                    }
                                    </span><span>{timeDiscount}</span></div></div>
                                <div className='BwzPWPYcLd'><GiftOutlined className='OGxbvhkgxM' /> Mưa quà tặng : </div>
                                <div className='BwzPWPYcLd'><GiftOutlined className='OGxbvhkgxM' /> FreeShip : </div>
                                <div className='BwzPWPYcLd'><GiftOutlined className='OGxbvhkgxM' /> Giảm giá : </div>
                            </div>
                            <div className='wqPWTPYvMr'>
                                <p className='fBvRJBvshu'> {startKey1} : <span>&nbsp;{Key1State?.name}</span></p>
                                <div className='ofRgAVTeYl'>
                                    {startValues1.map((item: { value: string, img: number }) => {
                                        return (
                                            <div className='lPibOcgFQi' onClick={() => setKey1State({ name: item.value, imageRoot: item.img })}>
                                                <img src={abp.serviceAlbumImage + unitCardProduct.imageProductCardDtos.filter((x: ImageProductCardDtos) => (x.imageRoot === item.img && x.size === "S80x80"))[0].src} alt="" />
                                                <span>{item.value.replace(" ", "")}</span>
                                                <span style={{ display: Key1State?.name === item.value ? 'block' : 'none' }} className='nuTLGkaQio'><CheckOutlined className='SWzJAVZYWg' /></span>
                                            </div>
                                        )
                                    })}
                                </div>
                            </div>
                            <div className='wqPWTPYvMr'>
                                <p className='fBvRJBvshu'> {startKey2} : <span>&nbsp; {Key2State}</span></p>
                                <div className='ofRgAVTeYl'>
                                    {startValues2.map((item: string) => {
                                        return (
                                            <div className='lBHJWvVzaH' onClick={() => setKey2State(item)}>
                                                <span>{item.replace(" ", "")}</span>
                                                <span style={{ display: Key2State === item ? 'block' : 'none' }} className='nuTLGkaQio'><CheckOutlined className='SWzJAVZYWg' /></span>
                                            </div>
                                        )
                                    })}
                                </div>
                            </div>
                            <div>
                                <hr className='BozncDhktp' />
                                <div className='hcUCOccMik'>
                                    <span>Địa chỉ của bạn : 60/122,đường xuân phương,nam từ liêm,hà nội <p onClick={() => setVisible(true)}>đổi địa chỉ</p></span>
                                </div>
                                <Modal
                                    title="Modal 1000px width"
                                    centered
                                    maskClosable={false}
                                    visible={visible}
                                    onOk={() => setVisible(false)}
                                    onCancel={() => setVisible(false)}
                                    className="YaGBdXOcDw"
                                    footer={null}
                                >

                                </Modal>
                                <div className='hcUCOccMik'>
                                    <span>Phí vận chuyển : </span>
                                    <Select defaultValue="lucy" bordered={false}>
                                        <Option value="jack">Jack</Option>
                                        <Option value="lucy">Lucy</Option>
                                    </Select>
                                </div>
                                <hr className='BozncDhktp' />
                            </div>
                            <div>
                                <div className='cqCDvWHHAI'>
                                    <div className='quirYXYDhV'>
                                        <PlusOutlined className='ZKcRNZsCHm' />
                                        <InputNumber className='JmuKvefzfZ' />
                                        <MinusOutlined className='ZKcRNZsCHm' />
                                    </div>
                                    <div className='HdSlNhizMl'>
                                        <Input className='yRHMrpPwQg' />
                                        <Text className='mHFRipNbVI' type="success">100%</Text>
                                    </div>
                                </div>
                                <div className='cqCDvWHHAI'>
                                    <Button className='NtyBxGgasl' type="primary" block>
                                        Thêm Vào Giỏ Hàng
                                    </Button>
                                </div>
                            </div>
                        </Col>
                        <Col className='otSUEGfNRF'>
                            <ul className='UPkAKNmJzp'>
                                {unitCardProduct.highlightProductCardDtos.map(((elment: HighlightProductCardDtos) => {
                                    return (
                                        <li className='QMUySBCWUx'>
                                            <span>{elment.nameShow}</span>{elment.values}
                                        </li>);
                                }))}
                            </ul>
                        </Col>
                    </Row>
                </Col>
            </Row >
            <Row gutter={[10, 10]}>
                <Col span={19}>
                    <div className='OJkXBiXyst'>
                        <p className='SwswGUqGyh'>Mô Tả Sản Phẩm</p>
                        {/* {pzScZkIiuj} */}
                        <div className={openintroduce ? "feTSsBMLGN" : "feTSsBMLGN pzScZkIiuj"} dangerouslySetInnerHTML={{
                            __html: unitCardProduct.productCardDtos.introduce
                        }}>
                        </div>
                        <div className={!openintroduce ? "kBynIEHFTL" : "kBynIEHFTL fudZxInsuq"} >{/*fudZxInsuq*/}</div >
                        <div className='XlRRNzXjls'>
                            <Button
                                className='qiLHzvzZEV'
                                onClick={() => setopenintroduce(!openintroduce)}
                                type='default'>{openintroduce ? "Thu gọn" : "Xem thêm"} mô tả</Button>
                        </div>
                    </div>
                    <YouAssessmentComponent id={parseInt(props.location.pathname.substring(props.location.pathname.lastIndexOf("/adsid=") + 7))} />
                    <AssessmentComponent id={parseInt(props.location.pathname.substring(props.location.pathname.lastIndexOf("/adsid=") + 7))} />
                </Col>
                <Col span={5}>
                    <div className="OJkXBiXyst">
                        <CardProduct />
                        <CardProduct />
                        <CardProduct />
                        <CardProduct />
                        <CardProduct />
                    </div>
                </Col>
            </Row>
        </>
    )
}
