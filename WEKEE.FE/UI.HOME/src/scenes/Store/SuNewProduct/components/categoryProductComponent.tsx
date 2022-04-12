import { PlusOutlined } from '@ant-design/icons';
import { Cascader, Divider, Form, Input, Select, Switch } from 'antd';
import TextArea from 'antd/lib/input/TextArea'
import React, { useEffect, useState } from 'react'
import { useDispatch, useSelector } from 'react-redux';
import { createStructuredSelector } from 'reselect';
import {
    ContainerCreateProductStart,
    getCategotyMainStart,
    proAttrTypesUnitStart,
    readFullAlbumProductStart,
} from '../actions';
import {
    makeSelectalbumProduct,
    makeSelectcategorySelectDto, makeSelectproductAttributeReadTypesDto,
     makeSelectproductContainer, makeSelectproductDto, makeSelectspecificationsCategoryDto,
      makeSelectTrademarkDto,
} from '../selectors';
import { ProductAttributeReadTypesDto } from '../dtos/productAttributeReadTypesDto';
const { Option } = Select;
interface ICategoryProductComponent { }

const stateSelector = createStructuredSelector < any, any> ({
    optionsCategory: makeSelectcategorySelectDto(),
    albumProduct: makeSelectalbumProduct(),
    specificationsCategoryDto: makeSelectspecificationsCategoryDto(),
    productDto: makeSelectproductDto(),
    productAttributeReadTypesDto: makeSelectproductAttributeReadTypesDto(),
    trademarkDto: makeSelectTrademarkDto(),
    productContainer: makeSelectproductContainer()
});

const origin = [
    {
        "value": "Toàn Quốc"
    },
    {
        "value": " H\u00E0 N\u1ED9i"
    },
    {
        "value": " H\u00E0 Giang"
    },
    {
        "value": " Cao B\u1EB1ng"
    },
    {
        "value": " B\u1EAFc K\u1EA1n"
    },
    {
        "value": " Tuy\u00EAn Quang"
    },
    {
        "value": " L\u00E0o Cai"
    },
    {
        "value": " \u0110i\u1EC7n Bi\u00EAn"
    },
    {
        "value": " Lai Ch\u00E2u"
    },
    {
        "value": " S\u01A1n La"
    },
    {
        "value": " Y\u00EAn B\u00E1i"
    },
    {
        "value": " Ho\u00E0 B\u00ECnh"
    },
    {
        "value": " Th\u00E1i Nguy\u00EAn"
    },
    {
        "value": " L\u1EA1ng S\u01A1n"
    },
    {
        "value": " Qu\u1EA3ng Ninh"
    },
    {
        "value": " B\u1EAFc Giang"
    },
    {
        "value": " Ph\u00FA Th\u1ECD"
    },
    {
        "value": " V\u0129nh Ph\u00FAc"
    },
    {
        "value": " B\u1EAFc Ninh"
    },
    {
        "value": " H\u1EA3i D\u01B0\u01A1ng"
    },
    {
        "value": "H\u1EA3i Ph\u00F2ng"
    },
    {
        "value": " H\u01B0ng Y\u00EAn"
    },
    {
        "value": " Th\u00E1i B\u00ECnh"
    },
    {
        "value": " H\u00E0 Nam"
    },
    {
        "value": " Nam \u0110\u1ECBnh"
    },
    {
        "value": " Ninh B\u00ECnh"
    },
    {
        "value": " Thanh H\u00F3a"
    },
    {
        "value": " Ngh\u1EC7 An"
    },
    {
        "value": " H\u00E0 T\u0129nh"
    },
    {
        "value": " Qu\u1EA3ng B\u00ECnh"
    },
    {
        "value": " Qu\u1EA3ng Tr\u1ECB"
    },
    {
        "value": " Th\u1EEBa Thi\u00EAn Hu\u1EBF"
    },
    {
        "value": "\u0110\u00E0 N\u1EB5ng"
    },
    {
        "value": " Qu\u1EA3ng Nam"
    },
    {
        "value": " Qu\u1EA3ng Ng\u00E3i"
    },
    {
        "value": " B\u00ECnh \u0110\u1ECBnh"
    },
    {
        "value": " Ph\u00FA Y\u00EAn"
    },
    {
        "value": " Kh\u00E1nh H\u00F2a"
    },
    {
        "value": " Ninh Thu\u1EADn"
    },
    {
        "value": " B\u00ECnh Thu\u1EADn"
    },
    {
        "value": " Kon Tum"
    },
    {
        "value": " Gia Lai"
    },
    {
        "value": " \u0110\u1EAFk L\u1EAFk"
    },
    {
        "value": " \u0110\u1EAFk N\u00F4ng"
    },
    {
        "value": " L\u00E2m \u0110\u1ED3ng"
    },
    {
        "value": " B\u00ECnh Ph\u01B0\u1EDBc"
    },
    {
        "value": " T\u00E2y Ninh"
    },
    {
        "value": " B\u00ECnh D\u01B0\u01A1ng"
    },
    {
        "value": " \u0110\u1ED3ng Nai"
    },
    {
        "value": " B\u00E0 R\u1ECBa - V\u0169ng T\u00E0u"
    },
    {
        "value": " H\u1ED3 Ch\u00ED Minh"
    },
    {
        "value": " Long An"
    },
    {
        "value": " Ti\u1EC1n Giang"
    },
    {
        "value": " B\u1EBFn Tre"
    },
    {
        "value": " Tr\u00E0 Vinh"
    },
    {
        "value": " V\u0129nh Long"
    },
    {
        "value": " \u0110\u1ED3ng Th\u00E1p"
    },
    {
        "value": " An Giang"
    },
    {
        "value": " Ki\u00EAn Giang"
    },
    {
        "value": " C\u1EA7n Th\u01A1"
    },
    {
        "value": " H\u1EADu Giang"
    },
    {
        "value": " S\u00F3c Tr\u0103ng"
    },
    {
        "value": " B\u1EA1c Li\u00EAu"
    },
    {
        "value": " C\u00E0 Mau"
    }
]

export default function CategoryProductComponent(props: ICategoryProductComponent) {
    const dispatch = useDispatch();

    const {
        optionsCategory, albumProduct, productAttributeReadTypesDto,
        trademarkDto, productContainer
    } = useSelector(stateSelector);
    useEffect(() => {
    }, [productContainer]);
    //#region START
    useEffect(() => {
        dispatch(getCategotyMainStart());
        dispatch(readFullAlbumProductStart());
    }, []);
    //#endregion
    //#region CATEGORY
    const [IsCategorySelect, setIsCategorySelect] = useState(true);

    let onChangeCascader = (value: any) => {
        
        dispatch(proAttrTypesUnitStart(1,value));

        if (productContainer.categoryProduct.categoryMain !== 0) {
            productContainer.categoryProduct.idCategory = value;
            productContainer.categoryProduct.categoryMain = value.length == 0 ? 0 : value[0];
            setIsCategorySelect(productContainer.categoryProduct.categoryMain === 0);
            dispatch(ContainerCreateProductStart(productContainer));
            // confirm({
            //     title: 'Cảnh Báo!',
            //     icon: <WarningOutlined />,
            //     content: 'Khi thay đổi Category sẽ tự động xóa dữ liệu đã nhập',
            //     onOk() {
            //         productContainer.categoryProduct.idCategory = value;
            //         setCategoryDefault(value);
            //         productContainer.categoryProduct.categoryMain = value.length == 0 ? 0 : value[0];
            //         setIsCategorySelect(productContainer.categoryProduct.categoryMain === 0);
            //         _removeAllData();
            //         dispatch(ContainerCreateProductStart(productContainer));
            //     },
            //     onCancel() {
            //         setCategoryDefault(productContainer.categoryProduct.idCategory);
            //     },
            // });
        }
        else {
            productContainer.categoryProduct.idCategory = value;
            productContainer.categoryProduct.categoryMain = value.length == 0 ? 0 : value[0];
            setIsCategorySelect(productContainer.categoryProduct.categoryMain === 0);
            dispatch(ContainerCreateProductStart(productContainer));
        }
    };
    //#endregion
    //#region Album Product 
    const [provinceDataAlbumProduct, setprovinceDataAlbumProduct] = useState(['']);
    const [nameAlbumProduct, setNameAlbumProduct] = useState('');


    useEffect(() => {
        setprovinceDataAlbumProduct(provinceDataAlbumProduct.concat(albumProduct));
    }, [albumProduct]);

    const onNameChangeAlbumProduct = (event: any) => {
        setNameAlbumProduct(
            event.target.value,
        );
    };

    const addItemAlbumProduct = () => {
        if (provinceDataAlbumProduct.findIndex((element) => element === nameAlbumProduct) === -1) {
            setprovinceDataAlbumProduct([...provinceDataAlbumProduct, nameAlbumProduct]);
        }

    };
    const selectAlbum = (value: string) => {
        productContainer.productInsertDto.productAlbum = value;
        dispatch(ContainerCreateProductStart(productContainer));
    }
    //#endregion
    //#region Tag 
    const [items, setitems] = useState < string[] > ([]);
    const [nameTag, setnameTag] = useState('');

    const addItem = () => {
        if (items.findIndex((element) => element === nameTag) === -1) {
            setitems([...items, nameTag]);
        }
    };

    const onNameChange = (event: any) => {
        setnameTag(event.target.value);
    };
    //#endregion
    //#region Attribute Product
    const selectunitProduct = (value: number) => {
        productContainer.productInsertDto.unitProduct = value;
        dispatch(ContainerCreateProductStart(productContainer));
    }
    //#endregion
    //#region Other 
    const selectOrigin = (value: string) => {
        productContainer.productInsertDto.origin = JSON.stringify(value);
        dispatch(ContainerCreateProductStart(productContainer));
    }

    const selectNameProduct = (value: string) => {
        productContainer.productInsertDto.name = value;
        dispatch(ContainerCreateProductStart(productContainer));
    }

    const selectfragileProduct = (value: boolean) => {
        productContainer.productInsertDto.fragile = value;
        dispatch(ContainerCreateProductStart(productContainer));
    }

    const selecttrademarkProduct = (value: number) => {
        productContainer.productInsertDto.trademark = value;
        dispatch(ContainerCreateProductStart(productContainer));
    }

    const selectTagProduct = (value: any) => {
        productContainer.productTagDtos = value;
        dispatch(ContainerCreateProductStart(productContainer));
    }
    //#endregion

    return (
        <>
            <Form.Item
                name="name"
                label="Tên Sản Phẩm"
                key="name"
                rules={[
                    {
                        required: true,
                        message: 'Cần điền tên sản phẩm',
                    },
                ]}
            >
                <TextArea
                    className="qTPFz3NQ2b"
                    placeholder="Tên Sản Phẩm"
                    showCount
                    maxLength={200}
                    onChange={(value: any) => selectNameProduct(value.target.value)} />
            </Form.Item>

            <Form.Item
                name="categoryProduct"
                label="Danh Mục Sản Phẩm"
                key="categoryProduct"
                rules={[
                    {
                        required: true,
                        message: 'Cần lựa chọn Danh mục sản phẩm',
                    },
                ]}
            >
                <Cascader
                    fieldNames={{
                        label: "nameCategory",
                        value: "id",
                        children: "items",
                    }}
                    options={optionsCategory}
                    style={{ width: "100%" }}
                    onChange={onChangeCascader}
                    changeOnSelect
                />
            </Form.Item>

            <Form.Item
                name="productAlbum"
                label="Album sản phẩm"
                key="productAlbum"
                rules={[
                    {
                        required: true,
                        message: 'Lựa chọn Album cho sản phẩm',
                    },
                ]}
            >
                <Select
                    style={{ width: '100%' }}
                    onChange={selectAlbum}
                    disabled={IsCategorySelect}
                    dropdownRender={menu => (
                        <div>
                            {menu}
                            <Divider style={{ margin: '4px 0' }} />
                            <div style={{ display: 'flex', flexWrap: 'nowrap', padding: 8 }}>
                                <Input style={{ flex: 'auto' }} onChange={onNameChangeAlbumProduct} />
                                <a
                                    style={{ flex: 'none', padding: '8px', display: 'block', cursor: 'pointer' }}
                                    onClick={addItemAlbumProduct}
                                >
                                    <PlusOutlined /> Thêm Album
                                </a>
                            </div>
                        </div>
                    )}
                >
                    {
                        provinceDataAlbumProduct.map(province => (
                            <Option value={province}>{province}</Option>
                        ))
                    }
                </Select>
            </Form.Item>

            <Form.Item
                name="origin"
                label="Địa chỉ"
                rules={[
                    {
                        required: true,
                        message: 'Cần lựa chọn khu vực bán',
                    },
                ]}
            >
                <Select
                    showSearch
                    style={{ width: '100%' }}
                    optionFilterProp="children"
                    mode="multiple"
                    filterOption={(input: any, option: any) =>
                        option.children.toLowerCase().indexOf(input.toLowerCase()) >= 0
                    }
                    filterSort={(optionA: any, optionB: any) =>
                        optionA.children.toLowerCase().localeCompare(optionB.children.toLowerCase())
                    }
                    onChange={selectOrigin}
                >
                    {
                        origin.map(province => (
                            <Option value={province.value}>{province.value}</Option>
                        ))
                    }
                </Select>
            </Form.Item>

            <Form.Item
                name="unitProduct"
                label="Đơn vị tính"
                key="unitProduct"
                rules={[
                    {
                        required: true,
                        message: 'Cần lựa chọn khu vực bán',
                    },
                ]}
            >
                <Select
                    showSearch
                    style={{ width: '100%' }}
                    optionFilterProp="children"
                    filterOption={(input: any, option: any) =>
                        option.children.toLowerCase().indexOf(input.toLowerCase()) >= 0
                    }
                    filterSort={(optionA: any, optionB: any) =>
                        optionA.children.toLowerCase().localeCompare(optionB.children.toLowerCase())
                    }
                    disabled={IsCategorySelect}
                    onChange={selectunitProduct}
                    onClick={()=>dispatch(proAttrTypesUnitStart(1,productContainer.categoryProduct.idCategory))}
                >
                    {
                        productAttributeReadTypesDto.map((province: ProductAttributeReadTypesDto) => (
                            <Option value={province.id}>{province.name}</Option>
                        ))
                    }
                </Select>
            </Form.Item>

            <Form.Item
                name="fragile"
                label="Hàng Dễ vỡ"
                key="fragile"
                rules={[
                    {
                        required: true,
                        message: 'Sản phẩm Dễ vỡ',
                    },
                ]}
            >
                <Switch
                    checkedChildren="Hàng Cứng"
                    unCheckedChildren="Hàng Dễ vỡ"
                    onChange={(value: boolean) => selectfragileProduct(value)}
                    defaultChecked />
            </Form.Item>

            <Form.Item
                name="trademark"
                label="Thương Hiệu"
                key="trademark"
                rules={[
                    {
                        required: true,
                        message: 'Cần lựa chọ thương hiệu. Nếu không có thì NoBrand',
                    },
                ]}
            >
                <Select
                    showSearch
                    style={{ width: '100%' }}
                    optionFilterProp="children"
                    filterOption={(input: any, option: any) =>
                        option.children.toLowerCase().indexOf(input.toLowerCase()) >= 0
                    }
                    filterSort={(optionA: any, optionB: any) =>
                        optionA.children.toLowerCase().localeCompare(optionB.children.toLowerCase())
                    }
                    disabled={IsCategorySelect}
                    onChange={
                        (value: number) => selecttrademarkProduct(value)
                    }
                    onClick ={()=>dispatch(proAttrTypesUnitStart(3,productContainer.categoryProduct.idCategory))}
                >
                    {
                        trademarkDto.map((province: ProductAttributeReadTypesDto) => (
                            <Option value={province.id}>{province.name}</Option>
                        ))
                    }
                </Select>
            </Form.Item>

            <Form.Item
                name="tag"
                label="Khóa tìm kiếm Nhanh"
                key="tag"
                rules={[
                    {
                        required: true,
                        message: 'Cần lựa chọn tag tìm kiếm',
                    },
                ]}
            >
                <Select
                    placeholder="Nhập và lựa chọn tag bài viết"
                    mode="multiple"
                    showArrow
                    onChange={
                        (value: any) => selectTagProduct(value)
                    }
                    dropdownRender={menu => (
                        <div>
                            {menu}
                            <Divider style={{ margin: '4px 0' }} />
                            <div style={{ display: 'flex', flexWrap: 'nowrap', padding: 4 }}>
                                <Input size='small' style={{ flex: 'auto' }} value={nameTag} onChange={onNameChange} />
                                <a
                                    style={{ flex: 'none', padding: '8px', display: 'block', cursor: 'pointer' }}
                                    onClick={addItem}
                                >
                                    <PlusOutlined /> Thêm tag
                                </a>
                            </div>
                        </div>
                    )}
                >
                    {items.map(item => (
                        <Option key={item} value={item}>{item}</Option>
                    ))}
                </Select>
            </Form.Item>
        </>
    )
}
