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
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("AUTHSECRET");
            var tokenDesc = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new[] { new Claim("IdMembers", user.IdMembers.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDesc);
            return tokenHandler.WriteToken(token);
        }
    }
}
