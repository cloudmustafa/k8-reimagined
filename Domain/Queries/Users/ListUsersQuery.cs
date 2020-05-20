using System.Collections.Generic;
using SimpleApi.Domain.Models;
using MediatR;

namespace SimpleApi.Domain.Queries.Users
{
    public class ListUsersQuery : IRequest<IEnumerable<User>>
    {
    }
}