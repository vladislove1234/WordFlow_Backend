using MediatR;
using VeeArc.Application.Common.Interfaces;

namespace VeeArc.Application.Feature.User.Update;

public record UpdateUserModelCommand : IRequest<Domain.Entities.User>
{
    public required int Id { get; init; }
    public required string FirstName { get; init; }

    public required string LastName { get; init; }

    public required string Email { get; init; }

    public required string Password { get; init; }
}

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserModelCommand, Domain.Entities.User>
{
    private readonly IUserRepository _userRepository;

    public UpdateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<Domain.Entities.User> Handle(UpdateUserModelCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id);
        throw new NotImplementedException();
    }
}