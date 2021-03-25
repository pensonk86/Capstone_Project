using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Capstone_Project.ActionFilters
{
   

    public class GlobalRouting : IActionFilter
    {
        private readonly ClaimsPrincipal _claimsPrincipal;
        public GlobalRouting(ClaimsPrincipal claimsprincipal)
        {
            _claimsPrincipal = claimsprincipal;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var controller = context.RouteData.Values["controller"];
            if(controller.Equals("Home"))
            {
                if (_claimsPrincipal.IsInRole("UserModel"))
                {
                    context.Result = new RedirectToActionResult("Index",
                        "Users", null);
                }
                
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {


        }
    }
}
