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

        /// <summary>
        /// 标记已读信息
        /// </summary>
        /// <param name="sendId"></param>
        /// <param name="replyId"></param>
        void MarkPTPMessage(int sendId, int replyId);

        /// <summary>
        /// 新增分组
        /// </summary>
        /// <param name="customerGoupDTO"></param>
        /// <returns></returns>
        bool AddCustomerGroup(CustomerGoupDTO customerGoupDTO);

        /// <summary>
        /// 修改分组名称
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="groupName"></param>
        /// <returns></returns>
        bool UpdateCustomerGroupName(int groupId, string groupName);

        /// <summary>
        /// 删除分组（非级联删除）
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        bool DeleteCustomerGroup(int groupId);

        /// <summary>
        /// 获取所有分组数据
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="IsCascade"></param>
        /// <returns></returns>
        List<CustomerGoupDTO> GetCustomerGroup(int userId, bool IsCascade);

        /// <summary>获取分组成员
        /// 
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        List<UserDTO> GetUserByGroupId(int groupId);

        /// <summary>
        /// 添加用户到分组
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="groupId"></param>
        /// <returns></returns>
        bool AddUserToCustomerGroup(int userId, int groupId);

        /// <summary>
        /// 从分组移除用户
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="groupId"></param>
        /// <returns></returns>
        bool RemoveUserFromCustomerGroup(int userId, int groupId);
    }
}
