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
    /// DelContactWin.xaml 的交互逻辑
    /// </summary>
    public partial class DelContactWin : MyMacClass_noneMaxBtn
    {

        HttpClient client = new HttpClient();

        /// <summary>
        /// 是否刷新联系人界面
        /// </summary>
        public bool IsRefresh = false;

        public DelContactWin()
        {
            InitializeComponent();

            client.BaseAddress = new Uri("http://localhost:37768");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            LoadUserGroup();
        }

        public object HttpCilent { get; private set; }

        private async void btn_delContact_Click(object sender, RoutedEventArgs e)
        {
            if (lbox_GroupMember.SelectedItem != null)
            {



                UserDTO selectedUser = lbox_GroupMember.SelectedItem as UserDTO;
                CustomGroupDTO selectedGroup = cbb_UserGroups.SelectedItem as CustomGroupDTO;
                HttpResponseMessage response = await client.GetAsync("api/User/RemoveUserFromCustomerGroup?userId=" + selectedUser.ID + "&groupId=" + selectedGroup.Id);
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    string ds = await response.Content.ReadAsStringAsync();
                    CustomMessage result = JsonConvert.DeserializeObject<CustomMessage>(ds);
                    if (result.Success)
                    {
                        //数据库删除成功
                        MessageBox.Show("删除成功");


                        //刷新本界面界面
                        //HttpResponseMessage response1 = await client.GetAsync("api/User/GetUserFromCustomerGroup?groupId=" + selectedGroup.ID);
                        //response1.EnsureSuccessStatusCode();
                        //if (response1.IsSuccessStatusCode)
                        //{
                        //    string ds1 = await response1.Content.ReadAsStringAsync();
                        //    CustomMessage result1 = JsonConvert.DeserializeObject<CustomMessage>(ds1);
                        //    if (result1.Success)
                        //    {
                        //        List<UserDTO> userlist = JsonConvert.DeserializeObject<List<UserDTO>>(result1.Data);
                        //        lbox_GroupMember.ItemsSource = userlist;
                        //    }
                        //}


                        //刷新联系人界面
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
                MessageBox.Show("没有选中要删除的联系人");
            }
        }

        private void cbb_UserGroups_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cbb_UserGroups.SelectedItem == null) { }
                else
                {
                    List<UserDTO> userlist = (cbb_UserGroups.SelectedItem as CustomGroupDTO).Members;
                    lbox_GroupMember.ItemsSource = userlist;
                    lbox_GroupMember.DisplayMemberPath = "ActualName";
                }
            }
            catch (Exception ex)
            { MessageBox.Show("用户组下拉框选择出错"); }
        }



        /// <summary>
        /// 下拉框加载用户组
        /// </summary>
        async void LoadUserGroup()
        {


            HttpResponseMessage response = await client.GetAsync("api/User/GetAllCustomerGroupWithUser?userId=" + MainClient.CurrentUser.ID);
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                string ds = await response.Content.ReadAsStringAsync();
                CustomMessage result = JsonConvert.DeserializeObject<CustomMessage>(ds);
                if (result.Success)
                {
                    List<CustomGroupDTO> listGroups = JsonConvert.DeserializeObject<List<CustomGroupDTO>>(result.Data);
                    cbb_UserGroups.ItemsSource = listGroups;
                    cbb_UserGroups.DisplayMemberPath = "GroupName";
                }

            }
        }
        
       
    }
}
