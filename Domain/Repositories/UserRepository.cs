using System.Collections.Generic;
using System.Threading.Tasks;
using SimpleApi.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace SimpleApi.Domain.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }
    }
}