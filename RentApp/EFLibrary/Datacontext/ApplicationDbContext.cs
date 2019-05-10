namespace EFLibrary.Datacontext
{
    using EFLibrary.Models;
    using System.Data.Entity;

    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<Bondora_Cart> Bondora_Cart { get; set; }
        public virtual DbSet<Bondora_Customer> Bondora_Customer { get; set; }
        public virtual DbSet<Bondora_Inventory> Bondora_Inventory { get; set; }
        public virtual DbSet<Bondora_Inventory_Types> Bondora_Inventory_Types { get; set; }
        public virtual DbSet<Bondora_Order> Bondora_Order { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
