import {  Row, Table, Tag } from 'antd';
import React, { useEffect } from 'react'
import { useDispatch, useSelector } from 'react-redux';
import { createStructuredSelector } from 'reselect';
import { AtomicgetListStart } from '../actions';
import { AtomicDto } from '../dtos/atomicDto';
import { makeSelectDataAtomic, makeSelectLoading } from '../selectors';

interface IAtomicComponentsProps {

}
const stateSelector = createStructuredSelector<any, any>({
    loading: makeSelectLoading(),
    data: makeSelectDataAtomic()
});
export default function AtomicComponents(props: IAtomicComponentsProps) {
    const dispatch = useDispatch();

    const {
        loading, data
    } = useSelector(stateSelector);

    useEffect(() => {
        dispatch(AtomicgetListStart());
    }, []);

    const columns = [
        {
            title: 'id',
            dataIndex: 'id',
            with: 50
        },
        {
            title: 'Tên',
            dataIndex: 'name',
            sorter: {
                compare: (a: { name: string; }, b: { name: string; }) => a.name.length - b.name.length,
                multiple: 3,
            },
            with: 300
        },
        {
            title: 'isActive',
            dataIndex: 'isActive',
            key: 'isActive',
            render: (text: boolean) => (text === true ? <Tag color="#2db7f5">True</Tag> : <Tag color="red">False</Tag>)
        },
        {
            title: 'Số lần sử dụng',
            dataIndex: 'count'
        },
        {
            title: 'Chi tiết',
            dataIndex: 'description'
        },
        {
            title: 'dateCreate',
            dataIndex: 'dateCreate'
        },
    ];
    return (
        <Row gutter={[10, 10]}>
            <Table
                columns={columns}
                rowKey={(record : AtomicDto) => record.id.toString()}
                dataSource={data}
                loading={loading}                
            />
        </Row >
    )
}
