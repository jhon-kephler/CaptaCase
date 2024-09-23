using CaptaCase.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaptaCase.Data.Map
{
    public class CustomerTypeMap
    {
        public CustomerTypeMap(EntityTypeBuilder<CustomerType> builder)
        {
            builder
                .HasKey(x => x.Id)
                .HasName("id");

            builder
                .Property(b => b.Id)
                .HasColumnType("INT")
                .HasColumnName("Id")
                .IsRequired();

            builder
                .Property(b => b.Type)
                .HasColumnType("varchar(100)")
                .HasColumnName("Type")
                .IsRequired();

            builder
                .HasOne(b => b.Customer)
                .WithOne(a => a.CustomerType)
                .HasForeignKey<Customer>(b => b.CustomerTypeId);
        }
    }
}
