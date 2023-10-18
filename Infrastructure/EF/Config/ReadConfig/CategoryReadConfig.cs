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
    internal class CategoryReadConfig : IEntityTypeConfiguration<CategoryReadModel>
    {
        public void Configure(EntityTypeBuilder<CategoryReadModel> builder)
        {
            builder.ToTable("Category");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("categoryId");
            builder.Property(x => x.Name).HasColumnName("name");
            builder.Property(x => x.Description).HasColumnName("description");
            builder.Property(x => x.UserId).HasColumnName("userId");
            builder.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId);
        }
    }
}
