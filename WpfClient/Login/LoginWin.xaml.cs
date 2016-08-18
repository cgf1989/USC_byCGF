using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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
using BCP.ViewModel;

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
            userList = SignalCore.Data.InitUserInfo();
        }

        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (tb_account.Text.Trim() == "" || tb_password.Password.Trim() == "")
            {
                MessageBox.Show("账号或密码为空，请输入");
            }
            else
            {
                UserDTO user = new UserDTO();
                //SignalCore.UserInfo user = new SignalCore.UserInfo();
                user.UserName = tb_account.Text.Trim();
                user.Password = tb_password.Password.Trim();

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:37768/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/Login/Login?userName=" + user.UserName + "&userPwd=" + user.Password);
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    string  ds = await response.Content.ReadAsStringAsync();
                    if (ds.ToString() == "false")
                    {
                        MessageBox.Show("用户名或密码错误");
                    }
                    else
                    {
                        CustomMessage result = JsonConvert.DeserializeObject<CustomMessage>(ds);
                        if (result.Success)
                        {
                            UserDTO currentUser = JsonConvert.DeserializeObject<UserDTO>(result.Data);
                            MainClient.CurrentUser = currentUser;  //返回当前用户
                            MainClient mainWin = new MainClient();
                            this.Close();

                            mainWin.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("用户名或密码错误");
                        }
                    }

                }

                //foreach (var currentUser in userList)
                //{
                //    if (currentUser.UserAccount == user.UserAccount)
                //    {
                //        if (currentUser.UserPwd== user.UserPwd)
                //        {
                //            MainClient.currentUser = currentUser;
                //            MainClient mainWin = new MainClient();
                //            this.Close();



                //            mainWin.ShowDialog();
                //        }
                //        else
                //        {
                //            MessageBox.Show("密码错误");
                //        }
                //        return;
                //    }

                //}
                
                //MessageBox.Show("该账户不存在");
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

        /// <summary>
        /// 找回密码 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hpLink_findPassword_Click(object sender, RoutedEventArgs e)
        {
            UserManageWin umw=new UserManageWin();
            umw.ShowDialog();
        }
    }




}
