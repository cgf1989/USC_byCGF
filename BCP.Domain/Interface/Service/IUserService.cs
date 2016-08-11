using BCP.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.Domain.Service
{
    public interface IUserService
    {
        void InitDataBase();
        bool Login(String userName, String userPwd);
        bool RegisterUser(UserDTO user);
        UserDTO GetUser(int id);
        UserDTO GetUser(String userName);
        List<UserDTO> GetUser();
        bool DeleteUser(int id);
        bool UpdateUserPwd(int id, String userPwd);
    }
}
