using System;

namespace Domain.Entities
{
    public class ProductCatalog
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public decimal Price { get; set; }
        public DateTime? LastUpdate { get; set; }
    }
}
