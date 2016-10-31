using BCP.ViewModel;
using BCP.WebAPI.SignalR;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfClient.Login;

namespace WpfClient.MessageTab
{
    /// <summary>
    /// MessageBox.xaml 的交互逻辑
    /// </summary>
    public partial class MessageBox : UserControl
    {
        public MessageBox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 判断未读信息页面是否打开着
        /// </summary>
        public static bool IsMsgWinOpen = false;

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                IsMsgWinOpen = true;

                Lv_message.Items.Clear();
                LoginWin.userMsgBoxs.Clear();
                LoginWin.userMsgCount.Clear();
                LoginWin.groupMsgBoxs.Clear();
                LoginWin.groupMsgCount.Clear();

                List<int> userIdList = new List<int>(); //有发送给登录者的用户ID

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:37768/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/User/GetAllCommunitcatedUserByUserId?userId=" + MainClient.CurrentUser.ID);
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    string ds = await response.Content.ReadAsStringAsync();
                    CustomMessage result = JsonConvert.DeserializeObject<CustomMessage>(ds);
                    if (result.Success)
                    {
                        userIdList = JsonConvert.DeserializeObject<List<int>>(result.Data);
                    }
                }

                List<GroupDTO> userGroupList=MainClient.SysUserGroupCollection;
                //获取聊天信息
                ConnectServer(userIdList,userGroupList);


                //IsMsgWinOpen = false;

            }
            catch (Exception ex)
            {
                //IsMsgWinOpen = false;
                System.Windows.Forms.MessageBox.Show("消息加载失败");                
            }
        }

        /// <summary>
        /// 获取信息盒内容，包括个人和群聊
        /// </summary>
        /// <param name="userList"></param>
        /// <param name="userGroupList"></param>
        void ConnectServer(List<int> userList, List<GroupDTO> userGroupList)
        {
            if (userList.Count > 0)
            {
                foreach (var item in userList)
                {
                    SignalRMessagePackage srmp = SignalRMessagePackageFactory.GetPTPTextPackage("", item, MainClient.CurrentUser.ID , System.DateTime.Now);
                    String json_srmp = JsonConvert.SerializeObject(srmp);
                    LoginWin.SignalRProxy.InitPTP(json_srmp);
                }
            }

            if (userGroupList.Count > 0)
            {
                foreach (var item in userGroupList)
                {
                    SignalRMessagePackage srmp_g = SignalRMessagePackageFactory.GetPTGTextPackage("", MainClient.CurrentUser.ID, item.Id, System.DateTime.Now);
                    String json_srmp_g = JsonConvert.SerializeObject(srmp_g);
                    LoginWin.SignalRProxy.InitPTP(json_srmp_g);
                }
            }


        }


        /// <summary>
        /// 最后7天的按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mi_Last7day_Click(object sender, RoutedEventArgs e)
        {
           

        }
    }
}
