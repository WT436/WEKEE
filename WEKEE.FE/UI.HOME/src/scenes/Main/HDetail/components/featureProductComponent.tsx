//#region import
import React, { useEffect, useState } from 'react'
import { useDispatch, useSelector } from 'react-redux';
import { createStructuredSelector } from 'reselect';
import moment from 'moment';
import { CheckOutlined } from '@ant-design/icons';
import { getFeatureProductCartStart, MainCheckFeatureStart } from '../actions';
import { makeSelectfeatureCartProduct, makeSelectmainFeatureCheck } from '../selectors';
import { ProductReadForCartDto } from '../dtos/productReadForCartDto';
import { ImageWithValueAttributeDto } from '../dtos/imageWithValueAttributeDto';

declare var abp: any;
//#endregion

interface IFeatureProductComponentProps {
    id: number
}

const stateSelector = createStructuredSelector < any, any> ({
    featureCartProduct: makeSelectfeatureCartProduct(),
    mainFeatureCheck: makeSelectmainFeatureCheck()
});

export default function FeatureProductComponent(props: IFeatureProductComponentProps) {

    const dispatch = useDispatch();

    const {
        featureCartProduct
    } = useSelector(stateSelector);

    //#region START
    useEffect(() => {
        dispatch(getFeatureProductCartStart(props.id));
    }, []);
    //#endregion

    const _getImageAttribute = (item: string) => {
        return (featureCartProduct.renderImage
            .filter((element: ImageWithValueAttributeDto) => element.valueName === item
            )[0].imgS80x80);
    }

    const [MainFeatureCheckOne, setMainFeatureCheckOne] = useState < { key: string, value: string } > ();
    const [MainFeatureCheckTwo, setMainFeatureCheckTwo] = useState < { key: string, value: string } > ();

    // Tao dell the nghi minh phai viet mot cach ngu dan nhu the nay
    // su ngu lol cua viec khong toan ven du lieu
    useEffect(() => {
        var data1;
        featureCartProduct.productReadForCartDto.forEach((el: ProductReadForCartDto) => {
            if ((el.name === MainFeatureCheckOne?.key && el.values === MainFeatureCheckOne?.value)) {
                data1 = el;
            }
        });
        console.log(data1);
    }, [MainFeatureCheckTwo, MainFeatureCheckOne]);

    useEffect(() => {
        if (featureCartProduct.productReadForCartDto) {
            featureCartProduct.productReadForCartDto.forEach((el: ProductReadForCartDto) => {
                if (el.mainProduct) {
                    if (el.name === featureCartProduct.keyValuesName[0].keyName) {
                        setMainFeatureCheckOne({ key: el.name, value: el.values });
                    }
                    else {
                        setMainFeatureCheckTwo({ key: el.name, value: el.values });
                    }
                }
            });
        }
    }, [featureCartProduct]);

    const _editCheckFeature = (key: string, item: string, index: number) => {
        if (index === 0) {
            setMainFeatureCheckOne({ key: key, value: item });
        }
        else {
            setMainFeatureCheckTwo({ key: key, value: item });
        }
    };

    return (
        <>
            {featureCartProduct.keyValuesName.length > 0 ?
                <>
                    <div className="wqPWTPYvMr">
                        {MainFeatureCheckOne !== undefined
                            ? <p className="fBvRJBvshu">
                                {MainFeatureCheckOne.key}
                                : <span>&nbsp; {MainFeatureCheckOne.value} </span>
                            </p>
                            : <></>
                        }
                        <div className="ofRgAVTeYl">
                            {featureCartProduct.keyValuesName[0].valuesName.map((item: string) => {
                                return (
                                    <div
                                        className="lPibOcgFQi"
                                        onClick={() => _editCheckFeature(featureCartProduct.keyValuesName[0].keyName, item, 0)}
                                    >
                                        <img src={abp.serviceAlbumImage + (() => _getImageAttribute(item))()} alt='' />
                                        <span>{item}</span>
                                        {
                                            MainFeatureCheckOne !== undefined
                                                ? <span
                                                    style={{
                                                        display: MainFeatureCheckOne.value == item ? "block" : "none",
                                                    }}
                                                    className="nuTLGkaQio"
                                                >
                                                    <CheckOutlined className="SWzJAVZYWg" />
                                                </span>
                                                : <></>
                                        }
                                    </div>
                                )
                            })}
                        </div>
                    </div>
                    <div className="wqPWTPYvMr">
                        {MainFeatureCheckTwo !== undefined
                            ? <p className="fBvRJBvshu">
                                {MainFeatureCheckTwo.key}
                                : <span>&nbsp; {MainFeatureCheckTwo.value} </span>
                            </p>
                            : <></>
                        }
                        <div className="ofRgAVTeYl">
                            {featureCartProduct.keyValuesName[1].valuesName.map((item: string) => {
                                return (
                                    <div
                                        className="lBHJWvVzaH"
                                        onClick={() => _editCheckFeature(featureCartProduct.keyValuesName[1].keyName, item, 1)}
                                    >
                                        <span>{item}</span>
                                        {
                                            MainFeatureCheckTwo !== undefined
                                                ? <span
                                                    style={{
                                                        display: MainFeatureCheckTwo.value == item ? "block" : "none",
                                                    }}
                                                    className="nuTLGkaQio"
                                                >
                                                    <CheckOutlined className="SWzJAVZYWg" />
                                                </span>
                                                : <></>
                                        }
                                    </div>
                                )
                            })}
                        </div>
                    </div>
                </>
                : ""}
        </>
    )
}
