using System;
using System.Threading;
using System.Threading.Tasks;
using SimpleApi.Domain.Models;
using SimpleApi.Domain.Repositories;
using MediatR;

namespace SimpleApi.Domain.Queries.Users
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, User>
    {
        private readonly IUserRepository _userRepository;

        public GetUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            if (request.UserId <= 0)
            {
                throw new ArgumentException(nameof(request.UserId));
            }

            return await _userRepository.FindByIdAsync(request.UserId);
        }
    }
}