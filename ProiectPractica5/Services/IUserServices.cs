using ProiectPractica5.Models.Authentication;

namespace ProiectPractica5.Services
{
    public interface IUserServices
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
    }
}
