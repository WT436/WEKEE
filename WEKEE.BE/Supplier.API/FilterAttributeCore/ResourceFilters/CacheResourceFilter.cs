using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Utils.Cache;

namespace Supplier.API.FilterAttributeCore.ResourceFilters
{
    public class CacheResourceFilter : IResourceFilter
    {
        private readonly static MemoryCache myCache = new MemoryCache(new MemoryCacheOptions());
        private ICacheBase _cache => new CacheMemoryHelper(myCache);
        private string _cacheKey;

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            //svc = context.HttpContext.RequestServices;
            //_cache = svc.GetService<ICacheBase>();

            _cacheKey = context.HttpContext.Request.Path.ToString();

            if (_cache.Get<string>(_cacheKey) is string cachedValue)
            {
                context.Result = new ContentResult()
                { Content = cachedValue };
            }
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            IActionResult result = context.Result;
            if (result != null)
            {
                if (result is JsonResult json && json.StatusCode==200)
                {
                    _cache.Add(json.Value, _cacheKey);
                }

                if (result is ObjectResult obr && obr.StatusCode == 200)
                {
                    _cache.Add(obr.Value, _cacheKey);
                }
            }
        }
    }
}
