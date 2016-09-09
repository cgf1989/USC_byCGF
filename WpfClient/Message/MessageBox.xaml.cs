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

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
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


                //获取聊天信息
                if (userIdList.Count > 0)
                {
                    ConnectServer(userIdList);
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("消息加载失败");
            }
        }


        void ConnectServer(List<int> userList)
        {
            foreach (var item in userList)
            {
                SignalRMessagePackage srmp = SignalRMessagePackageFactory.GetPTPTextPackage("", MainClient.CurrentUser.ID, item);
                String json_srmp = JsonConvert.SerializeObject(srmp);
                LoginWin.SignalRProxy.InitPTP(json_srmp);
            }            
        }


    }
}
