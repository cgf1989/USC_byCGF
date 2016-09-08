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
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

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
        public static UserDTO CurrentUser { set; get; }
        /// <summary>
        /// 系统所有用户的集合
        /// </summary>
        public static List<UserDTO> SysUserCollection { set; get; }

        

        public MainClient()
        {
            InitializeComponent();

            try
            {
                tb_UserName.Text = CurrentUser.ActualName;
                tb_LoginTime.Text = System.DateTime.Now.ToString();

                getAllUser();
            }
            catch { MessageBox.Show("用户信息获取失败"); }
        }

        private void hpLink_setting_Click(object sender, RoutedEventArgs e)
        {
            Login.ModifyPwdWin mdfPwdWin = new Login.ModifyPwdWin();
            mdfPwdWin.currentUser = CurrentUser;
            mdfPwdWin.ShowDialog();

            MessageBox.Show(aaa.Height.ToString()+"--"+aaa.ActualHeight.ToString()+ "-"+MsgPanel.Height.ToString()+"-"+ MsgPanel.ActualHeight.ToString());
           
            
            
        }

        async void getAllUser()
        {
            List<UserDTO> userlist = new List<UserDTO>();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:37768/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync("api/user/GetAllUser");
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                string ds = await response.Content.ReadAsStringAsync();
                CustomMessage result = JsonConvert.DeserializeObject<CustomMessage>(ds);
                if (result.Success)
                {
                    userlist = JsonConvert.DeserializeObject<List<UserDTO>>(result.Data);
                }
            }

            SysUserCollection = userlist;
        }
    }
}
