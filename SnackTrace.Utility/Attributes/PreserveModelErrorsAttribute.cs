using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SnackTrace.Utility.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class PreserveModelErrorsAttribute : ActionFilterAttribute
	{
        const string PRESERVED_MODEL_STATE_KEY = "PRESERVED_MODEL_STATE_KEY";

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            var controller = filterContext.Controller as Controller;

            // Store model state in temp data
            var modelErrors = new List<KeyValuePair<string, IEnumerable<string>>>();

            foreach(var entry in controller.ModelState)
			{
                modelErrors.Add(new KeyValuePair<string, IEnumerable<string>>(entry.Key, entry.Value.Errors.Select(i => i.ErrorMessage)));
			}

            controller.TempData[PRESERVED_MODEL_STATE_KEY] = JsonConvert.SerializeObject(modelErrors.AsEnumerable());
        }
    }
}
