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

        #region CustomerGroup
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
        List<UserDTO> GetUserByCustomerGroupId(int groupId);

        /// <summary>
        /// 获取分组数据(包括分组成员)
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        CustomerGoupDTO GetCustomerGroupById(int groupId);

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

        #endregion


        #region group
        /// <summary>
        /// 修改群组数据
        /// </summary>
        /// <param name="groupId">群组Id</param>
        /// <param name="groupNumber"></param>
        /// <param name="groupName"></param>
        /// <param name="groupNotes"></param>
        /// <param name="groupType"></param>
        /// <param name="userId">登录用户Id用于判断该用户是否有修改权限</param>
        /// <returns></returns>
        bool UpdateGroup(int groupId, string groupNumber, string groupName, string groupNotes, string groupType, int userId);

        /// <summary>
        /// 新建一个群组  检查数据完整性
        /// </summary>
        /// <param name="groupDTO"></param>
        /// <returns></returns>
        bool RegisterGroup(GroupDTO groupDTO);

        /// <summary>
        /// 删除一个空的群组
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="userId">登录用户Id（只有创建者才能删除权限)</param>
        /// <returns></returns>
        bool DeleteGroup(int groupId, int userId);

        /// <summary>
        /// 获取群组数据
        /// </summary>
        /// <param name="userId">登录用户</param>
        /// <param name="IsCacasde">是否取得成员数据</param>
        /// <returns>userId==-1则返回所有群组</returns>
        List<GroupDTO> GetAllGroupByUserId(int userId, bool IsCacasde);

        /// <summary>
        /// 获取群组信息
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns>返回群组基本信息</returns>
        GroupDTO GetGroupById(int groupId);

        /// <summary>
        /// 获取群组成员
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        List<GroupMemberDTO> GetGroupMembersByGroupId(int groupId);

        /// <summary>
        /// 添加用户到群组
        /// </summary>
        /// <param name="memberUserId"></param>
        /// <param name="groupId"></param>
        /// <param name="userId">登录用户，用于验证权限</param>
        /// <returns></returns>
        bool AddUserToGroup(int memberUserId, int groupId, int userId);

        /// <summary>
        /// 移除用户
        /// </summary>
        /// <param name="groupMemberId"></param>
        /// <param name="groupId"></param>
        /// <param name="userId">登录用户用于验证权限</param>
        /// <returns></returns>
        bool RemoveUserFromGroup(int groupMemberId, int groupId, int userId);

        /// <summary>
        /// 修改用户权限
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="groupId"></param>
        /// <param name="groupRole"></param>
        /// <param name="groupMemberId"></param>
        /// <returns></returns>
        bool ShiftGroupMemberRole(int userId, int groupId, string groupRole, int groupMemberId);

        /// <summary>
        /// 修改群名片
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="newName"></param>
        /// <param name="groupMemberId"></param>
        /// <returns></returns>
        bool UpdateGroupMemberName(int userId, string newName, int groupMemberId);

        /// <summary>
        /// 获取群名片
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        GroupMemberDTO GetGroupMemberById(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gmt"></param>
        /// <returns></returns>
        bool AddGroupMessage(GroupMessagerDTO gmt,int userId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        bool MarkPTGMessage(int userId);

        List<GroupMessagerDTO> GetPTGMessage(int userId);

        #endregion
    }
}
