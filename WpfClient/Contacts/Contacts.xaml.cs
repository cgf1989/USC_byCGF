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

namespace WpfClient.Contacts
{
    /// <summary>
    /// Contacts.xaml 的交互逻辑
    /// </summary>
    public partial class Contacts : UserControl
    {
        public Contacts()
        {
            InitializeComponent();
        }

        private void mi_AddGroup_Click(object sender, RoutedEventArgs e)
        {
            //AddNewGroupWin ang_win = new AddNewGroupWin();
            //ang_win.ShowDialog();
            //if (ang_win.NewGroupName != "")
            //{
            //    TreeViewItem tvi = new TreeViewItem();
            //    tvi.Header = ang_win.NewGroupName;
            //    tv_Contacts.Items.Add(tvi);
            //}

        }

        private void mi_AddContact_Click(object sender, RoutedEventArgs e)
        {
            //获取当前用户分组
            List<string> list_tvi = new List<string>();
            foreach (var item in tv_Contacts.Children)
            {
                list_tvi.Add((item as Expander).Header.ToString());
            }


            AddNewContactWin anc_win = new AddNewContactWin();
            anc_win.userGroupList = list_tvi;
            anc_win.ShowDialog();

            foreach (Expander item in tv_Contacts.Children)
            {
                if (anc_win.GroupName == item.Header.ToString())
                {
                    var listView = item.Content as ListView;
                    ListViewItem lvi = new ListViewItem();

                    //设置模板
                    ResourceDictionary mWindowResouce = new ResourceDictionary();
                    mWindowResouce.Source = new Uri("WpfClient;component/Resource/ControlStyle.xaml", UriKind.Relative);
                    this.Resources.MergedDictionaries.Add(mWindowResouce);
                    lvi.Style = (Style)mWindowResouce["ListViewItemStyle_ContractUser"];

                    lvi.Name = anc_win.userName;
                    BitmapImage image = new BitmapImage(new Uri("/WpfClient;component/Images/tr_logo.jpg", UriKind.Relative));
                    Image img = new Image();
                    img.Source = image;
                    lvi.Content = img;

                    listView.Items.Add(lvi);

                    return;
                }

            }
        }

        private void TreeViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //PrivateDialog pd1 = new PrivateDialog();
            //pd1.SignalRProxy = new SignalRProxy();
            //pd1.SignalRProxy.ConnectAsync();
            //pd1.To = (sender as ListViewItem).Name.ToString();
            //pd1.Self = MainClient.currentUser.UserName;
            //pd1.ReplyId = MainClient.currentUser.ID;

            //PrivateDialog pd2 = new PrivateDialog();
            //pd2.To = MainClient.currentUser.UserName;
            //pd2.Self = (sender as ListViewItem).Name.ToString();
            ////pd2.SignalRProxy = new SignalRProxy();
            //pd2.SignalRProxy.ConnectAsync();
            //// pd2 .ID =

            PrivateDialog pd1 = new PrivateDialog();
            pd1.SignalRProxy = new SignalRProxy();
            pd1.SignalRProxy.ConnectAsync();
            pd1.To = "cgf";
            pd1.Self = "hy";
            pd1.ReplyId = 2;

            PrivateDialog pd2 = new PrivateDialog();
            pd2.SignalRProxy = new SignalRProxy();
            pd2.SignalRProxy.ConnectAsync();
            pd2.To = "hy";
            pd2.Self = "cgf";
            pd2.ReplyId = 1;

            pd1.Closed += (sen, er) =>
            {
                //pd1.SignalRProxy.Logout(MainClient.currentUser.UserName);
                pd1.SignalRProxy.Dispose();
            };
            pd2.Closed += (sen, er) =>
            {
                //pd2.SignalRProxy.Logout((sender as ListViewItem).Name.ToString());
                pd2.SignalRProxy.Dispose();
            };

            pd1.Init();
            pd2.Init();

            System.Threading.Thread.Sleep(1000);

            string pwd1 = "";
            //string pwd2 = "";
            //foreach (SignalCore.UserInfo item in Login.LoginWin.userList)
            //{
            //    if (item.UserName == MainClient.currentUser.UserName)
            //    {
            //        pwd1 = item.UserPwd;
            //    }
            //    //if (item.UserName == (sender as ListViewItem).Name.ToString())
            //    //{
            //    //    pwd2 = item.UserPwd;
            //    //}
            //}

            //if (pd1.SignalRProxy.Login(MainClient.currentUser.UserName, pwd1))
            //{
            //    pd1.SignalRProxy.GetContactRecord(MainClient.currentUser.UserName, (sender as ListViewItem).Name.ToString());
            //    pd1.Show();
            //}
            //if (pd2.SignalRProxy.Login((sender as ListViewItem).Name.ToString(), pwd2))
            //{
            //    pd2.SignalRProxy.GetContactRecord((sender as ListViewItem).Name.ToString(), MainClient.currentUser.UserName);
            //    pd2.Show();
            //}

            pd1.SignalRProxy.Login("hy", "hy");
            pd1.SignalRProxy.InitPTP(2);
            pd1.Show();

            pd2.SignalRProxy.Login("cgf","cgf");
            pd2.SignalRProxy.InitPTP(1);
            pd2.Show();

        }
    }
}
