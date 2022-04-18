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
import { getImageProductStart } from '../actions';
import { makeSelectimageForProduct, makeSelectmainFeatureCheck } from '../selectors';
import { ImageForProductDto } from '../dtos/imageForProductDto';

declare var abp: any;
//#endregion

interface IImageZoomComponentProps {
    id: number
};

const stateSelector = createStructuredSelector < any, any> ({
    imageForProduct: makeSelectimageForProduct(),
    mainFeatureCheck: makeSelectmainFeatureCheck()
});

export default function ImageZoomComponent(props: IImageZoomComponentProps) {

    const dispatch = useDispatch();

    const {
        imageForProduct, mainFeatureCheck
    } = useSelector(stateSelector);

    //#region START
    useEffect(() => {
        dispatch(getImageProductStart(props.id));
    }, []);

    const [ImageS80x80, setImageS80x80] = useState < ImageForProductDto[] > ([]);
    const [ImageS1360x540, setImageS1360x540] = useState < ImageForProductDto[] > ([]);
    const [ImageS340x340, setImageS340x340] = useState < ImageForProductDto[] > ([]);
    const [zoomImage, setzoomImage] = useState({
        smallImage: { alt: "", isFluidWidth: true, src: "" },
        largeImage: { src: "", width: 900, height: 900 }
    });

    useEffect(() => {
        var dataZoomImage = zoomImage;
        setImageS80x80([]);
        setImageS1360x540([]);
        setImageS340x340([]);
        imageForProduct.forEach((element: ImageForProductDto) => {
            if (element.size == 'S80x80') {
                setImageS80x80(ImageS80x80 => [...ImageS80x80, element]);
            }
            else if (element.size == 'S1360x540') {
                setImageS1360x540(ImageS1360x540 => [...ImageS1360x540, element]);
                if (element.displayOrder === 1) {
                    dataZoomImage.largeImage.src = abp.serviceAlbumImage + element.virtualPath
                }
            }
            else {
                setImageS340x340(ImageS340x340 => [...ImageS340x340, element]);
                if (element.displayOrder === 1) {
                    setselectImage(element.imageRoot);
                    dataZoomImage.smallImage.src = abp.serviceAlbumImage + element.virtualPath;
                    dataZoomImage.smallImage.alt = element.altAttribute;
                }
            }
        });
        setzoomImage(dataZoomImage);
        console.log(imageForProduct)
    }, [imageForProduct]);
    //#endregion

    //#region MAP IMAGE TO ZOOM 
    const [selectImage, setselectImage] = useState(0);
    const _selectImageShow = (imageRoot: number) => {
        setselectImage(imageRoot);
        var image1360Show = ImageS1360x540.find((item: ImageForProductDto) => item.imageRoot === imageRoot);
        var image340Show = ImageS340x340.find((item: ImageForProductDto) => item.imageRoot === imageRoot);
        setzoomImage({
            smallImage: {
                alt: image340Show === undefined ? "" : image340Show.altAttribute,
                isFluidWidth: true,
                src: image340Show === undefined ? "" : abp.serviceAlbumImage + image340Show.virtualPath,
            },
            largeImage: {
                src: image1360Show === undefined ? "" : abp.serviceAlbumImage + image1360Show.virtualPath,
                width: 900,
                height: 900,
            }
        });
    }
    //#endregion

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

    return (
        <>
            <div className="diTRzvSLbS">
                <ReactImageMagnify style={{ zIndex: 10 }} {...zoomImage} />
            </div>
            <div className="CDBhRpMxwl">
                <Slider {...settings3}>
                    {ImageS80x80.map(item => {
                        return (
                            <img
                                className={
                                    "LmqLbjIyYc " +
                                    (item.imageRoot == selectImage ? "bFpTBTrDfH" : "")
                                }
                                onClick={() => _selectImageShow(item.imageRoot)}
                                src={abp.serviceAlbumImage + item.virtualPath}
                                alt={item.altAttribute}
                            />
                        )
                    })}
                </Slider>
            </div>
        </>
    )
}
