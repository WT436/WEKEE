using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Domain.ObjectValues.Const
{
    public enum ProductAttributeTypes
    {
        ATTRIBUTE = 0, // Thuộc tính sản phẩm
        UNIT = 1, // đơn vị sản phẩm
        SPECIFICATIONS = 2, // thông số kỹ thuật
        TRADEMARK = 3, // thương hiệu
        VIDU4 = 4,
        VIDU5 = 5,
    }

    public static class ProductAttributeTypesConvert
    {
        public static string ConvertAttributeTypes(int types)
        {
            return types switch
            {
                0 => "ATTRIBUTE",
                1 => "UNIT",
                2 => "SPECIFICATIONS",
                3 => "TRADEMARK",
                _ => "UNIT",
            };
        }

    }
}
