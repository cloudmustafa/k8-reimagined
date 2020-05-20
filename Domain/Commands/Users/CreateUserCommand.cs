using SimpleApi.Domain.Models;
using MediatR;

namespace SimpleApi.Domain.Commands.Users
{
    public class CreateUserCommand : IRequest<User>
    {
        public string Name { get; private set; }
        public byte Age { get; private set; }

        public CreateUserCommand(string name, byte age)
        {
            this.Age = age;
            this.Name = name;
        }
    }
}