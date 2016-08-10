﻿using BCP.Common;
using BCP.Domain;
using BCP.Domain.Service;
using BCP.ViewModel;
using Microsoft.Practices.Unity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace BCP.WebAPI.Controllers
{
    public class LoginController : ApiController
    {
        [Dependency]
        public IUserService UserService { get; set; }

        [HttpGet]
        public HttpResponseMessage Login(String userName, String userPwd)
        {
            try
            {
                UserService.InitDataBase();
                if (UserService.Login(userName, userPwd))
                {
                    var str= JsonConvert.SerializeObject(UserService.GetUser(userName));
                    HttpResponseMessage result = new HttpResponseMessage { Content = new StringContent(str, Encoding.GetEncoding("UTF-8"), "application/json") };
                    return result;

                }
            }
            catch (Exception ex)
            { }
           return new HttpResponseMessage { Content = new StringContent("false", Encoding.GetEncoding("UTF-8"), "application/json") };
        }
    }
}


