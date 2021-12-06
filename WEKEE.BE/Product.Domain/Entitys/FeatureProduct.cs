using System;
using System.Collections.Generic;

#nullable disable

namespace Product.Domain.Entitys
{
    public partial class FeatureProduct
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public decimal PriceMarket { get; set; }
        public int? TotalNumber { get; set; }
        public int? Key1 { get; set; }
        public string Properties1 { get; set; }
        public int? Key2 { get; set; }
        public string Properties2 { get; set; }
        public decimal? Vat { get; set; }
        public double? Mass { get; set; }
        public double? Volume { get; set; }
        public double Guarantee { get; set; }
        public DateTime? DateCreate { get; set; }
        public DateTime? DateUpdate { get; set; }
        public bool? IsDefault { get; set; }
        public int? IsStatus { get; set; }
        public bool IsEnabled { get; set; }
        public int? Product { get; set; }
        public int? ImageProduct { get; set; }

        public virtual ImageProduct ImageProductNavigation { get; set; }
        public virtual SpecificationsCategory Key1Navigation { get; set; }
        public virtual SpecificationsCategory Key2Navigation { get; set; }
        public virtual Product ProductNavigation { get; set; }
    }
}
