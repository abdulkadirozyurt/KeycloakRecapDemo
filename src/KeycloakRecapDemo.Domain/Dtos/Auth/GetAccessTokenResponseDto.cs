using System.Text.Json.Serialization;

namespace KeycloakRecapDemo.Domain.Dtos.Auth;
public sealed class GetAccessTokenResponseDto
{
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; } = default!;
}
