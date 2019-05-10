namespace EFLibrary.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Bondora_Order
    {
        [Key]
        public int Order_id { get; set; }

        [StringLength(300)]
        public string Token { get; set; }

        public DateTime? Date_order { get; set; }

        public int? Customer_id { get; set; }
    }
}
