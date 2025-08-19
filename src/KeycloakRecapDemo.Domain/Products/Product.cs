using System;
using KeycloakRecapDemo.Domain.Abstractions;

namespace KeycloakRecapDemo.Domain.Products
{
    public class Product : Entity
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
