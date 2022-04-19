//#region import
import React, { useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { createStructuredSelector } from "reselect";
import moment from "moment";
import { PlusOutlined, MinusOutlined } from "@ant-design/icons";
import { InputNumber, Input, Button, Typography } from "antd";
import { makeSelectmainFeatureCheck } from "../selectors";

const { Text } = Typography;
declare var abp: any;
//#endregion
interface IAddToCartComponentProps {}
const stateSelector = createStructuredSelector<any, any>({
  mainFeatureCheck: makeSelectmainFeatureCheck(),
});

export default function AddToCartComponent(props: IAddToCartComponentProps) {
  //#region  GLOBAL VARIABLE
  const dispatch = useDispatch();
  const { mainFeatureCheck } = useSelector(stateSelector);
  //#endregion

  //#region  SETTING
  //#endregion

  //#region  START
  useEffect(() => {
    console.log("mainFeatureCheck", mainFeatureCheck);
  }, [mainFeatureCheck]);

  //#endregion

  //#region  CHANGE NUMBER QUATITY
  const [orderQutity, setorderQutity] = useState<number>(1);
  const _changeQuatityOrder = (up: boolean) => {
    let data: number = orderQutity;
    let quatity =
      mainFeatureCheck[0] === undefined ? 0 : mainFeatureCheck[0].quantity;
    up ? (data = data + 1) : (data = data - 1);
    data = data > quatity ? quatity : data;
    data = data < 0 ? 0 : data;
    setorderQutity(data);
  };

  const _onChangeDataInput = (data: any) => {
    let quatity =
      mainFeatureCheck[0] === undefined ? 0 : mainFeatureCheck[0].quantity;
    data = data > quatity ? quatity : data;
    data = data < 0 ? 0 : data;
    console.log(data);
    if (data === null || data === undefined) data = 1;
    setorderQutity(data);
  };
  //#endregion
  return (
    <>
      {mainFeatureCheck[0] === undefined ||
      mainFeatureCheck[0].quantity === 0 ? (
        <>
          <div className="jIClzckmnh">Đã bán hết sản phẩm!</div>
          <hr />
        </>
      ) : (
        <div>
          <div className="cqCDvWHHAI">
            <div className="quirYXYDhV">
              <PlusOutlined
                className="ZKcRNZsCHm"
                onClick={() => _changeQuatityOrder(true)}
              />
              <InputNumber
                stringMode
                defaultValue={1}
                value={orderQutity}
                onChange={(value: any) => _onChangeDataInput(value)}
                min={1}
                max={
                  mainFeatureCheck[0] === undefined
                    ? 1
                    : mainFeatureCheck[0].quantity
                }
                keyboard={false}
                className="JmuKvefzfZ"
              />
              <MinusOutlined
                className="ZKcRNZsCHm"
                onClick={() => _changeQuatityOrder(false)}
              />
            </div>
            <div className="HdSlNhizMl">
              <Input className="yRHMrpPwQg" placeholder="Nhập mã của bạn!" />
              <Text className="mHFRipNbVI" type="success">
                100%
              </Text>
            </div>
          </div>
          <div className="cqCDvWHHAI">
            <Button className="NtyBxGgasl" type="primary" block>
              Thêm Vào Giỏ Hàng
            </Button>
          </div>
        </div>
      )}
    </>
  );
}
