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
        IUnitOfWork _unitOfWork = null;

        public UserService(IUnitOfWork unitOfWork,
            IUserMessageRepository userMessageRepository,
            ICustomerGoupRepository customerGroupRepository,
            IUserRepository userRepository)
        {
            this._userRepository = userRepository;
            this._userMessageRepository = userMessageRepository;
            this._customerGroupRepository = customerGroupRepository;

            this._unitOfWork = unitOfWork;
            this._userRepository.UnitOfWork = unitOfWork;
            this._userMessageRepository.UnitOfWork = unitOfWork;
            this._customerGroupRepository.UnitOfWork = unitOfWork;

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
                CustomerGoup cg = new CustomerGoup() { User = user, GroupName = "管理员" };
                _customerGroupRepository.Add(cg);
                _userRepository.Add(user);
                _unitOfWork.Commit();
            }
        }

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
            return _userRepository.GetAll().Where(it => it.ID == id).First().MapperTo<User, UserDTO>();
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


        #region group
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

        public List<UserDTO> GetUserByGroupId(int groupId)
        {
            return _userRepository.GetAll().Where(it => it.Belongs != null
                && it.Belongs.Where(be => be.ID == groupId).FirstOrDefault()!=null)
                .MapperTo<User, UserDTO>()
                .ToList();
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
    }
}
