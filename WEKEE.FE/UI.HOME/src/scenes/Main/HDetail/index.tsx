//#region  import
import * as React from "react";
import { useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { createStructuredSelector } from "reselect";
import { useInjectReducer, useInjectSaga } from "../../../redux/reduxInjectors";
import { getCategoryBreadcrumbStart } from "./actions";
import reducer from "./reducer";
import saga from "./saga";
import {
  Button, Col, Row, Select,
} from "antd";
import {
  makeSelectcategoryBreadcrumbDtos, makeSelectLoading,
} from "./selectors";
import { Helmet } from "react-helmet";
import {
  HomeOutlined
} from "@ant-design/icons";
import BasicSeo from "../../../components/Seo/basicSeo";
import { CategoryBreadcrumbDtos } from "./dtos/categoryBreadcrumbDtos";
import CardProduct from "../../../components/CardProduct";
import ImageZoomComponent from "./components/imageZoomComponent";
import ShopProductComponent from "./components/shopProductComponent";
import ProductInteractionComponent from "./components/productInteractionComponent";
import YouAssessmentComponent from "./components/youAssessmentComponent";
import AssessmentComponent from "./components/assessmentComponent";
import ChartsTopProductComponent from "./components/chartsTopProductComponent";
import BasicInfoProductComponent from "./components/basicInfoProductComponent";
import FeatureProductComponent from "./components/featureProductComponent";
import AddressShipProduct from "./components/addressShipProduct";
import AddToCartComponent from "./components/addToCartComponent";
const { Option } = Select;

//#endregion
export interface IHDetailProps {
  location: any;
  i: any;
}

declare var abp: any;
var urlCss = abp.serviceAlbumCss + "/detail.css";
const key = "hdetail";
const stateSelector = createStructuredSelector < any, any> ({
  loading: makeSelectLoading(),
  categoryBreadcrumbDtos: makeSelectcategoryBreadcrumbDtos()
});

export default function HDetail(props: IHDetailProps) {
  useInjectReducer(key, reducer);
  useInjectSaga(key, saga);
  const dispatch = useDispatch();
  const { categoryBreadcrumbDtos, unitCardProduct
  } = useSelector(stateSelector);

  const [routes, setroutes] = useState < { path: string; breadcrumbName: any }[] > ([]);

  useEffect(() => {
    var id = props.location.pathname.substring(
      props.location.pathname.lastIndexOf("/adsid=") + 7
    );
    dispatch(getCategoryBreadcrumbStart(id));
  }, []);

  useEffect(() => {
    setroutes([]);
    categoryBreadcrumbDtos.forEach((element: CategoryBreadcrumbDtos) => {
      routes[element.levelCategory] = {
        path: element.urlCategory,
        breadcrumbName: element.nameCategory,
      };
    });
    setroutes(routes);
  }, [categoryBreadcrumbDtos]);

  // var x = setInterval(function () {
  //   // Get today's date and time
  //   var now = new Date().getTime();

  //   // Find the distance between now and the count down date
  //   var distance = new Date("Jan 5, 2022 15:37:25").getTime() - now;

  //   // Time calculations for days, hours, minutes and seconds
  //   var days = Math.floor(distance / (1000 * 60 * 60 * 24));
  //   var hours = Math.floor(
  //     (distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60)
  //   );
  //   var minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
  //   var seconds = Math.floor((distance % (1000 * 60)) / 1000);

  //   // Display the result in the element with id="demo"
  //   settimeDiscount(days + " : " + hours + " : " + minutes + " : " + seconds);

  //   // If the count down is finished, write some text
  //   if (distance < 0) {
  //     clearInterval(x);
  //     settimeDiscount("");
  //   }
  // }, 1000);

  const [openintroduce, setopenintroduce] = useState(false);

  return (
    <>
      <BasicSeo />
      <Helmet>
        <link rel="stylesheet" href={urlCss} />
        <link
          rel="stylesheet"
          href={abp.serviceAlbumCss + "/discountProduct.css"}
        />
        <link rel="stylesheet" href={abp.serviceAlbumCss + "/home.css"} />
      </Helmet>

      {
        <ul className="GjLseculzy">
          <li>
            <a href="/">
              <HomeOutlined />
            </a>
          </li>
          {categoryBreadcrumbDtos
            .sort((m: CategoryBreadcrumbDtos) => m.levelCategory)
            .reverse((m: CategoryBreadcrumbDtos) => m.levelCategory)
            .map((element: CategoryBreadcrumbDtos, index: number) => {
              //className="GjLseculzyac"
              if (element.levelCategory == categoryBreadcrumbDtos.length) {
                return (
                  <li key={index}>
                    <a className="GjLseculzyac" href={element.urlCategory}>
                      {" "}
                      {element.nameCategory}
                    </a>
                  </li>
                );
              } else {
                return (
                  <li key={index}>
                    <a href={element.urlCategory}> {element.nameCategory}</a>
                  </li>
                );
              }
            })}
          <li key="End">
            <a className="GjLseculzyac">{'nameProduct'}</a>
          </li>
        </ul>
      }

      <Row>
        <Col span={7} className="lIiNahOSjz">
          <ImageZoomComponent />
          <ProductInteractionComponent />
          <ShopProductComponent />
        </Col>
        <Col style={{ width: "calc(100% - 340px)", paddingLeft: "10px" }}>
          <ChartsTopProductComponent />
          <Row>
            <Col className="otSUEGfNRF">
              <BasicInfoProductComponent />
              <FeatureProductComponent />
              <AddressShipProduct />
              <AddToCartComponent />
            </Col>
            <Col className="otSUEGfNRF">
              <ul className="UPkAKNmJzp">
                <li className="QMUySBCWUx">
                  <span>{'elment.nameShow'}</span>
                  {'elment.values'}
                </li>
              </ul>
            </Col>
          </Row>
        </Col>
      </Row>
      <Row gutter={[10, 10]}>
        <Col span={19}>
          <div className="OJkXBiXyst">
            <p className="SwswGUqGyh">Mô Tả Sản Phẩm</p>
            {/* {pzScZkIiuj} */}
            <div
              className={openintroduce ? "feTSsBMLGN" : "feTSsBMLGN pzScZkIiuj"}
              dangerouslySetInnerHTML={{
                __html: "unitCardProduct.productCardDtos.introduce",
              }}
            ></div>
            <div
              className={
                !openintroduce ? "kBynIEHFTL" : "kBynIEHFTL fudZxInsuq"
              }
            >
              {/*fudZxInsuq*/}
            </div>
            <div className="XlRRNzXjls">
              <Button
                className="qiLHzvzZEV"
                onClick={() => setopenintroduce(!openintroduce)}
                type="default"
              >
                {openintroduce ? "Thu gọn" : "Xem thêm"} mô tả
              </Button>
            </div>
          </div>
          <YouAssessmentComponent
            id={parseInt(
              props.location.pathname.substring(
                props.location.pathname.lastIndexOf("/adsid=") + 7
              )
            )}
          />
          <AssessmentComponent
            id={parseInt(
              props.location.pathname.substring(
                props.location.pathname.lastIndexOf("/adsid=") + 7)
            )}
          />
        </Col>
        <Col span={5}>
          <div className="OJkXBiXyst">
            <CardProduct image={"album/product/product-1.jpg.webp"} />
            <CardProduct image={"album/product/product-2.jpg.webp"} />
            <CardProduct image={"album/product/product-3.jpg.webp"} />
            <CardProduct image={"album/product/product-4.jpg.webp"} />
            <CardProduct image={"album/product/product-5.jpg.webp"} />
          </div>
        </Col>
      </Row>
    </>
  );
}
