using ModelLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IUserBL
    {
        bool RegisterUser(UserRegister request);
        string? LoginUser(UserLogin request);
        bool ForgotPassword(string email);
        bool ResetPassword(string token, string newPassword);
    }
}
