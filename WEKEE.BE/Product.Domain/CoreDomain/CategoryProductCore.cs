using Product.Domain.Shared.Entitys;
using System;
using System.Collections.Generic;
using System.Text;
using Utils.Exceptions;

namespace Product.Domain.CoreDomain
{
    public static class CategoryProductCore
    {
        public static List<CategoryProduct> CategoryProductsSwapNumberOrder(CategoryProduct categoryFirst, CategoryProduct categoryLast)
        {
            // 2 vị trí này ko tồn tại
            if ((categoryLast == null || categoryFirst == null)
                || (categoryLast.LevelCategory == categoryFirst.LevelCategory
                     && categoryLast.NumberOrder == categoryFirst.NumberOrder))
            {
                throw new ClientException(402, "DATA_INVALID");
            }
            else
            {
                int numberOrderSwap = categoryLast.NumberOrder;
                categoryLast.NumberOrder = categoryFirst.NumberOrder;
                categoryFirst.NumberOrder = numberOrderSwap;
                return new List<CategoryProduct>() { categoryFirst, categoryLast };
            }
        }
    }
}
