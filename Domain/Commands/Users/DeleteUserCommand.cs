using SimpleApi.Domain.Communication;
using SimpleApi.Domain.Models;
using MediatR;

namespace SimpleApi.Domain.Commands.Users
{
    public class DeleteUserCommand : IRequest<Response<User>>
    {
        public int Id { get; private set; }

        public DeleteUserCommand(int id)
        {
            this.Id = id;
        }
    }
}