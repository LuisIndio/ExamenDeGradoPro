using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EF.Config.WriteConfig
{
    internal class TransferWriteConfig : IEntityTypeConfiguration<Transfer>
    {
        public void Configure(EntityTypeBuilder<Transfer> builder)
        {
            builder.ToTable("Transfer");
            builder.Property(x => x.Id).HasColumnName("transferId");
            builder.Property(x => x.Amount).HasColumnType("decimal").HasPrecision(20, 2).HasColumnName("amount");
            builder.Property(x => x.AccountId).HasColumnName("accountId");
            builder.HasOne<Account>().WithMany().HasForeignKey(x => x.AccountId);
            builder.Property(x => x.AccountId2).HasColumnName("accountId2");
            builder.HasOne<Account>().WithMany().HasForeignKey(x => x.AccountId2);
            builder.Property(x => x.Date).HasColumnName("date");
            builder.Property(x => x.UserId).HasColumnName("userId");

            builder.Ignore(x => x.DomainEvents);
            builder.Ignore("_domainEvents");

        }
    }
}
