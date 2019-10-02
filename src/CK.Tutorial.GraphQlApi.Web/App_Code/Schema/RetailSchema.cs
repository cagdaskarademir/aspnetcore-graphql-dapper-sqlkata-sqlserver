using CK.Tutorial.GraphQlApi.Web.Query;
using GraphQL;

namespace CK.Tutorial.GraphQlApi.Web.Schema
{
    public class RetailSchema : GraphQL.Types.Schema
    {
        public RetailSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<TutorialQuery>();
        }
    }
}