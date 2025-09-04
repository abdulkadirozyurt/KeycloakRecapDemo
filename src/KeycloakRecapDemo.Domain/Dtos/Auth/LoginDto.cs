using System;

namespace KeycloakRecapDemo.Domain.Dtos.Auth;

public sealed record LoginDto(string UserName, string Password);
