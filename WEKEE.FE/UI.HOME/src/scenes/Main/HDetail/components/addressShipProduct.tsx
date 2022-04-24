//#region import
import React from 'react'
import { useDispatch, useSelector } from 'react-redux';
import { createStructuredSelector } from 'reselect';
import Select from 'antd/lib/select';
const { Option } = Select;

declare var abp: any;
//#endregion

interface IAddressShipProductProps {

}
const stateSelector = createStructuredSelector < any, any> ({

});
export default function AddressShipProduct(props: IAddressShipProductProps) {
    
    //const dispatch = useDispatch();
    
    // const {
    // } = useSelector(stateSelector);

    return (
        <>
            <div>
                <hr className="BozncDhktp" />
                <div className="hcUCOccMik">
                    <span>
                        Địa chỉ của bạn : 60/122,đường xuân phương,nam từ liêm,hà
                        nội <p>đổi địa chỉ</p>
                    </span>
                </div>
                <div className="hcUCOccMik">
                    <span>Phí vận chuyển : </span>
                    <Select defaultValue="lucy" bordered={false}>
                        <Option value="jack">Jack</Option>
                        <Option value="lucy">Lucy</Option>
                    </Select>
                </div>
                <hr className="BozncDhktp" />
            </div>
        </>
    )
}
