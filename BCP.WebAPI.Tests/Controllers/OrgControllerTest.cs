﻿using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BCP.WebAPI.Controllers;
using Microsoft.Practices.Unity;
using BCP.Domain.Mapping;
using BCP.Domain;
using BCP.ViewModel;

namespace BCP.WebAPI.Tests.Controllers
{
    /// <summary>
    /// OrgControllerTest 的摘要说明
    /// </summary>
    [TestClass]
    public class OrgControllerTest
    {
        public OrgControllerTest()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
            if (UnityBootStrapper == null) UnityBootStrapper = new UnityBootStrapper();
            UnityBootStrapper.Bindings();
        }

        public UnityBootStrapper UnityBootStrapper = new UnityBootStrapper();

        private TestContext testContextInstance;

        /// <summary>
        ///获取或设置测试上下文，该上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region 附加测试特性
        //
        // 编写测试时，可以使用以下附加特性:
        //
        // 在运行类中的第一个测试之前使用 ClassInitialize 运行代码
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // 在类中的所有测试都已运行之后使用 ClassCleanup 运行代码
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // 在运行每个测试之前，使用 TestInitialize 来运行代码
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // 在每个测试运行完之后，使用 TestCleanup 来运行代码
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestOrgRegister()
        {
            try
            {
                OrgController orgController = new OrgController();
                UserController userController = new UserController();
                IOrgService orgService = (IOrgService)UnityBootStrapper.UnityContainer.Resolve(typeof(IOrgService));
                IUserService userService = (IUserService)UnityBootStrapper.UnityContainer.Resolve(typeof(IUserService));
                orgController.OrgService = orgService;
                userController.UserService = userService;
                AutoMapperBootStrapper.Start();
                //

                var list = orgService.GetAllOrgRoot();
                if (list.Count > 0)
                {
                    orgService.RemoveOrg(list[0].Id,1);
                }

                var list2 = orgService.GetAllOrgRoot();


            }
            catch (Exception ex)
            { }
        }
    }
}
