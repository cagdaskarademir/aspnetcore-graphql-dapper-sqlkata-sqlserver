using System;
using System.Data.SqlClient;
using FluentMigrator.Runner;
using Smoothie.Business;
using Smoothie.Repository;
using GraphQL;
using GraphQL.Http;
using GraphQL.Server;
using GraphQL.Types;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Smoothie.Migration;
using Smoothie.Migration.M20200517;
using Smoothie.Web.Query;
using Smoothie.Web.Schema;
using Smoothie.Web.Types;
using SqlKata.Compilers;
using SqlKata.Execution;

namespace Smoothie.Web.Extensions
{
    public static class ServiceCollection
    {
        public static void AddDatabaseEngineServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            var databaseConnectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING") ?? configuration.GetConnectionString("SqlServerDatabaseConnection");

            services.AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    .AddSqlServer()
                    .WithGlobalConnectionString(databaseConnectionString)
                    .ScanIn(typeof(BaseMigration).Assembly).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole());
            
            services.AddSingleton(
                o => new QueryFactory(new SqlConnection(databaseConnectionString), new SqlServerCompiler())
                {
                    Logger = compiled => { Console.WriteLine(compiled.ToString()); }
                });
        }

        public static void AddRepositoryServices(this IServiceCollection services)
        {
            services.AddTransient(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddTransient<ICompanyRepository, CompanyRepository>();
        }

        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddTransient<ICompanyService, CompanyService>();
        }

        /// <summary>
        ///     Use GraphQl Layer Service
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddGraphQlServices(this IServiceCollection services)
        {
            services.AddSingleton<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
            services.AddSingleton<ISchema, RetailSchema>();
            services.AddScoped<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<IDocumentWriter, DocumentWriter>();

            services.AddSingleton<TutorialQuery>();

            services.AddGraphTypeServices();
            services.AddPrimitiveTypeServices();

            services.AddGraphQL(options =>
                {
                    options.EnableMetrics = true;
                    options.ExposeExceptions = false;
                })
                .AddGraphTypes(ServiceLifetime.Scoped)
                .AddDataLoader();
        }

        private static void AddGraphTypeServices(this IServiceCollection services)
        {
            services.AddTransient<CompanyGraphType>();
        }

        private static void AddPrimitiveTypeServices(this IServiceCollection services)
        {
            services.AddTransient<ShortGraphType>();
            services.AddTransient<IntGraphType>();
            services.AddTransient<StringGraphType>();
            services.AddTransient<BooleanGraphType>();
            services.AddTransient<ULongGraphType>();
        }
    }
}