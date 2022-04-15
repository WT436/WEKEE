//#region import
import React, { useEffect, useState } from 'react'
import { useDispatch, useSelector } from 'react-redux';
import { createStructuredSelector } from 'reselect';
import moment from 'moment';
import { CheckOutlined } from '@ant-design/icons';
import { getFeatureProductCartStart } from '../actions';
import { makeSelectfeatureCartProduct } from '../selectors';
import { ProductReadForCartDto } from '../dtos/productReadForCartDto';
import { ImageWithValueAttributeDto } from '../dtos/imageWithValueAttributeDto';

declare var abp: any;
//#endregion

interface IFeatureProductComponentProps {
    id: number
}
const stateSelector = createStructuredSelector < any, any> ({
    featureCartProduct: makeSelectfeatureCartProduct()
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

    // useEffect(() => {
    //     let intIndex = 0;
    //     for (const el of featureCartProduct.productReadForCartDto) {
    //         if (el.values === featureCartProduct.keyValuesName[0].valuesName[intIndex]) {
    //             intIndex++;
    //             setImageForFeature(ImageForFeature=>[...ImageForFeature,el.iMGS80x80]);
    //             console.log(el.iMGS80x80);
    //         }
    //     }
    // }, [featureCartProduct]);

    // const [AttributeValue, setAttributeValue] = useState < { name: string, values: string }[] > ([]);
    // const [AttributeName, setAttributeName] = useState < string[] > ([]);
    // useEffect(() => {
    //     const resultKey: string[] = [];
    //     const resultValue = [];
    //     const map = new Map();
    //     for (const item of featureCartProduct) {
    //         if (!map.has(item.values)) {
    //             map.set(item.values, true);    // set any value to Map
    //             resultValue.push({
    //                 name: item.name,
    //                 values: item.values
    //             });
    //         }

    //         if (!map.has(item.name)) {
    //             map.set(item.name, true);    // set any value to Map
    //             resultKey.push(item.name);
    //         }
    //     }

    //     setAttributeValue(resultValue);
    //     setAttributeName(resultKey);
    // }, [featureCartProduct]);
    //#endregion START

    const _getImageAttribute = (item: string) => {
        return (featureCartProduct.renderImage
            .filter((element: ImageWithValueAttributeDto) => element.valueName === item
            )[0].imgS80x80);
    }

    const [MainFeatureCheck, setMainFeatureCheck] = useState < { key: string, value: string }[] > ([{ key: '', value: '' }]);

    useEffect(() => {
        setMainFeatureCheck([]);
        featureCartProduct.productReadForCartDto.forEach((el: ProductReadForCartDto) => {
            if (el.mainProduct) {
                setMainFeatureCheck(al => [...al, { key: el.name, value: el.values }]);
            }
        });
    }, [featureCartProduct]);
    useEffect(() => {
        console.log(MainFeatureCheck);
    }, [MainFeatureCheck])

    return (
        <>
            <div className="wqPWTPYvMr">
                <p className="fBvRJBvshu">
                    {featureCartProduct.keyValuesName[0] === undefined ? "" : featureCartProduct.keyValuesName[0].keyName} : <span>&nbsp;{"Key1State?.name"}</span>
                </p>
                <div className="ofRgAVTeYl">
                    {(featureCartProduct.keyValuesName[0] === undefined
                        ? <></>
                        : (
                            featureCartProduct.keyValuesName[0].valuesName.map((item: string) => {
                                return (
                                    <div
                                        className="lPibOcgFQi"
                                    >
                                        <img src={abp.serviceAlbumImage + (() => _getImageAttribute(item))()} alt='' />
                                        <span>{item}</span>
                                        <span
                                            style={{
                                                display: MainFeatureCheck[0] !== undefined && MainFeatureCheck[0].value === item ? "block" : "none",
                                            }}
                                            className="nuTLGkaQio"
                                        >
                                            <CheckOutlined className="SWzJAVZYWg" />
                                        </span>
                                    </div>
                                )
                            })
                        )
                    )}
                </div>
            </div>
            <div className="wqPWTPYvMr">
                <p className="fBvRJBvshu">
                    {featureCartProduct.keyValuesName[1] === undefined ? "" : featureCartProduct.keyValuesName[1].keyName} : <span>&nbsp; {" Key2State"}</span>
                </p>
                <div className="ofRgAVTeYl">
                    {(featureCartProduct.keyValuesName[1] === undefined
                        ? <></>
                        : (
                            featureCartProduct.keyValuesName[1].valuesName.map((item: string) => {
                                return (
                                    <div
                                        className="lBHJWvVzaH"
                                    >
                                        <span>{item}</span>
                                        <span
                                            style={{
                                                display: MainFeatureCheck[1] !== undefined && MainFeatureCheck[1].value === item ? "block" : "none",
                                            }}
                                            className="nuTLGkaQio"
                                        >
                                            <CheckOutlined className="SWzJAVZYWg" />
                                        </span>
                                    </div>
                                )
                            })
                        )
                    )}
                </div>
            </div>
        </>
    )
}
