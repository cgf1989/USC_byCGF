using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using BCP.Domain;
using System.IO;
using BCP.Common;

namespace BCPTest
{
    /// <summary>
    /// DomainT4 的摘要说明
    /// </summary>
    [TestClass]
    public class DomainT4
    {
        public DomainT4()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

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
        public void IRepositoryT4()
        {
            //Assembly ass = Assembly.GetAssembly(typeof(CustomCategory));
            //Assembly ass = Assembly.GetExecutingAssembly();
            var ass = Assembly.Load("BCP.Domain");
            String path = @"E:\Work_hy\共性平台\BasePlace\BCP.Domain\Interface\Repostiory";

            foreach (var node in ass.GetTypes())
            {
                if (node.Namespace.Equals("BCP.Domain.Edmx") && !node.Name.Equals("DataContext")&&!node.IsEnum)
                {
                    using (FileStream fs = new FileStream(path + "\\I" + node.Name + "Repository.CS", FileMode.OpenOrCreate))
                    {
                        StreamWriter sw = new StreamWriter(fs);
                        sw.WriteLine("/*********************************************");
                        sw.WriteLine("* auto-generated code ");
                        sw.WriteLine("* ********************************************/");
                        sw.WriteLine("");
                        sw.WriteLine("using BCP.Common;");
                        sw.WriteLine("using System;");
                        sw.WriteLine("using System.Collections.Generic;");
                        sw.WriteLine("using System.Linq;");
                        sw.WriteLine("using System.Text;");
                        sw.WriteLine("using System.Threading.Tasks;");
                        sw.WriteLine("using BCP.Domain.Edmx;");
                        sw.WriteLine("namespace BCP.Domain");
                        sw.WriteLine("{");
                        sw.WriteLine("    /// <summary>");
                        sw.WriteLine("    /// " + node.Name + " 仓储接口");
                        sw.WriteLine("    /// </summary>");
                        sw.WriteLine("    public interface I" + node.Name + "Repository :IRepository<" + node.Name + ",Int32>");
                        sw.WriteLine("    {");
                        sw.WriteLine("    }");
                        sw.WriteLine("}");
                        sw.Dispose();
                        sw.Close();
                    }
                }
                else
                { }
            }
        }

        [TestMethod]
        public void PartialModelT4()
        {
            var ass = Assembly.Load("BCP.Domain");
            String path = @"E:\Work_hy\共性平台\BasePlace\BCP.Domain\Model";

            foreach (var node in ass.GetTypes())
            {
                if (node.Namespace.Equals("BCP.Domain.Edmx") && !node.Name.Equals("DataContext")&&!node.IsEnum)
                {
                    using (FileStream fs = new FileStream(path + "\\" + node.Name + ".CS", FileMode.OpenOrCreate))
                    {
                        StreamWriter sw = new StreamWriter(fs);
                        sw.WriteLine("using BCP.Common;");
                        sw.WriteLine("using System;");
                        sw.WriteLine("using System.Collections.Generic;");
                        sw.WriteLine("using System.Linq;");
                        sw.WriteLine("using System.Text;");
                        sw.WriteLine("using System.Threading.Tasks;");
                        sw.WriteLine("");
                        sw.WriteLine("namespace BCP.Domain.Edmx");
                        sw.WriteLine("{");
                        sw.WriteLine("    /// <summary>");
                        sw.WriteLine("    /// "+node.Name+" 实体类");
                        sw.WriteLine("    /// </summary>");
                        sw.WriteLine("    public partial class "+node.Name+":EntityBase");
                        sw.WriteLine("    {");
                        sw.WriteLine("    }");
                        sw.WriteLine("}");
                        sw.Dispose();
                        sw.Close();
                    }
                }
            }
        }

        [TestMethod]
        public void EFRepositoryT4()
        {
            var ass = Assembly.Load("BCP.Domain");
            String path = @"E:\Work_hy\共性平台\BasePlace\BCP.Domain\Implementation\Repository";

            foreach (var node in ass.GetTypes())
            {
                if (node.Namespace.Equals("BCP.Domain.Edmx") && !node.Name.Equals("DataContext") && !node.IsEnum)
                {
                    using (FileStream fs = new FileStream(path + "\\" + node.Name + "Repository.CS", FileMode.OpenOrCreate))
                    {
                        StreamWriter sw = new StreamWriter(fs);
                        sw.WriteLine("using BCP.Domain.Edmx;");
                        sw.WriteLine("using System;");
                        sw.WriteLine("using System.Collections.Generic;");
                        sw.WriteLine("using System.Linq;");
                        sw.WriteLine("using System.Text;");
                        sw.WriteLine("using System.Threading.Tasks;");
                        sw.WriteLine("");
                        sw.WriteLine("namespace BCP.Domain");
                        sw.WriteLine("{");
                        sw.WriteLine("    /// <summary>");
                        sw.WriteLine("    /// "+node.Name+" 基于EF的仓储实现");
                        sw.WriteLine("    /// </summary>");
                        sw.WriteLine("    public class "+node.Name+"Repository : EFRepository<"+node.Name+", Int32>,I"+node.Name+"Repository");
                        sw.WriteLine("    {");
                        sw.WriteLine("    }");
                        sw.WriteLine("}");
                        sw.Dispose();
                        sw.Close();
                    }
                }
            }
        }

        [TestMethod]
        public void ViewModelT4()
        {
            var ass = Assembly.Load("BCP.Domain");
            String path = @"E:\Work_hy\共性平台\BasePlace\BCP.ViewModel\Model";

            foreach (var node in ass.GetTypes())
            {
                if (node.Namespace.Equals("BCP.Domain.Edmx") && !node.Name.Equals("DataContext"))
                {
                    using (FileStream fs = new FileStream(path + "\\" + node.Name + "DTO.CS", FileMode.Create))
                    {
                        StreamWriter sw = new StreamWriter(fs);
                        sw.WriteLine("using System;");
                        sw.WriteLine("using System.Collections.Generic;");
                        sw.WriteLine("using System.Linq;");
                        sw.WriteLine("using System.Text;");
                        sw.WriteLine("using System.Threading.Tasks;");
                        sw.WriteLine("");
                        sw.WriteLine("namespace BCP.ViewModel");
                        sw.WriteLine("{");
                        sw.WriteLine("    /// <summary>");
                        sw.WriteLine("    /// "+node.Name+" DTO");
                        sw.WriteLine("    /// </summary>");



                        if (node.IsEnum)
                        {
                            sw.WriteLine("    public  enum " + node.Name + "DTO");
                            sw.WriteLine("    {");
                            var fields= Enum.GetNames(node);
                            if (fields != null && fields.Length > 0)
                            {
                                for (int i = 0; i < fields.Length; i++)
                                {
                                    if (i == fields.Length - 1)
                                    {
                                        sw.WriteLine("        "+fields[i]);
                                    }
                                    else
                                    {
                                        sw.WriteLine("        " + fields[i]+",");
                                    }
                                }
                            }
                        }
                        else
                        {
                            sw.WriteLine("    public partial class " + node.Name + "DTO");
                            sw.WriteLine("    {");
                            var properties = node.GetProperties();
                            if (properties != null)
                            {
                                foreach (var property in properties)
                                {
                                    if (property.PropertyType.IsEnum)
                                    {
                                        sw.WriteLine("        public " + property.PropertyType + "DTO " + property.Name + " { get; set; }");
                                        continue;
                                    }
                                    if (!property.PropertyType.IsGenericType && !property.PropertyType.IsSubclassOf(typeof(EntityBase)))
                                    {
                                        sw.WriteLine("        public " + property.PropertyType + " " + property.Name + " { get; set; }");
                                        continue;
                                    }
                                    if (property.PropertyType.IsValueType&&property.PropertyType.IsGenericType)
                                    {
                                        sw.WriteLine("        public " + property.PropertyType.GetGenericArguments()[0].Name + "? " + property.Name + " { get; set; }");
                                        continue;
                                    }
                                }
                            }
                        }

                        sw.WriteLine("    }");
                        sw.WriteLine("}");
                        sw.Dispose();
                        sw.Close();
                    }
                }
            }
        }

        [TestMethod]
        public void AutoMapperT4()
        {
            var ass = Assembly.Load("BCP.Domain");
            String path = @"E:\Work_hy\共性平台\BasePlace\BCP.Domain\Mapping";

            using (FileStream fs = new FileStream(path + "\\AutoMapperBootStrapper.CS", FileMode.OpenOrCreate))
            {
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine("using AutoMapper;");
                sw.WriteLine("using BCP.Domain.Edmx;");
                sw.WriteLine("using System.Collections.Generic;");
                sw.WriteLine("using BCP.ViewModel;");
                sw.WriteLine("using System;");
                sw.WriteLine("using System.Collections.Generic;");
                sw.WriteLine("using System.Linq;");
                sw.WriteLine("using System.Text;");
                sw.WriteLine("using System.Threading.Tasks;");
                sw.WriteLine("namespace BCP.Domain.Mapping");
                sw.WriteLine("{");
                sw.WriteLine("    /// <summary>");
                sw.WriteLine("    /// AutoMapper配置类");
                sw.WriteLine("    /// </summary>");
                sw.WriteLine("    public class AutoMapperBootStrapper");
                sw.WriteLine("    {");
                sw.WriteLine("        public static void Start()");
                sw.WriteLine("        {");
                foreach (var node in ass.GetTypes())
                {
                    if (node.Namespace.Equals("BCP.Domain.Edmx") && !node.Name.Equals("DataContext"))
                    {
                        sw.WriteLine("//");
                        sw.WriteLine("            Mapper.CreateMap<" + node.Name + ", " + node.Name + "DTO>();");
                        sw.WriteLine("            Mapper.CreateMap<" + node.Name + "DTO, " + node.Name + ">();");
                        sw.WriteLine("");
                    }
                }

                sw.WriteLine("        }");
                sw.WriteLine("    }");
                sw.WriteLine("}");

                sw.Dispose();
                sw.Close();
            }
        }

        [TestMethod]
        public void UnityBootStrapperT4()
        {
            var ass = Assembly.Load("BCP.Domain");
            String path = @"E:\Work_hy\共性平台\BasePlace\BCP.WebAPI\Controllers\Ioc";

            using (FileStream fs = new FileStream(path + "\\UnityBootStrapper.CS", FileMode.Create))
            {
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine("using BCP.Domain;");
                sw.WriteLine("using BCP.Common;");
                sw.WriteLine("using BCP.Domain.Service;");
                sw.WriteLine("using Microsoft.Practices.Unity;");
                sw.WriteLine("using Microsoft.Practices.Unity.InterceptionExtension;");
                sw.WriteLine("using System;");
                sw.WriteLine("using System.Collections.Generic;");
                sw.WriteLine("using System.Linq;");
                sw.WriteLine("using System.Text;");
                sw.WriteLine("");
                sw.WriteLine("namespace BCP.WebAPI.Controllers");
                sw.WriteLine("{");
                sw.WriteLine("    /// <summary>");
                sw.WriteLine("    /// Unit配置类");
                sw.WriteLine("    /// </summary>");
                sw.WriteLine("    public class UnityBootStrapper");
                sw.WriteLine("    {");
                sw.WriteLine("        public IUnityContainer UnityContainer = new UnityContainer();");
                sw.WriteLine("");
                sw.WriteLine("        public void Bindings()");
                sw.WriteLine("        {");
                sw.WriteLine("            UnityContainer.AddNewExtension<Interception>();");
                sw.WriteLine("            UnityContainer.RegisterType<IUnitOfWork, EFUnitOfWork>();");
                foreach (var node in ass.GetTypes())
                {
                    sw.Flush();
                    if (node.Namespace.Equals("BCP.Domain.Edmx") && !node.Name.Equals("DataContext")&&!node.IsEnum)
                    {
                        sw.WriteLine("            UnityContainer.RegisterType<I"+node.Name+"Repository, "+node.Name+"Repository>();");
                    }

                    if (node.Namespace.Equals("BCP.Domain.Service")&&node.IsInterface)
                    {
                        sw.WriteLine("            UnityContainer.RegisterType<" + node.Name + ", " + node.Name.Substring(1,node.Name.Length-1) + ">();");
                    }
                }

                sw.WriteLine("        }");
                sw.WriteLine("    }");
                sw.WriteLine("}");

                sw.Dispose();
                sw.Close();
            }
        }
    }
}
