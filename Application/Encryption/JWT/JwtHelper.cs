﻿using Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Encryption.JWT
{
    public class JwtHelper : ITokenHelper
    {
        private readonly TokenOptions _tokenOptions;

        public JwtHelper(TokenOptions tokenOptions)
        {
            _tokenOptions = tokenOptions;
        }

        public string CreateToken(User user)
        {
            DateTime expirationDate = DateTime.Now.AddMinutes(_tokenOptions.Expiration); // Konfigürasyondan gelmeli.


            byte[] key = Encoding.UTF8.GetBytes(_tokenOptions.SecurityKey);
            // Simetrik, Asimetrik
            SecurityKey securityKey = new SymmetricSecurityKey(key);

            SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256Signature);

            JwtSecurityToken jwtSecurityToken = new(
                issuer: _tokenOptions.Issuer, 
                audience: _tokenOptions.Audience, 
                notBefore: DateTime.Now, 
                expires: expirationDate,
                signingCredentials: signingCredentials,
                claims: SetClaims(user)
            );

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new();

            return jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);
        }

        private IEnumerable<Claim> SetClaims(User user)
        {
            List<Claim> claims = new();
            claims.Add(new Claim("Deneme", "123"));
            return claims;
        }
    }
}
