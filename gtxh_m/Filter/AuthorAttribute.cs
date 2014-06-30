using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gtxh_m.Filter
{
    public class AuthorAttribute : FilterAttribute, IAuthorizationFilter
    {
        #region IAuthorizationFilter 成员

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            HttpContextBase context = filterContext.HttpContext;
            if (context.Session["userid"] == null)
            {
                filterContext.Result = new RedirectResult("http://iv.gtxh.com");
            }
        }

        #endregion
    }
}