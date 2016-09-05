using BCP.ViewModel;
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
    /// RightMessageBoxUControl.xaml 的交互逻辑
    /// </summary>
    public partial class RightMessageBoxUControl : UserControl
    {
        public RightMessageBoxUControl()
        {
            InitializeComponent();
        }

        public void Init(String userName, String message, Image img, string msgType)
        {
            this.UserNameLable.Content = userName;
            if (msgType == "Image")
            {
                UserMessageImg.Source = img.Source;
                UserMessageLable.Visibility = Visibility.Hidden;
                UserMessageImg.Visibility = Visibility.Visible;
            }
            else if (msgType == "Text")
            {
                this.UserMessageLable.Text = message;
                UserMessageImg.Visibility = Visibility.Hidden;
                UserMessageLable.Visibility = Visibility.Visible;
            }
        }

        public void Init(String userName, UserMessageDTO record)
        {
            this.UserNameLable.Content = userName;
            this.UserMessageLable.Text = record == null ? "" : record.Content;
        }

        private void UserMessageImg_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                PictureBrower pb = new PictureBrower();
                pb.PicSource = (BitmapImage)UserMessageImg.Source;
                pb.ShowDialog();
            }
            
        }
    }
}
