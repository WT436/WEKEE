import { CheckSquareOutlined, BorderOutlined } from '@ant-design/icons';
import { Row, Col, Table, Button, Tag, message } from 'antd'
import React, { useEffect } from 'react'
import { useDispatch, useSelector } from 'react-redux';
import { createStructuredSelector } from 'reselect';
import { changPermissionAccountStart, listSubjectAssignStart, listSubjectStart } from '../actions';
import { AccountShowDtos } from '../dtos/accountShowDtos';
import { SubjectAssignmentDto } from '../dtos/subjectAssignmentDto';
import { SubjectDtos } from '../dtos/subjectDtos';
import { makeSelectLoading, makeSelectSubjectAssignmentDto, makeSelectSubjectDtos } from '../selectors';

interface IRoleAccountComponent {
    accountSelect: AccountShowDtos | undefined
}
const stateSelector = createStructuredSelector<any, any>({
    loading: makeSelectLoading(),
    subjectDtos: makeSelectSubjectDtos(),
    subjectAssignmentDto: makeSelectSubjectAssignmentDto()
});
export default function RoleAccountComponent(props: IRoleAccountComponent) {

    const { loading, subjectDtos, subjectAssignmentDto
    } = useSelector(stateSelector);

    const columns = [
        {
            title: 'Action',
            dataIndex: '',
            key: 'x',
            render: (text: SubjectAssignmentDto) => (
                <div>
                    <Button
                        type="link"
                        onClick={() => dispatch(changPermissionAccountStart(props.accountSelect?.id === undefined ? 0 : props.accountSelect?.id, text.id))}
                        icon={text.isCheck ? <CheckSquareOutlined style={{ color: 'blue' }} />
                            : <BorderOutlined style={{ color: 'black' }} />}>
                    </Button>
                </div>
            )
        },
        {
            title: 'id',
            dataIndex: 'id',
        },
        {
            title: 'description',
            dataIndex: 'description',
        },
        {
            title: 'Name',
            dataIndex: 'name',
            sorter: {
                compare: (a: { name: string; }, b: { name: string; }) => a.name.length - b.name.length,
                multiple: 3,
            }
        },
        {
            title: 'level Role',
            dataIndex: 'levelRole',
        },
        {
            title: 'role Id cha',
            dataIndex: 'roleId',
        },
        {
            title: 'Active',
            dataIndex: 'isActive',
            render: (text: boolean) => (text === true ? <Tag color="#2db7f5">True</Tag> : <Tag color="red">False</Tag>)
        }
    ];

    const columnsSubject = [
        {
            title: 'id',
            dataIndex: 'id',
        },
        {
            title: 'Id Account',
            dataIndex: 'userAccountId',
        },
        {
            title: 'Tên Nhóm',
            dataIndex: 'gorupId',
            render: (text: Number) => (text === null ? <Tag color="#2db7f5">Cá Nhân</Tag> : <Tag color="red">{text}</Tag>)
        },
        {
            title: 'Kích Hoạt',
            dataIndex: 'isActive',
            key: 'isActive',
            render: (text: boolean) => (text === true ? <Tag color="#2db7f5">Kích Hoạt</Tag> : <Tag color="red">Khóa</Tag>)
        }
        ,
        {
            title: 'Thời gian tạo',
            dataIndex: 'dateCreate',
            key: 'isActive'
        }
    ];

    const dispatch = useDispatch();
    
    useEffect(() => {
        if (props.accountSelect?.id === undefined) {
            message.info('Thông tin không xác định!');
        }
        else {
            var i = props.accountSelect?.id;
            dispatch(listSubjectStart(i))
        }
    }, [props.accountSelect]);

    const rowSelection = {
        onChange: (selectedRowKeys: React.Key[], selectedRows: SubjectDtos[]) => {
            dispatch(listSubjectAssignStart(selectedRows[0].id));
        }
    };

    return (
        <>
            <Row gutter={[35, 5]}>
                <Col span={12}>
                    <Row style={{ fontSize: '20px', fontFamily: 'cursive', padding: '5px 15px' }}>Hành động vai trò của tài khoản</Row>
                    <Table
                        rowSelection={{
                            type: 'radio',
                            checkStrictly: true,
                            ...rowSelection
                        }}
                        rowKey={(record: SubjectDtos | any) => record.id.toString()}
                        columns={columnsSubject}
                        dataSource={subjectDtos}
                        loading={loading}
                        size='small'
                        scroll={{ y: 350 }}
                        pagination={false}
                    />
                </Col>
                <Col span={12}>
                    <Row style={{ fontSize: '20px', fontFamily: 'cursive', padding: '5px 15px' }}>Danh sách vai trò</Row>
                    <Table
                        rowKey={(rec: any) => rec.id.toString()}
                        columns={columns}
                        dataSource={subjectAssignmentDto}
                        size='small'
                        scroll={{ y: 350 }}
                        pagination={false}
                    />
                </Col>
            </Row>
        </>
    )
}
