using System.ComponentModel.DataAnnotations;

namespace EFLibrary.Models
{
    public class Model_Cart
    {
        public int Inventory_id { get; set; }

        public string Name { get; set; }

        public int Type_id { get; set; }

        public string Type_name { get; set; }

        public int Days { get; set; }

        public decimal Price { get; set; }

        public string Price_cur { get; set; }

        public int Loyaltypoint { get; set; }

    }
}
