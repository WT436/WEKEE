//#region  import
import { HomeOutlined, LoadingOutlined, PlusOutlined } from '@ant-design/icons';
import { Avatar, Breadcrumb, Button, Card, Checkbox,
     Col, Form, Input, InputNumber, message, Row, 
     Table, Tag, Typography, Upload } from 'antd'
import * as React from 'react';
import { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { createStructuredSelector } from 'reselect';
import { useInjectReducer, useInjectSaga } from '../../redux/reduxInjectors';
import { createCategoryAdminStart, getCategoryAdminStart, watchPageStart } from './actions';
import { CategoryDtos } from './dtos/categoryDtos';
import reducer from './reducer';
import saga from './saga';
import {
    makeSelectLoading, makeSelectPageIndex, makeSelectPageSize,
    makeSelectTotalCount, makeSelectTotalPages, makeSelectCategoryDtos
} from './selectors';
const { Text } = Typography;

//#endregion

declare var abp: any;
export interface IACategoryProps {
    location: any;
}
const key = 'acategory';
const stateSelector = createStructuredSelector<any, any>({
    loading: makeSelectLoading(),
    pageIndex: makeSelectPageIndex(),
    pageSize: makeSelectPageSize(),
    totalCount: makeSelectTotalCount(),
    totalPages: makeSelectTotalPages(),
    categoryDtos: makeSelectCategoryDtos()
});

function beforeUpload(file: any) {
    const isJpgOrPng = file.type === 'image/jpeg' || file.type === 'image/png';
    if (!isJpgOrPng) {
        message.error('Bạn cần upload file JPG/PNG!');
    }
    const isLt2M = file.size / 1024 < 100;
    if (!isLt2M) {
        message.error('Ảnh không được phép lớn hơn 100kb!');
    }
    return isJpgOrPng && isLt2M;
}

export default function ACategory(props: IACategoryProps) {

    useInjectReducer(key, reducer);
    useInjectSaga(key, saga);
    const dispatch = useDispatch();

    const { loading, pageIndex, pageSize, totalCount,
        categoryDtos
    } = useSelector(stateSelector);

    const [loadingImage, setLoadingImage] = React.useState(false);
    const [imageUrl, setImageUrl] = React.useState("");
    const [idCategoryRoot, setIdCategoryRoot] = React.useState(false);
    const [categoryDrive1, setCategoryDrive1] = React.useState({ categoryMain: 0, name: "" });
    const [categoryDrive2, setCategoryDrive2] = React.useState({ categoryMain: 0, name: "" });
    const [categoryDrive3, setCategoryDrive3] = React.useState({ categoryMain: 0, name: "" });

    useEffect(() => {
        dispatch(getCategoryAdminStart(1, 0, 0));
    }, []);

    const columns = [
        {
            title: 'id',
            dataIndex: 'id',
            key: 'id',
            render: (text: any) => <a>{text}</a>,
        },
        {
            title: 'Name Category',
            dataIndex: 'nameCategory',
            key: 'nameCategory',
        },
        {
            title: 'Url Category',
            dataIndex: 'urlCategory',
            key: 'urlCategory',
        },
        {
            title: 'Icon Category',
            key: 'iconCategory',
            dataIndex: 'iconCategory',
            render: (text: String) => <Avatar size={32} src={abp.serviceAlbumImage+ text} />
        },
        {
            title: 'level Category',
            key: 'levelCategory',
            dataIndex: 'levelCategory'
        },
        {
            title: 'category Main',
            key: 'categoryMain',
            dataIndex: 'categoryMain'
        },
        {
            title: 'number Order',
            key: 'numberOrder',
            dataIndex: 'numberOrder'
        },
        {
            title: 'isEnabled',
            key: 'isEnabled',
            dataIndex: 'isEnabled',
            render: (text: boolean) => (text === true ? <Tag color="#2db7f5">True</Tag> : <Tag color="red">False</Tag>)
        }
    ];

    const normFile = (info: any) => {
        if (info.file.status === 'uploading') {
            setLoadingImage(true);
            return;
        }
        if (info.file.status === 'done') {
            // // Get this url from response in real world.
            setImageUrl(abp.serviceAlbumImage+ info.file.response.url.toString());

            setLoadingImage(false);
            return info.file.response.url.toString();
        }
    };

    const uploadButton = (
        <div>
            {loadingImage ? <LoadingOutlined /> : <PlusOutlined />}
            <div style={{ marginTop: 8 }}>Upload</div>
        </div>
    );

    const onFinish = (values: CategoryDtos) => {
        dispatch(createCategoryAdminStart(values));
    };

    const rowSelection = {
        onChange: (selectedRowKeys: React.Key[], selectedRows: CategoryDtos[]) => {
            if (selectedRows[0].levelCategory == 1) {
                setCategoryDrive1({ categoryMain: selectedRows[0].id, name: selectedRows[0].nameCategory })
            }
            dispatch(getCategoryAdminStart(selectedRows[0].levelCategory + 1, selectedRows[0].id, 0));
        }
    };

    return (
        <Row gutter={[20, 10]}>
            <Col span={24}>
                <Card title='Cấp độ Danh Mục' size="small" type="inner" loading={loading}>
                    <Breadcrumb>
                        <Breadcrumb.Item onClick={() => {
                            setCategoryDrive1({ categoryMain: 0, name: "" })
                            setCategoryDrive2({ categoryMain: 0, name: "" })
                            setCategoryDrive3({ categoryMain: 0, name: "" })
                            dispatch(getCategoryAdminStart(1, 0, 0))
                        }}>
                            <a><HomeOutlined /></a>
                        </Breadcrumb.Item>
                        <Breadcrumb.Item onClick={() => {
                            setCategoryDrive2({ categoryMain: 0, name: "" })
                            setCategoryDrive3({ categoryMain: 0, name: "" })
                            dispatch(getCategoryAdminStart(2, 0, 0))
                        }}>
                            <a>{categoryDrive1.name}</a>
                        </Breadcrumb.Item>
                        <Breadcrumb.Item onClick={() => {
                            setCategoryDrive3({ categoryMain: 0, name: "" })
                            dispatch(getCategoryAdminStart(3, 0, 0))
                        }}>
                            <a>{categoryDrive2.name}</a>
                        </Breadcrumb.Item>
                        <Breadcrumb.Item onClick={() => dispatch(getCategoryAdminStart(4, 0, 0))}>
                            <a>{categoryDrive3.name}</a>
                        </Breadcrumb.Item>
                    </Breadcrumb>
                </Card>
            </Col>
            <Col span={24}>
                <Card title='Chỉnh sửa Dữ liệu' size="small" type="inner" loading={loading}>
                    <Form
                        labelCol={{ span: 10 }}
                        wrapperCol={{ span: 14 }}
                        initialValues={{ isEnabled: true }}
                        onFinish={onFinish}
                    >
                        <Row>
                            <Col span={8}>
                                <Form.Item
                                    name="nameCategory"
                                    label="Tên Danh Mục"
                                    rules={[{ required: true, message: 'Tên danh mục không được để trống!' }]}
                                >
                                    <Input />
                                </Form.Item>
                            </Col>

                            <Col span={8}>
                                <Form.Item
                                    name="urlCategory"
                                    label="Đường dẫn"
                                    rules={[{ required: true, message: 'Đường dẫn danh mục không được để trống!' }]}
                                >
                                    <Input />
                                </Form.Item>
                            </Col>
                            <Col span={8}>
                                <Form.Item
                                    name="levelCategory"
                                    label="Cấp độ Danh Mục"
                                >
                                    <InputNumber onChange={(value: number) => { value === 1 ? setIdCategoryRoot(true) : setIdCategoryRoot(false) }} min={1} max={4} />
                                </Form.Item>
                            </Col>
                            <Col span={8}>
                                <Form.Item
                                    name="categoryMain"
                                    label="Id Danh Mục Gốc"
                                >
                                    <InputNumber disabled={idCategoryRoot} min={0} />
                                </Form.Item>
                            </Col>

                            <Col span={8}>
                                <Form.Item
                                    name="iconCategory"
                                    label="Icon Danh Mục"
                                    getValueFromEvent={normFile}
                                >
                                    <Upload
                                        name="file"
                                        listType="picture-card"
                                        className="avatar-uploader"
                                        showUploadList={false}
                                        action="https://localhost:44324/v1/api/patch/upload-icon"
                                        method="POST"
                                        beforeUpload={beforeUpload}
                                        disabled={!idCategoryRoot}
                                    >
                                        {imageUrl ? <img src={imageUrl} alt="avatar" style={{ width: '100%' }} /> : uploadButton}
                                    </Upload>
                                </Form.Item>
                            </Col>

                            <Col span={8}>
                                <Form.Item
                                    name="numberOrder"
                                    label="Vị trí Danh Mục"
                                    rules={[{ required: true, message: 'Vị trí danh mục không được để trống!' }]}
                                >
                                    <InputNumber value={0} min={0} />
                                </Form.Item>
                            </Col>
                            <Col span={24}>
                                <Form.Item name="isEnabled" wrapperCol={{ offset: 12, span: 24 }} valuePropName="checked">
                                    <Checkbox>Mở/Khóa Danh Mục</Checkbox>
                                </Form.Item>
                            </Col>
                        </Row>
                        <Form.Item wrapperCol={{ offset: 12, span: 24 }}>
                            <Button type="primary" htmlType="submit" >Khởi tạo</Button>
                        </Form.Item>
                    </Form>
                </Card>
            </Col>
            <Col span={24}>
                <Card title='Danh mục của : "Gậy chụp ảnh tự sướng"' size="small" type="inner" loading={loading}>
                    <Table
                        columns={columns}
                        pagination={false}
                        rowKey={(record: CategoryDtos | any) => record.id.toString()}
                        dataSource={categoryDtos}
                        loading={loading}
                        rowSelection={{
                            type: "radio",
                            ...rowSelection,
                        }} />
                </Card>
            </Col>
        </Row >
    )
}
