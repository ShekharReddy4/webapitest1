using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace WebApplication1
{
    public class AuthorizeAttribute : System.Web.Http.AuthorizeAttribute
    {
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            var token = actionContext.Request.Headers
                        .Where(h => h.Key.Equals("Authorization")).FirstOrDefault();

            if (token.Key == null)
            {
                return false;
            }
            else
            {
                // retrive the username and password from here
                // and assign it to the custom principal and custom roles 
                string username = token.Value.FirstOrDefault().ToString();
                
                if (username == "shekhar" || username == "reddy")
                {
                    if(username == "shekhar")
                    {
                        string[] roles = { "s", "h", "e", "k" };
                        Thread.CurrentPrincipal = new GenericPrincipal(
                        new GenericIdentity(username), roles);
                        return true;
                    }
                    else
                    {
                        string[] roles = {"r"};
                        Thread.CurrentPrincipal = new GenericPrincipal(
                        new GenericIdentity(username), roles);
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
        }
    }
}