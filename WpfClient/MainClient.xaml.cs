using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BCP.ViewModel;

namespace WpfClient
{
    /// <summary>
    /// MainClient.xaml 的交互逻辑
    /// </summary>
    public partial class MainClient : MyMacClass
    {
        /// <summary>
        /// 当前的登录用户
        /// </summary>
        public static UserDTO currentUser { set; get; }


        public MainClient()
        {
            InitializeComponent();

            try
            {
                tb_UserName.Text = currentUser.UserName;
                tb_LoginTime.Text = System.DateTime.Now.ToString();
            }
            catch { MessageBox.Show("用户名获取失败"); }
        }

      
    }
}
