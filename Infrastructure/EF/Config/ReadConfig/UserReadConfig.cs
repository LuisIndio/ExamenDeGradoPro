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
    internal class UserReadConfig : IEntityTypeConfiguration<UserReadModel>
    {
        public void Configure(EntityTypeBuilder<UserReadModel> builder)
        {
            builder.ToTable("User");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("userId");
            builder.Property(x => x.Name).HasColumnName("name");
            builder.Property(x => x.Email).HasColumnName("email");
            builder.Property(x => x.Password).HasColumnName("password");

        }
    }
}
