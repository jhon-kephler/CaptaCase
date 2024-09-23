using CaptaCase.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CaptaCase.Data.Map
{
    public class CustomerMap
    {
        public CustomerMap(EntityTypeBuilder<Customer> builder)
        {
            builder
                .HasKey(x => x.CPF)
                .HasName("CPF");

            builder
                .Property(b => b.CPF)
                .HasColumnType("varchar(11)")
                .HasColumnName("CPF")
                .IsRequired();

            builder
                .Property(b => b.Name)
                .HasColumnType("varchar(100)")
                .HasColumnName("Name")
                .IsRequired();

            builder
                .Property(b => b.Gender)
                .HasColumnType("varchar(15)")
                .HasColumnName("Gender")
                .IsRequired();

            builder
                .Property(b => b.CustomerSituationId)
                .HasColumnType("integer")
                .HasColumnName("CustomerSituationId")
                .IsRequired();

            builder
                .Property(b => b.CustomerTypeId)
                .HasColumnType("integer")
                .HasColumnName("CustomerTypeId")
                .IsRequired();

            builder
                .HasOne(b => b.CustomerType)
                .WithOne(v => v.Customer)
                .HasForeignKey<Customer>(b => b.CustomerTypeId)
                .HasPrincipalKey<CustomerType>(v => v.Id);

            builder
                .HasOne(b => b.CustomerSituation)
                .WithOne(v => v.Customer)
                .HasForeignKey<Customer>(b => b.CustomerSituationId)
                .HasPrincipalKey<CustomerSituation>(v => v.Id);
        }
    }
}
