using System;

namespace ProiectPractica5.Models.Authentication
{
    public class AuthenticateResponse
    {
        public Guid IdMember { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Token { get; set; }




        public AuthenticateResponse(Members user, string token)
        {
            IdMember = user.IdMembers;
            Name = user.Name;
            Title = user.Title;
            Token = token;
        }
    }
}
