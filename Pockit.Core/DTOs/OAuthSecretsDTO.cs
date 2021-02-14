namespace Pockit.Core.DTOs
{
    public sealed class OAuthSecretsDTO
    {
        public OAuthSecretsDTO(string clientId, string clientSecret)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
        }

        public string ClientId { get; }
        public string ClientSecret { get; }
    }
}