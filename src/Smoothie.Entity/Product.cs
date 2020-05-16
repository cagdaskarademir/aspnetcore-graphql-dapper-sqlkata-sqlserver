using Smoothie.Common.Enum;

namespace Smoothie.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ProductTypeId { get; set; }
        public Status Status { get; set; }
    }
}