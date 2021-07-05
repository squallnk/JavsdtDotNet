using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Javsdt.API.Filter
{
    public class SelectCarsResourceFilterAttribute:Attribute, IResourceFilter
    {
        private IMemoryCache _cache;

        public SelectCarsResourceFilterAttribute(IMemoryCache cache)
        {
            _cache = cache;
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            throw new NotImplementedException();
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            string car = context.HttpContext.Request.Path;
            throw new NotImplementedException();

        }
    }
}
