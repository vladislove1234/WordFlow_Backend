using MediatR;
using VeeArc.Application.Common.Interfaces;
using User = VeeArc.Domain.Entities.User;

namespace VeeArc.Application.Feature.User.Create;

public class CreateUserModelCommand : IRequest<Domain.Entities.User>
{
    public required string Username { get; init; }

    public required string FirstName { get; init; }

    public required string LastName { get; init; }

    public required string Email { get; init; }

    public required string Password { get; init; }
}

public class CreateUserCommandHandler : IRequestHandler<CreateUserModelCommand, Domain.Entities.User>
{
    private readonly IUserRepository _userRepository;

    public CreateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<Domain.Entities.User> Handle(CreateUserModelCommand modelCommand, CancellationToken cancellationToken)
    {
        var user = new Domain.Entities.User
        {
            Username = modelCommand.Username,
            FirstName = modelCommand.FirstName,
            LastName = modelCommand.LastName,
            Email = modelCommand.Email,
            Password = modelCommand.Password
        };

        await _userRepository.AddAsync(user);

        throw new NotImplementedException();
    }
}