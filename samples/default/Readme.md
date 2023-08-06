# Incremental upgrade with Owin OAuth

This sample considers the scenatio of incremental upgrade where the legacy application (i.e. Owin.OAuth.Server) implements Owin OAuth server which uses DPAPI to issue the access tokens. During migration, the new web API application will continue to process access token issued by the leagacy application.

# Notes

* Legacy application is configured to use Aspnet Core implementation of DPAPI stack. The security keyring will be accessible by the migrated Aspnet Core application.

* Migrated Aspnet Core application is configured for incremental upgrade & implements YARP proxy.

* Migrated Aspnet Core application uses custom authentication handler that is port of Owin OAuthe Bearer authentication.
 
## OAuth Configuration

Only implementing _Resource Owner Password_ grant flow.

* `grant_type` - _password_, basic testing
* `client_id` - _local_test_client_
* `client_secret` - any value
* `username` - _foouser_
* `password` - _secret_

## References

* [Owin OAuth Documentation](https://github.com/andrewlock/Docs/blob/master/aspnet/aspnet/overview/owin-and-katana/owin-oauth-20-authorization-server.md)
* [Owin OAuth Bearer authentication code](https://github.com/aspnet/AspNetKatana/blob/main/src/Microsoft.Owin.Security.OAuth/OAuthBearerAuthenticationHandler.cs)
* [ASP.NET Core Data Protection Overview](https://learn.microsoft.com/en-us/aspnet/core/security/data-protection/introduction?view=aspnetcore-7.0)
* [Replace the ASP.NET machineKey in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/data-protection/compatibility/replacing-machinekey?view=aspnetcore-7.0)
