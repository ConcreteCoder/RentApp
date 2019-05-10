using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFLibrary.Models
{
    public class Model_AddToCart
    {
        public int Inventory_id { get; set; }

        public int Numdays { get; set; }

        public string Token { get; set; }

    }
}
