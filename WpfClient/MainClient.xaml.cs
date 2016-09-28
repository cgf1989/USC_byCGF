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
        /// <summary>
        /// 系统当前用户所有普通群组的集合
        /// </summary>
        public static List<GroupDTO> SysUserGroupCollection { set; get; }

        

        public MainClient()
        {
            InitializeComponent();

            try
            {
                tb_UserName.Text = CurrentUser.ActualName;
                tb_LoginTime.Text = System.DateTime.Now.ToString();

                getAllUser();
                getUserAllGroup();
            }
            catch { MessageBox.Show("用户信息获取失败"); }
        }

        private void hpLink_setting_Click(object sender, RoutedEventArgs e)
        {
            Login.ModifyPwdWin mdfPwdWin = new Login.ModifyPwdWin();
            mdfPwdWin.currentUser = CurrentUser;
            mdfPwdWin.ShowDialog();

            
        }

        /// <summary>
        /// 获取系统所有用户保存在内存
        /// </summary>
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

        /// <summary>
        /// 获取用户的所有群组存放在内存
        /// </summary>
        async void getUserAllGroup()
        {
            List<GroupDTO> usergrouplist = new List<GroupDTO>();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:37768/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync("api/user/GetAllGroup?userId="+CurrentUser.ID);
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                string ds = await response.Content.ReadAsStringAsync();
                CustomMessage result = JsonConvert.DeserializeObject<CustomMessage>(ds);
                if (result.Success)
                {
                    usergrouplist = JsonConvert.DeserializeObject<List<GroupDTO>>(result.Data);
                }
            }

            SysUserGroupCollection = usergrouplist;
        }
    }
}
