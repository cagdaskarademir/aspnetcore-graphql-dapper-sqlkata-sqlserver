using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq.Expressions;
using CK.Tutorial.GraphQlApi.Business;
using CK.Tutorial.GraphQlApi.Repository;
using CK.Tutorial.GraphQlApi.Web.Query;
using CK.Tutorial.GraphQlApi.Web.Schema;
using CK.Tutorial.GraphQlApi.Web.Types;
using GraphQL;
using GraphQL.Http;
using GraphQL.Server;
using GraphQL.Types;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SqlKata.Compilers;
using SqlKata.Execution;

namespace CK.Tutorial.GraphQlApi.Web.Extensions
{
    public static class ServiceCollection
    {
        public static void AddDatabaseEngineServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            var databaseConnectionString = configuration.GetConnectionString("SqlServerDatabaseConnection");
            
            services.AddSingleton<QueryFactory>(
                o => new QueryFactory(new SqlConnection(databaseConnectionString), new SqlServerCompiler())
                {
                    Logger = compiled => { Console.WriteLine(compiled.ToString()); }
                });
        }
        
        public static void AddRepositoryServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddTransient(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddTransient<ICompanyRepository, CompanyRepository>();
        }
        
        public static void AddBusinessServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddTransient<ICompanyService, CompanyService>();
        }

        /// <summary>
        ///     Use GraphQl Layer Service
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddGraphQlServices(this IServiceCollection services,
            IConfiguration configuration)
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