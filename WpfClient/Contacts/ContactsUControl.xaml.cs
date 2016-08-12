using SignalCore;
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
    /// ContactsUControl.xaml 的交互逻辑
    /// </summary>
    public partial class ContactsUControl : UserControl
    {
        private TreeView _treeView = new TreeView();
        private SignalRProxy _signalRProxy = new SignalRProxy();
        private String _userName = String.Empty;

        public ContactsUControl()
        {
            InitializeComponent();
        }

        public void Init()
        {

            ////注册SignalR客户端方法
            //_signalRProxy.LoginFail = () =>
            //{
            //    this.Dispatcher.Invoke(() => MessageBox.Show("Login Failed"));
            //};
            //_signalRProxy.RecevieMessage = (name, message) =>
            //    {
            //        this.Dispatcher.Invoke(() => MessageBox.Show(name + ":" + message));
            //    };
            //_signalRProxy.UpdateContacts = (userList) =>
            //{
            //    this.Dispatcher.Invoke(() =>
            //        {
            //            if (_treeView.HasItems) _treeView.Items.Clear();
            //            List<String> department = Data.InitDepartment();
            //            foreach (var node in department)
            //            {
            //                TreeViewItem treeViewItemNode = new TreeViewItem();
            //                treeViewItemNode.Header = node;
            //                foreach (var item in userList.Where(it => it.Department.Equals(node)))
            //                {
            //                    //将自己从联系人列表中排除(未实现）
            //                    if (item.UserName.Equals(_userName)) continue;

            //                    TreeViewItem treeViewItemItem = new TreeViewItem();
            //                    treeViewItemItem.Header = item.UserName;
            //                    if (item.OnLine) treeViewItemItem.FontStyle = FontStyles.Italic;
            //                    else treeViewItemItem.FontStyle = FontStyles.Normal;
            //                    treeViewItemItem.MouseDown += (sender, e) =>
            //                        {
            //                            _signalRProxy.PrivateSend((e.Source as TreeViewItem).Header.ToString(), "Hi!");
            //                        };
            //                    treeViewItemNode.Items.Add(treeViewItemItem);
            //                }
            //                _treeView.Items.Add(treeViewItemNode);
            //            }
            //            this.Content = _treeView;
            //        });
            //};
            //_signalRProxy.ConnectAsync();
        }

        public void Login(String userName, String userPwd)
        {
            _userName = userName;
            _signalRProxy.Login(userName, userPwd);
        }

        public void Logout()
        {
            //_signalRProxy.Logout(_userName);
        }
    }
}
