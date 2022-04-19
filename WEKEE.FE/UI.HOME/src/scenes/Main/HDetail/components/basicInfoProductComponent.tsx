//#region import
import React, { useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { createStructuredSelector } from "reselect";
import moment from "moment";
import { GiftOutlined } from "@ant-design/icons";
import { makeSelectmainFeatureCheck } from "../selectors";

declare var abp: any;
//#endregion

interface IBasicInfoProductComponentProps {}
const stateSelector = createStructuredSelector<any, any>({
  mainFeatureCheck: makeSelectmainFeatureCheck(),
});
export default function BasicInfoProductComponent(
  props: IBasicInfoProductComponentProps
) {
  const dispatch = useDispatch();

  const { mainFeatureCheck } = useSelector(stateSelector);

  return (
    <>
      <div className="AEQBszOavW">
        <div className="dcp-khung">
          <span className="dcp-khung-before"></span>
          <span className="dcp-loi">
            <span className="dcp-base">
              <span>-{10}%</span>
            </span>
          </span>
        </div>
        <div className="oibhFVaXiQ">
          {new Intl.NumberFormat("vi-VN", {
            style: "currency",
            currency: "VND",
          }).format(mainFeatureCheck[0] === undefined ? 0 : mainFeatureCheck[0].price )}  
          {/* mainFeatureCheck[0]?.price */}
          <div>
            <span>
              {new Intl.NumberFormat("vi-VN", {
                style: "currency",
                currency: "VND",
              }).format(mainFeatureCheck[0] === undefined ? 0 : mainFeatureCheck[0].price)}
            </span>
            <span>{3000}</span>
          </div>
        </div>
        <div className="BwzPWPYcLd">
          <GiftOutlined className="OGxbvhkgxM" /> Mưa quà tặng :{" "}
        </div>
        <div className="BwzPWPYcLd">
          <GiftOutlined className="OGxbvhkgxM" /> FreeShip :{" "}
        </div>
        <div className="BwzPWPYcLd">
          <GiftOutlined className="OGxbvhkgxM" /> Giảm giá :{" "}
        </div>
      </div>
    </>
  );
}
