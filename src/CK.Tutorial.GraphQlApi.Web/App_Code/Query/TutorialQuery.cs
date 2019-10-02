using System.Collections.Generic;
using CK.Tutorial.GraphQlApi.Business;
using CK.Tutorial.GraphQlApi.Model.Request;
using CK.Tutorial.GraphQlApi.Web.Extensions;
using CK.Tutorial.GraphQlApi.Web.Types;
using GraphQL.Types;

namespace CK.Tutorial.GraphQlApi.Web.Query
{
    public class TutorialQuery : ObjectGraphType
    {
        public TutorialQuery(ICompanyService companyService)
        {
            #region Company

            Field<CompanyGraphType>(
                name: "company",
                arguments: new QueryArguments(new List<QueryArgument>
                {
                    new QueryArgument<IntGraphType>
                    {
                        Name = "companyId"
                    },
                    new QueryArgument<StringGraphType>
                    {
                        Name = "companyName"
                    },
                    new QueryArgument<BooleanGraphType>
                    {
                        Name = "isActive"
                    }
                }),
                resolve: delegate(ResolveFieldContext<object> context)
                {
                    var columns = context.GetMainSelectedFields();

                    var companyId = context.GetArgument<short?>("companyId");
                    var companyName = context.GetArgument<string>("companyName");
                    var isActive = context.GetArgument<bool?>("isActive");

                    var request = new SearchCompany
                    {
                        Id = companyId,
                        Name = companyName,
                        IsActive = isActive,
                        Columns = columns
                    };
                    return companyService.GetCompany(request);
                });

            Field<ListGraphType<CompanyGraphType>>(
                "companies",
                resolve: delegate(ResolveFieldContext<object> context)
                {
                    var columns = context.GetMainSelectedFields();

                    var request = new SearchCompany()
                    {
                        Columns = columns
                    };
                    return companyService.GetCompanies(request);
                });

            #endregion
        }
    }
}