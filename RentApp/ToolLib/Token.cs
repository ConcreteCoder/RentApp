using System;
using System.Collections.Generic;
using System.Security.Claims;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;

namespace ToolLib
{
    public interface IToken
    {
        string CreateToken();
    }

    public class Token : IToken
    {
        public string CreateToken()
        {
            string key = DateTime.Now.ToString();

            var claims = new Dictionary<string, string>()
        {
            {ClaimTypes.Name, "Varun Singh" },
            {ClaimTypes.WindowsAccountName, "VSingh"}
        };

            var algorithm = new HMACSHA256Algorithm();
            var serializer = new JsonNetSerializer();
            var urlEncoder = new JwtBase64UrlEncoder();
            var encoder = new JwtEncoder(algorithm, serializer, urlEncoder);
            var token = encoder.Encode(claims, key);
            return token;
        }

    }
}
