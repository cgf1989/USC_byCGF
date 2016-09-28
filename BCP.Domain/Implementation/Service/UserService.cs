using BCP.Common;
using BCP.Domain.Edmx;
using BCP.Domain.Service;
using BCP.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.Domain
{
    public class UserService : IUserService
    {
        IUserRepository _userRepository = null;
        IUserMessageRepository _userMessageRepository = null;
        ICustomGroupRepository _customGroupRepository = null;
        IGroupRepository _groupRepository = null;
        IGroupMemberRepository _groupMemberRepository = null;
        IGroupMessagerRepository _groupMessagerRepository = null;
        ICustomGroupUserRepository _customGroupUserRepository = null;
        IUnitOfWork _unitOfWork = null;

        public UserService(IUnitOfWork unitOfWork,
            IUserMessageRepository userMessageRepository,
            ICustomGroupRepository customGroupRepository,
            IGroupRepository groupRepository,
            IGroupMemberRepository groupMemberRepository,
            IGroupMessagerRepository groupMessagerRepository,
            ICustomGroupUserRepository customGroupUserRepository,
            IUserRepository userRepository)
        {
            this._userRepository = userRepository;
            this._userMessageRepository = userMessageRepository;
            this._customGroupRepository = customGroupRepository;
            this._groupRepository = groupRepository;
            this._groupMemberRepository = groupMemberRepository;
            this._groupMessagerRepository = groupMessagerRepository;
            this._customGroupUserRepository = customGroupUserRepository;

            this._unitOfWork = unitOfWork;
            this._userRepository.UnitOfWork = unitOfWork;
            this._userMessageRepository.UnitOfWork = unitOfWork;
            this._customGroupRepository.UnitOfWork = unitOfWork;
            this._groupMessagerRepository.UnitOfWork = unitOfWork;
            this._groupRepository.UnitOfWork = unitOfWork;
            this._groupMemberRepository.UnitOfWork = unitOfWork;
            this._customGroupUserRepository.UnitOfWork = unitOfWork;
        }

        public void InitDataBase()
        {
            if (_userRepository.GetAll().Count() <= 0)
            {
                User user = new User()
                {
                    UserName = "Admin",
                    Password = "Admin",
                    ActualName = "Admin",
                    LimitTime = DateTime.Now,
                    Notes = "",
                    State = 0,
                    Domain = "",
                    DomainId = ""
                };
                //CustomerGoup cg = new CustomerGoup() { User = user, GroupName = "管理员" };
                //_customerGroupRepository.Add(cg);
                _userRepository.Add(user);
                _unitOfWork.Commit();
            }
        }

        #region user

        public bool Login(string userName, string userPwd)
        {
            if (_userRepository.GetAll().Where(it=>it.IsDeleted==false)
                .Where(it => it.UserName.Equals(userName) && it.Password.Equals(userPwd)).FirstOrDefault() != null)
                return true;
            else
                return false;
        }

        public bool RegisterUser(UserDTO userDto)
        {
            if (userDto == null || String.IsNullOrWhiteSpace(userDto.UserName)) return false;
            if (_userRepository.GetAll().Where(it => it.UserName.Equals(userDto.UserName)).FirstOrDefault() != null)
                return false;
            User user = userDto.MapperTo<UserDTO, User>();
            _userRepository.Add(user);
            _unitOfWork.Commit();
            return true;
        }

        public UserDTO GetUser(int id)
        {
            var user = _userRepository.GetAllWithNavigationalProperty("GroupNames")
                .Where(it=>it.IsDeleted==false)
                .Where(it => it.ID == id).FirstOrDefault();
            if (user != null)
                return user.ConvertToUserDTO();
            else
                throw new Exception("不存在的用户");
        }

        public UserDTO GetUser(string userName)
        {
            var user = _userRepository.GetAllWithNavigationalProperty("GroupNames")
                .Where(it => it.IsDeleted == false)
                .Where(it => it.UserName.Equals(userName)).FirstOrDefault();
            if (user != null)
                return user.ConvertToUserDTO();
            else
                throw new Exception("不存在的用户");
        }

        public bool DeleteUser(int id)
        {
            User user = _userRepository.GetByKey(id);
            if (user == null||user.IsDeleted) return false;
            user.IsDeleted = true;
            _userRepository.Save(user);
            _unitOfWork.Commit();
            return true;
        }

        public bool UpdateUserPwd(int id, string userPwd)
        {
            var user = _userRepository.GetAll()
                .Where(it => it.IsDeleted == false)
                .Where(it => it.ID == id).FirstOrDefault();
            if (user == null) throw new Exception("不存在的用户");
            user.Password = userPwd;
            _userRepository.Save(user);
            _unitOfWork.Commit();
            return true;
        }

        public List<UserDTO> GetUser()
        {
            
            var list = _userRepository.GetAllWithNavigationalProperty("GroupNames")
                .Where(it => it.IsDeleted == false)
                .ConvertToUserDTO()
                .ToList();
            return list;
        }

        public List<UserMessageDTO> GetPTPMessage(int userId, int anotherId)
        {
            return _userMessageRepository.GetAll()
                .Where(it => it.IsDeleted == false)
                .Where(it =>
                (it.FromUserId == userId && it.ToUserId == anotherId)
                || (it.FromUserId == anotherId && it.ToUserId == userId))
                .OrderBy(it => it.Id)
                .MapperTo<UserMessage, UserMessageDTO>()
                .ToList();
        }

        public bool AddPTPMessage(UserMessageDTO message)
        {
            _userMessageRepository.Add(message.MapperTo<UserMessageDTO, UserMessage>());
            _unitOfWork.Commit();
            return true;
        }

        public bool Logout(int userId)
        {
            return true;
        }

        public void MarkPTPMessage(int sendId, int replyId)
        {
            var message = _userMessageRepository.GetAll()
                .Where(it => it.IsDeleted == false)
                .Where(it => it.FromUserId == sendId && it.ToUserId == replyId);
            foreach (var node in message)
            {
                node.State = 1;
                _userMessageRepository.Save(node);
            }
            _unitOfWork.Commit();
        }

        public List<Int32> GetAllCommunitcatedUserByUserId(int userId)
        {
            return _userMessageRepository.GetAll()
                .Where(it => it.IsDeleted == false)
                .Where(it => it.FromUserId == userId || it.ToUserId == userId)
                .Select(it => (Int32)(it.FromUserId == userId ? it.ToUserId : it.FromUserId)).Distinct().ToList();
        }

        #endregion

        #region customergroup
        public bool AddCustomGroup(CustomGroupDTO customGroupDTO)
        {
            CustomGroup cg = customGroupDTO.MapperTo<CustomGroupDTO, CustomGroup>();
            cg.User = _userRepository.GetAll()
                .Where(it => it.IsDeleted == false)
                .Where(it => it.ID == customGroupDTO.CreateUserId).FirstOrDefault();
            _customGroupRepository.Add(cg);
            _unitOfWork.Commit();
            return true;
        }

        public bool UpdateCustomGroupName(int groupId, string groupName)
        {
            CustomGroup cg = _customGroupRepository.GetAll()
                .Where(it => it.IsDeleted == false)
                .Where(it => it.Id == groupId).FirstOrDefault();
            if (cg == null) throw new Exception("不存在的分组");
            cg.GroupName = groupName;
            _customGroupRepository.Save(cg);
            _unitOfWork.Commit();
            return true;
        }

        public bool DeleteCustomGroup(int groupId)
        {
            CustomGroup customGroup = _customGroupRepository.GetByKey(groupId);
            if (customGroup == null||customGroup.IsDeleted) return false;

            customGroup.IsDeleted = true;
            _customGroupRepository.Save(customGroup);
            _unitOfWork.Commit();
            return true;
        }

        public List<CustomGroupDTO> GetCustomGroup(int userId, bool IsCascade)
        {
            //if (IsCascade)
            //{
            //    var list = _customerGroupRepository.GetAllWithNavigationalProperty("Members").Where(it => it.User.ID == userId)
            //        .ConvertToCustomGroupDTO();
            //    return list.ToList();
            //}
            //else
            //{
            //    var list = _customerGroupRepository.GetAll().Where(it => it.)
            //        .ConvertToCustomerGroupDTO();
            //    return list.ToList();
            //}
            if (IsCascade)
            {
                //var list=_customGroupRepository.GetAllWithNavigationalProperty("").Where(it=>it.CustomGroupUsers
                var list = _customGroupRepository.GetAllWithNavigationalProperty("CustomGroupUsers")
                    .Where(it => it.IsDeleted == false)
                    .Where(it => it.User.ID == userId)
                    .ConvertToCustomGroupDTO(_customGroupUserRepository);
                return list.ToList();
            }
            else
            {
                var list = _customGroupRepository.GetAll()
                    .Where(it => it.IsDeleted == false)
                    .Where(it => it.User.ID == userId)
                    .ConvertToCustomGroupDTO(_customGroupUserRepository);
                return list.ToList();
            }
        }

        public List<UserDTO> GetUserByCustomGroupId(int groupId)
        {
            var list = _customGroupUserRepository.GetAllWithNavigationalProperty("User")
                .Where(it => it.IsDeleted == false)
                .Where(it => it.GroupId == groupId).Select(it => it.User)
                .ConvertToUserDTO();
            return list.ToList();
        }

        public CustomGroupDTO GetCustomGroupById(int groupId)
        {
            //return _customerGroupRepository.GetAllWithNavigationalProperty("Members")
            //        .Where(it => it.ID == groupId)
            //        .FirstOrDefault()
            //        .ConvertToCustomerGroupDTO();
            var customgroup = _customGroupRepository.GetAllWithNavigationalProperty("CustomGroupUsers")
                .Where(it => it.IsDeleted == false)
                .Where(it => it.Id == groupId)
                .FirstOrDefault();
            if (customgroup == null) throw new Exception("不存在的分组");
            return customgroup.ConvertToCustomGroupDTO(_customGroupUserRepository);
        }

        public bool AddUserToCustomGroup(int userId, int groupId)
        {
            //var user = _customerGroupRepository.GetAllWithNavigationalProperty("User").Where(it => it.ID == groupId).First().User;
            //var groups = _customerGroupRepository.GetAll().Where(it => it.User.ID == user.ID);
            //if (groups.Where(it => it.Members.Where(m => m.ID == userId).FirstOrDefault() == null).FirstOrDefault() != null)
            //{
            //    ///不能如此做
            //    var adduser = _userRepository.GetAllWithNavigationalProperty("Belongs").Where(it => it.ID == userId).First();
            //    var addgroup = _customerGroupRepository.GetAll().Where(it => it.ID == groupId).First();
            //    if (adduser.Belongs == null) adduser.Belongs = new List<CustomerGoup>();
            //    adduser.Belongs.Add(addgroup);
            //    _userRepository.Save(adduser);
            //    _unitOfWork.Commit();
            //    return true;
            //}
            //else
            //{
            //    throw new Exception("该用户已分组");
            //}

            var user = _userRepository.GetByKey(userId);
            var group = _customGroupRepository.GetByKey(groupId);
            if (user == null || group == null||user.IsDeleted||group.IsDeleted) throw new Exception("用户或者分组不存在");

            //检测用户是否已经分组
            if (_customGroupUserRepository.GetAll().Where(it => it.IsDeleted == false).Where(it => it.UserId == userId && it.CustomGroup.CreateUserId == group.CreateUserId).FirstOrDefault() != null)
                throw new Exception("该用户已分组");

            //添加分组
            CustomGroupUser cgu = new CustomGroupUser() { User = user, CustomGroup = group };
            _customGroupUserRepository.Add(cgu);
            _unitOfWork.Commit();

            return true;
        }

        public bool RemoveUserFromCustomGroup(int userId, int groupId)
        {
            var cgu = _customGroupUserRepository.GetAll().Where(it => it.IsDeleted == false).Where(it => it.UserId == userId && it.GroupId == groupId).FirstOrDefault();
            if (cgu != null)
            {
                cgu.IsDeleted = true;
                //_customGroupUserRepository.RemoveNonCascaded(cgu);
                _customGroupUserRepository.Save(cgu);
                _unitOfWork.Commit();
            }

            return true;
        }
        #endregion

        #region group

        public bool UpdateGroup(int groupId, string groupNumber, string groupName, string groupNotes, string groupType, int userId)
        {
            var group = _groupRepository.GetByKey(groupId);
            if (group == null||group.IsDeleted) throw new Exception("未找到对应的群组");
            var member = _groupMemberRepository.GetAll().Where(it => it.IsDeleted == false).Where(it => it.User.ID == userId).FirstOrDefault();
            if (member == null) throw new Exception("用户不属于你群组");
            if (!member.GroupRole.Equals(GroupRole.GroupCreator.ToString()) && !member.GroupRole.Equals(GroupRole.GroupManager.ToString())) throw new Exception("用户没修改权限");
            group.GroupNo = groupNumber;
            group.Name = groupName;
            group.Notes = groupNotes;
            group.Category = groupType;
            _groupRepository.Save(group);
            _unitOfWork.Commit();
            return true;
        }

        public bool RegisterGroup(GroupDTO groupDTO)
        {
            Group group = groupDTO.MapperTo<GroupDTO, Group>();
            group.User = _userRepository.GetByKey((int)groupDTO.UserId);
            if (group.User == null||group.User.IsDeleted) throw new Exception("未找到用户数据");
            if (group.GroupMembers == null) group.GroupMembers = new List<GroupMember>();
            group.GroupMembers.Add(new GroupMember() { GroupRole = GroupRole.GroupCreator.ToString(), CreateTime = DateTime.Now, State = 0, ReferenceUserId = groupDTO.UserId, Name = group.User.ActualName, User = group.User });
            _groupRepository.Add(group);
            _unitOfWork.Commit();
            return true;
        }

        public bool DeleteGroup(int groupId, int userId)
        {
            var group = _groupRepository.GetAll().Where(it => it.IsDeleted == false).Where(it => it.Id == groupId && it.User.ID == userId).FirstOrDefault();
            if (group == null) throw new Exception("不存在的群组或不是群组创建者");
            if (_groupMessagerRepository.GetAll().Where(it => it.IsDeleted == false).Where(it => it.GroupId == groupId).Count() > 1) throw new Exception("群组成员不为空");
            var member = _groupMemberRepository.GetAll().Where(it => it.IsDeleted == false).Where(it => it.UserId == userId && it.GroupId == groupId).FirstOrDefault();
            if (member != null)
            {
                //_groupMemberRepository.RemoveNonCascaded(member);
                member.IsDeleted = true;
                _groupMemberRepository.Save(member);
            }
            
            //_groupRepository.RemoveNonCascaded(groupId);
            group.IsDeleted = true;
            _groupRepository.Save(group);
            _unitOfWork.Commit();
            return true;
        }

        public List<GroupDTO> GetAllGroupByUserId(int userId, bool IsCacasde)
        {
            if (IsCacasde)
            {
                if (userId == -1) throw new Exception("userId!=-1");
                //var creatList= _groupRepository.GetAllWithNavigationalProperty("GroupMembers").Where(it => it.User.ID == userId)
                //    .ConvertToGroupDTO()
                //    .ToList();
                //var partionList=_groupRepository.GetAllWithNavigationalProperty("GroupMembers")
                //    .Where(it=>it.GroupMembers.Where(it=>it.UserID
                var added = _groupMemberRepository.GetAll().Where(it => it.IsDeleted == false).Where(it => it.UserId == userId).Select(it => it.GroupId).ToList();

                var ret = _groupRepository.GetAllWithNavigationalProperty("GroupMembers").Where(it => it.IsDeleted == false).Where(it => added.Contains(it.Id));

                return ret.ConvertToGroupDTO().ToList();
            }
            else
            {
                if (userId == -1)
                    return _groupRepository.GetAll().Where(it => it.IsDeleted == false).MapperTo<Group, GroupDTO>().ToList();
                else
                //return _groupRepository.GetAll().Where(it => it.User.ID == userId).MapperTo<Group, GroupDTO>()
                //.ToList();
                {
                    var added = _groupMemberRepository.GetAll().Where(it => it.IsDeleted == false).Where(it => it.UserId == userId).Select(it => it.GroupId).ToList();
                    return _groupRepository.GetAllWithNavigationalProperty("GroupMembers").Where(it => it.IsDeleted == false).Where(it => added.Contains(it.Id))
                        .MapperTo<Group, GroupDTO>()
                        .ToList();
                }
            }
        }

        public GroupDTO GetGroupById(int groupId)
        {
            var ret = _groupRepository.GetByKey(groupId);
            if (ret == null||ret.IsDeleted) throw new Exception("未找到数据");
            return ret.MapperTo<Group, GroupDTO>();
        }

        public List<GroupMemberDTO> GetGroupMembersByGroupId(int groupId)
        {
            return _groupMemberRepository.GetAllWithNavigationalProperty("Group", "User").Where(it => it.IsDeleted == false).Where(it => it.GroupId == groupId)
                .ConvertToGroupMemberDTO()
                .ToList();
        }

        public bool AddUserToGroup(int memberUserId, int groupId, int userId, int referenceUserId)
        {
            //判读带加入用户是否存在并获取用户数据
            var member = _userRepository.GetByKey(memberUserId);
            if (member == null||member.IsDeleted) throw new Exception("不存在的用户");

            //判断群组是否存在并获得群组数据
            var group = _groupRepository.GetByKey(groupId);
            if (group == null||group.IsDeleted) throw new Exception("不存在的群组");

            //判断登录用户是否拥有操作权限
            var refer = _groupMemberRepository.GetAll().Where(it => it.IsDeleted == false).Where(it => it.UserId == userId).FirstOrDefault();
            if (refer == null || (!refer.GroupRole.Equals(GroupRole.GroupCreator.ToString()) && !refer.GroupRole.Equals(GroupRole.GroupManager.ToString())))
                throw new Exception("用户没有操作权限");

            //判断带加入用户是否已经加入群组
            if (_groupMemberRepository.GetAll().Where(it => it.IsDeleted == false).Where(it => it.UserId == memberUserId && it.GroupId == groupId).FirstOrDefault() != null) throw new Exception("用户已加入群组");

            GroupMember gm = new GroupMember() { Group = group, GroupRole = GroupRole.GroupMember.ToString(), CreateTime = DateTime.Now, Name = member.ActualName, ReferenceUserId = referenceUserId, User = member, UserId = member.ID };
            _groupMemberRepository.Add(gm);
            _unitOfWork.Commit();
            return true;
        }

        public bool RemoveUserFromGroup(int groupMemberId, int groupId, int userId)
        {
            //判断群成员是否存在以及是否可删除并获取群组成员数据
            var member = _groupMemberRepository.GetByKey(groupMemberId);
            if (member == null||member.IsDeleted) throw new Exception("群组不存在该用户");
            if (member.GroupRole == GroupRole.GroupCreator.ToString()) throw new Exception("不能删除群组创建者");

            //获取群组数据
            var group = _groupRepository.GetByKey(groupId);
            if (group == null||group.IsDeleted) throw new Exception("不存在的群组");

            //判断用户是否拥有删除权限
            var refer = _groupMemberRepository.GetAll().Where(it => it.IsDeleted == false).Where(it => it.UserId == userId).FirstOrDefault();
            if (refer == null || (!refer.GroupRole.Equals(GroupRole.GroupCreator.ToString()) && !refer.GroupRole.Equals(GroupRole.GroupManager.ToString())))
                throw new Exception("用户没有操作权限");

            //_groupMemberRepository.RemoveNonCascaded(groupMemberId);
            member.IsDeleted = true;
            _groupMemberRepository.Save(member);
            _unitOfWork.Commit();
            return true;
        }

        public bool ShiftGroupMemberRole(int userId, int groupId, string groupRole, int groupMemberId)
        {
            //
            if (groupRole == GroupRole.GroupCreator.ToString()) throw new Exception("群组创建者只能有一个");

            //验证并获得群组数据
            var group = _groupRepository.GetByKey(groupId);
            if (group == null||group.IsDeleted) throw new Exception("不存在的群组");

            //验证用户权限
            var refer = _groupMemberRepository.GetAll().Where(it => it.IsDeleted == false).Where(it => it.UserId == userId).FirstOrDefault();
            if (refer == null || (!refer.GroupRole.Equals(GroupRole.GroupCreator.ToString()) && !refer.GroupRole.Equals(GroupRole.GroupManager.ToString())))
                throw new Exception("用户没有操作权限");

            //验证并取得群成员数据
            var member = _groupMemberRepository.GetByKey(groupMemberId);
            if (member == null||member.IsDeleted) throw new Exception("不存在群成员");

            member.GroupRole = groupRole;
            _groupMemberRepository.Save(member);
            _unitOfWork.Commit();
            return true;
        }

        public bool UpdateGroupMemberName(int userId, string newName, int groupMemberId)
        {
            var member = _groupMemberRepository.GetAll().Where(it => it.IsDeleted == false).Where(it => it.Id == groupMemberId && it.UserId == userId).FirstOrDefault();
            if (member == null) throw new Exception("不存在的群成员或者并非用户修改自己的群名片");
            member.Name = newName;
            _groupMemberRepository.Save(member);
            _unitOfWork.Commit();
            return true;
        }

        public GroupMemberDTO GetGroupMemberById(int id)
        {
            //return _groupMemberRepository.GetByKey(id)
            //    .MapperTo<GroupMember, GroupMemberDTO>();
            return _groupMemberRepository.GetAll().Where(it => it.IsDeleted == false).Where(it => it.Id == id).FirstOrDefault()
                .MapperTo<GroupMember, GroupMemberDTO>();
        }

        public bool AddGroupMessage(GroupMessagerDTO gmt, int userid)
        {
            GroupMember gm = _groupMemberRepository.GetAll().Where(it => it.IsDeleted == false).Where(it => it.UserId == userid && it.GroupId == gmt.GroupId).FirstOrDefault();
            if (gm == null) throw new Exception("不存在的群成员");
            GroupMessager groupMessage = gmt.MapperTo<GroupMessagerDTO, GroupMessager>();
            groupMessage.GroupId = gm.GroupId;
            groupMessage.GroupMemberId = gm.Id;
            _groupMessagerRepository.Add(groupMessage);
            _unitOfWork.Commit();
            return true;
        }

        /// <summary>
        /// 暂时无法使用
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool MarkPTGMessage(int userId, int groupId)
        {
            //var groupMessage = _groupMessagerRepository.GetAll().Where(it => it.GroupMember != null && it.GroupMember.UserID == userId).FirstOrDefault();
            return true;
        }

        public List<GroupMessagerDTO> GetPTGMessage(int userId, int groupId)
        {
            //return _groupMessagerRepository.GetAll().Where(it => it.GroupMember != null && it.GroupMember.UserId == userId)
            //    .MapperTo<GroupMessager, GroupMessagerDTO>()
            //    .ToList();
            //return null;
            return _groupMessagerRepository.GetAll().Where(it => it.IsDeleted == false).Where(it => it.GroupId == groupId).OrderBy(it => it.Id)
                .MapperTo<GroupMessager, GroupMessagerDTO>()
                .ToList();
        }

        #endregion

    }
}
