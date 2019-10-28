using GraphQL.Server;
using GraphQL.Server.Ui.GraphiQL;
using GraphQL.Server.Ui.Playground;
using GraphQL.Server.Ui.Voyager;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace CK.Tutorial.GraphQlApi.Web.Extensions
{
    public static class ApplicationCollection
    {
        public static void UseGraphQlClient(this IApplicationBuilder builder)
        {
            builder.UseWebSockets();

            // use HTTP middleware for RetailSchema at path /graphql
            builder.UseGraphQL<ISchema>();

            // use graphiQL middleware at default url /graphiql
            builder.UseGraphiQLServer(new GraphiQLOptions());

            // use graphql-playground middleware at default url /ui/playground
            builder.UseGraphQLPlayground(new GraphQLPlaygroundOptions());

            // use voyager middleware at default url /ui/voyager
            builder.UseGraphQLVoyager(new GraphQLVoyagerOptions());
        }
    }
}