using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Owin.OAuth.Server.Providers.Auth;
using System;

[assembly: OwinStartup(typeof(Owin.OAuth.Server.Startup))]
namespace Owin.OAuth.Server
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // New code:
            ConfigureOAuth(app);
        }

        private void ConfigureOAuth(IAppBuilder app)
        {
            app.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions
            {
                AuthenticationMode = AuthenticationMode.Passive,
                AuthorizeEndpointPath = new PathString("/authorize"),
                TokenEndpointPath = new PathString("/token"),
                AllowInsecureHttp = true, // local testing only
                Provider = new AppOAuthAuthorizationServerProvider()
            });

            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions
            {
                Provider = new AppOAuthBearerAuthenticationProvider()
            });
        }
    }
}