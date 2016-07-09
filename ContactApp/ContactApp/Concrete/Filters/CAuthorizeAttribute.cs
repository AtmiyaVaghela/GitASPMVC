using ContactApp.Helpers.Encoding;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ContactApp.Concrete.Filters
{
    public class CAuthorizeAttribute : AuthorizeAttribute
    {
        private readonly string[] allowRoles;

        public CAuthorizeAttribute(params string[] roles)
        {
            this.allowRoles = roles;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool authorise = false;
            string userName = string.Empty;

            if (HttpContext.Current.Request.Cookies["ContactApp"] != null)
            {
                userName = System.Text.Encoding.ASCII.DecodeBase64(HttpContext.Current.Request.Cookies["ContactApp"]["UserName"]);
            }
            else
            {
            }

            if (userName.Equals("admin"))
            {
                authorise = true;
            }
            else
            {
                foreach (var role in allowRoles)
                {
                }
            }
            return authorise;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (HttpContext.Current.Request.Cookies["ContactApp"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(new
           RouteValueDictionary(new { controller = "Login", action = "SignIn" }));
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(new
            RouteValueDictionary(new { controller = "Error", action = "AccessDenied" }));
            }
        }
    }
}