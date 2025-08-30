
using KeycloakRecapDemo.Infrastructure.Options;
using Microsoft.Extensions.Options;

namespace KeycloakRecapDemo.Infrastructure.Services;

public sealed class KeycloakService(IOptions<KeycloakConfiguration> options)
{

}
