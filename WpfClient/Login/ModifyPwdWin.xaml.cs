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
    /// ModifyPwdWin.xaml 的交互逻辑
    /// </summary>
    public partial class ModifyPwdWin : Window
    {

        public UserDTO currentUser { get; set; }


        public ModifyPwdWin()
        {
            InitializeComponent();
        }

        private async void btn_ModifyPwd_Click(object sender, RoutedEventArgs e)
        {
            if (txt_newPwd.Text.Trim() != "")
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:37768/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("Application/Json"));

                HttpResponseMessage response = await client.GetAsync("api/User/UpdateUser?id=" + currentUser.ID + "&userName=" + currentUser.UserName + "&userPwd=" + txt_newPwd.Text);

                if (response.IsSuccessStatusCode)
                {
                    string ds = await response.Content.ReadAsStringAsync();
                    CustomMessage result = JsonConvert.DeserializeObject<CustomMessage>(ds);
                    if (result.Success)
                    {
                        MessageBox.Show("修改成功");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("修改失败");
                    }
                }
            }
            else
            {
                MessageBox.Show("请输入新密码");
            }
        }
    }
 
    
}
