using BCP.ViewModel;
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

namespace WpfClient.Login
{
    /// <summary>
    /// UserManageWin.xaml 的交互逻辑
    /// </summary>
    public partial class UserManageWin : Window
    {
        public UserManageWin()
        {
            InitializeComponent();
        }

        private async void btn_getAllUser_Click(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:37768");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/Json"));

            HttpResponseMessage response =await client.GetAsync("api/User/GetAllUser");

            if (response.IsSuccessStatusCode)
            {
                string ds = await response.Content.ReadAsStringAsync();
                CustomMessage result = JsonConvert.DeserializeObject<CustomMessage>(ds);
                List<UserDTO> listUser = JsonConvert.DeserializeObject<List<UserDTO>>(result.Data);

                dg_AllUser.ItemsSource = listUser;
                //"ID\":1,
                //    \"UserName\":\"Admin\",
                //    \"Password\":\"Admin\",
                //    \"ActualName\":\"Admin\",
                //    \"Status\":\"\",
                //    \"LimiteTime\":\"2016-08-08T14:02:55.757\",
                //    \"Note\":\"\",
                //    \"EventTime\":1,
                //    \"ContextId\":0},
            }
        }

        private async void btn_del_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (dg_AllUser.SelectedItem.GetType() !=typeof(UserDTO))
            {
                MessageBox.Show("该行没有用户数据");
            }
            else
            {
                UserDTO selectedUser = dg_AllUser.SelectedItem as UserDTO;
                MessageBox.Show("是否要删除用户'" + selectedUser.ActualName + "'");

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:37768");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/Json"));

                HttpResponseMessage response =await client.GetAsync("api/User/deleteUser?id="+selectedUser.ID);

                if (response.IsSuccessStatusCode)
                {
                    string ds = await response.Content.ReadAsStringAsync();
                    CustomMessage result = JsonConvert.DeserializeObject<CustomMessage>(ds);
                    if (result.Success)
                    {
                        MessageBox.Show("删除成功");                        
                    }
                    else
                    { MessageBox.Show("删除失败"); }
                }
            }
        }
    }
}
