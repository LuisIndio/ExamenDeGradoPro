using Infrastructure.EF.ReadModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EF.Config.ReadConfig
{
    internal class TransferReadConfig : IEntityTypeConfiguration<TransferReadModel>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<TransferReadModel> builder)
        {
            builder.ToTable("Transfer");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("transferId");
            builder.Property(x => x.Amount).HasColumnType("decimal").HasPrecision(20, 2).HasColumnName("amount");
            builder.Property(x => x.AccountId).HasColumnName("accountId");
            builder.Property(x => x.AccountId2).HasColumnName("accountId2");
            builder.Property(x => x.Date).HasColumnName("date");
            builder.Property(x => x.UserId).HasColumnName("userId");
            builder.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
