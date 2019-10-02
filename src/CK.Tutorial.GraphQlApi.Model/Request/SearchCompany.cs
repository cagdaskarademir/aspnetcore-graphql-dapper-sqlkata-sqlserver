using CK.Tutorial.GraphQlApi.Common.Enum;
using CK.Tutorial.GraphQlApi.Common.Model;

namespace CK.Tutorial.GraphQlApi.Model.Request
{
    public class SearchCompany : RequestBase
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }
    }
}