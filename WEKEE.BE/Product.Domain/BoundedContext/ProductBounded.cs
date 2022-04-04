using Product.Domain.Shared.DataTransfer.ProductDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Domain.BoundedContext
{
    public class ProductBounded
    {
        public Shared.Entitys.Product ProductMapping(ProductInsertDto input)
        {
            var dataretu = new Shared.Entitys.Product();
            dataretu.Name = input.Name;
            dataretu.Fragile = input.Fragile;
            dataretu.Origin = input.Origin;
            dataretu.UnitAttributeId = input.UnitAttributeId;
            dataretu.ShortDescription = input.ShortDescription;
            dataretu.FullDescription = input.FullDescription;
            return dataretu;
        }
    }
}
