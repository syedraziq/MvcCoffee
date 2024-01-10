using System.ComponentModel.DataAnnotations;

namespace MvcCoffee.Models
{
    public class Coffee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Descriptions { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

    }
    public class Tea
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Descriptions { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

    }

    public class Dessert
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Descriptions { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

    }
}