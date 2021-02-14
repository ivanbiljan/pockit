using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Pockit.Core.Helpers
{
    public static class StringHelpers
    {
        public static string BuildUri(string baseUri, IDictionary<string, string> queryParameters)
        {
            if (baseUri is null)
            {
                throw new ArgumentNullException(nameof(baseUri));
            }

            if (queryParameters is null)
            {
                throw new ArgumentNullException(nameof(queryParameters));
            }

            var uriBuilder = new StringBuilder();
            var parameters = new List<string>();

            var first = true;
            var questionMarkIndex = baseUri.IndexOf('?'); // Separates the uri from the parameters
            if (questionMarkIndex <= 0)
            {
                uriBuilder.Append(baseUri);
            }
            else
            {
                uriBuilder.Append(baseUri[..questionMarkIndex]);
                var parametersAsString = baseUri[(questionMarkIndex + 1)..];

                foreach (var parameter in parametersAsString.Split('&'))
                {
                    var split = parameter.Split('=');
                    uriBuilder.Append($"{(first ? '?' : '&')}{split[0]}={HttpUtility.UrlEncode(split[1])}");
                    parameters.Add(split[0]);
                    first = false;
                }
            }

            foreach (var (paramName, paramValue) in queryParameters)
            {
                if (parameters.Contains(paramName))
                {
                    continue;
                }

                uriBuilder.Append($"{(first ? '?' : '&')}{paramName}={HttpUtility.UrlEncode(paramValue)}");
                first = false;
            }

            return uriBuilder.ToString();
        }

        [ExcludeFromCodeCoverage]
        public static string GetRandomString(int length = 26)
        {
            const string characterPool = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789?!*()";

            var randomNumberBuffer = new byte[1];
            var rngProvider = new RNGCryptoServiceProvider();

            var result = new char[length];
            for (var i = 0; i < length; ++i)
            {
                do
                {
                    rngProvider.GetBytes(randomNumberBuffer);
                } while (!(randomNumberBuffer[0] < characterPool.Length * (byte.MaxValue / characterPool.Length)));

                result[i] = characterPool[randomNumberBuffer[0] % characterPool.Length];
            }

            return new string(result);
        }
    }
}