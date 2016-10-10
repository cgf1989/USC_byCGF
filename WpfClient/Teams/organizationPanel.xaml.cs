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
using WpfClient.Contacts;
using WpfClient.Login;

namespace WpfClient.Teams
{
    /// <summary>
    /// organizationPanel.xaml 的交互逻辑
    /// </summary>
    public partial class organizationPanel : UserControl
    {
        public organizationPanel()
        {
            InitializeComponent();

            NormalGroupDialogList = new List<NormalGroupDialog>();
            LoadNormalGroup();
        }

        private void TreeViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            InteractWindow iw = new InteractWindow();
            iw.Show();
        }

        private void mi_createOrganization_Click(object sender, RoutedEventArgs e)
        {
            CreatOrganizaiton createOrg = new CreatOrganizaiton();
            createOrg.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            createOrg.ShowDialog();
        }

        private void mi_createWorkspace_Click(object sender, RoutedEventArgs e)
        {
            CreatWorkSpace createWS = new CreatWorkSpace();
            createWS.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            createWS.ShowDialog();

            if (createWS.NewWorkSpaceName != null)
            {
                TreeViewItem tvi = new TreeViewItem();
                tvi.Header = createWS.NewWorkSpaceName;
                tvi_WorkSpace.Items.Add(tvi);
            }
        }

        private void mi_joinTeam_Click(object sender, RoutedEventArgs e)
        {
            joinTeam joinTeam = new joinTeam();
            joinTeam.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            joinTeam.ShowDialog();
        }

        private void mi_joinWorkspace_Click(object sender, RoutedEventArgs e)
        {
            JoinWorkSpace joinWorkspace = new JoinWorkSpace();
            joinWorkspace.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            joinWorkspace.ShowDialog();
        }

        private void mi_createNormalGroup_Click(object sender, RoutedEventArgs e)
        {
            CreateNormalGroup cng_win = new CreateNormalGroup();
            cng_win.ShowDialog();
            if (cng_win.IsRefresh)
            {
                tv_NormalSpace.ItemsSource = null;
                LoadNormalGroup();
            }
        }

        private void tv_publicDialog_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if ((e.Source as TreeViewItem).IsSelected)   //加这个判断防止父节点递归传递事件
            {

                TreeViewItem curTv = sender as TreeViewItem;
                lbName = curTv.Header.ToString();
                selectTreeViewParent(curTv);


                Contacts.PublicDialog pd = new Contacts.PublicDialog();
                //pd.lb_Title.Content = lbName;
                pd.TitleLable = lbName;
                Contacts.SignalRProxy s = new Contacts.SignalRProxy();
                pd.Closed += (sen, er) =>
                {
                    //s.Logout(MainClient.currentUser.UserName);
                    s.Dispose();
                };


                //pd.Init(MainClient.currentUser.UserName,MainClient.currentUser.Department, s);

                System.Threading.Thread.Sleep(1000);

                s.Login(MainClient.CurrentUser.UserName, MainClient.CurrentUser.Password);
                //s.GetContactRecord(MainClient.currentUser.Department);
                pd.Show();
            }

        }


        private void tv_workspaceDialog_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if ((e.Source as TreeViewItem).IsSelected)   //加这个判断防止父节点递归传递事件
            {

                TreeViewItem curTv = sender as TreeViewItem;
                lbName = curTv.Header.ToString();
                selectTreeViewParent(curTv);


                Contacts.WorkSpaceDialog pd = new Contacts.WorkSpaceDialog();
                //pd.lb_Title.Content = lbName;
                pd.TitleLable = lbName;
                Contacts.SignalRProxy s = new Contacts.SignalRProxy();
                pd.Closed += (sen, er) =>
                {
                    //s.Logout(MainClient.currentUser.UserName);
                    s.Dispose();
                };


                //pd.Init(MainClient.currentUser.UserName, MainClient.currentUser.Department, s);

                System.Threading.Thread.Sleep(1000);

                //s.Login(MainClient.currentUser.UserName, MainClient.currentUser.Password);
                //s.GetContactRecord(MainClient.currentUser.Department);
                pd.Show();
            }
        }

        string lbName = "";
        /// <summary>
        /// 遍历查找父节点
        /// </summary>
        /// <param name="tvItem"></param>
        void selectTreeViewParent(TreeViewItem tvItem)
        {
            if (tvItem.Parent != null)
            {
                var aaa = tvItem.Parent;
                if (aaa is TreeViewItem)
                {
                    if ((aaa as TreeViewItem).Header == null)
                    { }
                    else
                    {
                        lbName = (tvItem.Parent as TreeViewItem).Header.ToString() + "->" + lbName;
                        selectTreeViewParent(tvItem.Parent as TreeViewItem);
                    }
                }
                else
                {
                    return;
                }
            }
        }

        private void mi_moduleToPost_Click(object sender, RoutedEventArgs e)
        {
            ModuleToPost mtoPost = new ModuleToPost();
            mtoPost.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            mtoPost.ShowDialog();
        }


        public static List<NormalGroupDialog> NormalGroupDialogList { set; get; }
        /// <summary>
        /// 存储用户的普通群组
        /// </summary>
        List<GroupDTO> listGroup = new List<GroupDTO>();
        /// <summary>
        /// 加载用户的普通群
        /// </summary>
        async void LoadNormalGroup()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:37768/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/User/GetAllGroup?userId=" + MainClient.CurrentUser.ID);
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    string ds = await response.Content.ReadAsStringAsync();
                    CustomMessage result = JsonConvert.DeserializeObject<CustomMessage>(ds);
                    if (result.Success)
                    {
                        listGroup = JsonConvert.DeserializeObject<List<GroupDTO>>(result.Data);
                        tv_NormalSpace.ItemsSource = listGroup;
                        tv_NormalSpace.DisplayMemberPath = "Name";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 删除普通群
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mi_removeNormalGroup_Click(object sender, RoutedEventArgs e)
        {
            RemoveNormalGroup rng = new RemoveNormalGroup();
            rng.groupList = listGroup;
            rng.ShowDialog();
            if (rng.IsRefresh)
            {
                tv_NormalSpace.ItemsSource = null;
                LoadNormalGroup();
            }
        }


        /// <summary>
        /// 打开普通群聊天框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tv_NormalSpace_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if ((e.Source as TreeViewItem).IsSelected)   //加这个判断防止父节点递归传递事件
            {

                TreeViewItem curTv = sender as TreeViewItem;
                GroupDTO group = curTv.Header as GroupDTO;
                lbName = group.Name;


                //检查窗口是否已经打开
                foreach (var item in NormalGroupDialogList)
                {
                    if (item.CurrentGroup.Id == group.Id)
                        return;
                }
                //selectTreeViewParent(curTv);


                NormalGroupDialog pd = new NormalGroupDialog();
                NormalGroupDialogList.Add(pd);

                pd.TitleLable = lbName;
                pd.CurrentGroup = group;
                pd.Closed += (sen, er) =>
                {
                    //LoginWin.SignalRProxy.Dispose();
                    NormalGroupDialogList.Remove(pd);
                };


                pd.Init(MainClient.CurrentUser.ActualName, group.Id.ToString());

                //System.Threading.Thread.Sleep(1000);


                pd.Show();

                System.Threading.Thread.Sleep(500);

                SignalRMessagePackage srmp = SignalRMessagePackageFactory.GetPTGTextPackage("", MainClient.CurrentUser.ID, group.Id, System.DateTime.Now);
                String json_srmp = JsonConvert.SerializeObject(srmp);
                LoginWin.SignalRProxy.InitPTP(json_srmp);
            }

        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //加载组织
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:37768/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/Org/GetAllOrgRoots?");
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    string ds = await response.Content.ReadAsStringAsync();
                    CustomMessage result = JsonConvert.DeserializeObject<CustomMessage>(ds);
                    if (result.Success)
                    {
                        List<OrganizationDTO> OrgCollection = new List<OrganizationDTO>();
                        OrgCollection = JsonConvert.DeserializeObject<List<OrganizationDTO>>(result.Data);

                        tv_OrgWorkSpace.Items.Clear();
                        foreach (var item in OrgCollection)
                        {
                            tv_OrgWorkSpace.Items.Add(item);
                            tv_OrgWorkSpace.DisplayMemberPath = "OrgaName";
                            //MessageBox.Show(item.OrgaName);
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("组织信息加载出错");
            }
        }


        /// <summary>
        /// 创建部门
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mi_CreateDepartment_Click(object sender, RoutedEventArgs e)
        {

            var curOrgInfo = tv_main.SelectedItem as OrganizationDTO;
            if (curOrgInfo != null)
            {
                CreatOrganizaiton win_createOrg = new CreatOrganizaiton();
                win_createOrg.btnCreateOrg.IsEnabled = false;
                win_createOrg.Title = "创建部门";
                win_createOrg.orgaNameTextBox.Text = curOrgInfo.OrgaName;
                win_createOrg.orgaNameTextBox.IsEnabled = false;
                win_createOrg.organizationCodeTextBox.Text = curOrgInfo.OrganizationCode;
                win_createOrg.organizationCodeTextBox.IsEnabled = false;
                win_createOrg.typeTextBox.Text = curOrgInfo.Type;
                win_createOrg.typeTextBox.IsEnabled = false;
                win_createOrg.establishmentDateDatePicker.SelectedDate = (System.DateTime)curOrgInfo.CreateTime;
                win_createOrg.establishmentDateDatePicker.IsEnabled = false;
                win_createOrg.OrgRootID = curOrgInfo.Id;
                win_createOrg.ShowDialog();
            }

        }


        #region 树的右键用的
        private void TreeViewItem_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            var treeViewItem = VisualUpwardSearch<TreeViewItem>(e.OriginalSource as DependencyObject) as TreeViewItem;
            if (treeViewItem != null)
            {
                treeViewItem.Focus();
                e.Handled = true;
            }
        }

        static DependencyObject VisualUpwardSearch<T>(DependencyObject source)
        {
            while (source != null && source.GetType() != typeof(T))
                source = VisualTreeHelper.GetParent(source);

            return source;
        }
        #endregion


        /// <summary>
        /// 移除组织
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void mi_RemoveOrg_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("是否移除该组织", "注意", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                var curOrgInfo = tv_main.SelectedItem as OrganizationDTO;

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:37768/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/Org/RemoveOrg?orgId=" + curOrgInfo.Id + "&loginId=" + MainClient.CurrentUser.ID);
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    string ds = await response.Content.ReadAsStringAsync();
                    CustomMessage result = JsonConvert.DeserializeObject<CustomMessage>(ds);
                    if (result.Success)
                    {
                        //从界面移除
                        tv_OrgWorkSpace.Items.Remove(tv_main.SelectedItem);
                    }
                }
            }
        }
    }
}
