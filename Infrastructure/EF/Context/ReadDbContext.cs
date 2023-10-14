using Infrastructure.EF.Config.ReadConfig;
using Infrastructure.EF.ReadModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EF.Context
{
    internal class ReadDbContext : DbContext
    {
        public virtual DbSet<UserReadModel> Users { get; set; }
        public virtual DbSet<AccountReadModel> Accounts { get; set; }
        public virtual DbSet<CategoryReadModel> Categories { get; set; }

        public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration<UserReadModel>(new UserReadConfig());
            modelBuilder.ApplyConfiguration<AccountReadModel>(new AccountReadConfig());
            modelBuilder.ApplyConfiguration<CategoryReadModel>(new CategoryReadConfig());
        }
    }
}
