using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace taller_mecanico.Filters
{
    public class LanguageFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
           
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var httpHeaders = context.HttpContext.Request.Headers;
            var language = httpHeaders.ContainsKey("Language")
                ? httpHeaders["Language"].ToString()
                : CultureInfo.CurrentCulture.Name;
            context.HttpContext.Items.Add("Lang", new CultureInfo(language)); 
        }
    }
}
