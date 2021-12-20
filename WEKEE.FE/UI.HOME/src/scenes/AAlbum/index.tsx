//#region  import
import { RedoOutlined, FilePdfOutlined, CheckOutlined, CloseOutlined, PlusOutlined, SafetyCertificateOutlined, UsergroupAddOutlined, LinkOutlined, ClockCircleOutlined, IssuesCloseOutlined, StopOutlined, CheckCircleOutlined, SettingOutlined } from '@ant-design/icons';
import { Avatar, Image, Button, Card, Col, Divider, List, Row, Tabs, Checkbox, Dropdown, Menu, Select, Tooltip, Input, Modal, PageHeader, Breadcrumb } from 'antd'
import Meta from 'antd/lib/card/Meta';
import * as React from 'react';
import { useEffect, useState } from  'react';
import { useDispatch, useSelector } from 'react-redux';
import { createStructuredSelector } from 'reselect';
import { useInjectReducer, useInjectSaga } from '../../redux/reduxInjectors';
import { watchPageStart } from './actions';
import reducer from './reducer';
import saga from './saga';
import { makeSelectLoading } from './selectors';
const { Search } = Input;
const { Option } = Select;
const { confirm } = Modal;
//#endregion
export interface IHomeProps {
    location: any;
}
const key = 'home';
declare var abp: any;
const { TabPane } = Tabs;
const stateSelector = createStructuredSelector<any, any>({
    loading: makeSelectLoading()
});

const data = [

    {
        title: 'Kinh Tế',
        image: '/album/avatar/wekee-Nam(737)-014329-04082021-S120x120.jpg',
        type: 1
    },
    {
        title: 'Thư mục của tôi',
        image: '/album/avatar/wekee-Untitled-1-202359-04082021-S120x120.jpg',
        type: 1
    },
    {
        title: 'wekee-Nam(737)-014329-04082021-S120x120.jpg',
        image: '/album/avatar/wekee-Nam(737)-014329-04082021-S120x120.jpg',
        type: 1
    },
    {
        title: 'Kỹ năng mềm',
        image: '/album/icon/folderFile96.svg',
        type: 0
    },
    {
        title: 'Quản trị học',
        image: '/album/icon/folder96.svg',
        type: 0
    },

    {
        title: 'Kinh Tế',
        image: '/album/avatar/wekee-Nam(737)-014329-04082021-S120x120.jpg',
        type: 1
    },
    {
        title: 'Thư mục của tôi',
        image: '/album/avatar/wekee-Untitled-1-202359-04082021-S120x120.jpg',
        type: 1
    },
    {
        title: 'wekee-Nam(737)-014329-04082021-S120x120.jpg',
        image: '/album/avatar/wekee-Nam(737)-014329-04082021-S120x120.jpg',
        type: 1
    },
    {
        title: 'Kỹ năng mềm',
        image: '/album/icon/folderFile96.svg',
        type: 0
    },
    {
        title: 'Quản trị học',
        image: '/album/icon/folder96.svg',
        type: 0
    },

    {
        title: 'Kinh Tế',
        image: '/album/avatar/wekee-Nam(737)-014329-04082021-S120x120.jpg',
        type: 1
    },
    {
        title: 'Thư mục của tôi',
        image: '/album/avatar/wekee-Untitled-1-202359-04082021-S120x120.jpg',
        type: 1
    },
    {
        title: 'wekee-Nam(737)-014329-04082021-S120x120.jpg',
        image: '/album/avatar/wekee-Nam(737)-014329-04082021-S120x120.jpg',
        type: 1
    },
    {
        title: 'Kỹ năng mềm',
        image: '/album/icon/folderFile96.svg',
        type: 0
    },
    {
        title: 'Quản trị học',
        image: '/album/icon/folder96.svg',
        type: 0
    },

    {
        title: 'Kinh Tế',
        image: '/album/avatar/wekee-Nam(737)-014329-04082021-S120x120.jpg',
        type: 1
    },
    {
        title: 'Thư mục của tôi',
        image: '/album/avatar/wekee-Untitled-1-202359-04082021-S120x120.jpg',
        type: 1
    },
    {
        title: 'wekee-Nam(737)-014329-04082021-S120x120.jpg',
        image: '/album/avatar/wekee-Nam(737)-014329-04082021-S120x120.jpg',
        type: 1
    },
    {
        title: 'Kỹ năng mềm',
        image: '/album/icon/folderFile96.svg',
        type: 0
    },
    {
        title: 'Quản trị học',
        image: '/album/icon/folder96.svg',
        type: 0
    },

    {
        title: 'Kinh Tế',
        image: '/album/avatar/wekee-Nam(737)-014329-04082021-S120x120.jpg',
        type: 1
    },
    {
        title: 'Thư mục của tôi',
        image: '/album/avatar/wekee-Untitled-1-202359-04082021-S120x120.jpg',
        type: 1
    },
    {
        title: 'wekee-Nam(737)-014329-04082021-S120x120.jpg',
        image: '/album/avatar/wekee-Nam(737)-014329-04082021-S120x120.jpg',
        type: 1
    },
    {
        title: 'Kỹ năng mềm',
        image: '/album/icon/folderFile96.svg',
        type: 0
    },
    {
        title: 'Quản trị học',
        image: '/album/icon/folder96.svg',
        type: 0
    },

    {
        title: 'Kinh Tế',
        image: '/album/avatar/wekee-Nam(737)-014329-04082021-S120x120.jpg',
        type: 1
    },
    {
        title: 'Thư mục của tôi',
        image: '/album/avatar/wekee-Untitled-1-202359-04082021-S120x120.jpg',
        type: 1
    },
    {
        title: 'wekee-Nam(737)-014329-04082021-S120x120.jpg',
        image: '/album/avatar/wekee-Nam(737)-014329-04082021-S120x120.jpg',
        type: 1
    },
    {
        title: 'Kỹ năng mềm',
        image: '/album/icon/folderFile96.svg',
        type: 0
    },
    {
        title: 'Quản trị học',
        image: '/album/icon/folder96.svg',
        type: 0
    },
];
export default function Home(props: IHomeProps) {
    useInjectReducer(key, reducer);
    useInjectSaga(key, saga);
    const dispatch = useDispatch();
    const { loading } = useSelector(stateSelector);
    const [checkbox, setCheckbox] = useState(true);
    useEffect(() => {
        dispatch(watchPageStart());
    }, []);

    return (
        <>
            <PageHeader
                className="site-page-header"
                style={{ padding: '10px 0' }}
                onBack={() => window.history.back()}
                title={
                    <Breadcrumb>
                        <Breadcrumb.Item>
                            <a href="">Application Center</a>
                        </Breadcrumb.Item>
                        <Breadcrumb.Item>
                            <a href="">Application Center</a>
                        </Breadcrumb.Item>
                        <Breadcrumb.Item>
                            <a href="">Application List</a>
                        </Breadcrumb.Item>
                        <Breadcrumb.Item>An Application</Breadcrumb.Item>
                    </Breadcrumb>
                }
            />
            <Row>
                <Col span={22}>
                    <Row gutter={[10, 10]}>
                        <Col span={4}>
                            <Select defaultValue="_" style={{ display: 'block' }}>
                                <Option value="_">Sắp xếp theo Role</Option>
                                <Option value="lucy">Lucy</Option>
                                <Option value="Yiminghe">yiminghe</Option>
                            </Select>
                        </Col>
                        <Col span={1}></Col>
                        <Col span={1}><Tooltip title="Làm mới"><Button block icon={<RedoOutlined />}></Button></Tooltip></Col>
                        <Col span={1}><Tooltip title="Tải file"><Button block icon={<FilePdfOutlined />}></Button></Tooltip></Col>
                        <Col span={1}><Tooltip title="Lưu Thay Đổi"><Button block icon={<CheckOutlined />}></Button></Tooltip></Col>
                        <Col span={1}><Tooltip title="Hủy Thay Đổi"><Button block icon={<CloseOutlined />}></Button></Tooltip></Col>
                        <Col span={1}></Col>
                        <Col span={1}><Tooltip title="Tạo Tài Khoản"><Button icon={<PlusOutlined />}></Button></Tooltip></Col>
                        <Col span={1}><Tooltip title="Gán Quyền"><Button block icon={<SafetyCertificateOutlined />}></Button></Tooltip></Col>
                        <Col span={1}><Tooltip title="Tạo Nhóm"><Button block icon={<UsergroupAddOutlined />}></Button></Tooltip></Col>
                        <Col span={1}></Col>
                        <Col span={1}>
                            <Tooltip title="Sửa Trạng thái tài khoản">
                                <Dropdown overlay={
                                    <Menu>
                                        <Menu.Item>
                                            <Button block icon={<CheckOutlined style={{ float: 'left', color: '#237804' }} />} >Tài khoản đang hoạt động</Button>
                                        </Menu.Item>
                                        <Menu.Item>
                                            <Button block icon={<LinkOutlined style={{ float: 'left', color: '#0050b3' }} />} >Tài khoản đang xác nhận đăng ký</Button>
                                        </Menu.Item>
                                        <Menu.Item>
                                            <Button block icon={<ClockCircleOutlined style={{ float: 'left', color: '#0050b3' }} />} >Tài khoản đang được lấy lại</Button>
                                        </Menu.Item>
                                        <Menu.Item>
                                            <Button block icon={<IssuesCloseOutlined style={{ float: 'left', color: '#a8071a' }} />} >Tài khoản đang để mất tài khoản</Button>
                                        </Menu.Item>
                                        <Menu.Item>
                                            <Button block icon={<IssuesCloseOutlined style={{ float: 'left', color: '#a8071a' }} />} >Tài khoản đang đăng nhập sai</Button>
                                        </Menu.Item>
                                        <Menu.Item>
                                            <Button block icon={<CloseOutlined style={{ float: 'left', color: '#000000' }} />} >Tài khoản đang checkpoint</Button>
                                        </Menu.Item>
                                    </Menu>
                                }
                                    placement="bottomCenter"
                                    arrow>
                                    <Button block icon={<StopOutlined />}></Button>
                                </Dropdown>
                            </Tooltip></Col>
                        <Col span={1}><Tooltip title="Mở Tài Khoản"><Button block icon={<CheckCircleOutlined />}></Button></Tooltip></Col>
                        <Col span={8}>
                            <Input.Group compact>
                                <Select defaultValue="_" style={{ width: '30%' }}>
                                    <Option value="_">Sắp xếp</Option>
                                    <Option value="lucy">Lucy</Option>
                                    <Option value="Yiminghe">yiminghe</Option>
                                </Select>
                                <Search placeholder="Tìm kiếm theo Id" min={0} type='number' style={{ width: '70%' }} />
                            </Input.Group>
                        </Col>
                    </Row>
                </Col>
                <Col span={2}>
                    <Dropdown.Button
                        style={{ border: 'none', outline: 'none' }}
                        overlay={
                            <Menu>
                                <Menu.Item key="1">
                                    1st menu item
                                </Menu.Item>
                                <Menu.Item key="2">
                                    2nd menu item
                                </Menu.Item>
                                <Menu.Item key="3">
                                    3rd menu item
                                </Menu.Item>
                            </Menu>}
                        placement="bottomCenter"
                        icon={<SettingOutlined />}
                    >
                    </Dropdown.Button>
                </Col>
            </Row>
            <Row>
                <Divider style={{ margin: '10px 0' }} orientation="left"></Divider>
            </Row>
            <Row>
                <List
                    grid={{ gutter: 16, column: 9 }}
                    dataSource={data}
                    style={{ width: '100%' }}
                    renderItem={item => (
                        item.type === 0
                            ? <List.Item>
                                <Checkbox style={{ position: 'absolute', zIndex: checkbox ? 100 : 0, left: '13px' }}></Checkbox>
                                <Card
                                    hoverable
                                    size="small"
                                    style={{ fontSize: '12px' }}
                                    bodyStyle={{ padding: '5px' }}
                                    bordered={false}
                                    onDoubleClick={() => { alert("Open") }}
                                    cover={<Avatar shape="square" src={abp.serviceAlbumImage + item.image} style={{ width: '100%', height: '100%' }} />}
                                >
                                    <Meta description={item.title} />
                                </Card>
                            </List.Item>
                            : <List.Item>
                                <Checkbox style={{ position: 'absolute', zIndex: checkbox ? 100 : 0, left: '13px' }}></Checkbox>
                                <Card
                                    hoverable
                                    size="small"
                                    style={{ fontSize: '12px' }}
                                    bodyStyle={{ padding: '5px' }}
                                    bordered={false}
                                    cover={<Image src={abp.serviceAlbumImage + item.image} />}
                                >
                                    <Meta description={item.title} />
                                </Card>
                            </List.Item>
                    )}
                />
            </Row>
        </>
    )
}
