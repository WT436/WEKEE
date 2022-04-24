import { UpOutlined, DownOutlined } from '@ant-design/icons';
import { Button, Input, Table, Tag } from 'antd';
import '../sty.css';
import React, { useEffect, useState } from 'react'
import { createStructuredSelector } from 'reselect';
import { makeSelectLoading, makeSelectspecificationsCategoryDto } from '../selectors';
import { useSelector } from 'react-redux';
import { SpecificationsCategoryDto } from '../dtos/specificationsCategoryDto';

const { TextArea } = Input;

interface InfomationSalesComponent { parentCallback: any }

const stateSelector = createStructuredSelector<any, any>({
    loading: makeSelectLoading(),
    specificationsCategoryDto: makeSelectspecificationsCategoryDto()
});
interface dataShow { key: string, displayOrder: number, nameShow: string, values: string }
export default function InfomationSalesComponent(props: InfomationSalesComponent) {

    const {
        specificationsCategoryDto
    } = useSelector(stateSelector);

    //useState
    const [showSpecifi, setshowSpecifi] = useState<{ key: string; nameShow: string; }[]>([]);
    const [data, setdata] = useState<dataShow[]>([]);

    //useEffect
    useEffect(() => {
        setshowSpecifi([]);
        specificationsCategoryDto.forEach((p: SpecificationsCategoryDto) => {
            if (p.classify === 2 && showSpecifi.findIndex(item => item.key === p.key) === -1) {
                showSpecifi.push({ key: p.key, nameShow: p.nameShow });
                setshowSpecifi([...showSpecifi]);
            }
        });
    }, [specificationsCategoryDto]);

    useEffect(() => {
        var dataSup: dataShow[] = [];
        showSpecifi.map((item: any, index: number) => (
            dataSup.push({
                key: item.key,
                nameShow: item.nameShow,
                displayOrder: index,
                values: ''
            })
        ))
        setdata(dataSup);
    }, [showSpecifi]);

    useEffect(() => {
        props.parentCallback(data);
    }, [data]);

    const columnsData = [
        {
            title: 'Vị trí hiển thị',
            key: 'displayOrder',
            dataIndex: 'displayOrder',
            width: '20%',
            render: (item: any) => (
                <> <Button
                    className="ZZGJtqNgXd"
                    icon={<UpOutlined />}
                    onClick={() => {
                        data[data.findIndex(m => m.displayOrder === item)].displayOrder--;
                        data[data.findIndex(m => m.displayOrder === item - 1)].displayOrder++;
                        setdata([...data]);
                    }}
                    disabled={item === 0}
                ></Button>
                    <Tag style={{ top: "1px" }} className="ZZGJtqNgXd">{item}</Tag>
                    <Button
                        className="ZZGJtqNgXd"
                        icon={<DownOutlined />}
                        disabled={item === data.length - 1}
                        onClick={() => {
                            data[data.findIndex(m => m.displayOrder == item + 1)].displayOrder--;
                            data[data.findIndex(m => m.displayOrder == item)].displayOrder++;
                            setdata([...data]);
                        }}></Button>
                </>
            ),
        },
        {
            title: 'Khóa',
            dataIndex: 'key',
            key: 'key',
            width: '20%',
            render: (item: any) => <Tag color="red">{item}</Tag>,
        },
        {
            title: 'Tên hiển thị',
            dataIndex: 'nameShow',
            key: 'nameShow',
            width: '20%',
            render: (item: any) => <Tag color="blue">{item}</Tag>,
        },
        {
            title: 'Giá trị',
            dataIndex: '',
            width: '40%',
            render: (item: dataShow) =>
                <TextArea
                    placeholder="Nhập thông tin!"
                    showCount maxLength={300}
                    style={{ height: '90px' }}
                    onChange={(value: any) => item.values = value.target.value} />,
        }
    ];

    return (
        <>
            <Table
                columns={columnsData}
                pagination={false}
                rowKey={(record: dataShow | any) => record.id}
                dataSource={data.sort(function (a, b) { return a.displayOrder - b.displayOrder })}
            />
        </>
    )
}
