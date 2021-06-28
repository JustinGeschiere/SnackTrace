using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SnackTrace.Utility.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
	public class RestoreModelErrorsAttribute : ActionFilterAttribute
	{
        const string PRESERVED_MODEL_STATE_KEY = "PRESERVED_MODEL_STATE_KEY";

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            var controller = filterContext.Controller as Controller;

            // Retrieve model state from temp data
            if (controller.TempData.ContainsKey(PRESERVED_MODEL_STATE_KEY))
            {
                var preservedModelErrors = JsonConvert.DeserializeObject<IEnumerable<KeyValuePair<string, IEnumerable<string>>>>(controller.TempData[PRESERVED_MODEL_STATE_KEY] as string);

                foreach(var entry in preservedModelErrors)
				{
                    foreach(var error in entry.Value)
					{
                        controller.ModelState.AddModelError(entry.Key, error);
					}
				}
            }
        }
    }
}
