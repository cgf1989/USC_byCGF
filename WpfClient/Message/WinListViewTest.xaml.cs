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
using System.Windows.Shapes;

namespace WpfClient.Message
{
    /// <summary>
    /// WinListViewTest.xaml 的交互逻辑
    /// </summary>
    public partial class WinListViewTest : Window
    {
        public WinListViewTest()
        {
            InitializeComponent();

            
           
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            UnReadMsgBox UrMb = new UnReadMsgBox();
            UrMb.tb_MsgContent.Text = "hello world  1111111111111111111111111111";
            UrMb.tb_Time.Text = System.DateTime.Now.ToShortTimeString();
            UrMb.tb_UnReadMsgCount.Text = "2";
            UrMb.tb_UserName.Text = "阿童木";
            UrMb.Img_Header.Source = new BitmapImage(new Uri("/WpfClient;component/Images/Img_Header/Head8.jpg", UriKind.Relative));
            lv_main.Items.Add(UrMb);

            UnReadMsgBox UrMb1 = new UnReadMsgBox();
            UrMb1.tb_MsgContent.Text = "有怪兽";
            UrMb1.tb_Time.Text = System.DateTime.Now.ToShortTimeString();
            UrMb1.tb_UnReadMsgCount.Text = "1";
            UrMb1.tb_UserName.Text = "阿凡达";
            UrMb1.Img_Header.Source = new BitmapImage(new Uri("/WpfClient;component/Images/Img_Header/Head5.jpg", UriKind.Relative));
            lv_main.Items.Add(UrMb1);
        }
    }
}
