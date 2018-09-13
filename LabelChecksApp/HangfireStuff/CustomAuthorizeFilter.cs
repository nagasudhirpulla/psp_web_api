using Hangfire.Annotations;
using Hangfire.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabelChecksApp.HangfireStuff
{
    public class CustomAuthorizeFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize([NotNull] DashboardContext context)
        {
            var httpcontext = context.GetHttpContext();
            if (httpcontext.User != null && httpcontext.User.Identity.IsAuthenticated && httpcontext.User.Identity.Name == "Administrator")
            {
                return true;
            }
            return false;
        }
    }
}
