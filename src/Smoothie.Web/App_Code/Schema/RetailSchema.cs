using GraphQL;
using Smoothie.Web.Query;

namespace Smoothie.Web.Schema
{
    public class RetailSchema : GraphQL.Types.Schema
    {
        public RetailSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<TutorialQuery>();
        }
    }
}