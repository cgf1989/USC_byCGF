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

namespace WpfClient.Contacts
{
    /// <summary>
    /// RemoveGroupWin.xaml 的交互逻辑
    /// </summary>
    public partial class RemoveGroupWin : MyMacClass_noneMaxBtn
    {

        public List<CustomGroupDTO> GroupWitoutUserList { set; get; }
        public bool IsRefresh { set; get; }

        public RemoveGroupWin()
        {
            InitializeComponent();
            GroupWitoutUserList = new List<CustomGroupDTO>();
            IsRefresh = false;
        }

        private async void btn_RemoveGroup_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cbb_NormalGroup.SelectedItem != null)
                {
                    CustomGroupDTO selectedGroup = cbb_NormalGroup.SelectedItem as CustomGroupDTO;

                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri("http://localhost:37768/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync("api/User/DeleteCustomerGroup?groupId=" + selectedGroup.Id);
                    response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        string ds = await response.Content.ReadAsStringAsync();
                        CustomMessage result = JsonConvert.DeserializeObject<CustomMessage>(ds);
                        if (result.Success)
                        {
                            IsRefresh = true;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("删除分组失败");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }




        /// <summary>
        /// 本窗体加载时的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyMacClass_noneMaxBtn_Loaded(object sender, RoutedEventArgs e)
        {
            cbb_NormalGroup.ItemsSource = GroupWitoutUserList;
            cbb_NormalGroup.DisplayMemberPath = "GroupName";
        }
    }
}
