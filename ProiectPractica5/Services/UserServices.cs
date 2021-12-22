using Microsoft.IdentityModel.Tokens;
using ProiectPractica5.App_Data;
using ProiectPractica5.Models;
using ProiectPractica5.Models.Authentication;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ProiectPractica5.Services
{
    public class UserServices : IUserServices
    {
        private readonly ClubMembershipDbContext _context;
        public UserServices(ClubMembershipDbContext context)
        {
            _context = context;
        }
        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _context.Members.SingleOrDefault(x => x.IdMembers == model.Username && x.Name == model.Password);
            if (user == null) return null;
            var token = GenerateJWTToken(user);
            return new AuthenticateResponse(user, token);
        }

        private string GenerateJWTToken(Members user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("AUTHSECRET_AUTHSECRET"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);



            var token = new JwtSecurityToken("https://localhost:44306",
            "https://localhost:44306",
            null,
            expires: DateTime.Now.AddDays(3),
            signingCredentials: credentials);



            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
