namespace Pockit.Core.DTOs
{
    public sealed class AccessTokenDTO
    {
        public AccessTokenDTO(string accessToken, string state)
        {
            AccessToken = accessToken;
            State = state;
        }

        public string AccessToken { get; }
        public string State { get; }
    }
}