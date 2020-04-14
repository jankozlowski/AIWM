using AIWM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIWM.Web.Connection
{
    public interface IUserApi
    {
        Task<bool> Login(User user);
        Task<User> FindUserByName(string login);
    }
}
