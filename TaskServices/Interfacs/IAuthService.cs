using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskModels.DTOs.User;

namespace TaskServices.Interfacs
{
    public interface IAuthService
    {
        void Register(UserRegisterDTO user);
        string Login(UserLoginDTO user);
    }
}
