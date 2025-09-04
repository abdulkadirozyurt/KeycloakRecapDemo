using KeycloakRecapDemo.Application.Services;
using Microsoft.Extensions.Options;
using TS.MediatR;
using TS.Result;

namespace KeycloakRecapDemo.Application.Auth;

public sealed record LoginCommand(string Username, string Password) : IRequest<Result<LoginCommandResponse>>;

public sealed record LoginCommandResponse
{
    public string AccessToken { get; set; } = default!;
}

internal sealed class LoginCommandHandler(IJwtProvider jwtProvider) : IRequestHandler<LoginCommand, Result<LoginCommandResponse>>
{
    public async Task<Result<LoginCommandResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var response = await jwtProvider.CreateJwtAsync(request.Username, request.Password, cancellationToken);

        return Result<LoginCommandResponse>.Succeed(new LoginCommandResponse
        {
            AccessToken = response
        });
    }
}