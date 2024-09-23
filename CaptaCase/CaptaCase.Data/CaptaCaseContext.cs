using CaptaCase.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CaptaCase.Data
{
    public class CaptaCaseContext : DbContext
    {
        public CaptaCaseContext(DbContextOptions<CaptaCaseContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var assembly = typeof(CaptaCaseContext).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);

            modelBuilder.Entity<Customer>(entity =>
            {

                entity.ToTable("Customer");
                entity.HasKey(e => e.CPF);
                entity.Property(e => e.CPF).HasColumnName("CPF");
                entity.Property(e => e.Name).HasColumnName("Name");
                entity.Property(e => e.CustomerTypeId).HasColumnName("CustomerTypeId");
                entity.Property(e => e.Gender).HasColumnName("Gender");
                entity.Property(e => e.CustomerSituationId).HasColumnName("CustomerSituationId");
            });

            modelBuilder.Entity<CustomerType>(entity =>
            {
                entity.ToTable("CustomerType");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.Type).HasColumnName("Type");
            });

            modelBuilder.Entity<CustomerSituation>(entity =>
            {
                entity.ToTable("CustomerSituation");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.Situation).HasColumnName("Situation");
            });

            modelBuilder.Entity<CustomerType>()
                        .HasOne(d => d.Customer)
                        .WithOne(o => o.CustomerType)
                        .HasForeignKey<Customer>(o => o.CustomerTypeId);

            modelBuilder.Entity<CustomerSituation>()
                        .HasOne(d => d.Customer)
                        .WithOne(o => o.CustomerSituation)
                        .HasForeignKey<Customer>(o => o.CustomerSituationId);
        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<CustomerType> CustomerType { get; set; }
        public DbSet<CustomerSituation> CustomerSituation { get; set; }
    }
}