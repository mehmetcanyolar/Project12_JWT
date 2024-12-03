using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Project12_JWT.JWT
{
    public class TokenGenerator
    {
        public string GenerateJwtToken(string username,string name,string surname ,string email)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("20FarklıMethodla20ProjeToken+-*/1234tokenJWT"));
            var credentials =new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claimsExmp = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,username),
                new Claim(JwtRegisteredClaimNames.Name,name),
                new Claim(JwtRegisteredClaimNames.FamilyName,surname),
                new Claim(JwtRegisteredClaimNames.Email,email),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: "localhost",
                audience: "localhost",
                claims: claimsExmp,
                expires:DateTime.Now.AddMinutes(5),
                signingCredentials:credentials);



            return new JwtSecurityTokenHandler().WriteToken(token);

        }

        public string GenerateJwtToken2(string username)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("20FarklıMethodla20ProjeToken+-*/1234tokenJWT"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claimsExmp = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,username),
                
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: "localhost",
                audience: "localhost",
                claims: claimsExmp,
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: credentials);



            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
