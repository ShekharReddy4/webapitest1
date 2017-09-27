using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace WebApplication1
{
    public class AuthorizeUser : AuthorizeAttribute
    {
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            var token = actionContext.Request.Headers
                        .Where(h => h.Key.Equals("Authorization")).FirstOrDefault();

            if (token.Key == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                return false;
            }
            else
            {
                string username = token.Value.FirstOrDefault().ToString();
                if (username == "shekhar")
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(username), null);
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.OK);
                    return true;
                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                    return false;
                }
            }
        }
    }
}