using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PocketBook.Api.Core.IRepositories;
using PocketBook.Api.Data;
using PocketBook.Api.Models;

namespace PocketBook.Api.Core.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context, ILogger logger) : base(context, logger)
        {
        }

        public override async Task<IEnumerable<User>> GetAll()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} GetAll method has generated error", typeof(UserRepository));
                return new List<User>();
            }
        }

        public override async Task<bool> Upsert(User entity)
        {
            try
            {
                var existingUser = await dbSet.Where(x => x.Id == entity.Id).FirstOrDefaultAsync();

                if (existingUser is null) return await Add(entity);

                existingUser.FirstName = entity.FirstName;
                existingUser.LastName = entity.LastName;
                existingUser.Email = entity.Email;
                return true;
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "{Repo} Upsert method has generated error", typeof(UserRepository));
                return false;
            }
        }

        public override async Task<bool> Delete(Guid id)
        {
            try
            {
                var existingUser = await dbSet.Where(x => x.Id == id).FirstOrDefaultAsync();

                if (existingUser is not null)
                {
                    dbSet.Remove(existingUser);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "{Repo} Delete method has generated error", typeof(UserRepository));
                return false;
            }
        }
    }
}