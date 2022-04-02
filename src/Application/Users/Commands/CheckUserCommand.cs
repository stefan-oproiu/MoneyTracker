using Application.Common.Errors;
using Application.Common.Interfaces;
using Application.Common.Mappings;
using Application.Common.Models;
using AutoMapper;
using CSharpFunctionalExtensions;
using Domain.Entities;
using MediatR;

namespace Application.Users.Commands
{
    public class CheckUserCommand :
        IRequest<Result<Unit, BaseError>>,
        IMapFrom<ICurrentUserService>,
        IMapTo<User>
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
    }

    public class CheckUserCommandHandler : IRequestHandler<CheckUserCommand, Result<Unit, BaseError>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public CheckUserCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Result<Unit, BaseError>> Handle(CheckUserCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _dbContext.Users.FindAsync(request.UserId);

            if (existingUser != null)
            {
                return Unit.Value;
            }

            var user = _mapper.Map<User>(request);
            _dbContext.Users.Add(user);

            var maybeCommitError = await _dbContext.CommitChangesAsync(Constants.UserAlreadyRegisteredErrorMessage);

            return maybeCommitError.Match(
                error => Result.Failure<Unit, BaseError>(error),
                () => Result.Success<Unit, BaseError>(Unit.Value));
        }
    }
}
