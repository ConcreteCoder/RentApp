using System.ComponentModel.DataAnnotations;

namespace EFLibrary.Models
{
    public class Model_Inventory
    {
        public int Inventory_id { get; set; }

        public string Name { get; set; }

        public int Type_id { get; set; }

        public string Type_name { get; set; }

    }
}
