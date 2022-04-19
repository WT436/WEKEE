using Product.Domain.Shared.Entitys;
using System;
using System.Collections.Generic;
using System.Text;
using Utils.Exceptions;

namespace Product.Domain.CoreDomain
{
    public class CategoryProductCore
    {
        public List<CategoryProduct> CategoryProductsSwapNumberOrder(CategoryProduct categoryFirst, CategoryProduct categoryLast)
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
                (categoryFirst.NumberOrder, categoryLast.NumberOrder) = (categoryLast.NumberOrder, categoryFirst.NumberOrder);
                return new List<CategoryProduct>() { categoryFirst, categoryLast };
            }
        }
    }
}
