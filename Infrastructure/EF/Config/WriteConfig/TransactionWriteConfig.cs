using Domain.Model.Transaction;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EF.Config.WriteConfig
{
    internal class TransactionWriteConfig : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
           builder.ToTable("Transaction");
           builder.Property(x => x.Id).HasColumnName("transactionId");
           builder.Property(x => x.Description).HasColumnName("description");
           builder.Property(x => x.Amount).HasColumnName("amount");
           builder.Property(x => x.Date).HasColumnName("date");
           builder.Property(x => x.Type).HasColumnName("type");
           builder.Property(x => x.CategoryId).HasColumnName("categoryId");
           builder.Property(x => x.AccountId).HasColumnName("accountId");
           builder.Property(x => x.UserId).HasColumnName("userId");

           builder.Ignore(x => x.DomainEvents);
           builder.Ignore("_domainEvents");
        }
    }
}
