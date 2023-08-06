using Microsoft.Owin.Security.OAuth;
using System.Linq;
using System.Threading.Tasks;

namespace Owin.OAuth.Server.Providers.Auth
{
    public class AppOAuthBearerAuthenticationProvider: OAuthBearerAuthenticationProvider
    {
        public override Task ValidateIdentity(OAuthValidateIdentityContext context)
        {
            if(context.Ticket.Identity.Claims
                .FirstOrDefault(c => c.Type == "custom:issuer")?.Value != "local_test_server")
            {
                context.Rejected();
            }
            else  context.Validated();

            return Task.CompletedTask;
        }
    }
}