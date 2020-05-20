using System.Threading;
using System.Threading.Tasks;
using SimpleApi.Domain.Communication;
using SimpleApi.Domain.Models;
using SimpleApi.Domain.Repositories;
using MediatR;

namespace SimpleApi.Domain.Commands.Users
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Response<User>>
    {
        private readonly IUserRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUserCommandHandler(IUserRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<User>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.FindByIdAsync(request.Id);

            if (user == null)
            {
                return new Response<User>("User not found.");
            }

            user.Name = request.Name;
            user.Age = request.Age;

            _repository.Update(user);
            await _unitOfWork.CompleteAsync();

            return new Response<User>(user);
        }
    }
}