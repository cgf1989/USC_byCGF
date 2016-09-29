using BCP.Common.Helper;
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

        public void Init(String userName, String message, Image img, string msgType,string sendedTime)
        {
            this.UserNameLable.Content = userName;
            this.lbl_msgSendedTime.Content = sendedTime;
            if (msgType == "Image")
            {
                UserMessageImg.Source = img.Source;
                UserMessageLable.Visibility = Visibility.Hidden;
                UserMessageImg.Visibility = Visibility.Visible;
                UserFile.Visibility = Visibility.Hidden;
            }
            else if (msgType == "Text")
            {
                this.UserMessageLable.Text = message;
                UserMessageImg.Visibility = Visibility.Hidden;
                UserMessageLable.Visibility = Visibility.Visible;
                UserFile.Visibility = Visibility.Hidden;
            }
            else if (msgType == "File")
            {
                string fileName = FileHelper.UnEncrept_byCgf(message);
                tb_FileName.Text = "【文件】" + fileName;
                tb_FileName.Tag = message;
                UserMessageLable.Visibility = Visibility.Hidden;
                UserMessageImg.Visibility = Visibility.Hidden;
                UserFile.Visibility = Visibility.Visible;
            }
        }

        //public void Init(String userName, UserMessageDTO record)
        //{
        //    this.UserNameLable.Content = userName;
        //    this.UserMessageLable.Text = record == null ? "" : record.Content;
        //}

 

        /// <summary>
        /// 打开文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hyLink_openFile_Click(object sender, RoutedEventArgs e)
        {
            //有可能会因为刚发出去的，没下载到设置路径所以获取不到，重新打开窗口自动下载就可以
            try
            {
                string filePath = tb_FileName.Tag.ToString();
                System.Diagnostics.Process.Start(@"D:\MiniU_tempImg\" + filePath);
            }
            catch (Exception ex)
            { MessageBox.Show("请重新打开窗口"); }
        }


        /// <summary>
        /// 双击图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
