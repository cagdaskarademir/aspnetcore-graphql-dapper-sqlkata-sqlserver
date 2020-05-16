using Smoothie.Common.Enum;
using Smoothie.Common.Model;

namespace Smoothie.Model.Request
{
    public class SearchCompany : RequestBase
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }
    }
}