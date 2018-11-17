using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiSample.DataAccess.Models;


namespace WebApiSample.DataAccess.Repositories
{
    public class UserRepository
    {
        private readonly UserContext _context;

        public UserRepository(UserContext context)
        {
            _context = context;

            if (_context.Users.Count() == 0)
            {
                _context.Users.AddRange(
                    new User
                    {
                        UserName = "Willem",
                        PassWord = "Test"
                    },
                    new User
                    {
                        UserName = "Test",
                        PassWord = "Test"
                    });
                _context.SaveChanges();
            }


        }
            public async Task<List<User>> GetUsersAsync()
            {
                return await _context.Users.ToListAsync();
            }

        public async Task<User> GetById(int id)
        {
            return await _context.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
       
    }
}
