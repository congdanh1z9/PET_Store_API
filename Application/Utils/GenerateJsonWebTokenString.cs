﻿using Application.Commons;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Utils
{
    public static class GenerateJsonWebTokenString
    {

        //public static string GenerateJsonWebToken(this User user, AppConfiguration appSettingConfiguration, string secretKey, DateTime now)
        //{
        //    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        //    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        //    var claims = new[]
        //    {
        //        new Claim("Id", user.Id.ToString()),
        //        new Claim("Email" ,user.email),
        //        new Claim(ClaimTypes.Role ,user.Role.RoleName),
        //    };
        //    var token = new JwtSecurityToken(
        //        issuer: appSettingConfiguration.JWTSection.Issuer,
        //        audience: appSettingConfiguration.JWTSection.Audience,
        //        claims: claims,
        //        expires: now.AddMinutes(15),
        //        signingCredentials: credentials);


        //    return new JwtSecurityTokenHandler().WriteToken(token);
        //}
    }
}
