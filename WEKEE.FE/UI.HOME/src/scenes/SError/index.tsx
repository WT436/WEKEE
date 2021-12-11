//#region  import
import { Breadcrumb, Col, DatePicker, Modal, PageHeader, Row, Select, Table, Tag } from 'antd'
import * as React from 'react';
import { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { createStructuredSelector } from 'reselect';
import { useInjectReducer, useInjectSaga } from '../../redux/reduxInjectors';
import { makeSelectExceptionDtos, makeSelectPageIndex, makeSelectPageSize, 
    makeSelectTotalCount, makeSelectTotalPages } from './selectors';
import { fixErrorSystemStart, getListErrorSystemStart } from './actions';
import reducer from './reducer';
import saga from './saga';
import { makeSelectLoading } from './selectors';
import { ExceptionDtos } from './dtos/exceptionDtos';
import { RetweetOutlined, EyeOutlined } from '@ant-design/icons';

const { Option } = Select;

//#endregion
export interface ISErrorProps {
    location: any;
}
const key = 'serror';

const stateSelector = createStructuredSelector<any, any>({
    loading: makeSelectLoading(),
    pageIndex: makeSelectPageIndex(),
    pageSize: makeSelectPageSize(),
    totalCount: makeSelectTotalCount(),
    totalPages: makeSelectTotalPages(),
    exceptionDtos: makeSelectExceptionDtos()
});

export default function SError(props: ISErrorProps) {

    useInjectReducer(key, reducer);
    useInjectSaga(key, saga);

    const dispatch = useDispatch();

    const { loading, pageIndex, pageSize, totalCount,
        exceptionDtos } = useSelector(stateSelector);
    useEffect(() => {
        dispatch(getListErrorSystemStart({
            pageIndex: 0,
            pageSize: 20,
            property: "",
            orderBy: "",
        }));
    }, []);

    const showDetailError = (detail: ExceptionDtos) => {
        Modal.error({
            width: '100%',
            style: { top: '80px' },
            title: detail.errorMessage,
            content: detail.errorTrace,
        });
    }
    const onChangeAccountList = (page: any, pageSize: any) => {
        dispatch(getListErrorSystemStart({
            pageIndex: page - 1,
            pageSize: pageSize,
            property: "",
            orderBy: "",
        }));
    }
    const columns = [
        {
            title: 'Hành Động',
            dataIndex: '',
            key: 'x',
            width: '5%',
            render: (text: ExceptionDtos) => (
                <>
                    <RetweetOutlined onClick={()=>dispatch(fixErrorSystemStart(text.id))} title="Đổi trạng thái" style={{ cursor: 'pointer' }} /> &nbsp;
                    <EyeOutlined title="Chi tiết" onClick={() => showDetailError(text)} style={{ cursor: 'pointer' }} />
                </>
            )
        },
        {
            title: 'ID',
            key: 'id',
            dataIndex: 'id',
            width: '5%'
        },
        {
            title: 'Micro lỗi',
            key: 'serverError',
            dataIndex: 'serverError',
            width: '10%'
        },
        {
            title: 'Id Tài khoản',
            key: 'accountCreate',
            dataIndex: 'accountCreate',
            width: '10%'
        },
        {
            title: 'IP',
            key: 'ipAccount',
            dataIndex: 'ipAccount',
            width: '10%'
        },
        {
            title: 'Cấp độ',
            key: 'level',
            dataIndex: 'level',
            width: '10%'
        },
        {
            title: 'Tên Lỗi',
            key: 'errorMessage',
            dataIndex: 'errorMessage',
            width: '40%',
            ellipsis: true
        },
        {
            title: 'Số lần',
            key: 'updateCount',
            dataIndex: 'updateCount',
            width: '5%',
        },
        {
            title: 'Trạng Thái Fix',
            key: 'isFix',
            dataIndex: 'isFix',
            width: '10%',
            render: (text: boolean) => (text === true ? <Tag color="#2db7f5">True</Tag> : <Tag color="red">False</Tag>)
        },
    ];

    const onChangeDateTime = (date: any, dateString: any) => {
        dispatch(getListErrorSystemStart({
            pageIndex: pageIndex,
            pageSize: pageSize,
            property: dateString,
            orderBy: 'DateTime'
        }));
    }
    const handleChange = (value: string) => {
        dispatch(getListErrorSystemStart({
            pageIndex: pageIndex,
            pageSize: pageSize,
            property: value,
            orderBy: value
        }));
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
                        <Breadcrumb.Item>Lỗi Hệ Thống</Breadcrumb.Item>
                    </Breadcrumb>
                }
            />
            <Row>
                <Col span={22}>
                    <Row gutter={[10, 10]}>
                        <Col span={4}>
                            <Select onChange={handleChange} defaultValue="Error" style={{ display: 'block' }}>
                                <Option value="Error">Error Chưa Fix</Option>
                                <Option value="Wanning">Wanning</Option>
                                <Option value="ErrorFix">Error Đã Fix</Option>
                            </Select>
                        </Col>
                        <Col span={4}>
                            <DatePicker onChange={onChangeDateTime} format={'YYYY/MM/DD'} />
                        </Col>
                    </Row>
                </Col>
            </Row>
            <Row style={{ margin: '10px 5px' }}>
                <Table
                    rowKey={(record: ExceptionDtos | any) => record.id.toString()}
                    size='small'
                    columns={columns}
                    dataSource={exceptionDtos}
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
        </>
    )
}
