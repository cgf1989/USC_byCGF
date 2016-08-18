using System;
using System.Collections.Generic;
using System.Linq;
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

            if (createWS.NewWorkSpaceName!=null)
            {
                TreeViewItem tvi = new TreeViewItem();
                tvi.Header = createWS.NewWorkSpaceName;
                tvi_WorkSpace.Items.Add(tvi);
            }
        }

        private void mi_joinTeam_Click(object sender, RoutedEventArgs e)
        {
            jioinTeam joinTeam = new jioinTeam();
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
            if (cng_win.NewGroupName != "")
            {
                TreeViewItem tvi = new TreeViewItem();
                tvi.Header = cng_win.NewGroupName;
                tv_NormalSpace.Items.Add(tvi);
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
                    lbName = (tvItem.Parent as TreeViewItem).Header.ToString() + "->" + lbName;
                    selectTreeViewParent(tvItem.Parent as TreeViewItem);
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
    }
}
