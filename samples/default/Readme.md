# Incremental upgrade with Owin OAuth

This sample considers the scenatio of incremental upgrade where the legacy application (i.e. Owin.OAuth.Server) implements Owin OAuth server which uses DPAPI to issue the access tokens. During migration, the new web API application will continue to process access token issued by the leagacy application.

## Notes

* Legacy application is configured to use Aspnet Core implementation of DPAPI stack. The security keyring will be accessible by the migrated Aspnet Core application.

* Migrated Aspnet Core application is configured for incremental upgrade & implements YARP proxy.

* Migrated Aspnet Core application uses custom authentication handler that is port of Owin OAuthe Bearer authentication.
