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
        bool Logout(int userId);

        bool RegisterUser(UserDTO user);
        UserDTO GetUser(int id);
        UserDTO GetUser(String userName);
        List<UserDTO> GetUser();
        bool DeleteUser(int id);
        bool UpdateUserPwd(int id, String userPwd);

        /// <summary>
        /// 获取用户点对点聊天记录
        /// </summary>
        /// <param name="user">用户名</param>
        /// <param name="another">对方用户名</param>
        /// <returns></returns>
        List<UserMessageDTO> GetPTPMessage(int userId, int anotherId);

        /// <summary>
        /// 添加点对点聊天记录
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        bool AddPTPMessage(UserMessageDTO message);
    }
}
