using TS.MediatR;
using TS.Result;

namespace KeycloakRecapDemo.Application.Auth;

public sealed record LoginCommand(string Username, string Password):IRequest<Result<LoginCommandResponse>>;

public sealed record LoginCommandResponse
{
    public string AccessToken { get; set; } = default!;
}

internal sealed class LoginCommandHandler : IRequestHandler<LoginCommand, Result<LoginCommandResponse>>
{
    string loginEndpoint = $"";
    public Task<Result<LoginCommandResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}