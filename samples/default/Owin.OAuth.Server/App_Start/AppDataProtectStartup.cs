using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.SystemWeb;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace Owin.OAuth.Server
{
    public class AppDataProtectStartup: DataProtectionStartup
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            var keyFolder = Environment.GetEnvironmentVariable("APP_Owin_OAuth_Server_KeyFolder")
                ?? throw new InvalidOperationException("set env var 'APP_Owin_OAuth_Server_KeyFolder'");

            services.AddDataProtection()
                .SetApplicationName("Owin.OAuth.Server")
                .PersistKeysToFileSystem(new DirectoryInfo(keyFolder));
        }
    }
}