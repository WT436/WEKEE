//#region import
import React, { useEffect, useState } from 'react'
import { useDispatch, useSelector } from 'react-redux';
import { createStructuredSelector } from 'reselect';
import moment from 'moment';
import ReactImageMagnify from 'react-image-magnify';
import "react-lazy-load-image-component/src/effects/blur.css";
import "slick-carousel/slick/slick.css";
import "slick-carousel/slick/slick-theme.css";
import Slider from 'react-slick';

declare var abp: any;
//#endregion

interface IImageZoomComponentProps {

}
const stateSelector = createStructuredSelector < any, any> ({
});
export default function ImageZoomComponent(props: IImageZoomComponentProps) {

    const dispatch = useDispatch();

    const {
        imageS80x80, imageS340x340, imageS1360x1360,
    } = useSelector(stateSelector);


    const [selectImage, setselectImage] = useState(0);
    const [zoomImage, setzoomImage] = useState({
        smallImage: {
            alt: "",
            isFluidWidth: true,
            src: "",
        },
        largeImage: {
            src: "",
            width: 900,
            height: 900,
        },
    });

    const settings3 = {
        dots: false,
        infinite: true,
        speed: 1000,
        slidesToShow: 5,
        slidesToScroll: 3,
        autoplay: true,
        autoplaySpeed: 5000,
        pauseOnHover: true,
    };

    const onSelectImageZoom = (value: number) => {
        // imageS80x80.map((element: ImageProductCardDtos) => {
        //     if (element.imageRoot === value) {
        //         setselectImage(element.id);
        //     }
        // });

        // var data340: ImageProductCardDtos = {
        //     id: 0,
        //     src: "",
        //     alt: "",
        //     title: "",
        //     size: "",
        //     folder: "",
        //     product: 0,
        //     imageRoot: 0,
        // };

        // imageS340x340.forEach((element: ImageProductCardDtos) => {
        //     if (element.imageRoot === value) {
        //         data340 = element;
        //     }
        // });

        // var dataS1360x1360: ImageProductCardDtos = {
        //     id: 0,
        //     src: "",
        //     alt: "",
        //     title: "",
        //     size: "",
        //     folder: "",
        //     product: 0,
        //     imageRoot: 0,
        // };

        // imageS1360x1360.forEach((element: ImageProductCardDtos) => {
        //     if (element.imageRoot === value) {
        //         dataS1360x1360 = element;
        //     }
        // });

        // setzoomImage({
        //     smallImage: {
        //         alt: data340.alt,
        //         isFluidWidth: true,
        //         src: abp.serviceAlbumImage + data340.src,
        //     },
        //     largeImage: {
        //         src: abp.serviceAlbumImage + dataS1360x1360.src,
        //         width: 900,
        //         height: 900,
        //     },
        // });
    };

    return (
        <>
            <div className="diTRzvSLbS">
                <ReactImageMagnify style={{ zIndex: 10 }} {...zoomImage} />
            </div>
            <div className="CDBhRpMxwl">
                <Slider {...settings3}>
                    <img
                        className={
                            "LmqLbjIyYc" +
                            " " +
                            (true ? "bFpTBTrDfH" : "")
                        }
                        src={abp.serviceAlbumImage + "element.src"}
                        alt={"element.alt"}
                    />
                </Slider>
            </div>
        </>
    )
}
