using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils.Any;
using Utils.Cache;

namespace Product.API.FilterAttributeCore.ResourceFilters
{
    public class CacheResourceFilter : IResourceFilter
    {
        private readonly static MemoryCache myCache = new MemoryCache(new MemoryCacheOptions());
        private ICacheBase _cache => new CacheMemoryHelper(myCache);

        public void OnResourceExecuting(ResourceExecutingContext context)
        {

            string _cacheKey = GetCacheKey(context.HttpContext);

            if (_cacheKey == null)
            {
                return;
            }

            if (_cache.Get<string>(_cacheKey) is string cachedValue)
            {
                context.Result = new ContentResult()
                { Content = cachedValue };
            }
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            string _cacheKey = GetCacheKey(context.HttpContext);

            if (_cacheKey == null)
            {
                return;
            }

            IActionResult result = context.Result;
            if (result != null)
            {
                if (result is JsonResult json && json.StatusCode == 200)
                {
                    _cache.Add(json.Value, _cacheKey);
                }

                if (result is ObjectResult obr && obr.StatusCode == 200)
                {
                    _cache.Add<string>(JsonConvert.SerializeObject(obr.Value), _cacheKey);
                }
            }
        }

        public string GetCacheKey(HttpContext context)
        {
            var method = context.Request.Method.ToString();
            var controller = context.Request.RouteValues["controller"].ToString();
            var action = context.Request.RouteValues["action"].ToString();
            var parameter = context.Request.QueryString.ToString();
            var path = context.Request.Path.ToString();
            var host = context.Request.Host.Host.ToString();
            var port = context.Request.Host.Port.ToString();

            return HttpContextGetRequest.ConvertToKey(method: method, controller: controller, action: action,
                                                      parameter: parameter, path: path, host: host, port: port);
        }
    }
}
