using Hospital.BLL.Repo.IRepo;
using Hospital.DAL.Database;
using Hospital.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BLL.Repo
{
    public class AppuserRepo : IAppuserRepo
    {
        private readonly ApplicationDbContext _context;
        public AppuserRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Appuser?> GetByIdAsync(Guid id)
        {
            string stringId = id.ToString();
            return await _context.Set<Appuser>().FindAsync(stringId);
        }

        public async Task<Appuser> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FindAsync(email);
        }

        public async Task<IEnumerable<Appuser>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<IEnumerable<Appuser>> GetAllByTypeAsync(string userType)
        {
            return await _context.Users.Where(u => u.usertype == userType).ToListAsync();
        }


        public async Task AddAsync(Appuser user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Appuser user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            string stringId = id.ToString();
            var user = await _context.Set<Appuser>().FindAsync(stringId);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
            await _context.Set<Appuser>().FindAsync(stringId);
        }

        public Task AddUserAsync(Appuser newUser)
        {
            throw new NotImplementedException();
        }
        public async Task<Appuser?> GetByStringIdIdAsync(string id)
        {
            return await _context.Users.FindAsync(id);
        }
    }
}

