using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Owin.OAuth.Server.Providers.Auth
{
    public class AppOAuthAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            _ = context.TryGetFormCredentials(out string clientId, out string clientSecret);
            if (clientId != "local_test_client")
            {
                context.SetError("invalid_client");
            }
            else
            {
                context.Validated();
            }

            return Task.CompletedTask;
        }
        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            if (context.UserName == "foouser" && context.Password == "secret")
            {
                var claims = context.Scope.Select(x => new Claim("urn:oauth:scope", x)).ToList();

                claims.Add(new Claim("custom:issuer", "local_test_server"));

                var identity = new ClaimsIdentity(new GenericIdentity(
                    context.UserName, OAuthDefaults.AuthenticationType),
                    claims);

                var authProps = new AuthenticationProperties(new Dictionary<string, string>
                {
                    ["username"] = context.UserName,
                });
                var ticket = new AuthenticationTicket(identity, authProps);
                context.Validated(ticket);
            }
            else context.Rejected();

            return Task.CompletedTask;
        }
    }
}