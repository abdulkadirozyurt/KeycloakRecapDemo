using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeycloakRecapDemo.Application.Services;

public interface IJwtProvider
{
    public Task<string> CreateJwtAsync(string username,string password, CancellationToken cancellationToken);
}
