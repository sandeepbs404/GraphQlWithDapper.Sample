using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using DbUp;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Protocols;

namespace GraphQl.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var connectionString =
            //    args.FirstOrDefault()
            //    ?? ConfigurationManager<>.ConnectionStrings["YourDBConnectionName"].ConnectionString;

            //var upgrader =
            //    DeployChanges.To
            //        .SqlDatabase(connectionString)
            //        .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
            //        .LogToConsole()
            //        .Build();

            //var result = upgrader.PerformUpgrade();
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
