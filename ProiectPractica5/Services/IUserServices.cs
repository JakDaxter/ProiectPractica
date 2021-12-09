using ProiectPractica5.Models.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectPractica5.Services
{
    public interface IUserServices
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
    }
}
