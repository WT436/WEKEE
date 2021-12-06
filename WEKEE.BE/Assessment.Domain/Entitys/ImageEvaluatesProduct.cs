using System;
using System.Collections.Generic;

#nullable disable

namespace Assessment.Domain.Entitys
{
    public partial class ImageEvaluatesProduct
    {
        public ImageEvaluatesProduct()
        {
            InverseImageRootNavigation = new HashSet<ImageEvaluatesProduct>();
        }

        public int Id { get; set; }
        public string Src { get; set; }
        public string Alt { get; set; }
        public string Title { get; set; }
        public string Size { get; set; }
        public string Folder { get; set; }
        public int? ImageRoot { get; set; }
        public bool TypesImage { get; set; }
        public int IdEvaluatesProduct { get; set; }
        public bool IsEnabled { get; set; }
        public DateTime? DateCreate { get; set; }
        public DateTime? DateUpdate { get; set; }

        public virtual ImageEvaluatesProduct ImageRootNavigation { get; set; }
        public virtual ICollection<ImageEvaluatesProduct> InverseImageRootNavigation { get; set; }
    }
}
