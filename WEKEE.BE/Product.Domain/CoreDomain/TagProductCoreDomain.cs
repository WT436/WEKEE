using System;
using System.Collections.Generic;
using System.Text;
using Utils.Any;

namespace Product.Domain.CoreDomain
{
    public class TagProductCoreDomain
    {
        public string ProcessTag(string tag)
        {
            // convert về không dấu
            var tagRetu = String.Empty;
            tagRetu = LanguageConvert.ConvertVietNamese(tag.ToLower().Replace(" ",""));
            return tagRetu;
        }
    }
}
