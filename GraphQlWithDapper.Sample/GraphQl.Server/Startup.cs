using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Dapper.GraphQL;
using DbUp;
using GarphQl.Core.DapperGraphQl;
using GarphQl.Core.Models;
using GarphQl.Core.Query;
using GarphQl.Core.Schema;
using GraphQL;
using GraphQL.Server.Transports.AspNetCore;
using GraphQL.Server.Transports.WebSockets;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQl.Server
{
    public class Startup
    {

        public IConfigurationRoot Configuration { get; set; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "scripts");
            var upgrader =
                DeployChanges.To
                    .SqlDatabase(connectionString)
                    .WithScriptsFromFileSystem(path)
                    .LogToConsole()
                    .Build();
            
           EnsureDatabase.For.SqlDatabase(connectionString);
            var result = upgrader.PerformUpgrade();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<FormQuery>();
            services.AddSingleton<FormType>();
            services.AddSingleton<EmployerDeclarationType>();
            services.AddSingleton<FormSchema>();

            services.AddSingleton<IDependencyResolver>(
                c => new FuncDependencyResolver(type => c.GetRequiredService(type)));

            services.AddDapperGraphQL(options =>
            {
                options.AddType<FormQuery>();
                options.AddType<FormType>();
                options.AddType<EmployerDeclarationType>();
                options.AddSchema<FormSchema>();

                options.AddQueryBuilder<Form, FormQueryBuilder>();
                options.AddQueryBuilder<EmployerDeclaration, EmployerDeclarationQueryBuilder>();

                options.AddEntityMapper<Form, FormEntityMapper>();
                options.AddEntityMapper<EmployerDeclaration, EmployerDeclarationEntityMapper>();
            });

            services.AddGraphQLHttp();
            services.AddGraphQLWebSocket<FormSchema>();
            services.AddTransient<IDbConnection>(serviceProvider => GetDbConnection());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseGraphQLHttp<FormSchema>(new GraphQLHttpOptions());
            app.UseWebSockets();
            app.UseGraphQLWebSocket<FormSchema>(new GraphQLWebSocketsOptions());

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }

        private IDbConnection GetDbConnection()
        {
            var connectionString = Configuration.GetSection("ConnectionStrings:DefaultConnection").Value;
            // Ensure the database exists

            var sqlConnection = new SqlConnection(connectionString);
            return sqlConnection;
        }
    }
}
