using Smoothie.Common.Model;

namespace Smoothie.Model.Request
{
    public class SearchCompanies : RequestBase
    {
        public int?[] Ids { get; set; }
        public string[] Names { get; set; }
        public bool? IsActive { get; set; }
    }
}