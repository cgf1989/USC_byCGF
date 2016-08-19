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
    public class UserService:IUserService
    {
        IUserRepository _userRepository = null;
        IUserMessageRepository _userMessageRepository = null;
        ICustomerGoupRepository _customerGroupRepository = null;
        IGroupRepository _groupRepository = null;
        IGroupMemberRepository _groupMemberRepository = null;
        IGroupMessagerRepository _groupMessagerRepository = null;
        IUnitOfWork _unitOfWork = null;

        public UserService(IUnitOfWork unitOfWork,
            IUserMessageRepository userMessageRepository,
            ICustomerGoupRepository customerGroupRepository,
            IGroupRepository groupRepository,
            IGroupMemberRepository groupMemberRepository,
            IGroupMessagerRepository groupMessagerRepository,
            IUserRepository userRepository)
        {
            this._userRepository = userRepository;
            this._userMessageRepository = userMessageRepository;
            this._customerGroupRepository = customerGroupRepository;
            this._groupRepository = groupRepository;
            this._groupMemberRepository = groupMemberRepository;
            this._groupMessagerRepository = groupMessagerRepository;

            this._unitOfWork = unitOfWork;
            this._userRepository.UnitOfWork = unitOfWork;
            this._userMessageRepository.UnitOfWork = unitOfWork;
            this._customerGroupRepository.UnitOfWork = unitOfWork;
            this._groupMessagerRepository.UnitOfWork = unitOfWork;
            this._groupRepository.UnitOfWork = unitOfWork;
            this._groupMemberRepository.UnitOfWork = unitOfWork;
        }

        public void InitDataBase()
        {
            if (_userRepository.GetAll().Count()<=0)
            {
                User user = new User()
                {
                    UserName = "Admin",
                    Password = "Admin",
                    ActualName = "Admin",
                    EventTime = 1,
                    LimiteTime = DateTime.Now,
                    Note = "",
                    Status = "",
                    Domain="",
                    DomainId=""
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
            if (_userRepository.GetAll().Where(it => it.UserName.Equals(userName) && it.Password.Equals(userPwd)).FirstOrDefault()!=null)
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
            return _userRepository.GetAllWithNavigationalProperty("GroupNames").Where(it => it.ID == id).First().ConvertToUserDTO();
        }

        public UserDTO GetUser(string userName)
        {
            return _userRepository.GetAll().Where(it => it.UserName.Equals(userName)).First().MapperTo<User, UserDTO>();
        }

        public bool DeleteUser(int id)
        {
            _userRepository.RemoveNonCascaded(id);
            _unitOfWork.Commit();
            return true;
        }

        public bool UpdateUserPwd(int id, string userPwd)
        {
            var user = _userRepository.GetAll().Where(it => it.ID == id).First();
            user.Password = userPwd;
            _userRepository.Save(user);
            _unitOfWork.Commit();
            return true;
        }

        public List<UserDTO> GetUser()
        {
            var list = _userRepository.GetAll()
                .MapperTo<User, UserDTO>()
                .ToList();
            return list;
        }

        public List<UserMessageDTO> GetPTPMessage(int userId, int anotherId)
        {
            return _userMessageRepository.GetAll().Where(it =>
                (it.SenderID == userId && it.ReplyId == anotherId)
                || (it.SenderID == anotherId && it.ReplyId == userId))
                .OrderBy(it=>it.ID)
                .MapperTo<UserMessage, UserMessageDTO>()
                .ToList();
        }

        public bool AddPTPMessage(UserMessageDTO message)
        {
            _userMessageRepository.Add(message.MapperTo<UserMessageDTO,UserMessage>());
            _unitOfWork.Commit();
            return true;
        }

        public bool Logout(int userId)
        {
            return true;
        }

        public void MarkPTPMessage(int sendId, int replyId)
        {
            var message = _userMessageRepository.GetAll().Where(it => it.SenderID == sendId && it.ReplyId == replyId);
            foreach (var node in message)
            {
                node.State = "1";
                _userMessageRepository.Save(node);
            }
            _unitOfWork.Commit();
        }

        #endregion

        #region customergroup
        public bool AddCustomerGroup(CustomerGoupDTO customerGoupDTO)
        {
            CustomerGoup cg = customerGoupDTO.MapperTo<CustomerGoupDTO, CustomerGoup>();
            cg.User = _userRepository.GetAll().Where(it => it.ID == customerGoupDTO.CreatID).FirstOrDefault();
            _customerGroupRepository.Add(cg);
            _unitOfWork.Commit();
            return true;
        }

        public bool UpdateCustomerGroupName(int groupId, string groupName)
        {
            CustomerGoup cg = _customerGroupRepository.GetAll().Where(it => it.ID == groupId).FirstOrDefault();
            if (cg == null) throw new Exception("不存在的分组");
            cg.GroupName = groupName;
            _customerGroupRepository.Save(cg);
            _unitOfWork.Commit();
            return true;
        }

        public bool DeleteCustomerGroup(int groupId)
        {
            _customerGroupRepository.RemoveNonCascaded(groupId);
            _unitOfWork.Commit();
            return true;
        }

        public List<CustomerGoupDTO> GetCustomerGroup(int userId, bool IsCascade)
        {
            if (IsCascade)
            {
                var list = _customerGroupRepository.GetAllWithNavigationalProperty("Members").Where(it => it.User.ID == userId)
                    .ConvertToCustomerGroupDTO();
                return list.ToList();
            }
            else
            {
                var list = _customerGroupRepository.GetAll().Where(it => it.User.ID == userId)
                    .ConvertToCustomerGroupDTO();
                return list.ToList();
            }
        }

        public List<UserDTO> GetUserByCustomerGroupId(int groupId)
        {
            var ret = _userRepository.GetAllWithNavigationalProperty("Belongs").Where(it =>
                (it.Belongs.Where(be => be.ID == groupId).FirstOrDefault()) != null);
            return ret.MapperTo<User, UserDTO>().ToList();
        }

        public CustomerGoupDTO GetCustomerGroupById(int groupId)
        {
            return _customerGroupRepository.GetAllWithNavigationalProperty("Members")
                    .Where(it => it.ID == groupId)
                    .FirstOrDefault()
                    .ConvertToCustomerGroupDTO();
        }

        public bool AddUserToCustomerGroup(int userId, int groupId)
        {
            var user = _customerGroupRepository.GetAllWithNavigationalProperty("User").Where(it => it.ID == groupId).First().User;
            var groups = _customerGroupRepository.GetAll().Where(it => it.User.ID == user.ID);
            if (groups.Where(it => it.Members.Where(m => m.ID == userId).FirstOrDefault() == null).FirstOrDefault() != null)
            {
                ///不能如此做
                var adduser = _userRepository.GetAllWithNavigationalProperty("Belongs").Where(it => it.ID == userId).First();
                var addgroup = _customerGroupRepository.GetAll().Where(it => it.ID == groupId).First();
                if (adduser.Belongs == null) adduser.Belongs = new List<CustomerGoup>();
                adduser.Belongs.Add(addgroup);
                _userRepository.Save(adduser);
                _unitOfWork.Commit();
                return true;
            }
            else
            {
                throw new Exception("该用户已分组");
            }
        }

        public bool RemoveUserFromCustomerGroup(int userId, int groupId)
        {
            var user = _userRepository.GetAll().Where(it => it.ID == userId).First();
            var group = _customerGroupRepository.GetAllWithNavigationalProperty("Members").Where(it => it.ID == groupId).First();
            if (group.Members == null) group.Members = new List<User>();
            group.Members.Remove(user);
            _customerGroupRepository.Save(group);
            _unitOfWork.Commit();
            return true;
        }
        #endregion

        #region group

        public bool UpdateGroup(int groupId, string groupNumber, string groupName, string groupNotes, string groupType, int userId)
        {
            var group = _groupRepository.GetByKey(groupId);
            if (group == null) throw new Exception("未找到对应的群组");
            var member = _groupMemberRepository.GetAll().Where(it => it.User.ID == userId).FirstOrDefault();
            if (member == null) throw new Exception("用户不属于你群组");
            if (!member.GroupRole.Equals(GroupRole.GroupCreator.ToString()) && !member.GroupRole.Equals(GroupRole.GroupManager.ToString())) throw new Exception("用户没修改权限");
            group.GroupNumber = groupNumber;
            group.Name = groupName;
            group.Notes = groupNotes;
            group.Type = groupType;
            _groupRepository.Save(group);
            _unitOfWork.Commit();
            return true;
        }

        public bool RegisterGroup(GroupDTO groupDTO)
        {
            Group group = groupDTO.MapperTo<GroupDTO, Group>();
            group.User = _userRepository.GetByKey(groupDTO.UserID);
            if (group.User == null) throw new Exception("未找到用户数据");
            if (group.GroupMembers == null) group.GroupMembers = new List<GroupMember>();
            group.GroupMembers.Add(new GroupMember() { GroupRole = GroupRole.GroupCreator.ToString(), JoinTime = DateTime.Now, State = "1", Name = group.User.ActualName, ReferenceUserId = group.UserID,User=group.User });
            _groupRepository.Add(group);
            _unitOfWork.Commit();
            return true;
        }

        public bool DeleteGroup(int groupId, int userId)
        {
            var group = _groupRepository.GetAll().Where(it => it.ID == groupId && it.User.ID == userId).FirstOrDefault();
            if (group == null) throw new Exception("不存在的群组或不是群组创建者");
            if (_groupMessagerRepository.GetAll().Where(it => it.GroupID == groupId).Count() > 1) throw new Exception("群组成员不为空");
            var member = _groupMemberRepository.GetAll().Where(it => it.UserID == userId && it.GroupID == groupId).FirstOrDefault();
            if (member != null)
            {
                _groupMemberRepository.RemoveNonCascaded(member);
            }
            _groupRepository.RemoveNonCascaded(groupId);
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
                var added = _groupMemberRepository.GetAll().Where(it => it.UserID == userId).Select(it => it.GroupID).ToList();

                var ret= _groupRepository.GetAllWithNavigationalProperty("GroupMembers").Where(it =>added.Contains(it.ID));

                return ret.ConvertToGroupDTO().ToList();
            }
            else
            {
                if (userId == -1)
                    return _groupRepository.GetAll().MapperTo<Group, GroupDTO>().ToList();
                else
                //return _groupRepository.GetAll().Where(it => it.User.ID == userId).MapperTo<Group, GroupDTO>()
                //.ToList();
                {
                    var added = _groupMemberRepository.GetAll().Where(it => it.UserID == userId).Select(it => it.GroupID).ToList();
                    return _groupRepository.GetAllWithNavigationalProperty("GroupMembers").Where(it => added.Contains(it.ID))
                        .MapperTo<Group,GroupDTO>()
                        .ToList();
                }
            }
        }

        public GroupDTO GetGroupById(int groupId)
        {
            var ret = _groupRepository.GetByKey(groupId);
            if (ret == null) throw new Exception("未找到数据");
            return ret.MapperTo<Group, GroupDTO>();
        }

        public List<GroupMemberDTO> GetGroupMembersByGroupId(int groupId)
        {
            return _groupMemberRepository.GetAllWithNavigationalProperty("Group", "User").Where(it => it.GroupID == groupId)
                .ConvertToGroupMemberDTO()
                .ToList();
        }

        public bool AddUserToGroup(int memberUserId, int groupId, int userId)
        {
            //判读带加入用户是否存在并获取用户数据
            var user = _userRepository.GetByKey(memberUserId);
            if (user == null) throw new Exception("不存在的用户");

            //判断群组是否存在并获得群组数据
            var group = _groupRepository.GetByKey(groupId);
            if (group == null) throw new Exception("不存在的群组");

            //判断登录用户是否拥有操作权限
            var refer = _groupMemberRepository.GetAll().Where(it => it.UserID == userId).FirstOrDefault();
            if (refer == null || (!refer.GroupRole.Equals(GroupRole.GroupCreator) && !refer.GroupRole.Equals(GroupRole.GroupManager)))
                throw new Exception("用户没有操作权限");

            //判断带加入用户是否已经加入群组
            if (_groupMemberRepository.GetAll().Where(it => it.UserID == memberUserId).FirstOrDefault() != null) throw new Exception("用户已加入群组");

            GroupMember gm = new GroupMember() { Group = group, GroupRole = GroupRole.GroupMember.ToString(), JoinTime = DateTime.Now, Name = user.ActualName, ReferenceUserId = userId, User = user, UserID = user.ID };
            _groupMemberRepository.Add(gm);
            _unitOfWork.Commit();
            return true;
        }

        public bool RemoveUserFromGroup(int groupMemberId, int groupId, int userId)
        {
            //判断群成员是否存在以及是否可删除并获取群组成员数据
            var member = _groupMemberRepository.GetByKey(groupMemberId);
            if (member == null) throw new Exception("群组不存在该用户");
            if (member.GroupRole == GroupRole.GroupCreator.ToString()) throw new Exception("不能删除群组创建者");

            //获取群组数据
            var group = _groupRepository.GetByKey(groupId);
            if (group == null) throw new Exception("不存在的群组");

            //判断用户是否拥有删除权限
            var refer = _groupMemberRepository.GetAll().Where(it => it.UserID == userId).FirstOrDefault();
            if (refer == null || (!refer.GroupRole.Equals(GroupRole.GroupCreator) && !refer.GroupRole.Equals(GroupRole.GroupManager)))
                throw new Exception("用户没有操作权限");

            _groupMemberRepository.RemoveNonCascaded(groupMemberId);
            _unitOfWork.Commit();
            return true;
        }

        public bool ShiftGroupMemberRole(int userId, int groupId, string groupRole, int groupMemberId)
        {
            //
            if (groupRole == GroupRole.GroupCreator.ToString()) throw new Exception("群组创建者只能有一个");

            //验证并获得群组数据
            var group = _groupRepository.GetByKey(groupId);
            if (group == null) throw new Exception("不存在的群组");

            //验证用户权限
            var refer = _groupMemberRepository.GetAll().Where(it => it.UserID == userId).FirstOrDefault();
            if (refer == null || (!refer.GroupRole.Equals(GroupRole.GroupCreator) && !refer.GroupRole.Equals(GroupRole.GroupManager)))
                throw new Exception("用户没有操作权限");

            //验证并取得群成员数据
            var member = _groupMemberRepository.GetByKey(groupMemberId);
            if (member == null) throw new Exception("不存在群成员");

            member.GroupRole = groupRole;
            _groupMemberRepository.Save(member);
            _unitOfWork.Commit();
            return true;
        }

        public bool UpdateGroupMemberName(int userId, string newName, int groupMemberId)
        {
            var member = _groupMemberRepository.GetAll().Where(it => it.ID == groupMemberId && it.UserID == userId).FirstOrDefault();
            if (member == null) throw new Exception("不存在的群成员或者并非用户修改自己的群名片");
            member.Name = newName;
            _groupMemberRepository.Save(member);
            _unitOfWork.Commit();
            return true;
        }

        public GroupMemberDTO GetGroupMemberById(int id)
        {
            return _groupMemberRepository.GetByKey(id)
                .MapperTo<GroupMember, GroupMemberDTO>();
        }

        public bool AddGroupMessage(GroupMessagerDTO gmt,int userid)
        {
            GroupMember gm = _groupMemberRepository.GetAll().Where(it => it.UserID == userid).FirstOrDefault();
            if (gm == null) throw new Exception("不存在的群成员");
            GroupMessager groupMessage = gmt.MapperTo<GroupMessagerDTO, GroupMessager>();
            groupMessage.GroupID = gm.GroupID;
            groupMessage.GroupMemberID = gm.ID;
            _groupMessagerRepository.Add(groupMessage);
            _unitOfWork.Commit();
            return true;
        }


        /// <summary>
        /// 暂时无法使用
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool MarkPTGMessage(int userId)
        {
            var groupMessage = _groupMessagerRepository.GetAll().Where(it => it.GroupMember != null && it.GroupMember.UserID == userId).FirstOrDefault();
            return true;
        }

        public List<GroupMessagerDTO> GetPTGMessage(int userId)
        {
            return _groupMessagerRepository.GetAll().Where(it => it.GroupMember != null && it.GroupMember.UserID == userId)
                .MapperTo<GroupMessager, GroupMessagerDTO>()
                .ToList();
        }

        #endregion
    }
}
