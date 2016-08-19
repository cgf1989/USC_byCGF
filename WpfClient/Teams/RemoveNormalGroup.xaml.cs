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

namespace WpfClient.Teams
{
    /// <summary>
    /// RemoveNormalGroup.xaml 的交互逻辑
    /// </summary>
    public partial class RemoveNormalGroup : MyMacClass_noneMaxBtn
    {

        public List<GroupDTO> groupList { set; get; }
        /// <summary>
        /// 是否需要刷新界面
        /// </summary>
        public bool IsRefresh { set; get; }

        public RemoveNormalGroup()
        {
            InitializeComponent();
            IsRefresh = false;

            
            
        }

        private async void btn_RemoveGroup_Click(object sender, RoutedEventArgs e)
        {
            if (cbb_NormalGroup.SelectedItem != null)
            {
                GroupDTO gdto = cbb_NormalGroup.SelectedItem as GroupDTO;

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:37768/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/User/DeleteGroup?userId=" + MainClient.CurrentUser.ID+ "&groupId="+gdto.ID);
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
                        MessageBox.Show("删除失败");
                    }
                }
            }
            else
            {
                MessageBox.Show("选择要删除的分组");
            }
        }

        /// <summary>
        /// 移除分组主窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyMacClass_noneMaxBtn_Loaded(object sender, RoutedEventArgs e)
        {
            cbb_NormalGroup.ItemsSource = groupList;
            cbb_NormalGroup.DisplayMemberPath = "Name";
        }
    }
}
