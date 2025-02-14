﻿using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;

namespace Domain.Security
{
    public class SigningConfigurations
    {
        public SecurityKey Key { get; set; }
        public SigningCredentials signingCredentials { get; set; }
        public SigningConfigurations()
        {
            using (var provider = new RSACryptoServiceProvider(2048))
            {
                Key = new RsaSecurityKey(provider.ExportParameters(true));
            }

            signingCredentials = new SigningCredentials(Key, SecurityAlgorithms.RsaSha256Signature);

        }
    }
}
