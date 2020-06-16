namespace AppicoTest.Models.Context
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AppicoContext : DbContext
    {
        public AppicoContext()
            : base("name=AppicoContext")
        {
        }

        public virtual DbSet<contact> contact { get; set; }
        public virtual DbSet<dealer> dealer { get; set; }
        public virtual DbSet<inventory> inventory { get; set; }
        public virtual DbSet<models> models { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<dealer>()
                .HasMany(e => e.inventory)
                .WithRequired(e => e.dealer1)
                .HasForeignKey(e => e.dealer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<models>()
                .HasMany(e => e.inventory)
                .WithRequired(e => e.models)
                .HasForeignKey(e => e.model)
                .WillCascadeOnDelete(false);
        }
    }
}
