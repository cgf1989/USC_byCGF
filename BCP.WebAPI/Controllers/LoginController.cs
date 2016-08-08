﻿using BCP.Common;
using BCP.Domain;
using BCP.Domain.Service;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BCP.WebAPI.Controllers
{
    public class LoginController : ApiController
    {
        [Dependency]
        public IUserService UserService { get; set; }

        [HttpGet]
        public bool Login(String userName,String userPwd)
        {
            try
            {
                UserService.InitDataBase();
                if (UserService.Login(userName, userPwd))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            { }
            return false;
        }
    }
}
