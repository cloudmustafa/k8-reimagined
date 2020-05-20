using SimpleApi.Domain.Models;
using MediatR;

namespace SimpleApi.Domain.Queries.Users
{
    public class GetUserQuery : IRequest<User>
    {
        public int UserId { get; private set; }

        public GetUserQuery(int userId)
        {
            this.UserId = userId;
        }
    }
}