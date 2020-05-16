using System.Collections.Generic;
using Smoothie.Business;
using Smoothie.Model.Request;
using Smoothie.Web.Extensions;
using GraphQL.Types;
using Smoothie.Web.Types;

namespace Smoothie.Web.Query
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
                resolve: delegate (ResolveFieldContext<object> context)
                {
                    var columns = context.GetMainSelectedFields();

                    var companyId = context.GetArgument<int?>("companyId");
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
                arguments: new QueryArguments(new List<QueryArgument>
                {
                    new QueryArgument<ListGraphType<IntGraphType>>
                    {
                        Name = "companyIds"
                    },
                    new QueryArgument<ListGraphType<StringGraphType>>
                    {
                        Name = "companyNames"
                    },
                     new QueryArgument<BooleanGraphType>
                    {
                        Name = "isActive"
                    },
                    new QueryArgument<IntGraphType>
                    {
                        Name = "page"
                    },
                    new QueryArgument<IntGraphType>
                    {
                        Name = "pageSize"
                    }
                }),
                resolve: delegate (ResolveFieldContext<object> context)
                {
                    var columns = context.GetMainSelectedFields();
                    var companyIds = context.GetArgument<int?[]>("companyIds");
                    var companyNames = context.GetArgument<string[]>("companyNames");
                    var isActive = context.GetArgument<bool?>("isActive");

                    var page = context.GetArgument<int?>("page");
                    var pageSize = context.GetArgument<int?>("pageSize");

                    var request = new SearchCompanies()
                    {
                        Ids = companyIds,
                        Names = companyNames,
                        IsActive = isActive,
                        Page = page,
                        PageSize = pageSize,
                        Columns = columns
                    };
                    return companyService.GetCompanies(request);
                });

            #endregion
        }
    }
}