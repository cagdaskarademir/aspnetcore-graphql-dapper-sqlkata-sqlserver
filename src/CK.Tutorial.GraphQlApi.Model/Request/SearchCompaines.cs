using CK.Tutorial.GraphQlApi.Common.Enum;
using CK.Tutorial.GraphQlApi.Common.Model;

namespace CK.Tutorial.GraphQlApi.Model.Request
{
    public class SearchCompanies : RequestBase
    {
        public int?[] Ids { get; set; }
        public string[] Names { get; set; }
        public bool? IsActive { get; set; }
    }
}