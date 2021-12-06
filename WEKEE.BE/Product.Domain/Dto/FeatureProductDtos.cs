using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Domain.Dto
{
   public class FeatureProductDtos
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public decimal PriceMarket { get; set; }
        public int? TotalNumber { get; set; }
        public string Key1 { get; set; }
        public string Properties1 { get; set; }
        public string Key2 { get; set; }
        public string Properties2 { get; set; }
        public decimal? Vat { get; set; }
        public double? Mass { get; set; }
        public double? Volume { get; set; }
        public double Guarantee { get; set; }
        public string Image { get; set; }
    }
}
