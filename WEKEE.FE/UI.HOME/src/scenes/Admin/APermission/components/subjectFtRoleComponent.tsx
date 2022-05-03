//#region import
import React, { useEffect, useState } from 'react'
import { useDispatch, useSelector } from 'react-redux';
import { createStructuredSelector } from 'reselect';
import { L } from "../../../../lib/abpUtility";
import moment from 'moment';
import { PlusCircleOutlined } from '@ant-design/icons';
import { Tag, Tooltip, Button, Card, Col, Table, Row, Modal } from 'antd';
import utils from '../../../../utils/utils';
import { makePageIndexSubjectFtRole, makePageSizeSubjectFtRole, makesubjectFtRoleRead,  makeTotalCountSubjectFtRole, makeTotalPagesSubjectFtRole } from '../selectors';
import { subjectFtRoleStart, savePermissionFtResourceStart, saveSubjectFtRoleStart } from '../actions';
import { FtPermissionReadDto } from '../dto/ftPermissionReadDto';


declare var abp: any;
//#endregion

interface ISubjectFtRoleComponentProps {
    idPermission: number
}

const stateSelector = createStructuredSelector<any, any>({
    subjectFtRoleRead:makesubjectFtRoleRead(),
    pageIndex: makePageIndexSubjectFtRole(),
    pageSize: makePageSizeSubjectFtRole(),
    totalCount: makeTotalCountSubjectFtRole(),
    totalPages: makeTotalPagesSubjectFtRole()

});

export default function SubjectFtRoleComponent(props: ISubjectFtRoleComponentProps) {

    const dispatch = useDispatch();

    const { subjectFtRoleRead, loadingTable, pageIndex, pageSize, totalCount, totalPages
    } = useSelector(stateSelector);

    //#region  START
    useEffect(() => {
        dispatch(subjectFtRoleStart({
            pageIndex: 1,
            pageSize: 20,
            propertyOrder: undefined,
            valueOrderBy: undefined,
            propertySearch: [1],
            valuesSearch: [props.idPermission.toString()],
        }));
    }, [props.idPermission]);

    const _searchDataOnClick = (
        page: number,
        pageSizeTable: number | undefined
    ) => {
        dispatch(subjectFtRoleStart({
            propertySearch: [1],
            valuesSearch: [props.idPermission.toString()],
            propertyOrder: undefined,
            valueOrderBy: undefined,
            pageIndex: page,
            pageSize: pageSizeTable === undefined ? 20 : pageSizeTable,
        }));
    }
    //#endregion

    //#region TABLE
    const [selectedRowKeys, setselectedRowKeys] = useState<React.Key[]>([]);
    useEffect(() => {
        setselectedRowKeys([]);
        var data = subjectFtRoleRead
            .filter((item: FtPermissionReadDto) => item.isGranted)
            .map((item: FtPermissionReadDto) => item.id);
        setselectedRowKeys(data);
    }, [subjectFtRoleRead]);

    const columns = [
        {
            title: L("NAME", "CONST_TYPE_ROLE"),
            dataIndex: "name",
        },
        {
            title: L("IS_ACTIVE", "CONST_TYPE_ROLE"),
            dataIndex: "isActive",
            key: "isActive",
            render: (text: boolean) =>
                text === true ? (
                    <Tag color={utils._randomColor(text)}>True</Tag>
                ) : (
                    <Tag color={utils._randomColor(text)}>False</Tag>
                ),
        },
        {
            title: L("DESCRIPTION", "CONST_TYPE_ROLE"),
            dataIndex: "description",
        },
        {
            title: L("LEVEL_ROLE", "CONST_TYPE_ROLE"),
            dataIndex: "levelRole",
        },
        {
            title: L("ROLE_MANAGE_NAME", "CONST_TYPE_ROLE"),
            dataIndex: "roleManageName",
        },
        {
            title: L("CREATE_BY_NAME", "CONST_TYPE_ROLE"),
            dataIndex: "createByName",
            render: (text: string) =>
                text.toUpperCase() === "ADMIN" || text.toUpperCase() === "SYSTEM" ? (
                    <Tag color="#b3d4ff">{text}</Tag>
                ) : (
                    <Tag color="#2db7f5">{text}</Tag>
                ),
        },
        {
            title: L("IS_DELETE", "CONST_TYPE_ROLE"),
            dataIndex: "isDelete",
            key: "isDelete",
            render: (text: boolean) =>
                text === true ? (
                    <Tag color={utils._randomColor(text)}>True</Tag>
                ) : (
                    <Tag color={utils._randomColor(text)}>False</Tag>
                ),
        },
        {
            title: L("CREATE_DATE_UTC", "CONST_TYPE_ROLE"),
            dataIndex: "updatedOnUtc",
            render: (text: Date) => moment(text).format("DD/MM/YYYY hh:mm:ss"),
        },
        {
            title: L("UPDATE_DATE_UTC", "CONST_TYPE_ROLE"),
            dataIndex: "createdOnUtc",
            render: (text: Date) => moment(text).format("DD/MM/YYYY hh:mm:ss"),
        }
    ];

    const rowSelection = {
        getCheckboxProps: (record: FtPermissionReadDto) => ({
            disabled: record.isActive === false,
            name: record.name,
        }),
        onChange: (
            selectedRowKeys: React.Key[],
            selectedRows: FtPermissionReadDto[],
        ) => {
            setselectedRowKeys(selectedRowKeys);
            console.log(selectedRowKeys)
        },
        selectedRowKeys: selectedRowKeys,
    };
    //#endregion   

    //#region  SAVE
    const _savePermissionFtResource = () => {
        dispatch(saveSubjectFtRoleStart({ id: props.idPermission, roleId: selectedRowKeys }));
    }
    //#endregion

    return (
        <>
            <Row style={{ margin: 10 }} gutter={[10, 10]}>
                <Col span={2}>
                    <Tooltip title={L("SAVE_PERMISSION_FT_RESOURCE", "CONST_TYPE_PERMISSION_RESOURCE")}>
                        <Button onClick={_savePermissionFtResource} icon={<PlusCircleOutlined />}></Button>
                    </Tooltip>
                </Col>
            </Row>
            <Table
                columns={columns}
                dataSource={subjectFtRoleRead}
                rowSelection={{
                    type: "checkbox",
                    ...rowSelection,
                }}
                rowKey={(record: FtPermissionReadDto) => record.id}
                style={{ width: "100%" }}
                size="small"
                pagination={{
                    pageSize: pageSize,
                    total: totalCount,
                    defaultCurrent: 1,
                    onChange: (page: number, pageSize?: number | undefined) =>
                        _searchDataOnClick(page, pageSize),
                    showSizeChanger: true,
                    pageSizeOptions: ["5", "10", "20", "50", "100"],
                }}
            />
        </>
    )
}