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
        IUnitOfWork _unitOfWork = null;

        public UserService(IUnitOfWork unitOfWork,
            IUserRepository userRepository)
        {
            this._userRepository = userRepository;

            this._unitOfWork = unitOfWork;
            this._userRepository.UnitOfWork = unitOfWork;

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
                    Status = ""
                };
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
    }
}
