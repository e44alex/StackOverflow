using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using StackOverflowWebApi.Authentication;
using StackOverflowWebApi.Models;

namespace StackOverflowWebApi.Helpers;

public static class AuthenticationHelpers
{
    public async static Task<ClaimsIdentity?> GetIdentity(string username, string password)
    {
        using (AppDbContext _context = new AppDbContext()) // TODO: this should be call for factory
        {
            var user = _context.Users.FirstOrDefault(x => x.Email == username);
            
            if (user == null) return null;
            if (!await VerifyHashedPasswordAsync(user.PasswordHash, password)) return null;

            var claims = new List<Claim>
            {
                new(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new(ClaimsIdentity.DefaultRoleClaimType, "user")
            };

            var claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);

            return claimsIdentity;
        }
    }

    public async static Task<string> HashPasswordAsync(string password)
    {
        byte[] salt;
        byte[] buffer2;
        if (string.IsNullOrEmpty(password)) throw new ArgumentNullException("password is empty");

        using (var bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8))
        {
            salt = bytes.Salt;
            buffer2 = bytes.GetBytes(0x20);
        }

        var dst = new byte[0x31];
        Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
        Buffer.BlockCopy(buffer2, 0, dst, 0x11, 0x20);
        return Convert.ToBase64String(dst);
    }

    public async static Task<bool> VerifyHashedPasswordAsync(string? hashedPassword, string password)
    {
        byte[] buffer4;
        if (string.IsNullOrEmpty(hashedPassword)) return false;

        if (string.IsNullOrEmpty(password)) throw new ArgumentNullException("password is empty");

        var src = Convert.FromBase64String(hashedPassword);
        if (src.Length != 0x31 || src[0] != 0) return false;

        var dst = new byte[0x10];
        Buffer.BlockCopy(src, 1, dst, 0, 0x10);
        var buffer3 = new byte[0x20];
        Buffer.BlockCopy(src, 0x11, buffer3, 0, 0x20);
        using (var bytes = new Rfc2898DeriveBytes(password, dst, 0x3e8))
        {
            buffer4 = bytes.GetBytes(0x20);
        }

        return buffer3.Equal(buffer4);
    }

    public static Task<string?> CreateToken(ClaimsIdentity identity)
    {
        var now = DateTime.UtcNow;
        // создаем JWT-токен
        var jwt = new JwtSecurityToken(
            AuthOptions.ISSUER,
            AuthOptions.AUDIENCE,
            notBefore: now,
            claims: identity.Claims,
            expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(),
                SecurityAlgorithms.HmacSha256));
        var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

        return Task.FromResult(encodedJwt);
    }
}

public static class ByteArrayExtensions
{
    public static bool Equal(this byte[] a1, byte[] a2)
    {
        return a1.Length == a2.Length && !a1.Where((t, i) => t != a2[i]).Any();
    }
}