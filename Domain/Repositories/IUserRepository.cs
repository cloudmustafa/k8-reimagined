using System.Collections.Generic;
using System.Threading.Tasks;
using SimpleApi.Domain.Models;

namespace SimpleApi.Domain.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
    }
}