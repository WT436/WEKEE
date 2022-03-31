//#region  import
import { Avatar, Button, Card, Col, Rate, Row, Tag } from "antd";
import * as React from "react";
import { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import "slick-carousel/slick/slick.css";
import "slick-carousel/slick/slick-theme.css";
import { createStructuredSelector } from "reselect";
import { useInjectReducer, useInjectSaga } from "../../../redux/reduxInjectors";
import { watchPageStart } from "./actions";
import reducer from "./reducer";
import saga from "./saga";
import { makeSelectLoading } from "./selectors";
import Slider from "react-slick";
import { Helmet } from "react-helmet";
import {
  CaretRightOutlined,
  HeartTwoTone,
  SearchOutlined,
  SyncOutlined,
} from "@ant-design/icons";
import { Typography } from "antd";
import CardProduct from "../../../components/CardProduct";
const { Meta } = Card;

const { Text } = Typography;
//#endregion
export interface IHomeProps {
  location: any;
}
const key = "home";
declare var abp: any;
var urlCss = abp.serviceAlbumCss + "/home.css";
var urlDiscountProduct = abp.serviceAlbumCss + "/discountProduct.css";
const stateSelector = createStructuredSelector<any, any>({
  loading: makeSelectLoading(),
});

export default function Home(props: IHomeProps) {
  useInjectReducer(key, reducer);
  useInjectSaga(key, saga);

  const dispatch = useDispatch();

  const {} = useSelector(stateSelector);
  useEffect(() => {
    dispatch(watchPageStart());
  }, []);

  const settings = {
    dots: true,
    infinite: true,
    speed: 500,
    slidesToShow: 1,
    slidesToScroll: 1,
    autoplay: true,
    autoplaySpeed: 2000,
    pauseOnHover: true,
  };
  const settings3 = {
    dots: false,
    infinite: true,
    speed: 1000,
    slidesToShow: 5,
    slidesToScroll: 3,
  };
  return (
    <>
      <Helmet>
        <title>Wekee.vn</title>
        <link rel="stylesheet" href={urlCss} />
        <link rel="stylesheet" href={urlDiscountProduct} />
        <link rel="stylesheet" href={abp.serviceAlbumCss + "/home.css"} />
      </Helmet>
      <Row
        gutter={[10, 10]}
        className="home-carousell-main"
        style={{ alignItems: "center" }}
      >
        <Col span={16}>
          <Slider {...settings}>
            <a className="home-carousell-a">
              <img
                src={
                  abp.serviceAlbumImage +
                  "album/banner/21e4573959ecb121d8d0d4237ad56be4.png.jpg"
                }
              />
            </a>
            <a className="home-carousell-a">
              <img
                src={
                  abp.serviceAlbumImage +
                  "album/banner/2a5dea5bf70fec21cbc4d6fd58a16c31.png.jpg"
                }
              />
            </a>
            <a className="home-carousell-a">
              <img
                src={
                  abp.serviceAlbumImage +
                  "album/banner/5c0b195194c5314c1f4e1e630b1a0dc4.png.jpg"
                }
              />
            </a>
            <a className="home-carousell-a">
              <img
                src={
                  abp.serviceAlbumImage +
                  "album/banner/9ed820421df28e1c0c62669a04b15d8e.png.jpg"
                }
              />
            </a>
            <a className="home-carousell-a">
              <img
                src={
                  abp.serviceAlbumImage +
                  "album/banner/aa71a52f6b73215b171bbc982b2c5eed.png.jpg"
                }
              />
            </a>
            <a className="home-carousell-a">
              <img
                src={
                  abp.serviceAlbumImage +
                  "album/banner/adb8db3489db2353b5f0b1da38f15d8a.png.jpg"
                }
              />
            </a>
          </Slider>
        </Col>
        <Col span={8}>
          <img
            src={
              abp.serviceAlbumImage +
              "subBanner/f386cd12b8c72a56bbf43ca06b55ca06.jpg"
            }
          />
        </Col>
      </Row>
      <Row style={{ margin: "20px 0" }}>
        <Card
          title="Giảm Giá Hôm Nay"
          extra={
            <Button size="small" type="link" block>
              <Tag color="red">06</Tag> : &nbsp;
              <Tag color="red">40</Tag> : &nbsp;
              <Tag color="red">30</Tag>
              <CaretRightOutlined />
            </Button>
          }
          size="small"
          style={{ width: "100%" }}
        >
          <Slider {...settings3}>
            <CardProduct image={"album/product/product-1.jpg.webp"} />
            <CardProduct image={"album/product/product-2.jpg.webp"} />
            <CardProduct image={"album/product/product-3.jpg.webp"} />
            <CardProduct image={"album/product/product-4.jpg.webp"} />
            <CardProduct image={"album/product/product-5.jpg.webp"} />
            <CardProduct image={"album/product/product-6.jpg.webp"} />
            <CardProduct image={"album/product/product-7.jpg.webp"} />
            <CardProduct image={"album/product/product-8.jpg.webp"} />
            <CardProduct image={"album/product/product-9.jpg.webp"} />
            <CardProduct image={"album/product/product-10.jpg.webp"} />
          </Slider>
        </Card>
      </Row>
      <Row style={{ margin: "20px 0" }}>
        <Card
          title="Danh mục nổi bật."
          extra={
            <Button size="small" type="link" block>
              <CaretRightOutlined />
            </Button>
          }
          size="small"
          style={{ width: "100%" }}
        >
          <Row gutter={[6, 6]}>
            <Col className="category-highlights" span={2}>
              <a>
                <Avatar size={64} />
                <p>Áo khoác nữ</p>
              </a>
            </Col>
          </Row>
        </Card>
      </Row>
      <Row style={{ margin: "20px 0" }}>
        <Card
          title={
            <>
              <SearchOutlined /> Tìm kiếm nổi bật.
            </>
          }
          extra={
            <Button size="small" type="link" block>
              <SyncOutlined spin /> Làm Mới
            </Button>
          }
          size="small"
          style={{ width: "100%" }}
        >
          <Row gutter={[16, 6]}>
            <Col span={6}>
              <Card
                hoverable
                cover={
                  <div className="search-highlights">
                    <a>
                      <img
                        alt="example"
                        src="https://os.alipayobjects.com/rmsportal/QBnOOoLaAfKPirc.png"
                      />
                    </a>
                    <a>
                      <img
                        alt="example"
                        src="https://os.alipayobjects.com/rmsportal/QBnOOoLaAfKPirc.png"
                      />
                    </a>
                    <a>
                      <img
                        alt="example"
                        src="https://os.alipayobjects.com/rmsportal/QBnOOoLaAfKPirc.png"
                      />
                    </a>
                  </div>
                }
              >
                <a href="#">
                  <Meta
                    style={{ padding: "5px 10px" }}
                    title="Sách Kinh Tế"
                    description="66 Sản Phẩm"
                  />
                </a>
              </Card>
            </Col>
            <Col span={6}>
              <Card
                hoverable
                cover={
                  <div className="search-highlights">
                    <a>
                      <img
                        alt="example"
                        src="https://os.alipayobjects.com/rmsportal/QBnOOoLaAfKPirc.png"
                      />
                    </a>
                    <a>
                      <img
                        alt="example"
                        src="https://os.alipayobjects.com/rmsportal/QBnOOoLaAfKPirc.png"
                      />
                    </a>
                    <a>
                      <img
                        alt="example"
                        src="https://os.alipayobjects.com/rmsportal/QBnOOoLaAfKPirc.png"
                      />
                    </a>
                  </div>
                }
              >
                <a>
                  <Meta
                    style={{ padding: "5px 10px" }}
                    title="Sách Kinh Tế"
                    description="66 Sản Phẩm"
                  />
                </a>
              </Card>
            </Col>
            <Col span={6}>
              <Card
                hoverable
                cover={
                  <div className="search-highlights">
                    <a>
                      <img
                        alt="example"
                        src="https://os.alipayobjects.com/rmsportal/QBnOOoLaAfKPirc.png"
                      />
                    </a>
                    <a>
                      <img
                        alt="example"
                        src="https://os.alipayobjects.com/rmsportal/QBnOOoLaAfKPirc.png"
                      />
                    </a>
                    <a>
                      <img
                        alt="example"
                        src="https://os.alipayobjects.com/rmsportal/QBnOOoLaAfKPirc.png"
                      />
                    </a>
                  </div>
                }
              >
                <a>
                  <Meta
                    style={{ padding: "5px 10px" }}
                    title="Sách Kinh Tế"
                    description="66 Sản Phẩm"
                  />
                </a>
              </Card>
            </Col>
            <Col span={6}>
              <Card
                hoverable
                cover={
                  <div className="search-highlights">
                    <a>
                      <img
                        alt="example"
                        src="https://os.alipayobjects.com/rmsportal/QBnOOoLaAfKPirc.png"
                      />
                    </a>
                    <a>
                      <img
                        alt="example"
                        src="https://os.alipayobjects.com/rmsportal/QBnOOoLaAfKPirc.png"
                      />
                    </a>
                    <a>
                      <img
                        alt="example"
                        src="https://os.alipayobjects.com/rmsportal/QBnOOoLaAfKPirc.png"
                      />
                    </a>
                  </div>
                }
              >
                <a>
                  <Meta
                    style={{ padding: "5px 10px" }}
                    title="Sách Kinh Tế"
                    description="66 Sản Phẩm"
                  />
                </a>
              </Card>
            </Col>
          </Row>
        </Card>
      </Row>
      <Row className="sXQJOsEJXk" gutter={[6, 6]}>
        <Col span={24}>Dành Cho Bạn!</Col>
        <CardProduct image={"album/product/product-1.jpg.webp"} />
        <CardProduct image={"album/product/product-2.jpg.webp"} />
        <CardProduct image={"album/product/product-3.jpg.webp"} />
        <CardProduct image={"album/product/product-4.jpg.webp"} />
        <CardProduct image={"album/product/product-5.jpg.webp"} />
        <CardProduct image={"album/product/product-6.jpg.webp"} />
        <CardProduct image={"album/product/product-7.jpg.webp"} />
        <CardProduct image={"album/product/product-8.jpg.webp"} />
        <CardProduct image={"album/product/product-9.jpg.webp"} />
        <CardProduct image={"album/product/product-10.jpg.webp"} />
        <CardProduct image={"album/product/product-1.jpg.webp"} />
        <CardProduct image={"album/product/product-2.jpg.webp"} />
        <CardProduct image={"album/product/product-3.jpg.webp"} />
        <CardProduct image={"album/product/product-4.jpg.webp"} />
        <CardProduct image={"album/product/product-5.jpg.webp"} />
        <CardProduct image={"album/product/product-6.jpg.webp"} />
        <CardProduct image={"album/product/product-7.jpg.webp"} />
        <CardProduct image={"album/product/product-8.jpg.webp"} />
        <CardProduct image={"album/product/product-9.jpg.webp"} />
        <CardProduct image={"album/product/product-10.jpg.webp"} />
      </Row>
    </>
  );
}
