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
    internal class AccountWriteConfig : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Account");
            builder.Property(x => x.Id).HasColumnName("accountId");
            builder.Property(x => x.Name).HasColumnName("name");
            builder.Property(x => x.Balance).HasColumnType("decimal").HasPrecision(20, 2).HasColumnName("balance");
            builder.Property(x => x.UserId).HasColumnName("userId");
            builder.HasOne<User>().WithMany().HasForeignKey(x => x.UserId);

            builder.Ignore(x => x.DomainEvents);
            builder.Ignore("_domainEvents");
        }
    }
}
