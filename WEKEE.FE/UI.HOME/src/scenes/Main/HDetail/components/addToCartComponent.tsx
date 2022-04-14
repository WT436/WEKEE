//#region import
import React, { useEffect, useState } from 'react'
import { useDispatch, useSelector } from 'react-redux';
import { createStructuredSelector } from 'reselect';
import moment from 'moment';
import { PlusOutlined, MinusOutlined } from '@ant-design/icons';
import { InputNumber, Input, Button, Typography } from 'antd';

const { Text } = Typography;
declare var abp: any;
//#endregion
interface IAddToCartComponentProps {

}
const stateSelector = createStructuredSelector < any, any> ({

});

export default function AddToCartComponent(props: IAddToCartComponentProps) {

  const dispatch = useDispatch();

  const {
  } = useSelector(stateSelector);

  return (
    <>
      <div>
        <div className="cqCDvWHHAI">
          <div className="quirYXYDhV">
            <PlusOutlined className="ZKcRNZsCHm" />
            <InputNumber className="JmuKvefzfZ" />
            <MinusOutlined className="ZKcRNZsCHm" />
          </div>
          <div className="HdSlNhizMl">
            <Input className="yRHMrpPwQg" />
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
    </>
  )
}
