//#region import
import React, { useEffect, useState } from 'react'
import { useDispatch, useSelector } from 'react-redux';
import { createStructuredSelector } from 'reselect';
import { listFormRoleStart, RoleCreateStart, RoleEditStart, RoleRemoveFeCancel, RoleRemoveFeStart, RoleRemoveStart } from '../actions';
import {
    CheckOutlined, CloseOutlined, DeleteOutlined, EditOutlined,
    FilePdfOutlined, PlusOutlined, RedoOutlined
} from '@ant-design/icons';
import { Button, Col, Form, Input, Row, Switch, Table, Tag } from 'antd'
import {
    makeSelectCompleted, makeSelectDataRole, makeSelectDataRemoveRole, makeSelectLoading, makeSelectPageIndex,
    makeSelectPageSize, makeSelectTotalCount, makeSelectTotalPages
} from '../selectors';
import { RoleDto } from '../dtos/roleDto';
//#endregion

interface IRoleComponentsProps {

}


const stateSelector = createStructuredSelector<any, any>({
    loading: makeSelectLoading(),
    completed: makeSelectCompleted(),
    pageIndex: makeSelectPageIndex(),
    pageSize: makeSelectPageSize(),
    totalCount: makeSelectTotalCount(),
    totalPages: makeSelectTotalPages(),
    dataRole: makeSelectDataRole(),
    dataRemoveRole: makeSelectDataRemoveRole()
});


export default function RoleComponents(props: IRoleComponentsProps) {
    const [checkCreate, setCheckCreate] = useState(false);
    const [checkRemove, setCheckRemove] = useState(true);
    const [checkRestart, setCheckRestart] = useState(true);

    const dispatch = useDispatch();

    const {
        loading, dataRole, pageSize, totalCount, pageIndex,
        dataRemoveRole
    } = useSelector(stateSelector);

    useEffect(() => {
        dispatch(listFormRoleStart({
            pageIndex: pageIndex,
            pageSize: pageSize,
            property: "",
            orderBy: "",
        }));
    }, []);

    useEffect(() => {

    }, [pageSize]);

    useEffect(() => {
        if (dataRemoveRole.length === 0) {
            setCheckRemove(true);
        }
        else {
            setCheckRemove(false);
            setCheckRestart(false);
        }
    }, [dataRemoveRole]);


    const [form] = Form.useForm();

    const onFill = (value: RoleDto) => {
        form.setFieldsValue(value);
    };
    const onRemove = (value: RoleDto) => {
        dispatch(RoleRemoveFeStart(value.id));
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
            title: 'Kích Hoạt',
            dataIndex: 'isActive',
            key: 'isActive',
            render: (text: boolean) => (text === true ? <Tag color="#2db7f5">True</Tag> : <Tag color="red">False</Tag>)
        },
        {
            title: 'Xóa Bỏ',
            dataIndex: 'isDelete',
            key: 'isDelete',
            render: (text: boolean) => (text === true ? <Tag color="#2db7f5">True</Tag> : <Tag color="red">False</Tag>)
        },
        {
            title: 'Action',
            dataIndex: '',
            key: 'x',
            render: (text: RoleDto) => (
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
            title: 'Cấp độ',
            dataIndex: 'levelRole'
        },
        {
            title: 'Role cha',
            dataIndex: 'roleId'
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
        dispatch(listFormRoleStart({
            pageIndex: page - 1,
            pageSize: pageSize,
            property: "",
            orderBy: "",
        }));
    };

    const onFinish = (values: RoleDto) => {
        if (values.id === undefined) {
            dispatch(RoleCreateStart(values));
        }
        else {
            dispatch(RoleEditStart(values));
        }
    };

    const onReset = () => {
        setCheckCreate(false);
        form.resetFields();
    };
    return (
        <Row gutter={[10, 10]} >
            <Col span={14}>
                <Row gutter={[10, 10]} >
                    <Col span={4}><Button loading={loading} onClick={() => {
                        dispatch(listFormRoleStart({
                            pageIndex: pageIndex,
                            pageSize: pageSize,
                            property: "",
                            orderBy: "",
                        }));
                        setCheckRestart(true);

                    }} disabled={checkRestart} block icon={<RedoOutlined />}>Làm Mới</Button></Col>
                    <Col span={4}><Button loading={loading} block icon={<FilePdfOutlined />}>Tải File</Button></Col>
                    <Col span={4}>
                        <Button loading={loading}
                            disabled={checkRemove}
                            block
                            onClick={() => { dispatch(RoleRemoveStart(dataRemoveRole)) }}
                            icon={<CheckOutlined />}>Lưu</Button></Col>
                    <Col span={4}><Button loading={loading} disabled={checkRemove} onClick={() => dispatch(RoleRemoveFeCancel())} block icon={<CloseOutlined />}>Hủy</Button></Col>
                </Row>
                <Row style={{ margin: '10px 0' }}>
                    <Table
                        columns={columns}
                        dataSource={dataRole}
                        rowKey={(record: RoleDto) => record.id.toString()}
                        loading={loading}
                        scroll={{ y: 500, x: 900 }}
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
                            label="Tên :"
                            name="name"
                            rules={[{ required: true, message: 'Tên không được để trống!' }]}
                        >
                            <Input />
                        </Form.Item>
                        <Form.Item
                            label="Chi Tiết"
                            name="description"
                            rules={[{ required: true, message: 'Please input your password!' }]}
                        >
                            <Input.TextArea />
                        </Form.Item>
                        <Form.Item
                            label="RoleId :"
                            name="roleId"
                            initialValue={1}
                        >
                            <Input type='number' />
                        </Form.Item>
                        <Form.Item
                            label="level Role :"
                            name="levelRole"
                            initialValue={0}
                            rules={[{ required: true, message: 'level Role không được để trống!' }]}
                        >
                            <Input type='number' max='100' min='0' />
                        </Form.Item>
                        <Form.Item name="isActive" label="Active">
                            <Switch />
                        </Form.Item>
                        <Form.Item name="isDelete" label="Delete">
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
