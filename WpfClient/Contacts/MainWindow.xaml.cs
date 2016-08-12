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
using System.Threading;

namespace WpfClient.Contacts
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        ContactsUControl contactsUControl = new ContactsUControl();
        public MainWindow()
        {
            InitializeComponent();
            //this.Closed += MainWindow_Closed;
            //LoginBtn.Click += LoginBtn_Click;
            //contactsUControl.Init();
            //this.TreeViewContent.Children.Add(contactsUControl);
            //PrivateDialog pd1 = new PrivateDialog();
            //pd1.SignalRProxy = new SignalRProxy();
            //pd1.SignalRProxy.ConnectAsync();
            //pd1.To = "阿发";
            //pd1.Self = "邵工";
            //PrivateDialog pd2 = new PrivateDialog();
            //pd2.To = "邵工";
            //pd2.Self = "阿发";

            //pd2.SignalRProxy.ConnectAsync();
            //pd1.Init();
            //pd2.Init();

            //Thread.Sleep(10000);

            //if (pd1.SignalRProxy.Login("邵工", "邵工"))
            //{
            //    pd1.SignalRProxy.GetContactRecord("邵工", "阿发");
            //    pd1.Show();
            //}
            //if (pd2.SignalRProxy.Login("阿发", "阿发"))
            //{
            //    pd2.SignalRProxy.GetContactRecord("阿发", "邵工");
            //    pd2.Show();
            //}


            PublicDialog();
        }

        void PublicDialog()
        {
            PublicDialog pd = new PublicDialog();
            SignalRProxy s = new SignalRProxy();
            pd.Init("邵工", "市场部", s);

            Thread.Sleep(10000);

            s.Login("邵工", "邵工");
            //s.GetContactRecord("市场部");
            pd.Show();
        }

        void MainWindow_Closed(object sender, EventArgs e)
        {
            //contactsUControl.Logout();
        }

        void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            //contactsUControl.Login(this.UserNameTBox.Text, this.UserNameTBox.Text);
        }
    }
}
