//#region import
import React, { useEffect, useState } from 'react'
import { useDispatch, useSelector } from 'react-redux';
import { createStructuredSelector } from 'reselect';
import { listFormResourceStart, ResourceCreateStart, ResourceEditStart, ResourceRemoveFeCancel, ResourceRemoveFeStart, ResourceRemoveStart } from '../actions';
import {
    CheckOutlined, CloseOutlined, DeleteOutlined, EditOutlined,
    FilePdfOutlined, PlusOutlined, RedoOutlined
} from '@ant-design/icons';
import { Button, Col, Form, Input, Row, Select, Switch, Table, Tag } from 'antd'
import {
    makeSelectCompleted, makeSelectDataResource, makeSelectDataRemoveResource, makeSelectLoading, makeSelectPageIndex,
    makeSelectPageSize, makeSelectTotalCount, makeSelectTotalPages
} from '../selectors';
import { ResourceDto } from '../dtos/resourceDto';
const { Option } = Select;
//#endregion
interface IResourceComponentsProps {

}


const stateSelector = createStructuredSelector<any, any>({
    loading: makeSelectLoading(),
    completed: makeSelectCompleted(),
    pageIndex: makeSelectPageIndex(),
    pageSize: makeSelectPageSize(),
    totalCount: makeSelectTotalCount(),
    totalPages: makeSelectTotalPages(),
    dataResource: makeSelectDataResource(),
    dataRemoveResource: makeSelectDataRemoveResource()
});


export default function ResourceComponents(props: IResourceComponentsProps) {
    const [checkCreate, setCheckCreate] = useState(false);
    const [checkRemove, setCheckRemove] = useState(true);
    const [checkRestart, setCheckRestart] = useState(true);

    const dispatch = useDispatch();

    const {
        loading, dataResource, pageSize, totalCount, pageIndex,
        dataRemoveResource
    } = useSelector(stateSelector);

    useEffect(() => {
        dispatch(listFormResourceStart({
            pageIndex: pageIndex,
            pageSize: pageSize,
            property: '',
            orderBy: ''
        }));
    }, []);

    useEffect(() => {
        
    }, [pageSize]);

    useEffect(() => {
        if (dataRemoveResource.length === 0) {
            setCheckRemove(true);
        }
        else {
            setCheckRemove(false);
            setCheckRestart(false);
        }
    }, [dataRemoveResource]);


    const [form] = Form.useForm();

    const onFill = (value: ResourceDto) => {
        form.setFieldsValue(value);
    };
    const onRemove = (value: ResourceDto) => {
        dispatch(ResourceRemoveFeStart(value.id));
    };
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
            with: 300
        },
        {
            title: 'isActive',
            dataIndex: 'isActive',
            key: 'isActive',
            render: (text: boolean) => (text === true ? <Tag color="#2db7f5">True</Tag> : <Tag color="red">False</Tag>)
        },
        {
            title: 'Action',
            dataIndex: '',
            key: 'x',
            render: (text: ResourceDto) => (
                <div>
                    <Button type="link" icon={<EditOutlined />}
                        onClick={() => {
                            setCheckCreate(true);
                            onFill(text);
                        }}></Button>
                    &nbsp;
                    <Button type="link" icon={<DeleteOutlined />}
                        onClick={() => {
                            onRemove(text);
                        }}
                    ></Button>
                </div>
            )
        },
        {
            title: 'Kiểu',
            dataIndex: 'typesRsc'
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
    let onChange = (page: any, pageSize: any) => {
        dispatch(listFormResourceStart({
            pageIndex: page - 1,
            pageSize: pageSize,
            property: '',
            orderBy: ''
        }));
    };

    const onFinish = (values: ResourceDto) => {
        if (values.id === undefined) {
            dispatch(ResourceCreateStart(values));
        }
        else {
            dispatch(ResourceEditStart(values));
        }
    };

    const onReset = () => {
        setCheckCreate(false);
        form.resetFields();
    };
    const onGenderChange = (value: string) => {
        form.setFieldsValue({ types: value });
    };
    return (
        <Row gutter={[10, 10]} >
            <Col span={14}>
                <Row gutter={[10, 10]} >
                    <Col span={4}><Button loading={loading} onClick={() => {
                        dispatch(listFormResourceStart({
                            pageIndex: pageIndex,
                            pageSize: pageSize,
                            property: '',
                            orderBy: ''
                        }));
                        setCheckRestart(true);

                    }} disabled={checkRestart} block icon={<RedoOutlined />}>Làm Mới</Button></Col>
                    <Col span={4}><Button loading={loading} block icon={<FilePdfOutlined />}>Tải File</Button></Col>
                    <Col span={4}>
                        <Button loading={loading}
                            disabled={checkRemove}
                            block
                            onClick={()=>{dispatch(ResourceRemoveStart(dataRemoveResource))}}
                            icon={<CheckOutlined />}>Lưu</Button></Col>
                    <Col span={4}><Button loading={loading} disabled={checkRemove} onClick={() => dispatch(ResourceRemoveFeCancel())} block icon={<CloseOutlined />}>Hủy</Button></Col>
                </Row>
                <Row style={{ margin: '10px 0' }}>
                    <Table
                        columns={columns}
                        dataSource={dataResource}
                        rowKey={(record : ResourceDto) => record.id.toString()}
                        loading={loading}
                        scroll={{ y: 500, x: 1300 }}
                        pagination={{
                            pageSize: pageSize,
                            total: totalCount,
                            defaultCurrent: 1,
                            onChange: onChange,
                            showSizeChanger: true,
                            pageSizeOptions: ['5', '10', '20', '50', '100']
                        }}
                    />
                </Row>
            </Col>
            <Col span={10} style={{ textAlign: 'center' }} >
                <Row style={{ fontSize: '20px', fontFamily: 'initial', fontWeight: 600 }}>CHỈNH SỬA CHI TIẾT</Row>
                <Row style={{
                    fontSize: '16px', fontFamily: 'monospace',
                    margin: '10px 0', padding: '20px 10px',
                    borderTop: '3px solid #150799', borderRadius: '5px',
                }}
                >
                    <Form
                        name="basic"
                        labelCol={{ span: 8 }}
                        wrapperCol={{ span: 16 }}
                        initialValues={{ remember: true }}
                        form={form}
                        onFinish={onFinish}
                        style={{ width: '100%', textAlign: 'left' }}
                    >
                        <Form.Item
                            label="ID"
                            name="id"
                        >
                            <Input disabled />
                        </Form.Item>

                        <Form.Item
                            label="Đường dẫn"
                            name="name"
                            rules={[{ required: true, message: 'Đường dẫn không được để trống!' }]}
                        >
                            <Input />
                        </Form.Item>
                        <Form.Item
                            label="Kiểu"
                            name="typesRsc"
                        >
                            <Select
                                onChange={onGenderChange}
                                allowClear
                                style={{ width: '100%' }}
                                defaultValue="_">
                                <Option value="_">Chọn Kiểu dữ liệu</Option>
                                <Option value="URL">URL</Option>
                            </Select>
                        </Form.Item>
                        <Form.Item
                            label="Chi Tiết"
                            name="description"
                            rules={[{ required: true, message: 'Please input your password!' }]}
                        >
                            <Input.TextArea />
                        </Form.Item>
                        <Form.Item name="isActive" label="Trạng Thái" valuePropName="checked">
                            <Switch />
                        </Form.Item>
                        <Form.Item
                            label="Ngày sửa :"
                            name="dateCreate"
                        >
                            <Input disabled />
                        </Form.Item>
                        <Row gutter={[10, 10]}>
                            <Col span={6}><Button loading={loading} onClick={onReset} block icon={<RedoOutlined />}>Làm Mới</Button></Col>
                            <Col span={6}><Button loading={loading} disabled={!checkCreate} type="primary" htmlType="submit" block icon={<CheckOutlined />}>Lưu</Button></Col>
                            <Col span={6}><Button loading={loading} disabled={!checkCreate} onClick={onReset} block icon={<CloseOutlined />}>Hủy</Button></Col>
                            <Col span={6}><Button loading={loading} disabled={checkCreate} type="primary" htmlType="submit" block icon={<PlusOutlined />}>Tạo mới</Button></Col>
                        </Row>
                    </Form>
                </Row>
            </Col>
        </Row >
    )
}
