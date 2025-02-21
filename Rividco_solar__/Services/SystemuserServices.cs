using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Rividco_solar__.Dbcontext;
using Rividco_solar__.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;

namespace Rividco_solar__.Services
{
    public class SystemuserServices : ISystemuserServices
    {
        private readonly AppDbcontext appDbcontext;
        private readonly IConfiguration _config;

        public SystemuserServices(AppDbcontext context, IConfiguration config)
        {
            appDbcontext = context;
            _config = config;
        }

        public async Task<string> RegisterUser(SystemuserDTO systemuserDTO)
        {
            if (systemuserDTO.Password != systemuserDTO.ConfirmPassword)
                return "Passwords do not match";

            if (await appDbcontext.Systemusers.AnyAsync(u => u.email == systemuserDTO.email))
                return "Email already exists";

            var user = new Systemuser
            {
                FirstName = systemuserDTO.FirstName,
                LastName = systemuserDTO.LastName,
                email = systemuserDTO.email,
                contactno=systemuserDTO.contactno,
               passwordhash = HashPassword(systemuserDTO.Password),
                address = systemuserDTO.address
            };

            appDbcontext.Systemusers.Add(user);
            await appDbcontext.SaveChangesAsync();

            return "User registered successfully";
        }

        public async Task<string> LoginUser(LoginDTO systemuserDTO)
        {
            var user = await appDbcontext.Systemusers.FirstOrDefaultAsync(u => u.email == systemuserDTO.email);
            if (user == null || !VerifyPassword(user.passwordhash, systemuserDTO.Password))
                return "Invalid credentials";

            return GenerateJwtToken(user);
        }

        public string GenerateJwtToken(Systemuser systemuser)
        {
            var key = Encoding.UTF8.GetBytes(_config["JwtSettings:Key"]);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,systemuser.email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("id", systemuser.Systemuser_ID.ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _config["JwtSettings:Issuer"],
                audience: _config["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string HashPassword(string password)
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: Encoding.UTF8.GetBytes("your_salt_here"),
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 32));
        }

        public bool VerifyPassword(string hashedPassword, string password)
        {
            return hashedPassword == HashPassword(password);
        }

        public async Task<(IEnumerable<Systemuser> systemuser, int TotalCount)> GetAllAsync(int page=1,int pagesize=10)
        {
            var TotalCount =await appDbcontext.Systemusers.CountAsync();
            var systemuser= await appDbcontext.Systemusers.Skip((page-1)*pagesize).Take(pagesize).ToListAsync();
            return (systemuser,TotalCount);
        }
    }



}
