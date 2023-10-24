using Infrastructure.EF.ReadModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EF.Config.ReadConfig
{
    internal class TransactionReadConfig : IEntityTypeConfiguration<TransactionReadModel>
    {
         public void Configure(EntityTypeBuilder<TransactionReadModel> builder)
        {
            builder.ToTable("Transaction");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("transactionId");
            builder.Property(x => x.Description).HasColumnName("description");
            builder.Property(x => x.Amount).HasColumnType("decimal").HasPrecision(20, 2).HasColumnName("amount");
            builder.Property(x => x.Date).HasColumnName("date");
            builder.Property(x => x.Type).HasColumnName("type");

            builder.Property(x => x.CategoryId).HasColumnName("categoryId");
            builder.HasOne(x => x.Category).WithMany().HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.NoAction);
            builder.Property(x => x.AccountId).HasColumnName("accountId");
            builder.HasOne(x => x.Account).WithMany().HasForeignKey(x => x.AccountId);
            builder.Property(x => x.UserId).HasColumnName("userId");
            builder.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
