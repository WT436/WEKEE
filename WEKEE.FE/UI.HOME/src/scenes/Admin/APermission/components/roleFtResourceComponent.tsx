//#region import
import React, { useEffect, useState } from 'react'
import { useDispatch, useSelector } from 'react-redux';
import { createStructuredSelector } from 'reselect';
import { L } from "../../../../lib/abpUtility";
import moment from 'moment';
import { PlusCircleOutlined } from '@ant-design/icons';
import { Tag, Tooltip, Button, Card, Col, Table, Row, Modal } from 'antd';
import utils from '../../../../utils/utils';
import { makeLoadingTableRoleFtPermission,  makePageIndexRoleFtPermission, makePageSizeRoleFtPermission, makeroleFtPermissionRead,  makeTotalCountRoleFtPermission, makeTotalPagesRoleFtPermission } from '../selectors';
import { roleFtPermissionStart, savePermissionFtResourceStart, saveRoleFtPermissionStart } from '../actions';
import { FtPermissionReadDto } from '../dto/ftPermissionReadDto';


declare var abp: any;
//#endregion

interface IRoleFtResourceComponentProps {
    idPermission: number
}

const stateSelector = createStructuredSelector<any, any>({
    roleFtPermissionRead:makeroleFtPermissionRead(),
    loadingTable: makeLoadingTableRoleFtPermission(),
    pageIndex: makePageIndexRoleFtPermission(),
    pageSize: makePageSizeRoleFtPermission(),
    totalCount: makeTotalCountRoleFtPermission(),
    totalPages: makeTotalPagesRoleFtPermission()

});

export default function RoleFtResourceComponent(props: IRoleFtResourceComponentProps) {

    const dispatch = useDispatch();

    const { roleFtPermissionRead, loadingTable, pageIndex, pageSize, totalCount, totalPages
    } = useSelector(stateSelector);

    //#region  START
    useEffect(() => {
        dispatch(roleFtPermissionStart({
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
        dispatch(roleFtPermissionStart({
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
        var data = roleFtPermissionRead
            .filter((item: FtPermissionReadDto) => item.isGranted)
            .map((item: FtPermissionReadDto) => item.id);
        setselectedRowKeys(data);
    }, [roleFtPermissionRead]);

    const columns = [
        {
            title: L("NAME", "CONST_TYPE_PERMISSION"),
            dataIndex: "name",
        },
        {
            title: L("IS_ACTIVE", "CONST_TYPE_PERMISSION"),
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
            title: L("ATOMIC_NAME", "CONST_TYPE_PERMISSION"),
            dataIndex: "atomicName",
        },
        {
            title: L("LEVEL_PERMISSION", "CONST_TYPE_PERMISSION"),
            dataIndex: "levelPermition",
        },
        {
            title: L("PERMISSION_NAME", "CONST_TYPE_PERMISSION"),
            dataIndex: "permissionName",
        },
        {
            title: L("CREATE_BY_NAME", "CONST_TYPE_PERMISSION"),
            dataIndex: "createByName",
            render: (text: string) =>
                text.toUpperCase() === "ADMIN" || text.toUpperCase() === "SYSTEM" ? (
                    <Tag color="#b3d4ff">{text}</Tag>
                ) : (
                    <Tag color="#2db7f5">{text}</Tag>
                ),
        },
        {
            title: L("CREATE_DATE_UTC", "CONST_TYPE_PERMISSION"),
            dataIndex: "updatedOnUtc",
            render: (text: Date) => moment(text).format("DD/MM/YYYY hh:mm:ss"),
        },
        {
            title: L("UPDATE_DATE_UTC", "CONST_TYPE_PERMISSION"),
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
        dispatch(saveRoleFtPermissionStart({ id: props.idPermission, permissionId: selectedRowKeys }));
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
                dataSource={roleFtPermissionRead}
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