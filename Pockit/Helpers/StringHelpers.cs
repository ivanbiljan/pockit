using System.Security.Cryptography;

namespace Pockit.Helpers {
    public static class StringHelpers 
    {
        public static string GetRandomString(int length = 26)
        {
            string CharacterPool = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789?!*()";

            var randomNumberBuffer = new byte[1];
            var rngProvider = new RNGCryptoServiceProvider();

            var result = new char[length];
            for (var i = 0; i < length; ++i)
            {
                do
                {
                    rngProvider.GetBytes(randomNumberBuffer);
                } while (!(randomNumberBuffer[0] < CharacterPool.Length * (byte.MaxValue / CharacterPool.Length)));

                result[i] = CharacterPool[randomNumberBuffer[0] % CharacterPool.Length];
            }

            return new string(result);
        }
    }
}