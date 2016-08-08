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
using System.Windows.Shapes;

namespace WpfClient.Login
{
    /// <summary>
    /// LoginWin.xaml 的交互逻辑
    /// </summary>
    public partial class LoginWin : MyMacClass_noneMaxBtn
    {
        /// <summary>
        /// 所有用户信息都存在该列表（deomo用）
        /// </summary>
        public static List<SignalCore.UserInfo> userList = new List<SignalCore.UserInfo>();

        public LoginWin()
        {
            InitializeComponent();
            userList=SignalCore.Data.InitUserInfo();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (tb_account.Text.Trim() == "" || tb_password.Password.Trim() == "")
            {
                MessageBox.Show("账号或密码为空，请输入");
            }
            else
            {
                SignalCore.UserInfo user = new SignalCore.UserInfo();
                user.UserAccount=tb_account.Text.Trim();
                user.UserPwd = tb_password.Password.Trim();
                foreach (var currentUser in userList)
                {
                    if (currentUser.UserAccount == user.UserAccount)
                    {
                        if (currentUser.UserPwd== user.UserPwd)
                        {
                            MainClient.currentUser = currentUser;
                            MainClient mainWin = new MainClient();
                            this.Close();
                            mainWin.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("密码错误");
                        }
                        return;
                    }

                }
                MessageBox.Show("该账户不存在");
            }            
        }


        /// <summary>
        /// 用户注册账号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hpLink_registAccount_Click(object sender, RoutedEventArgs e)
        {
            RegistWin rgWin = new RegistWin();
            rgWin.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            rgWin.ShowDialog();
        }
    }

 

   
}
