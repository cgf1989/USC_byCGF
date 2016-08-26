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
    /// Win_NewUserToNormalGroup.xaml 的交互逻辑
    /// </summary>
    public partial class Win_NewUserToNormalGroup : Window
    {
        /// <summary>
        /// 要加入的群组
        /// </summary>
        public GroupDTO CurGroup { set; get; }

        public GroupDTO AddedUser { set; get; }

        public Win_NewUserToNormalGroup()
        {
            InitializeComponent();
            CurGroup = new GroupDTO();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<UserDTO> users = new List<UserDTO>();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:37768/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync("api/User/GetAllCustomerGroupWithUser?userId=" + MainClient.CurrentUser.ID);
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                string ds = await response.Content.ReadAsStringAsync();
                CustomMessage result = JsonConvert.DeserializeObject<CustomMessage>(ds);
                if (result.Success)
                {

                    List<CustomGroupDTO> usergroupList = JsonConvert.DeserializeObject<List<CustomGroupDTO>>(result.Data);
                    if (usergroupList.Count > 0)
                    {
                        foreach (var item in usergroupList)
                        {
                            users.AddRange(item.Members);
                        }
                    }
                }
            }
            lbox_Contacts.ItemsSource = users;
            lbox_Contacts.DisplayMemberPath = "ActualName";
        }


        /// <summary>
        /// 添加按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btn_AddToGroup_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AddedUser = new GroupDTO();
                if (lbox_Contacts.SelectedItem != null)
                {
                    UserDTO selectedContact = lbox_Contacts.SelectedItem as UserDTO;

                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri("http://localhost:37768/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync("api/User/AddUserToGroup?userId=" + MainClient.CurrentUser.ID + "&groupId=" + CurGroup.Id + "&memberUserId=" + selectedContact.ID + "&referenceUserId=" + "0");
                    response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        string ds = await response.Content.ReadAsStringAsync();
                        CustomMessage result = JsonConvert.DeserializeObject<CustomMessage>(ds);
                        if (result.Success)
                        {

                            GroupDTO usergroup = JsonConvert.DeserializeObject<GroupDTO>(result.Data);
                            //if (usergroupList.Count > 0)
                            //{
                            AddedUser = usergroup;
                            //}
                            this.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.ToString()); }
        }
    }
}
