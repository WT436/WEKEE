using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Album.API.FilterAttributeCore.ResourceFilters
{
    public class CacheResourceAttribute : TypeFilterAttribute
    {
        public CacheResourceAttribute()
            : base(typeof(CacheResourceFilter))
        {
        }
    }
}
