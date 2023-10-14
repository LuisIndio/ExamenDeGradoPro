using Domain.Model;
using Infrastructure.EF.Config.WriteConfig;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EF.Context
{
    internal class WriteDbContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration<User>(new UserWriteConfig());
            modelBuilder.ApplyConfiguration<Account>(new AccountWriteConfig());
            modelBuilder.ApplyConfiguration<Category>(new CategoryWriteConfig());
        }
    }
}
