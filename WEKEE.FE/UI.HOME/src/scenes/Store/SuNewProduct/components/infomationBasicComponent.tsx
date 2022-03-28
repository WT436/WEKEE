import { PlusCircleOutlined } from '@ant-design/icons';
import { Col, Form, message, Row, Typography, Upload } from 'antd'
import { Console } from 'console';
import { convertToRaw, EditorState } from 'draft-js';
import draftToHtml from 'draftjs-to-html';
import React, { useEffect, useState } from 'react'
import { Editor } from 'react-draft-wysiwyg';
import { useSelector } from 'react-redux';
import { createStructuredSelector } from 'reselect';
import { setProductsStart } from '../actions';
import { ImageProductDtos } from '../dtos/imageProductDtos';
import { ProductDtos } from '../dtos/productDtos';
import { makeSelectLoading, makeSelectproductDto } from '../selectors';
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

function uploadImageCallBack(file: string | Blob) {
    return new Promise(
        (resolve, reject) => {
            const xhr = new XMLHttpRequest();
            xhr.open('POST', abp.appServiceUrl + '/v1/api/patch/upload-post');
            xhr.setRequestHeader('Authorization', abp.auth.getToken());
            const data = new FormData();
            data.append('file', file);
            xhr.send(data);
            xhr.addEventListener('load', () => {
                const response = JSON.parse(xhr.responseText);
                response.data.link = abp.serviceAlbumCss + "/" + response.data.link
                resolve(response);
            });
            xhr.addEventListener('error', () => {
                const error = JSON.parse(xhr.responseText);
                reject(error);
            });
        }
    );
}

const stateSelector = createStructuredSelector<any, any>({
    loading: makeSelectLoading(),
    productDto: makeSelectproductDto()
});
export default function InfomationBasicComponent(props: IInfomationBasicComponent) {

    const {
        loading, productDto
    } = useSelector(stateSelector);

    //useState
    const [fileList, setFileList] = useState<ImageProductDtos[]>([
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

    const [editorState, seteditorState] = useState(EditorState.createEmpty());

    //useEffect

    const handleChange = (info: any, id: number) => {
        // if (fileList !== '') {
        //     dispatch(removeAvatarUploadStart(fileList));
        // }
        //info.file.response.url.toString()
        if (info.file.response !== undefined) {
            fileList[id].url = info.file.response.url.toString()
            setFileList([...fileList]);
        }
        props.parentCallback(fileList);
    };


    const onEditorStateChange = (editorState: any) => {
        var productSave: ProductDtos = productDto;
        productSave.introduce = draftToHtml(convertToRaw(editorState.getCurrentContent()));
        setProductsStart(productSave);
        seteditorState(editorState);
    };

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
                            action="https://localhost:44324/v1/api/patch/upload-root"
                            name="file"
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
                            action="https://localhost:44324/v1/api/patch/upload-root"
                            name="file"
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
                            action="https://localhost:44324/v1/api/patch/upload-root"
                            name="file"
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
                            action="https://localhost:44324/v1/api/patch/upload-root"
                            name="file"
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
                            action="https://localhost:44324/v1/api/patch/upload-root"
                            name="file"
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
                            action="https://localhost:44324/v1/api/patch/upload-root"
                            name="file"
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
                            action="https://localhost:44324/v1/api/patch/upload-root"
                            name="file"
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
                            action="https://localhost:44324/v1/api/patch/upload-root"
                            name="file"
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
                            action="https://localhost:44324/v1/api/patch/upload-root"
                            name="file"
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
                name="Mô tả sản phẩm"
                label="Mô tả sản phẩm"
                rules={[
                    {
                        required: true,
                        message: 'Please input your name',
                    },
                ]}
            >
                <Editor
                    editorState={editorState}
                    wrapperClassName="demo-wrapper"
                    editorClassName="demo-editor"
                    onEditorStateChange={onEditorStateChange}
                    toolbar={{
                        image: { uploadCallback: uploadImageCallBack, alt: { present: true, mandatory: true } },
                    }}
                />
                <textarea
                    style={{ width: '100%' }}
                    disabled
                    value={draftToHtml(convertToRaw(editorState.getCurrentContent()))}
                />
            </Form.Item>

            <Form.Item
                name="username"
                label="Name"
                rules={[
                    {
                        required: true,
                        message: 'Please input your name',
                    },
                ]}
            ></Form.Item>
        </>
    )
}
