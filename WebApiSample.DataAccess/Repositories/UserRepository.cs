using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HourRegistration.DataAccess.Models;


namespace HourRegistration.DataAccess.Repositories
{
    public class UserRepository
    {
        private readonly UserContext _context;

        public UserRepository(UserContext context)
        {
            _context = context;



        }
        public async Task<List<User>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> CreateAsync(string name, string password)
        {
            var user = await _context.AddAsync(new User { UserName = name, PassWord = password });
            await _context.SaveChangesAsync();
            return user.Entity;
        }

        public async Task<User> GetById(int id)
        {
            return await _context.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

    }
}
