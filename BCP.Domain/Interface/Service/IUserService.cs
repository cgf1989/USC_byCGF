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
    }
}
