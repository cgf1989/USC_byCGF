using BCP.WebAPI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace BCP.WebAPI.Controllers.Filters
{
    public class WebApiFilterAttribute : ActionFilterAttribute 
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception != null)
            {
                actionExecutedContext.Response = JsonHelper.GetResponseMessage(false, actionExecutedContext.Exception.Message, null, false, null);
            }
        }

        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            base.OnActionExecuting(actionContext);
            var queryString = actionContext.Request.GetQueryNameValuePairs();
            foreach (var node in queryString)
            {
                if (String.IsNullOrWhiteSpace(node.Value))
                {
                    actionContext.Response = JsonHelper.GetResponseMessage(false, "请求参数不能为空", null, false, null);
                }
            }
        }
    }
}