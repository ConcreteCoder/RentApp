namespace EFLibrary.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Bondora_Inventory
    {
        [Key]
        public int Inventory_id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int? Type_id { get; set; }
    }
}
