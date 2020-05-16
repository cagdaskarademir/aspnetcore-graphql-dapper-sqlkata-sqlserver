using System;
using Smoothie.Business;
using Smoothie.Entity;
using GraphQL.Types;

namespace Smoothie.Web.Types
{
    public class CompanyGraphType : ObjectGraphType<Company>
    {
        public CompanyGraphType()
        {
            Name = "Company";
            Field(x => x.Id).Description("Şirket Benzersiz No");
            Field(x => x.Name, true).Description("Şirket Adı");
            Field(x => x.IsActive, true).Description("Şirket Aktif mi?");
        }
    }
}