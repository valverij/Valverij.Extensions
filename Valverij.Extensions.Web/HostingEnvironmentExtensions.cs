using Microsoft.AspNetCore.Hosting;
using System;

namespace Valverij.Extensions.Web
{
    public static class HostingEnvironmentExtensions
    {
        public static bool IsDebug(this IHostingEnvironment env) => string.Equals(env.EnvironmentName, "Debug", StringComparison.OrdinalIgnoreCase);
    }
}
