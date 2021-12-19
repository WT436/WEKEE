import { ArrowRightOutlined, CheckCircleOutlined, CheckOutlined, ClockCircleOutlined, CloseOutlined, DeleteOutlined, ExclamationCircleOutlined, EyeOutlined, FilePdfOutlined, FilterOutlined, FormOutlined, HomeOutlined, IssuesCloseOutlined, LinkOutlined, LockOutlined, MessageOutlined, MoreOutlined, PlusOutlined, RedoOutlined, SafetyCertificateOutlined, SearchOutlined, SettingOutlined, StopOutlined, SwapOutlined, UsergroupAddOutlined, UserOutlined, WarningOutlined } from '@ant-design/icons';
import { Avatar, Breadcrumb, Button, Col, Drawer, Dropdown, Input, Menu, Modal, notification, PageHeader, Row, Select, Table, Tooltip } from 'antd'
import Form from 'antd/lib/form/Form';
import SubMenu from 'antd/lib/menu/SubMenu';
import { type } from 'os';
import React, { useEffect, useState } from 'react'
import { useDispatch, useSelector } from 'react-redux';
import { createStructuredSelector } from 'reselect';
import { useInjectReducer, useInjectSaga } from '../../redux/reduxInjectors';
import { deleteAccountStart, listAccountAdminStart } from './actions';
import CreateAccountComponents from './components/createAccountComponents';
import RoleAccountComponent from './components/roleAccountComponent';
import { AccountShowDtos } from './dtos/accountShowDtos';
import reducer from './reducer';
import saga from './saga';
import {
    makeSelectAccountAdminList, makeSelectId, makeSelectLoading, makeSelectPageIndex,
    makeSelectPageSize, makeSelectTotalCount, makeSelectTotalPages
} from './selectors';


const { Search } = Input;
const { Option } = Select;
const { confirm } = Modal;
declare var abp: any;

export interface IAAccount {

}

const key = 'aaccount';

const stateSelector = createStructuredSelector<any, any>({
    loading: makeSelectLoading(),
    pageIndex: makeSelectPageIndex(),
    pageSize: makeSelectPageSize(),
    totalCount: makeSelectTotalCount(),
    totalPages: makeSelectTotalPages(),
    accountShowDtos: makeSelectAccountAdminList(),
    id: makeSelectId()
});

export default function AAccount(props: IAAccount) {

    const { loading, pageIndex, pageSize, totalCount,
        accountShowDtos, id
    } = useSelector(stateSelector);

    useInjectReducer(key, reducer);
    useInjectSaga(key, saga);

    const dispatch = useDispatch();

    const [visible, setVisible] = useState(false);
    const [visibleModal, setVisibleModal] = useState(false);
    const [nameModal, setNameModal] = useState("");
    const [accountSelect, setAccountSelect] = useState<AccountShowDtos>();
    const [listId, setListId] = useState<Number[]>([]);

    const columns = [
        {
            title: 'ID',
            dataIndex: 'id',
            width: '5%',
            filterDropdown: () => (
                <Search placeholder="Tìm kiếm theo Id" min={0} type='number' onSearch={(value, type) => searchAccount(value, 'User_Profile_Id')} style={{ width: 200 }} />
            ),
            filterIcon: () => <SearchOutlined />,
        },
        {
            title: 'Ảnh',
            dataIndex: 'picture',
            width: '5%',
            render: (text: String) => (
                text == null || text === undefined || text === ''
                    ? <Avatar size={32} icon={<UserOutlined />} />
                    : <Avatar src={abp.appServiceUrlStaticFile + '/' + text} size={32} />
            )
        },
        {
            title: 'Tài khoản',
            dataIndex: 'userName',
            width: '15%',
            filterDropdown: () => (
                <Search placeholder="Tìm kiếm theo Tài khoản" onSearch={(value, type) => searchAccount(value, 'User_Profile_User_Name')} style={{ width: 200 }} />
            ),
            filterIcon: () => <SearchOutlined />,
        },
        {
            title: 'Tên đầy đủ',
            dataIndex: 'fullName',
            width: '15%',
            filterDropdown: () => (
                <Search placeholder="Tìm kiếm theo tên" onSearch={(value, type) => searchAccount(value, 'User_Profile_Full_Name')} style={{ width: 200 }} />
            ),
            filterIcon: () => <SearchOutlined />,
        },
        {
            title: 'Email',
            dataIndex: 'email',
            width: '23%',
            filterDropdown: () => (
                <Search placeholder="Tìm kiếm theo Email" onSearch={(value, type) => searchAccount(value, 'User_Profile_Email')} style={{ width: 200 }} />
            ),
            filterIcon: () => <SearchOutlined />,
        },
        {
            title: 'Số điện thoại',
            dataIndex: 'numberPhone',
            width: '12%',
            filterDropdown: () => (
                <Search placeholder="Tìm kiếm theo số điện thoại" onSearch={(value, type) => searchAccount(value, 'User_Profile_Number_Phone')} style={{ width: 200 }} />
            ),
            filterIcon: () => <SearchOutlined />,
        },
        {
            title: 'Giới Tính',
            dataIndex: 'gender',
            width: '7%',
            filterDropdown: () => (
                <>
                    <Button onClick={() => searchAccount("Nam", 'User_Profile_Gender')} block>Nam</Button>
                    <Button onClick={() => searchAccount("Nữ", 'User_Profile_Gender')} block style={{ margin: '5px 0' }}>Nữ</Button>
                    <Button onClick={() => searchAccount("Khác", 'User_Profile_Gender')} block>Khác</Button>
                </>
            ),
            filterIcon: () => <FilterOutlined />,
        },
        {
            title: 'Status',
            dataIndex: 'isStattus',
            width: '7%',
            filterDropdown: () => (
                <>
                    <Menu>
                        <Menu.Item>
                            <Button onClick={() => searchAccountNumberStatus(0)} block icon={<CheckOutlined style={{ float: 'left', color: '#237804' }} />} >Tài khoản đang hoạt động</Button>
                        </Menu.Item>
                        <Menu.Item>
                            <Button onClick={() => searchAccountNumberStatus(1)} block icon={<LinkOutlined style={{ float: 'left', color: '#0050b3' }} />} >Tài khoản đang xác nhận đăng ký</Button>
                        </Menu.Item>
                        <Menu.Item>
                            <Button onClick={() => searchAccountNumberStatus(2)} block icon={<ClockCircleOutlined style={{ float: 'left', color: '#0050b3' }} />} >Tài khoản đang được lấy lại</Button>
                        </Menu.Item>
                        <Menu.Item>
                            <Button onClick={() => searchAccountNumberStatus(3)} block icon={<WarningOutlined style={{ float: 'left', color: '#a8071a' }} />} >Tài khoản đang để mất tài khoản</Button>
                        </Menu.Item>
                        <Menu.Item>
                            <Button onClick={() => searchAccountNumberStatus(4)} block icon={<IssuesCloseOutlined style={{ float: 'left', color: '#a8071a' }} />} >Tài khoản đang đăng nhập sai</Button>
                        </Menu.Item>
                        <Menu.Item>
                            <Button onClick={() => searchAccountNumberStatus(5)} block icon={<CloseOutlined style={{ float: 'left', color: '#000000' }} />} >Tài khoản đang checkpoint</Button>
                        </Menu.Item>
                    </Menu>
                </>
            ),
            filterIcon: () => <FilterOutlined />,
            render: (text: Number) => {
                switch (text) {
                    case 0: return <Tooltip title="Tài khoản đang hoạt động" color={'#237804'} key={'#237804'}><CheckOutlined style={{ color: '#237804' }} /></Tooltip>
                    case 1: return <Tooltip title="Tài khoản đang xác nhận đăng ký" color={'#0050b3'} key={'#0050b3'}><LinkOutlined style={{ color: '#0050b3' }} /></Tooltip>
                    case 2: return <Tooltip title="Tài khoản đang được lấy lại" color={'#0050b3'} key={'#0050b3'}><ClockCircleOutlined style={{ color: '#0050b3' }} /></Tooltip>
                    case 3: return <Tooltip title="Tài khoản đang để mất tài khoản" color={'#a8071a'} key={'#a8071a'}><WarningOutlined style={{ color: '#a8071a' }} /></Tooltip>
                    case 4: return <Tooltip title="Tài khoản đang đăng nhập sai nhiều lần" color={'#a8071a'} key={'#a8071a'}><IssuesCloseOutlined style={{ color: '#a8071a' }} /></Tooltip>
                    case 5: return <Tooltip title="Tài khoản đang checkpoint" color={'#000000'} key={'#000000'}><CloseOutlined style={{ color: '#000000' }} /></Tooltip>
                    default: return <Tooltip title="Không Xác Định" color={'#000000'} key={'#000000'}><CloseOutlined style={{ color: '#000000' }} /></Tooltip>
                }
            }
        },
        {
            title: 'Quyền',
            dataIndex: 'role',
            width: '12%'
        },
        {
            title: 'Action',
            width: '7%',
            dataIndex: '',
            key: 'x',
            render: (text: any) => (
                <Dropdown
                    overlay={
                        <Menu>
                            <SubMenu key="1" title="Chuyển Trạng Thái" icon={<SwapOutlined />}>
                                <Menu.Item key="1_1"><Button block icon={<CheckOutlined style={{ float: 'left', color: '#237804' }} />} >Tài khoản đang hoạt động</Button></Menu.Item>
                                <Menu.Item key="1_2"><Button block icon={<LinkOutlined style={{ float: 'left', color: '#237804' }} />} >Tài khoản đang xác nhận đăng ký</Button></Menu.Item>
                                <Menu.Item key="1_3"><Button block icon={<ClockCircleOutlined style={{ float: 'left', color: '#237804' }} />} >Tài khoản đang được lấy lại</Button></Menu.Item>
                                <Menu.Item key="1_4"><Button block icon={<WarningOutlined style={{ float: 'left', color: '#237804' }} />} >Tài khoản đang để mất tài khoản</Button></Menu.Item>
                                <Menu.Item key="1_5"><Button block icon={<IssuesCloseOutlined style={{ float: 'left', color: '#237804' }} />} >Tài khoản đang đăng nhập sai</Button></Menu.Item>
                                <Menu.Item key="1_6"><Button block icon={<CloseOutlined style={{ float: 'left', color: '#237804' }} />} >Tài khoản đang checkpoint</Button></Menu.Item>
                            </SubMenu>
                            <Menu.Item key="2" icon={<EyeOutlined />}>
                                Chi tiết
                            </Menu.Item>
                            <Menu.Item key="3" icon={<FormOutlined />}>
                                Chỉnh sửa
                            </Menu.Item>
                            <Menu.Item key="4" onClick={(id: AccountShowDtos | any) => openEditPermission(text)} icon={<SafetyCertificateOutlined />}>
                                Sửa quyền
                            </Menu.Item>
                            <Menu.Item key="5" icon={<LockOutlined />}>
                                Khóa tài khoản
                            </Menu.Item>
                            <Menu.Item key="6" onClick={() => dispatch(deleteAccountStart(text.id))} icon={<DeleteOutlined />}>
                                Xóa
                            </Menu.Item>
                        </Menu>}
                    placement="bottomCenter"
                >
                    <Button type='link'><MoreOutlined /></Button>
                </Dropdown>
            )
        },
    ];

    useEffect(() => {
        dispatch(listAccountAdminStart({
            pageIndex: pageIndex,
            pageSize: pageSize,
            propertyOrder: "",
            valueOrderBy: "",
            propertySearch: [],
            valuesSearch: []
        }))
    }, []);

    let onChangeAccountList = (page: any, pageSize: any) => {
        dispatch(listAccountAdminStart({
            pageIndex: page,
            pageSize: pageSize,
            propertyOrder: "",
            valueOrderBy: "",
            propertySearch: [],
            valuesSearch: []
        }));
    };

    let reloadData = () => {
        dispatch(listAccountAdminStart({
            pageIndex: pageIndex,
            pageSize: pageSize,
            propertyOrder: "",
            valueOrderBy: "",
            propertySearch: [],
            valuesSearch: []
        }));
    }

    let searchAccount = (value: String, type: String) => {
        if (value === null || value === undefined || value === '') {
            notification.warning({
                message: "Thất bại",
                description: "Bạn cần nhập đầy đủ thông tin!",
                placement: 'bottomRight'
            });
        }
        else {
            dispatch(listAccountAdminStart({
                pageIndex: 0,
                pageSize: 20,
                propertyOrder: "",
                valueOrderBy: "",
                propertySearch: [type],
                valuesSearch: [value]
            }));
        }
    }

    let searchAccountNumberStatus = (value: Number) => {
        if (value === null || value === undefined) {
            notification.warning({
                message: "Thất bại",
                description: "Bạn cần nhập đầy đủ thông tin!",
                placement: 'bottomRight'
            });
        }
        else {
            dispatch(listAccountAdminStart({
                pageIndex: 0,
                pageSize: 20,
                propertyOrder: "",
                valueOrderBy: "",
                propertySearch: ['User_Profile_Is_Status'],
                valuesSearch: [value.toString()]
            }));
        }
    }

    const rowSelection = {

        onChange: (selectedRowKeys: React.Key[], selectedRows: AccountShowDtos[]) => {
            setListId(Array.from(selectedRows.map(m => m.id)));
        },

        getCheckboxProps: (record: AccountShowDtos) => ({
            disabled: record.id === 1
        }),
    };

    const showConfirm = (select: Number) => {
        confirm({
            title: 'Bạn Muốn làm mới dữ liệu',
            icon: <ExclamationCircleOutlined />,
            okText: 'Ok',
            cancelText: 'No',
            onOk() {
                console.log(select);
            },
            onCancel() {
                console.log(select);
            },
        });
    }

    const openEditPermission = (id: AccountShowDtos) => {
        setNameModal("Chỉnh sửa quyền tài khoản ( id : " + id.id + ' Tên Tài Khoản : ' + id.userName + " )");
        setVisibleModal(true);
        setAccountSelect(id);
    }
    return (
        <>
            <PageHeader
                className="site-page-header"
                style={{ padding: '10px 0' }}
                onBack={() => window.history.back()}
                title={
                    <Breadcrumb>
                        <Breadcrumb.Item>
                            <a href="/">Home</a>
                        </Breadcrumb.Item>
                        <Breadcrumb.Item>
                            <a href="/admin">Admin</a>
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
                                <Option value="_">Sắp Xếp</Option>
                                <Option value="lucy">Tài Khoản</Option>
                                <Option value="Yiminghe">Nhóm Trưởng</Option>
                            </Select>
                        </Col>
                        <Col span={4}>
                            <Search placeholder="Tìm Kiếm Nhóm" allowClear style={{ width: 200 }} />
                        </Col>
                        <Col span={1}></Col>
                        <Col span={1}><Tooltip title="Làm mới"><Button onClick={reloadData} block icon={<RedoOutlined />}></Button></Tooltip></Col>
                        <Col span={1}><Tooltip title="Tải file"><Button block icon={<FilePdfOutlined />}></Button></Tooltip></Col>
                        <Col span={1}></Col>
                        <Col span={1}><Tooltip title="Tạo Tài Khoản"><Button block onClick={() => setVisible(true)} icon={<PlusOutlined />}></Button></Tooltip></Col>
                        <Col span={1}><Tooltip title="Gán Quyền"><Button block onClick={() => setVisibleModal(true)} icon={<SafetyCertificateOutlined />}></Button></Tooltip></Col>
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
                        <Col span={1}><Tooltip title="Mở Tài Khoản"><Button onClick={() => showConfirm(1)} block icon={<CheckCircleOutlined />}></Button></Tooltip></Col>
                        <Col span={1}><Tooltip title="Khóa Tài khoản"><Button onClick={() => showConfirm(1)} block icon={<LockOutlined />}></Button></Tooltip></Col>
                        <Col span={1}><Tooltip title="Xóa vĩnh viễn tài khoản"><Button onClick={() => showConfirm(1)} block icon={<DeleteOutlined />}></Button></Tooltip></Col>
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
            <Row style={{ margin: '10px 5px' }}>
                <Table
                    rowSelection={{
                        type: 'checkbox',
                        ...rowSelection,
                    }}
                    rowKey={(record: AccountShowDtos | any) => record.id.toString()}
                    size='small'
                    columns={columns}
                    dataSource={accountShowDtos}
                    loading={loading}
                    scroll={{ y: 400 }}
                    pagination={{
                        pageSize: pageSize,
                        total: totalCount,
                        defaultCurrent: 1,
                        onChange: onChangeAccountList,
                        showSizeChanger: true,
                        pageSizeOptions: ['5', '10', '20', '50', '100']
                    }}
                />
            </Row>
            <Drawer
                placement={'left'}
                closable={false}
                onClose={() => setVisible(false)}
                width='70%'
                visible={visible}
                key={'left'}
            >
                <CreateAccountComponents />
            </Drawer>
            <Modal
                title={nameModal}
                visible={visibleModal}
                footer={null}
                width={'95%'}
                onCancel={() => setVisibleModal(false)}
            >
                <RoleAccountComponent accountSelect={accountSelect} />
            </Modal>
        </>
    )
}
