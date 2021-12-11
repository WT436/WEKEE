import { PlusOutlined, RedoOutlined, FilePdfOutlined, CheckOutlined, CloseOutlined } from '@ant-design/icons';
import { Button, Col, Input, Row, Select, Table, Tag } from 'antd';
import React, { useEffect } from 'react'
import { useDispatch, useSelector } from 'react-redux';
import { createStructuredSelector } from 'reselect';
import { AtomicgetListStart, listFormResourceStart, ResourceRemoveFeCancel, ResourceRemoveStart } from '../actions';
import { AtomicDto } from '../dtos/atomicDto';
import { makeSelectDataAtomic, makeSelectLoading } from '../selectors';
const { Option } = Select;
interface IAtomicComponentsProps {

}
const stateSelector = createStructuredSelector<any, any>({
    loading: makeSelectLoading(),
    data: makeSelectDataAtomic()
});
export default function AtomicComponents(props: IAtomicComponentsProps) {
    const dispatch = useDispatch();

    const {
        loading, data
    } = useSelector(stateSelector);

    useEffect(() => {
        dispatch(AtomicgetListStart());
    }, []);

    const columns = [
        {
            title: 'id',
            dataIndex: 'id',
            with: 50
        },
        {
            title: 'Tên',
            dataIndex: 'name',
            sorter: {
                compare: (a: { name: string; }, b: { name: string; }) => a.name.length - b.name.length,
                multiple: 3,
            },
        },
        {
            title: 'isActive',
            dataIndex: 'isActive',
            key: 'isActive',
            render: (text: boolean) => (text === true ? <Tag color="#2db7f5">True</Tag> : <Tag color="red">False</Tag>)
        },
        {
            title: 'Số lần sử dụng',
            dataIndex: 'count'
        },
        {
            title: 'Chi tiết',
            dataIndex: 'description'
        },
        {
            title: 'dateCreate',
            dataIndex: 'dateCreate'
        },
    ];
    return (
        <Row gutter={[10, 10]}>
            <Col span={24}>
                <Row gutter={[10, 10]} >
                    <Col span={3}>
                        <Button loading={loading} block icon={<PlusOutlined />}

                        >Thêm</Button></Col>
                    <Col span={3}><Button loading={loading} onClick={() => {

                    }} block icon={<RedoOutlined />}>Làm Mới</Button></Col>
                    <Col span={3}><Button loading={loading} block icon={<FilePdfOutlined />}>Xuất File</Button></Col>
                    <Col span={3}>
                        <Button loading={loading}
                            block
                            icon={<CheckOutlined />}>Lưu</Button></Col>
                    <Col span={3}><Button loading={loading}
                        onClick={() => {
                            dispatch(ResourceRemoveFeCancel());
                        }} block icon={<CloseOutlined />}>Hủy</Button>
                    </Col>
                    <Col span={5}>
                        <Input placeholder="Basic usage" />
                    </Col>
                    <Col span={2}>
                        <Select
                            showSearch
                            placeholder="Select a person"
                            optionFilterProp="children"
                            style={{ width: '100%'}}
                            filterOption={(input, option: any) =>
                                option.children.toLowerCase().indexOf(input.toLowerCase()) >= 0
                            }
                        >
                            <Option value="jack">Tất cả</Option>
                            <Option value="lucy">Lucy</Option>
                            <Option value="tom">Tom</Option>
                        </Select>
                    </Col>
                    <Col span={2}>
                        <Button type="primary">Tìm kiếm</Button>
                    </Col>
                </Row>
            </Col>
            <Row style={{ margin: '10px 0' }}>
                <Table
                    columns={columns}
                    rowKey={(record: AtomicDto) => record.id.toString()}
                    dataSource={data}
                    loading={loading}
                    style={{ width: 'calc(100% - 10px)' }}
                    scroll={{ y: 350 }}
                />
            </Row>
        </Row >
    )
}
