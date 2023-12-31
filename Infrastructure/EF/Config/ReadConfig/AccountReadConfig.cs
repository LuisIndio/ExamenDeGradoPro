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
            builder.Property(x => x.Balance).HasColumnType("decimal").HasPrecision(20,2).HasColumnName("balance");
            builder.Property(x => x.UserId).HasColumnName("userId");


        }
    }
}
