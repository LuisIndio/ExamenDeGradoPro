﻿using Infrastructure.EF.ReadModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EF.Config.ReadConfig
{
    internal class AccountReadConfig : IEntityTypeConfiguration<AccountReadModel>
    {
        public void Configure(EntityTypeBuilder<AccountReadModel> builder)
        {
            builder.ToTable("Account");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("accountId");
            builder.Property(x => x.Name).HasColumnName("name");
            builder.Property(x => x.Balance).HasColumnName("balance");
            builder.Property(x => x.UserId).HasColumnName("userId");
            builder.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId);

        }
    }
}
