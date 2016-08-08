using BCP.Common;
using BCP.Domain.Edmx;
using BCP.Domain.Service;
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
    }
}
