using Product.Application.Interface;
using Product.Domain.ObjectValues.Const;
using Product.Domain.Shared.DataTransfer.ProductAttributeDTO;
using Product.Domain.Shared.Entitys;
using Product.Infrastructure.ModelQuery;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Utils.Exceptions;

namespace Product.Application.Application
{
    public class ProductAttributeService : IProductAttribute
    {
        ProductAttributeQuery _productAttributeQuery = new ProductAttributeQuery();
        public async Task<int> InsertProductAttribute(ProductAttributeInsertDto input, int idAccount)
        {
            // check name + type any
            if (await _productAttributeQuery.CheckNameAndTypeExists(name: input.Name, type: input.Types))
            {
                throw new ClientException(422, MessageOutput.EXISTS_PARAMETER);
            }
            else
            {
                _productAttributeQuery.Insert(new ProductAttribute
                {
                    Name = input.Name,
                    Types = input.Types,
                    IsDelete = false,
                    CreateBy = idAccount,
                    CreatedOnUtc = DateTime.Now,
                    UpdatedOnUtc= DateTime.Now
                });
                return 1;
            }
        }
    }
}
