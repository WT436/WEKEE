import { Form, Input, Select, Button, Table, Checkbox } from 'antd';
import React, { useEffect, useState } from 'react';
import { SortableContainer, SortableElement, SortableHandle } from 'react-sortable-hoc';
import { MenuOutlined } from '@ant-design/icons';
import { arrayMoveImmutable } from 'array-move';
import { createStructuredSelector } from 'reselect';
import { makeSelectKeyOfGroupSpec, makeSelectLoading, makeSelectnameGroupSpec, makeSelectproductContainer } from '../selectors';
import { useDispatch, useSelector } from 'react-redux';
import { loadKeyGroupStart, nameGroupSpecStart } from '../actions';
import { SpecificationProductInsertDto } from '../dtos/specificationProductInsertDto';
const { Option } = Select;

interface IInfomationDetailComponent { }

const DragHandle = SortableHandle(() => <MenuOutlined style={{ cursor: 'grab', color: '#999' }} />);

const SortableItem = SortableElement((props: any) => <tr {...props} />);
const SortableBody = SortableContainer((props: any) => <tbody {...props} />);

const columns = [
    {
        title: 'Sắp xếp hiển thị',
        dataIndex: 'displayOrder',
        className: 'drag-visible',
        render: () => <DragHandle />,
    },
    {
        title: 'Từ khóa',
        dataIndex: 'specificationKey',
        className: 'drag-visible',
    },
    {
        title: 'Nội dung',
        dataIndex: '',
        render: (text: SpecificationProductInsertDto) =>
            <Input placeholder="Nhập từ khóa"
                onChange={(content: any) => { text.customValue = content.target.value }}
                defaultValue={text.customValue} />
    },
    {
        title: 'Bộ lọc tìm kiếm',
        dataIndex: '',
        render: (text: SpecificationProductInsertDto) =>
            <Checkbox defaultChecked={text.allowFiltering}
                onChange={(content: any) => { text.allowFiltering = content.target.checked }}
            />
    },
    {
        title: 'Hiển thị trên trang',
        dataIndex: '',
        render: (text: SpecificationProductInsertDto) =>
            <Checkbox defaultChecked={text.showOnProductPage}
                onChange={(content: any) => { text.allowFiltering = content.target.checked }}
            />
    }
];

const stateSelector = createStructuredSelector < any, any> ({
    loading: makeSelectLoading(),
    productContainer: makeSelectproductContainer(),
    nameGroupSpec: makeSelectnameGroupSpec(),
    keyOfGroupSpec: makeSelectKeyOfGroupSpec()
});

export default function InfomationDetailComponent(props: IInfomationDetailComponent) {
    const {
        loading, productContainer, nameGroupSpec, keyOfGroupSpec
    } = useSelector(stateSelector);

    const dispatch = useDispatch();

    const [dataSource, setdataSource] = useState < SpecificationProductInsertDto[] > ([]);
    const [nameGroup, setnameGroup] = useState < string > ();

    useEffect(() => {
        if (IsGroupSelect) {
            setdataSource([]);
            keyOfGroupSpec.forEach((m: string, index: number) => {
                setdataSource(dataSource => [...dataSource, {
                    customValue: '',
                    specificationKey: m,
                    SpecificationGroup: nameGroup,
                    allowFiltering: true,
                    showOnProductPage: true,
                    displayOrder: 0,
                    index: index
                }]);
            });
        }
    }, [keyOfGroupSpec]);

    const onSortEnd = ({ oldIndex, newIndex }: any) => {
        if (oldIndex !== newIndex) {
            const newData = arrayMoveImmutable(dataSource, oldIndex, newIndex)
                .filter(el => !!el);
            setdataSource(newData);
        }
    };

    const DraggableContainer = (props: any) => (
        <SortableBody
            useDragHandle
            disableAutoscroll
            helperClass="row-dragging"
            onSortEnd={onSortEnd}
            {...props}
        />
    );

    const DraggableBodyRow = ({ className, style, ...restProps }: any) => {
        const index = dataSource.findIndex((x: any) => x.index === restProps['data-row-key']);
        return <SortableItem index={index} {...restProps} />;
    };

    //#region Select Type Spec
    const [IsGroupSelect, setIsGroupSelect] = useState(false);

    const _selectTypesSpec = (value: any) => {
        console.log(value)
        if (value === 'group') {
            setIsGroupSelect(true);
            dispatch(nameGroupSpecStart(productContainer.categoryProduct.idCategory));           
            setnameGroup(value);
        }
        else {
            dispatch(loadKeyGroupStart(productContainer.categoryProduct.idCategory, undefined));
            setIsGroupSelect(false);
        }
    }
    //#endregion
    //#region Render Sepc On select 
    const _renderOnselect = (value: any) => {
        if (IsGroupSelect) {
            // load data group đẩy thẳng vào
            if (value !== undefined) {
                dispatch(loadKeyGroupStart(productContainer.categoryProduct.idCategory, value));
                setnameGroup(value);
            }
        }
        else {
            setdataSource([]);
            value.forEach((m: string, index: number) => {
                setdataSource(dataSource => [...dataSource, {
                    customValue: '',
                    specificationKey: m,
                    SpecificationGroup: undefined,
                    allowFiltering: true,
                    showOnProductPage: true,
                    displayOrder: 0,
                    index: index
                }]);
            });
        }
    }
    //#endregion
    const _saveDataSource = () => {
        setdataSource(dataSource);
        productContainer.specificationProductDtos = dataSource;
        console.log(dataSource);
    }

    return (
        <>
            <Form.Item
                label="Cài đặt thông số sản phẩm"
                name="Cài đặt thông số sản phẩm"
                labelAlign='left'
                wrapperCol={{ span: 24 }}
                labelCol={{ span: 24 }}
                rules={[
                    {
                        required: true,
                        message: 'Please input your name',
                    },
                ]}
            >
                <Input.Group className="lLwemSWham" compact>
                    <Select
                        showSearch
                        style={{ width: 200 }}
                        placeholder="Lựa chọn kiểu nhập thông số"
                        optionFilterProp="children"
                        onChange={(value: any) => _selectTypesSpec(value)}
                    >
                        <Option key='1' value='default'>Lưu động</Option>
                        <Option key='2' value='group'>Nhóm</Option>
                    </Select>
                    <Select
                        style={{ width: 300 }}
                        placeholder="Lựa chọn thành phần!"
                        mode={IsGroupSelect ? undefined : "tags"}
                        onChange={(value: any) => _renderOnselect(value)}
                    >
                        {IsGroupSelect
                            ?
                            nameGroupSpec.map((item: string) => (
                                <Option key={item} value={item}>{item}</Option>)
                            ) : keyOfGroupSpec.map((item: string) => (
                                <Option key={item} value={item}>{item}</Option>
                            ))
                        }
                    </Select>
                </Input.Group>
            </Form.Item>

            <Form.Item>
                <Table
                    pagination={false}
                    dataSource={dataSource}
                    columns={columns}
                    rowKey="index"
                    size='small'
                    components={{
                        body: {
                            wrapper: DraggableContainer,
                            row: DraggableBodyRow,
                        },
                    }}
                />
            </Form.Item>
            <div className='HjgYTIG'>
                <Button type='default' onClick={_saveDataSource}>Xác nhận thông số</Button>
            </div>
        </>
    )
}
