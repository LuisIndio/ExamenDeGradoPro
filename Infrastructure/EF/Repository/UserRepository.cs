using Domain.Model;
using Domain.Repositories;
using Infrastructure.EF.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EF.Repository
{
    internal class UserRepository : IUserRepository
    {
        private readonly WriteDbContext _writeDbContext;
        public UserRepository(WriteDbContext writeDbContext)
        {
            _writeDbContext = writeDbContext;
        }
        public async Task CreateAsync (User user)
        {
            await _writeDbContext.Users.AddAsync(user);
        }

        public async Task DeleteAsync(Guid userId)
        {
            var user = _writeDbContext.Users.Find(userId);
            _writeDbContext.Remove(user);
            await _writeDbContext.SaveChangesAsync();
        }

        public Task<User?> FindByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetAsync(string email)
        {
            return await _writeDbContext.Users.Where(x => x.Email == email).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(User user)
        {
            _writeDbContext.Users.Update(user);
            await _writeDbContext.SaveChangesAsync();
        }
    }
}
