namespace EFLibrary.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Bondora_Cart
    {
        public int Id { get; set; }

        public int? Inventory_id { get; set; }

        public int? Days { get; set; }

        public int? Status { get; set; }

        [StringLength(300)]
        public string Token { get; set; }
    }
}
