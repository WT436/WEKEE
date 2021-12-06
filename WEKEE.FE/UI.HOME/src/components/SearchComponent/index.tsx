import { Input, Menu, Select } from 'antd';
const { Option } = Select;
const { SubMenu } = Menu;
import React, { Component } from 'react'

export default class index extends Component {
    render() {
        return (
            <>
                <Input.Group compact>
                    <Select defaultValue="Option1">
                        <Option value="Option1">Tất Cả</Option>
                        <Option value="Option2">Tên sản phẩm</Option>
                        <Option value="Option3">Tên nhà cung cấp</Option>
                        <Option value="Option4">Tên người dùng</Option>
                        <Option value="Option5">Giá sản phẩm</Option>
                        <Option value="Option6">Mô tả sản phẩm</Option>
                        <Option value="Option7">Tag sản phẩm</Option>
                    </Select>
                    <Input.Search className='hdfutmipsdt' style={{ width: '80%' }} placeholder='Tìm kiếm sản phẩm, nhà cung cấp' />
                </Input.Group>
            </>
        )
    }
}
