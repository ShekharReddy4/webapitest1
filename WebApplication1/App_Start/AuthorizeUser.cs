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
                string username = token.Value.FirstOrDefault().ToString();
                if (username == "shekhar")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}