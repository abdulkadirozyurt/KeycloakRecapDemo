using System;
using Microsoft.Extensions.Configuration;

namespace KeycloakRecapDemo.Infrastructure.Options;

public sealed class KeycloakConfiguration
{
    // Maps to Keycloak:auth-server-url (hyphenated key)
    [ConfigurationKeyName("auth-server-url")]
    public string AuthServerUrl { get; set; } = default!;

    public string Realm { get; set; } = default!;

    // Maps to Keycloak:resource
    [ConfigurationKeyName("resource")]
    public string ClientId { get; set; } = default!;

    // Nested object: Keycloak:credentials:secret
    public CredentialConfiguration Credentials { get; set; } = new();

    public sealed class CredentialConfiguration
    {
        public string Secret { get; set; } = default!;
    }

    // Convenience helpers
    public string TokenEndpoint => $"{NormalizeBase(AuthServerUrl)}realms/{Realm}/protocol/openid-connect/token";
    public string UserInfoEndpoint => $"{NormalizeBase(AuthServerUrl)}realms/{Realm}/protocol/openid-connect/userinfo";

    private static string NormalizeBase(string url)
    {
        if (string.IsNullOrWhiteSpace(url)) return string.Empty;
        return url.EndsWith('/') ? url : url + "/";
    }
}
