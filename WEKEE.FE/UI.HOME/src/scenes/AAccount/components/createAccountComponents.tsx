import { Button, Col, Form, Input, Radio, Row, Select, Upload } from 'antd'
import Checkbox from 'antd/lib/checkbox/Checkbox'
import Title from 'antd/lib/typography/Title'
import React, { useEffect, useState } from 'react'
import ImgCrop from 'antd-img-crop';
import { useDispatch, useSelector } from 'react-redux';
import { createStructuredSelector } from 'reselect';
import { makeSelectAccountAdminCreate, makeSelectLoading } from '../selectors';
import { createAccountAdminStart, removeAvatarUploadStart } from '../actions';
import { AccountAdminCreate } from '../dtos/accountAdminCreate';

const { Option } = Select;



declare var abp: any;

const stateSelector = createStructuredSelector<any, any>({
    loading: makeSelectLoading(),
    accountAdminCreate: makeSelectAccountAdminCreate(),
});
export default function CreateAccountComponents() {

    const [form] = Form.useForm();

    const dispatch = useDispatch();

    const {
        loading, accountAdminCreate
    } = useSelector(stateSelector);
    useEffect(() => {
        form.setFieldsValue(accountAdminCreate);
    }, []);

    const [fileList, setFileList] = useState('');

    const handleChange = (info: any) => {
        if (fileList !== '') {
            dispatch(removeAvatarUploadStart(fileList));
        }

        if (info.file.response !== undefined) {
            setFileList(info.file.response.url.toString());
        }
    };



    const onFinish = (values: AccountAdminCreate) => {
        values.picture = fileList;
        values.timeZone = '';
        dispatch(createAccountAdminStart(values));
    };

    return (
        <>
            <Title level={3}>Tạo hoặc chỉnh sửa Tài Khoản</Title>
            <Row>
                <Form
                    layout="inline"
                    style={{ width: '100%' }}
                    form={form}
                    onFinish={onFinish}
                >
                    <Row gutter={[10, 10]}>
                        <Col span={24}>
                            <Title level={5} style={{ borderBottom: '1px solid gainsboro' }}>Thông Tin Căn Bản</Title>
                        </Col>
                        <Col span={24}>
                            <Form.Item name="id" initialValue={0} label="Id tài khoản">
                                Chưa có
                            </Form.Item>
                        </Col>
                        <Col span={8}>
                            <Form.Item name="firstName" rules={[{ required: true }]}>
                                <Input placeholder='Họ' />
                            </Form.Item>
                        </Col>
                        <Col span={8}>
                            <Form.Item name="lastName" rules={[{ required: true }]}>
                                <Input placeholder='Tên' />
                            </Form.Item>
                        </Col>
                        <Col span={8}>
                            <Form.Item name="acceptTermOfService" valuePropName="checked" rules={[{ required: true }]}>
                                <Checkbox>Chấp nhận Điều khoản</Checkbox>
                            </Form.Item>
                        </Col>
                        <Col span={8}>
                            <Form.Item name="facebookId" initialValue={false} label="Liên kết Facebook">
                                Chưa có
                            </Form.Item>
                        </Col>
                        <Col span={8}>
                            <Form.Item name="googleId" initialValue={false} label="Liên kết Google">
                                Chưa có
                            </Form.Item>
                        </Col>
                        <Col span={8}>
                            <Form.Item name="zaloId" initialValue={false} label="Liên kết Zalo">
                                Chưa có
                            </Form.Item>
                        </Col>
                        <Col span={24}>
                            <Title level={5} style={{ borderBottom: '1px solid gainsboro' }}>Thông tin đăng nhập</Title>
                        </Col>
                        <Col span={8}>
                            <Form.Item name="userName" rules={[{ required: true }]}>
                                <Input placeholder='Tên Tài khoản' />
                            </Form.Item>
                        </Col>
                        <Col span={8}>
                            <Form.Item name="email" rules={[{ required: true }]}>
                                <Input placeholder='Email' type='email' />
                            </Form.Item>
                        </Col>
                        <Col span={8}>
                            <Form.Item name="numberPhone" rules={[{ required: true }]}>
                                <Input placeholder='Số điện thoại' type='number' />
                            </Form.Item>
                        </Col>
                        <Col span={8}>
                            <Form.Item name="password" rules={[{ required: true }]}>
                                <Input placeholder='Mật khẩu' type='password' />
                            </Form.Item>
                        </Col>
                        <Col span={8}>
                            <Form.Item name="passwordAgain" dependencies={['password']}
                                hasFeedback
                                rules={[
                                    {
                                        required: true,
                                        message: 'Please confirm your password!',
                                    },
                                    ({ getFieldValue }) => ({
                                        validator(_, value) {
                                            if (!value || getFieldValue('password') === value) {
                                                return Promise.resolve();
                                            }
                                            return Promise.reject(new Error('Mật khẩu không khớp!'));
                                        },
                                    }),
                                ]}>
                                <Input placeholder='Nhập lại Mật khẩu' type='password' />
                            </Form.Item>
                        </Col>
                        <Col span={24}>
                            <Form.Item name="isStatus" rules={[{ required: true }]}>
                                <Radio.Group>
                                    <Radio value={0}>Đang Hoạt động</Radio>
                                    <Radio value={1}>Đang chờ Xác nhận</Radio>
                                    <Radio value={2}>Đang được lấy lại</Radio>
                                    <Radio value={3}>Đang mất tài khoản</Radio>
                                    <Radio value={4}>Đang đăng nhập sai nhiều lần</Radio>
                                    <Radio value={5}>Đang checkpoint</Radio>
                                </Radio.Group>
                            </Form.Item>
                        </Col>
                        <Col span={24}>
                            <Title level={5} style={{ borderBottom: '1px solid gainsboro' }}>Thông tin địa chỉ</Title>
                        </Col>
                        <Col span={8}>
                            <Form.Item name="adressLine1" rules={[{ required: true }]}>
                                <Input placeholder='Địa Chỉ Chính' />
                            </Form.Item>
                        </Col>
                        <Col span={8}>
                            <Form.Item name="adressLine2" rules={[{ required: true }]}>
                                <Input placeholder='Địa chỉ phụ 1' />
                            </Form.Item>
                        </Col>
                        <Col span={8}>
                            <Form.Item name="adressLine3" rules={[{ required: true }]}>
                                <Input placeholder='Địa chỉ phụ 2' />
                            </Form.Item>
                        </Col>
                        <Col span={8}>
                            <Form.Item name="descriptionAdress" rules={[{ required: true }]}>
                                <Input.TextArea placeholder='Miêu tả' />
                            </Form.Item>
                        </Col>
                        <Col span={8}>
                            <Form.Item name="isActive" valuePropName="checked" rules={[{ required: true }]}>
                                <Checkbox value="a">Trạng thái</Checkbox>
                            </Form.Item>
                        </Col>
                        <Col span={24}>
                            <Title level={5} style={{ borderBottom: '1px solid gainsboro' }}>Thông tin cá nhân</Title>
                        </Col>
                        <Col span={8}>
                            <ImgCrop rotate>
                                <Upload
                                    action="https://localhost:44324/v1/api/patch/upload-avatar"
                                    name="file"
                                    method="POST"
                                    listType="picture-card"
                                    className="avatar-uploader"
                                    showUploadList={false}
                                    onChange={handleChange}
                                >
                                    {fileList ? <img src={abp.serviceAlbumImage + fileList} alt="avatar" style={{ width: '100%' }} /> : 'Upload'}
                                </Upload>
                            </ImgCrop>
                        </Col>
                        <Col span={8}>
                            <Form.Item
                                name="gender"
                                hasFeedback
                                rules={[{ required: true }]}
                            >
                                <Select placeholder="Giới tính!">
                                    <Option value="Nam">Nam</Option>
                                    <Option value="Nữ">Nữ</Option>
                                    <Option value="Khác">Khác</Option>
                                </Select>
                            </Form.Item>
                        </Col>
                        <Col span={8}>
                            <Form.Item name="description" rules={[{ required: true }]}>
                                <Input.TextArea placeholder='Miêu tả' />
                            </Form.Item>
                        </Col>
                        <Col style={{
                            textAlign: 'center'
                        }} span={24}>
                            <Form.Item>
                                <Button type="primary" style={{ margin: '0 8px' }} htmlType="submit" loading={loading}>Lưu lại</Button>
                                <Button type="default" style={{ margin: '0 8px' }}>Làm sạch</Button>
                            </Form.Item>
                        </Col>
                    </Row>
                </Form>
            </Row>
        </>
    )
}