using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MyDbContext _dbContext;

        public UserRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> CreateAsync(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user), "O usuário informado é inválido!");

            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            if (user == null)
                return false;

            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            if (user == null)
                return null;
            return user;
        }

        public async Task<IEnumerable<User>> GetByNameAsync(string name)
        {
            return await _dbContext.Users
                .Where(x => x.Name.Contains(name))
                .ToListAsync();
        }

        public async Task<User?> UpdateAsync(User user)
        {
            var existingUser = await _dbContext.Users.FindAsync(user.Id);
            if (existingUser == null)
                return null;

            // Atualize os valores específicos conforme necessário
            existingUser.Name = user.Name;
            existingUser.Age = user.Age;

            await _dbContext.SaveChangesAsync();
            return existingUser;
        }
    }
}
