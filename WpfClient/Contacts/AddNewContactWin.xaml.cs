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
    /// AddNewContactWin.xaml 的交互逻辑
    /// </summary>
    public partial class AddNewContactWin : MyMacClass_noneMaxBtn
    {
        public List<CustomGroupDTO> userGroupList = new List<CustomGroupDTO>();
        /// <summary>
        /// 搜索后选中的好友
        /// </summary>
        UserDTO SelectedUser { get; set; }

        public AddNewContactWin()
        {
            InitializeComponent();

           
        }

        /// <summary>
        /// 加载用户分组
        /// </summary>
        void LoadingUserGroups()
        {
            cbb_Groups.ItemsSource = userGroupList;
            cbb_Groups.DisplayMemberPath = "GroupName";
        }

        private void cbb_Groups_Loaded(object sender, RoutedEventArgs e)
        {
            LoadingUserGroups();
        }

        private void btn_searchUser_Click(object sender, RoutedEventArgs e)
        {
            SelectedUser = new UserDTO();
            if (tb_userId.Text.Trim() != "")
            {
           
                string userName = tb_userId.Text.Trim();
                var a = from b in MainClient.SysUserCollection where b.ActualName == userName select b;
                if (a.Any())
                {
                    SelectedUser = a.First();
                    lbl_userName.Content = SelectedUser.ActualName;
                    return;
                }
                else
                {
                    lbl_userName.Content = "找不到该用户";
                }
                
            }
            else
            {
                MessageBox.Show("请输入要搜索的用户名");
            }
        }

        public string GroupName = "";
        public string userName = "";
        public int newContactId = 0;
        private async void btn_AddNewContact_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (lbl_userName.Content.ToString() != "找不到该用户" && lbl_userName.Content.ToString() != "")
                {
                    if (cbb_Groups.SelectedItem != null)
                    {
                        CustomGroupDTO selectedGroup = cbb_Groups.SelectedItem as CustomGroupDTO;
                        GroupName = selectedGroup.GroupName;
                        userName = lbl_userName.Content.ToString();

                        //把该好友存到数据库
                        HttpClient client = new HttpClient();
                        client.BaseAddress = new Uri("http://localhost:37768/");
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                        HttpResponseMessage response = await client.GetAsync("api/user/AddUserToCustomerGroup?userId=" + SelectedUser.ID + "&groupId=" + selectedGroup.Id);
                        response.EnsureSuccessStatusCode();
                        if (response.IsSuccessStatusCode)
                        {
                            string ds = await response.Content.ReadAsStringAsync();
                            CustomMessage result = JsonConvert.DeserializeObject<CustomMessage>(ds);
                            if (result.Success)
                            {
                                MessageBox.Show("添加成功");
                                newContactId = SelectedUser.ID;
                            }
                        }

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("请选择联系人分组");
                    }
                }
                else
                {
                    MessageBox.Show("找不到该联系人");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("添加失败，请联系管理员");
            }
        }
    }
}
