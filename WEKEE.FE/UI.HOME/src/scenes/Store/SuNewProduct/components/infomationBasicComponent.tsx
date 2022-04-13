import { PlusCircleOutlined } from '@ant-design/icons';
import { Button, Col, Form, message, Modal, Row, Typography, Upload } from 'antd';
import React, { useEffect, useState } from 'react'
import { useDispatch, useSelector } from 'react-redux';
import { createStructuredSelector } from 'reselect';
import EditorComponent from '../../../../components/EditorComponent';
import { ContainerCreateProductStart } from '../actions';
import { ImageProductDtos } from '../dtos/imageProductDtos';
import { makeSelectLoading, makeSelectproductContainer, makeSelectproductDto } from '../selectors';
const { Text } = Typography;

declare var abp: any;

interface IInfomationBasicComponent {
    parentCallback: any
}

function beforeUpload(file: any) {

    const isJpgOrPng = file.type === 'image/jpeg' || file.type === 'image/png';
    if (!isJpgOrPng) {
        message.error('ảnh cần có định dạng JPG/PNG!');
    }

    const isLt2M = file.size / 1024 / 1024 < 2;
    if (!isLt2M) {
        message.error('Ảnh không được lớn hơn 2MB!');
    }

    return isJpgOrPng && isLt2M;
}

const stateSelector = createStructuredSelector < any, any> ({
    loading: makeSelectLoading(),
    productDto: makeSelectproductDto(),
    productContainer: makeSelectproductContainer()
});
export default function InfomationBasicComponent(props: IInfomationBasicComponent) {

    const {
        productContainer
    } = useSelector(stateSelector);

    const dispatch = useDispatch();

    //useState
    const [fileList, setFileList] = useState < ImageProductDtos[] > ([
        {
            uid: '',
            name: '',
            status: '',
            url: '',
        },
        {
            uid: '',
            name: '',
            status: '',
            url: '',
        },
        {
            uid: '',
            name: '',
            status: '',
            url: '',
        },
        {
            uid: '',
            name: '',
            status: '',
            url: '',
        },
        {
            uid: '',
            name: '',
            status: '',
            url: '',
        },
        {
            uid: '',
            name: '',
            status: '',
            url: '',
        },
        {
            uid: '',
            name: '',
            status: '',
            url: '',
        },
        {
            uid: '',
            name: '',
            status: '',
            url: '',
        },
        {
            uid: '',
            name: '',
            status: '',
            url: '',
        },
    ]);
    //useEffect

    const handleChange = (info: any, id: number) => {
        if (info.file.response !== undefined) {
            fileList[id].url = info.file.response.url.toString()
            setFileList([...fileList]);
        }
        props.parentCallback(fileList);
    };

    //#region Map Image
    useEffect(() => {
        var dataImage: string[] = [];
        fileList.forEach(m => dataImage.push(m.url));
        productContainer.imageRoot = dataImage;
        dispatch(ContainerCreateProductStart(productContainer));
    }, [fileList]);
    //#endregion

    //#region Modal Review  And Process 
    const [isModalVisible, setIsModalVisible] = useState(false);
    const [ShortDescription, setShortDescription] = useState < string > ("");
    const [FullDescription, setFullDescription] = useState < string > ("");
    const [IsShortDescription, setIsShortDescription] = useState(false)

    const showModal = (isShortDescription: boolean) => {
        setIsShortDescription(isShortDescription)
        setIsModalVisible(true);
    };

    const ConfirmOkShort = () => {
        productContainer.productInsertDto.shortDescription = ShortDescription;
        productContainer.productInsertDto.fullDescription = FullDescription;
        dispatch(ContainerCreateProductStart(productContainer));
    };

    const handleCancel = () => {
        setIsModalVisible(false);
    };

    const callbackEditorHTMLShortDescription = (childData: string) => {
        setShortDescription(childData);
    }
    const callbackEditorHTMLFullDescription = (childData: string) => {
        setFullDescription(childData);
    }

    //#endregion

    return (
        <>
            <Form.Item
                name="Hình Ảnh Sản Phẩm"
                label="Hình Ảnh Sản Phẩm"
                rules={[
                    {
                        required: true,
                        message: 'Please input your name',
                    },
                ]}
            >
                <Row>
                    <Col span={4}>
                        <Upload
                            action={abp.serviceAlbumAPI + "patch/upload-product"}
                            name="files"
                            method="POST"
                            listType="picture-card"
                            className="avatar-uploader"
                            beforeUpload={beforeUpload}
                            showUploadList={false}
                            onChange={(info: any) => handleChange(info, 0)}
                        >
                            {fileList[0].url !== '' ? <img src={abp.serviceAlbumImage + fileList[0].url} alt="avatar" style={{ width: '100%' }} /> : <PlusCircleOutlined className="esQVBWrDEg" />}
                        </Upload>
                        Ảnh Bìa
                    </Col>
                    <Col span={4}>
                        <Upload
                            action={abp.serviceAlbumAPI + "patch/upload-product"}
                            name="files"
                            method="POST"
                            listType="picture-card"
                            className="avatar-uploader"
                            showUploadList={false}
                            beforeUpload={beforeUpload}
                            onChange={(info: any) => handleChange(info, 1)}
                        >
                            {fileList[1].url !== '' ? <img src={abp.serviceAlbumImage + fileList[1].url} alt="avatar" style={{ width: '100%' }} /> : <PlusCircleOutlined className="esQVBWrDEg" />}
                        </Upload>
                        Ảnh 1
                    </Col>
                    <Col span={4}>
                        <Upload
                            action={abp.serviceAlbumAPI + "patch/upload-product"}
                            name="files"
                            method="POST"
                            listType="picture-card"
                            className="avatar-uploader"
                            showUploadList={false}
                            beforeUpload={beforeUpload}
                            onChange={(info: any) => handleChange(info, 2)}
                        >
                            {fileList[2].url !== '' ? <img src={abp.serviceAlbumImage + fileList[2].url} alt="avatar" style={{ width: '100%' }} /> : <PlusCircleOutlined className="esQVBWrDEg" />}
                        </Upload>
                        Ảnh 2
                    </Col>
                    <Col span={4}>
                        <Upload
                            action={abp.serviceAlbumAPI + "patch/upload-product"}
                            name="files"
                            method="POST"
                            listType="picture-card"
                            className="avatar-uploader"
                            showUploadList={false}
                            beforeUpload={beforeUpload}
                            onChange={(info: any) => handleChange(info, 3)}
                        >
                            {fileList[3].url !== ''
                                ? <img src={abp.serviceAlbumImage + fileList[3].url} alt="avatar" style={{ width: '100%' }} />
                                : <PlusCircleOutlined className="esQVBWrDEg" />}
                        </Upload>
                        Ảnh 3
                    </Col>
                    <Col span={4}>
                        <Upload
                            action={abp.serviceAlbumAPI + "patch/upload-product"}
                            name="files"
                            method="POST"
                            listType="picture-card"
                            className="avatar-uploader"
                            showUploadList={false}
                            beforeUpload={beforeUpload}
                            onChange={(info: any) => handleChange(info, 4)}
                        >
                            {fileList[4].url !== ''
                                ? <img src={abp.serviceAlbumImage + fileList[4].url} alt="avatar" style={{ width: '100%' }} />
                                : <PlusCircleOutlined className="esQVBWrDEg" />}
                        </Upload>
                        Ảnh 4
                    </Col>
                    <Col span={4}>
                        <Upload
                            action={abp.serviceAlbumAPI + "patch/upload-product"}
                            name="files"
                            method="POST"
                            listType="picture-card"
                            className="avatar-uploader"
                            showUploadList={false}
                            beforeUpload={beforeUpload}
                            onChange={(info: any) => handleChange(info, 5)}
                        >
                            {fileList[5].url !== ''
                                ? <img src={abp.serviceAlbumImage + fileList[5].url} alt="avatar" style={{ width: '100%' }} />
                                : <PlusCircleOutlined className="esQVBWrDEg" />}
                        </Upload>
                        Ảnh 5
                    </Col>
                    <Col span={4}>
                        <Upload
                            action={abp.serviceAlbumAPI + "patch/upload-product"}
                            name="files"
                            method="POST"
                            listType="picture-card"
                            className="avatar-uploader"
                            showUploadList={false}
                            beforeUpload={beforeUpload}
                            onChange={(info: any) => handleChange(info, 6)}
                        >
                            {fileList[6].url !== ''
                                ? <img src={abp.serviceAlbumImage + fileList[6].url} alt="avatar" style={{ width: '100%' }} />
                                : <PlusCircleOutlined className="esQVBWrDEg" />}
                        </Upload>
                        Ảnh 6
                    </Col>
                    <Col span={4}>
                        <Upload
                            action={abp.serviceAlbumAPI + "patch/upload-product"}
                            name="files"
                            method="POST"
                            listType="picture-card"
                            className="avatar-uploader"
                            showUploadList={false}
                            beforeUpload={beforeUpload}
                            onChange={(info: any) => handleChange(info, 7)}
                        >
                            {fileList[7].url !== ''
                                ? <img src={abp.serviceAlbumImage + fileList[7].url} alt="avatar" style={{ width: '100%' }} />
                                : <PlusCircleOutlined className="esQVBWrDEg" />}
                        </Upload>
                        Ảnh 7
                    </Col>
                    <Col span={4}>
                        <Upload
                            action={abp.serviceAlbumAPI + "patch/upload-product"}
                            name="files"
                            method="POST"
                            listType="picture-card"
                            className="avatar-uploader"
                            showUploadList={false}
                            beforeUpload={beforeUpload}
                            onChange={(info: any) => handleChange(info, 8)}
                        >
                            {fileList[8].url !== ''
                                ? <img src={abp.serviceAlbumImage + fileList[8].url} alt="avatar" style={{ width: '100%' }} />
                                : <PlusCircleOutlined className="esQVBWrDEg" />}
                        </Upload>
                        Ảnh 8
                    </Col>
                </Row>
            </Form.Item>

            <Form.Item
                name="Video sản phẩm"
                label="Video sản phẩm"
                rules={[
                    {
                        required: true,
                        message: 'Please input your name',
                    },
                ]}
            >
                <Row>
                    <Col span={4}>
                        <Upload
                            action=""
                            name="file"
                            method="POST"
                            listType="picture-card"
                            className="avatar-uploader"
                            showUploadList={false}
                        >
                            {fileList[8].url !== ''
                                ? <img src={abp.serviceAlbumImage + fileList[8].url} alt="avatar" style={{ width: '100%' }} />
                                : <PlusCircleOutlined className="esQVBWrDEg" />}
                        </Upload>
                        Video Bìa
                    </Col>
                    <Col span={20}>
                        <Text className="HR0PH7NZ6x" type="secondary">1. Kích thước: Tối đa 30Mb, độ phân giải không vượt quá 1280x1280px</Text>
                        <Text className="HR0PH7NZ6x" type="secondary">2. Độ dài: 10s-60s</Text>
                        <Text className="HR0PH7NZ6x" type="secondary">3. Định dạng: MP4 (không hỗ trợ vp9)</Text>
                        <Text className="HR0PH7NZ6x" type="secondary">4. Lưu ý: sản phẩm có thể hiển thị trong khi video đang được xử lý. Video sẽ tự động hiển thị sau khi đã xử lý thành công.</Text>
                    </Col>
                </Row>
            </Form.Item>

            <Form.Item
                name="Mô tả sản phẩm ngắn gọn"
                label={
                    <div> Mô tả sản phẩm ngắn gọn &emsp;
                        <Button type="primary" onClick={() => showModal(true)}>
                            Xem thử
                        </Button>
                    </div>
                }
                className='MJnbqTsvvM'
                rules={[
                    {
                        required: true,
                        message: 'Please input your name',
                    },
                ]}
            >
                <EditorComponent editorHTMLCallback={callbackEditorHTMLShortDescription} />
            </Form.Item>

            <Form.Item
                name="Mô tả sản phẩm Đầy đủ"
                label={
                    <div> Mô tả sản phẩm đầy đủ &emsp;
                        <Button type="primary" onClick={() => showModal(false)}>
                            Xem thử
                        </Button>
                    </div>
                }
                className='MJnbqTsvvM'
                rules={[
                    {
                        required: true,
                        message: 'Please input your name',
                    },
                ]}
            >
                <EditorComponent editorHTMLCallback={callbackEditorHTMLFullDescription} />
            </Form.Item>
            <div style={{ margin: '10px 0', textAlign: "center" }}>
                <Button
                    type='primary'
                    style={{ margin: '0 10px ', textAlign: "center" }}
                    onClick={() => { ConfirmOkShort() }}
                >Áp dụng description</Button>
            </div>
            <Modal
                title="Kiểm tra hiển thị"
                visible={isModalVisible}
                footer={null}
                className='UYtFCeVF'
                style={{ width: '60vw !important' }}
                onCancel={handleCancel}>
                <div
                    dangerouslySetInnerHTML={{
                        __html: IsShortDescription ? ShortDescription : FullDescription,
                    }}
                ></div>
            </Modal>
        </>
    )
}
